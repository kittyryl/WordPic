using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourPicsOneWordGame.Models;
using MySql.Data.MySqlClient;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

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

            cartesianChartTopPlayers.Series = Enumerable.Empty<ISeries>();
            cartesianChartTopPlayers.XAxes = new[] { new Axis { IsVisible = false } };
            cartesianChartTopPlayers.YAxes = new[] { new Axis { IsVisible = false } };

            try
            {
                List<Tuple<string, long>> topPlayersData = new List<Tuple<string, long>>();

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string puzzlesQuery = "SELECT COUNT(*) FROM gamelevels;";
                    using (var puzzlesCmd = new MySqlCommand(puzzlesQuery, connection))
                    {
                        object? puzzlesResult = await puzzlesCmd.ExecuteScalarAsync();
                        lblTotalPuzzles.Text = $"Total Puzzles: {puzzlesResult?.ToString() ?? "0"}";
                    }

                    string playersQuery = "SELECT COUNT(*) FROM users;";
                    using (var playersCmd = new MySqlCommand(playersQuery, connection))
                    {
                        object? playersResult = await playersCmd.ExecuteScalarAsync();
                        lblTotalPlayers.Text = $"Total Players: {playersResult?.ToString() ?? "0"}";
                    }

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

                    string topPlayersQuery = @"
                        SELECT 
                            u.Username, 
                            SUM(up.Score) AS TotalScore
                        FROM userprogresses up
                        JOIN users u ON up.UserId = u.UserId
                        WHERE up.IsCompleted = 1
                        GROUP BY u.UserId, u.Username
                        ORDER BY TotalScore DESC
                        LIMIT 5;";

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
                }
                if (topPlayersData.Any())
                {
                    cartesianChartTopPlayers.Series = new ISeries[]
                    {
                        new ColumnSeries<long>
                        {
                            Name = "Total Score",
                            Values = topPlayersData.Select(tp => tp.Item2).ToArray(),
                            DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                            DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                            DataLabelsFormatter = (chartPoint) =>
                            {
                                if (chartPoint.Model is long scoreValue)
                                {
                                    return scoreValue.ToString("N0");
                                }
                                return string.Empty;
                            },
                            Fill = new SolidColorPaint(SKColors.CornflowerBlue),
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
                            NameTextSize = 12,
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
                }
                else
                {
                    cartesianChartTopPlayers.Series = new ISeries[] {
                        new ColumnSeries<long> { Name = "Total Score", Values = new long[] {} }
                    };
                    cartesianChartTopPlayers.XAxes = new[] { new Axis { Name = "Player", Labels = new[] { "No Player Data" } } };
                    cartesianChartTopPlayers.YAxes = new[] { new Axis { Name = "Total Score", MinLimit = 0 } };
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading dashboard: {ex.Message}", "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalPuzzles.Text = "Total Puzzles: Error";
                lblTotalPlayers.Text = "Total Players: Error";
                lblAverageScore.Text = "Average Score: Error";
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
