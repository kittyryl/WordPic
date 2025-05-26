using System;
using System.Data;
using System.Drawing;
using System.Linq; // Not strictly needed with DataTable iteration here, but good practice
using System.Threading.Tasks;
using System.Windows.Forms;
using FourPicsOneWordGame.Models; // For CurrentUser
using MySql.Data.MySqlClient;

namespace FourPicsOneWordGame
{
    public partial class ViewProgressForm : Form
    {
        public ViewProgressForm()
        {
            InitializeComponent();
        }

        private async void ViewProgressForm_Load(object sender, EventArgs e)
        {
            await LoadAllProgressDataAsync();
        }

        private void btnClose_Click(object sender, EventArgs e) // Assuming your close button is named btnClose
        {
            this.Close();
        }

        private async Task LoadAllProgressDataAsync()
        {
            if (CurrentUser.LoggedInUser == null)
            {
                MessageBox.Show("No user is logged in. Cannot display progress.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (lblTitle != null) lblTitle.Text = "My Progress"; // Check if lblTitle exists

                Control? overallScoreCtrl = this.Controls.Find("lblOverallTotalScore", true).FirstOrDefault();
                if (overallScoreCtrl is Label overallScoreLabel)
                {
                    overallScoreLabel.Text = "Total Score: N/A";
                }

                if (flpProgressEntries != null) flpProgressEntries.Controls.Clear();
                return;
            }

            int currentUserId = CurrentUser.LoggedInUser.UserId;
            long totalScore = 0;

            if (flpProgressEntries != null) flpProgressEntries.Controls.Clear();

            if (lblTitle != null)
            {
                lblTitle.Text = $"Progress for: {CurrentUser.LoggedInUser.UserName}";
            }

            try
            {
                DataTable progressDetailsTable = new DataTable();

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    // 1. Fetch Total Score
                    string totalScoreQuery = "SELECT SUM(Score) FROM userprogresses WHERE UserId = @UserId AND IsCompleted = 1;";
                    using (var scoreCmd = new MySqlCommand(totalScoreQuery, connection))
                    {
                        scoreCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        object? scoreResult = await scoreCmd.ExecuteScalarAsync();
                        if (scoreResult != null && scoreResult != DBNull.Value)
                        {
                            totalScore = Convert.ToInt64(scoreResult);
                        }
                    }

                    Control? overallScoreCtrl = this.Controls.Find("lblOverallTotalScore", true).FirstOrDefault();
                    if (overallScoreCtrl is Label overallScoreLabel)
                    {
                        overallScoreLabel.Text = $"Total Score: {totalScore:N0}";
                    }


                    // 2. Fetch Detailed Progress for the list
                    string detailsQuery = @"SELECT 
                                            gl.GameLevelId, 
                                            gl.CorrectWord AS Word, 
                                            up.Score AS ScoreEarned, 
                                            up.CompletedDate AS DateCompleted
                                         FROM userprogresses up
                                         JOIN gamelevels gl ON up.GameLevelId = gl.GameLevelId
                                         WHERE up.UserId = @UserId AND up.IsCompleted = 1
                                         ORDER BY gl.GameLevelId ASC;";

                    using (var detailsCmd = new MySqlCommand(detailsQuery, connection))
                    {
                        detailsCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        using (var adapter = new MySqlDataAdapter(detailsCmd))
                        {
                            await Task.Run(() => adapter.Fill(progressDetailsTable));
                        }
                    }
                } // Connection is closed here

                // --- Create and Add Header Panel for Progress ---
                if (progressDetailsTable.Rows.Count > 0 && flpProgressEntries != null)
                {
                    Panel headerPanelProgress = new Panel
                    {
                        Width = flpProgressEntries.ClientSize.Width - (flpProgressEntries.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0) - flpProgressEntries.Padding.Horizontal - 5,
                        Height = 30,
                        Margin = new Padding(3, 3, 3, 1),
                        BackColor = Color.FromArgb(220, 220, 220)
                    };

                    // Define X positions for alignment for header
                    int xPosHeaderLevel = 10;
                    int xPosHeaderWord = 70;
                    int widthForWord = 150; // Example width
                    int xPosHeaderScore = xPosHeaderWord + widthForWord + 10;
                    int widthForScore = 80;
                    int xPosHeaderDate = xPosHeaderScore + widthForScore + 10;
                    int widthForDate = Math.Max(120, headerPanelProgress.Width - xPosHeaderDate - 10); // Remaining width for date


                    Label lblHeaderLevel = new Label { Text = "Level", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(xPosHeaderLevel, 7), AutoSize = true, ForeColor = Color.Black };
                    Label lblHeaderWord = new Label { Text = "Word Guessed", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(xPosHeaderWord, 7), Size = new Size(widthForWord, 20), TextAlign = ContentAlignment.MiddleLeft, ForeColor = Color.Black };
                    Label lblHeaderScore = new Label { Text = "Score", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(xPosHeaderScore, 7), Size = new Size(widthForScore, 20), TextAlign = ContentAlignment.MiddleRight, ForeColor = Color.Black };
                    Label lblHeaderDate = new Label { Text = "Date Completed", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(xPosHeaderDate, 7), Size = new Size(widthForDate, 20), TextAlign = ContentAlignment.MiddleRight, ForeColor = Color.Black, Anchor = AnchorStyles.Top | AnchorStyles.Right };

                    headerPanelProgress.Controls.Add(lblHeaderLevel);
                    headerPanelProgress.Controls.Add(lblHeaderWord);
                    headerPanelProgress.Controls.Add(lblHeaderScore);
                    headerPanelProgress.Controls.Add(lblHeaderDate);
                    flpProgressEntries.Controls.Add(headerPanelProgress);
                }
                // --- End of Header Panel ---

                // --- Dynamically Create and Add Progress Entry Controls ---
                if (progressDetailsTable.Rows.Count > 0 && flpProgressEntries != null)
                {
                    int playerLevelCounter = 1;
                    foreach (DataRow row in progressDetailsTable.Rows)
                    {
                        Panel entryPanel = new Panel
                        {
                            Width = flpProgressEntries.ClientSize.Width - (flpProgressEntries.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0) - flpProgressEntries.Padding.Horizontal - 5,
                            Height = 45,
                            Margin = new Padding(3, 1, 3, 6),
                            BorderStyle = BorderStyle.None,
                            BackColor = (playerLevelCounter % 2 == 0) ? Color.FromArgb(248, 248, 248) : Color.White
                        };

                        // Define X positions for alignment (should match header positions)
                        int xPosLevel = 10;
                        int xPosWord = 70;
                        int widthForWord = 150; // Consistent with header
                        int xPosScore = xPosWord + widthForWord + 10;
                        int widthForScore = 80; // Consistent with header
                        int xPosDate = xPosScore + widthForScore + 10;
                        int widthForDate = Math.Max(120, entryPanel.Width - xPosDate - 10);


                        Label lblPlayerLevel = new Label { Text = $"{playerLevelCounter++}", Font = new Font("Segoe UI", 9F, FontStyle.Regular), Location = new Point(xPosLevel, 14), AutoSize = true };
                        Label lblWord = new Label { Text = $"{row["Word"]?.ToString() ?? "N/A"}", Font = new Font("Segoe UI", 9F), Location = new Point(xPosWord, 14), Size = new Size(widthForWord, 20), AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
                        Label lblScore = new Label { Text = $"{Convert.ToInt64(row["ScoreEarned"]):N0}", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(xPosScore, 14), Size = new Size(widthForScore, 20), TextAlign = ContentAlignment.MiddleRight };
                        Label lblDate = new Label { Text = $"{Convert.ToDateTime(row["DateCompleted"]):yyyy-MM-dd HH:mm}", Font = new Font("Segoe UI", 8F, FontStyle.Italic), ForeColor = Color.DarkSlateGray, Location = new Point(xPosDate, 14), Size = new Size(widthForDate, 20), TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.Top | AnchorStyles.Right };

                        entryPanel.Controls.Add(lblPlayerLevel);
                        entryPanel.Controls.Add(lblWord);
                        entryPanel.Controls.Add(lblScore);
                        entryPanel.Controls.Add(lblDate);

                        flpProgressEntries.Controls.Add(entryPanel);
                    }
                }
                else if (flpProgressEntries != null) // No data
                {
                    Label lblNoData = new Label
                    {
                        Text = "You haven't completed any levels yet!",
                        Font = new Font("Segoe UI", 11F),
                        ForeColor = Color.DimGray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = flpProgressEntries.ClientSize.Width - 10,
                        Height = 50,
                        Margin = new Padding(5)
                    };
                    flpProgressEntries.Controls.Add(lblNoData);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading progress: {ex.Message}", "Database Error");
                if (flpProgressEntries != null)
                {
                    Label lblError = new Label { Text = "Could not load progress.", AutoSize = true, Margin = new Padding(5), ForeColor = Color.Red };
                    flpProgressEntries.Controls.Add(lblError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
                if (flpProgressEntries != null)
                {
                    Label lblError = new Label { Text = "An error occurred.", AutoSize = true, Margin = new Padding(5), ForeColor = Color.Red };
                    flpProgressEntries.Controls.Add(lblError);
                }
            }
        }

        // You will need to add the btnClose_Click event handler if it's not already generated
        // by double-clicking the button in the designer.
        // If you named your button btnClose on the form:
        // private void btnClose_Click(object sender, EventArgs e)
        // {
        //     this.Close();
        // }
    }
}