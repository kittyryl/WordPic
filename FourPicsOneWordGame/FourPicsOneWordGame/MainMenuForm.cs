using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FourPicsOneWordGame.Models;

namespace FourPicsOneWordGame
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser.LoggedInUser != null)
            {
                lblWelcomeMessage.Text = $"Welcome, {CurrentUser.LoggedInUser.UserName}! ";

                btnPlayGame.Visible = false;
                btnViewProgress.Visible = false;
                btnManageLevels.Visible = false;

                btnManageLevels.Visible = false;
                if (this.Controls.ContainsKey("btnManageUsers")) 
                {
                    this.Controls["btnManageUsers"].Visible = false;
                }

                btnViewDashboard.Visible = false;

                if (CurrentUser.LoggedInUser.Role == UserRole.Admin)
                {
                    btnManageLevels.Visible = true;
                    if (this.Controls.ContainsKey("btnManageUsers"))
                    {
                        this.Controls["btnManageUsers"].Visible = true;
                    }
                    btnViewDashboard.Visible = true;
                    btnPlayGame.Visible = true;
                    btnViewProgress.Visible = true;
                    btnManageUsers.Visible = true;
                }
                else if (CurrentUser.LoggedInUser.Role == UserRole.User)
                {
                    btnPlayGame.Visible = true;
                    btnViewProgress.Visible = true;
                }

                _ = LoadAndDisplayUserScore();
            }
            else
            {
                lblWelcomeMessage.Text = "Welcome, Guest! (Error: User not logged in)";
                btnPlayGame.Visible = false;
                btnViewProgress.Visible = false;
                btnManageLevels.Visible = false;
                btnManageUsers.Visible = false;
                btnViewDashboard.Visible = false;

                MessageBox.Show("No user is logged in. Returning to login screen.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.LoggedInUser = null;
            this.Close();
        }

        private void btnManageLevels_Click(object sender, EventArgs e)
        {
            AdminLevelManagementForm levelManagementForm = new AdminLevelManagementForm();
            levelManagementForm.ShowDialog(this);
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            GamePlayForm gamePlayForm = new GamePlayForm();
            gamePlayForm.ShowDialog(this);
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            ViewProgressForm progressForm = new ViewProgressForm();
            progressForm.ShowDialog(this);
        }

        private async Task LoadAndDisplayUserScore()
        {
            if (CurrentUser.LoggedInUser == null)
            {
                return;
            }

            int userId = CurrentUser.LoggedInUser.UserId;
            long totalScore = 0;

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT SUM(Score) FROM userprogresses WHERE UserId = @UserId AND IsCompleted = 1;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            totalScore = Convert.ToInt64(result);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading score: {ex.Message}", "Score Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while loading score: {ex.Message}", "Score Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainMenuForm_Activated(object sender, EventArgs e)
        {
            _ = LoadAndDisplayUserScore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeaderboardForm leaderboardForm = new LeaderboardForm();
            leaderboardForm.ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CurrentUser.LoggedInUser != null && CurrentUser.LoggedInUser.Role == UserRole.Admin)
            {
                AdminUserManagementForm userManagementForm = new AdminUserManagementForm();
                userManagementForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("You do not have permission to access user management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewDashboard_Click(object sender, EventArgs e)
        {
            if (CurrentUser.LoggedInUser != null && CurrentUser.LoggedInUser.Role == UserRole.Admin)
            {
                AdminDashboardForm dashboardForm = new AdminDashboardForm();
                dashboardForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Access to the dashboard is restricted to administrators.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            InstructionsForm instructionsForm = new InstructionsForm();
            instructionsForm.ShowDialog(this);
        }
    }
}
