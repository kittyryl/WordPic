using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourPicsOneWordGame.Models; // For UserRole if you were to use it, not strictly needed here
using MySql.Data.MySqlClient;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms; // For specific WinForms types if needed
using SkiaSharp; // For SKColors

namespace FourPicsOneWordGame
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private async void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            lblTotalPuzzles.Text = "Total Puzzles: Loading...";
            lblTotalPlayers.Text = "Total Players: Loading...";
            lblAverageScore.Text = "Average Score: Loading...";

            await LoadAdminDashboardDataAsync();
        }

        private async Task LoadAdminDashboardDataAsync()
        {
            if (cartesianChartTopPlayers == null)
            {
                MessageBox.Show("Chart control (cartesianChartTopPlayers) is not initialized on the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear previous chart data and setup
            cartesianChartTopPlayers.Series = Enumerable.Empty<ISeries>();
            cartesianChartTopPlayers.XAxes = new[] { new Axis { IsVisible = false } };
            cartesianChartTopPlayers.YAxes = new[] { new Axis { IsVisible = false } };
            // For LiveCharts2, titles are often managed differently or via a specific Title component/property if available,
            // or by adding a Label control above the chart.

            try
            {
                List<Tuple<string, long>> topPlayersData = new List<Tuple<string, long>>();

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    // 1. Get Total Puzzles
                    string puzzlesQuery = "SELECT COUNT(*) FROM gamelevels;";
                    using (var puzzlesCmd = new MySqlCommand(puzzlesQuery, connection))
                    {
                        object? puzzlesResult = await puzzlesCmd.ExecuteScalarAsync();
                        lblTotalPuzzles.Text = $"Total Puzzles: {puzzlesResult?.ToString() ?? "0"}";
                    }

                    // 2. Get Total Players
                    string playersQuery = "SELECT COUNT(*) FROM users;";
                    using (var playersCmd = new MySqlCommand(playersQuery, connection))
                    {
                        object? playersResult = await playersCmd.ExecuteScalarAsync();
                        lblTotalPlayers.Text = $"Total Players: {playersResult?.ToString() ?? "0"}";
                    }

                    // 3. Get Average Score
                    string avgScoreQuery = "SELECT AVG(Score) FROM userprogresses WHERE IsCompleted = 1;";
                    using (var avgScoreCmd = new MySqlCommand(avgScoreQuery, connection))
                    {
                        object? avgScoreResult = await avgScoreCmd.ExecuteScalarAsync();
                        if (avgScoreResult != null && avgScoreResult != DBNull.Value)
                        {
                            lblAverageScore.Text = $"Average Score: {Convert.ToDouble(avgScoreResult):F1}";
                        }
                        else
                        {
                            lblAverageScore.Text = "Average Score: N/A";
                        }
                    }

                    // 4. Get Data for Top Players Chart
                    string topPlayersQuery = @"
                        SELECT 
                            u.Username, 
                            SUM(up.Score) AS TotalScore
                        FROM userprogresses up
                        JOIN users u ON up.UserId = u.UserId
                        WHERE up.IsCompleted = 1
                        GROUP BY u.UserId, u.Username
                        ORDER BY TotalScore DESC
                        LIMIT 5;"; // Get Top 5 players

                    using (var topPlayersCmd = new MySqlCommand(topPlayersQuery, connection))
                    {
                        using (var reader = await topPlayersCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                topPlayersData.Add(new Tuple<string, long>(
                                    reader.GetString("Username"),
                                    reader.GetInt64("TotalScore")
                                ));
                            }
                        }
                    }
                } // Connection is closed here

                // --- Populate LiveCharts2 CartesianChart ---
                if (topPlayersData.Any())
                {
                    cartesianChartTopPlayers.Series = new ISeries[]
                    {
                        new ColumnSeries<long>
                        {
                            Name = "Total Score",
                            Values = topPlayersData.Select(tp => tp.Item2).ToArray(),
                            DataLabelsPaint = new SolidColorPaint(SKColors.Black), // Changed to Black for visibility on default bar colors
                            DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top, // Position on top of bar
                            DataLabelsFormatter = (chartPoint) =>
                            {
                                if (chartPoint.Model is long scoreValue) // Access value via Model
                                {
                                    return scoreValue.ToString("N0");
                                }
                                return string.Empty;
                            },
                            Fill = new SolidColorPaint(SKColors.CornflowerBlue), // Example bar color
                            Stroke = null
                        }
                    };

                    cartesianChartTopPlayers.XAxes = new[]
                    {
                        new Axis
                        {
                            Name = "Player",
                            Labels = topPlayersData.Select(tp => tp.Item1).ToArray(),
                            LabelsRotation = (topPlayersData.Count > 3) ? -45 : 0,
                            TextSize = 10,
                            NameTextSize = 12, // Font size for "Player" axis title
                            NamePaint = new SolidColorPaint(SKColors.Black),
                            LabelsPaint = new SolidColorPaint(SKColors.DarkSlateGray),
                            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 0.5f }
                        }
                    };

                    cartesianChartTopPlayers.YAxes = new[]
                    {
                        new Axis
                        {
                            Name = "Total Score",
                            MinLimit = 0,
                            TextSize = 10,
                            NameTextSize = 12,
                            NamePaint = new SolidColorPaint(SKColors.Black),
                            LabelsPaint = new SolidColorPaint(SKColors.DarkSlateGray),
                            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 0.5f }
                        }
                    };
                    // You can add a chart title using a separate Label or by exploring LiveCharts title visual components if needed.
                    // Example using a Form Label:
                    // lblDashboardTitle.Text = "Admin Dashboard - Top Player Scores"; 
                }
                else
                {
                    // Handle no data for chart (show an empty state or message)
                    cartesianChartTopPlayers.Series = new ISeries[] {
                        new ColumnSeries<long> { Name = "Total Score", Values = new long[] {} }
                    };
                    cartesianChartTopPlayers.XAxes = new[] { new Axis { Name = "Player", Labels = new[] { "No Player Data" } } };
                    cartesianChartTopPlayers.YAxes = new[] { new Axis { Name = "Total Score", MinLimit = 0 } };
                    // lblDashboardTitle.Text = "Admin Dashboard - No Player Data";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading dashboard: {ex.Message}", "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalPuzzles.Text = "Total Puzzles: Error";
                lblTotalPlayers.Text = "Total Players: Error";
                lblAverageScore.Text = "Average Score: Error";
                // Optionally display an error message on the chart itself
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalPuzzles.Text = "Total Puzzles: Error";
                lblTotalPlayers.Text = "Total Players: Error";
                lblAverageScore.Text = "Average Score: Error";
            }
        }

        private void btnCloseDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
