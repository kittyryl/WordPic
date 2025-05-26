using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FourPicsOneWordGame
{
    public partial class LeaderboardForm : Form
    {
        public LeaderboardForm()
        {
            InitializeComponent();
        }

        private async void LeaderboardForm_Load(object sender, EventArgs e)
        {
            Control? titleLabel = this.Controls.Find("lblLeaderboardTitle", true).FirstOrDefault();
            if (titleLabel != null)
            {
                titleLabel.Text = "Top Players";
            }
            await LoadLeaderboardAsync();
        }

        private async void btnRefreshLeaderboard_Click(object sender, EventArgs e)
        {
            await LoadLeaderboardAsync();
        }

        private void btnCloseLeaderboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task LoadLeaderboardAsync()
        {
            if (flpLeaderboardEntries == null) return;

            flpLeaderboardEntries.Controls.Clear();
            List<Tuple<int, string, long>> leaderboardData = new List<Tuple<int, string, long>>();

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                        SELECT 
                            u.Username, 
                            SUM(up.Score) AS TotalScore
                        FROM userprogresses up
                        JOIN users u ON up.UserId = u.UserId
                        WHERE up.IsCompleted = 1
                        GROUP BY u.UserId, u.Username
                        ORDER BY TotalScore DESC
                        LIMIT 10;";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        int rank = 1;
                        while (await reader.ReadAsync())
                        {
                            leaderboardData.Add(new Tuple<int, string, long>(
                                rank++,
                                reader.GetString("Username"),
                                reader.GetInt64("TotalScore")
                            ));
                        }
                    }
                }

                int panelWidth = flpLeaderboardEntries.ClientSize.Width - (flpLeaderboardEntries.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0) - flpLeaderboardEntries.Padding.Horizontal;
                int panelContentWidth = flpLeaderboardEntries.ClientSize.Width - flpLeaderboardEntries.Padding.Horizontal;

                if (leaderboardData.Any())
                {
                    Panel headerPanel = new Panel
                    {
                        Width = panelContentWidth,
                        Height = 30,
                        Margin = new Padding(3, 3, 3, 1),
                        BackColor = Color.FromArgb(210, 210, 220)
                    };

                    Label lblHeaderScore = new Label
                    {
                        Text = "Score",
                        Dock = DockStyle.Right,
                        Width = 70,
                        TextAlign = ContentAlignment.MiddleRight,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        Padding = new Padding(0, 0, 5, 0) 
                    };
                    Label lblHeaderRank = new Label
                    {
                        Text = "Rank",
                        Dock = DockStyle.Left,
                        Width = 50,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        Padding = new Padding(5, 0, 0, 0)
                    };
                    Label lblHeaderUsername = new Label
                    {
                        Text = "Username",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        Padding = new Padding(5, 0, 0, 0)
                    };

                    headerPanel.Controls.Add(lblHeaderUsername);
                    headerPanel.Controls.Add(lblHeaderRank);
                    headerPanel.Controls.Add(lblHeaderScore);
                    flpLeaderboardEntries.Controls.Add(headerPanel);

                    foreach (var entry in leaderboardData)
                    {
                        Panel entryPanel = new Panel
                        {
                            Width = panelContentWidth,
                            Height = 35,
                            Margin = new Padding(3, 0, 3, 3),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = (entry.Item1 % 2 == 0) ? Color.FromArgb(248, 248, 248) : Color.White
                        };

                        Label lblScore = new Label
                        {
                            Text = entry.Item3.ToString("N0"),
                            Dock = DockStyle.Right,
                            Width = 70,
                            TextAlign = ContentAlignment.MiddleRight,
                            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                            ForeColor = Color.ForestGreen,
                            Padding = new Padding(0, 0, 5, 0)
                        };
                        Label lblRank = new Label
                        {
                            Text = $"#{entry.Item1}",
                            Dock = DockStyle.Left,
                            Width = 50,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Font = new Font("Segoe UI", 9F),
                            Padding = new Padding(5, 0, 0, 0)
                        };
                        Label lblUsername = new Label
                        {
                            Text = entry.Item2,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Font = new Font("Segoe UI", 9F),
                            Padding = new Padding(5, 0, 0, 0)
                        };

                        entryPanel.Controls.Add(lblUsername); 
                        entryPanel.Controls.Add(lblRank);
                        entryPanel.Controls.Add(lblScore);

                        flpLeaderboardEntries.Controls.Add(entryPanel);
                    }
                }
                else
                {
                    Label lblNoData = new Label
                    {
                        Text = "No leaderboard data available yet. Play some levels!",
                        Font = new Font("Segoe UI", 11F),
                        ForeColor = Color.DimGray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = panelWidth - 10,
                        Height = 50,
                        Margin = new Padding(5)
                    };
                    flpLeaderboardEntries.Controls.Add(lblNoData);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading leaderboard: {ex.Message}", "Leaderboard Error");
                Label lblError = new Label { Text = "Could not load leaderboard data.", AutoSize = true, Margin = new Padding(5), ForeColor = Color.Red };
                if (flpLeaderboardEntries != null) flpLeaderboardEntries.Controls.Add(lblError);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Leaderboard Error");
                Label lblError = new Label { Text = "An error occurred.", AutoSize = true, Margin = new Padding(5), ForeColor = Color.Red };
                if (flpLeaderboardEntries != null) flpLeaderboardEntries.Controls.Add(lblError);
            }
        }
    }
}