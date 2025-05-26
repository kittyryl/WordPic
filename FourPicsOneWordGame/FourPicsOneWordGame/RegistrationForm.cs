using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourPicsOneWordGame.Models;
using MySql.Data.MySqlClient;

namespace FourPicsOneWordGame
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Red;

            if (string.IsNullOrWhiteSpace(username))
            {
                lblMessage.Text = "Username cannot be empty.";
                txtUsername.Focus();
                return;
            }
            if (username.Length < 3)
            {
                lblMessage.Text = "Username must be at least 3 characters long.";
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Password cannot be empty.";
                txtPassword.Focus();
                return;
            }
            if (password.Length < 6)
            {
                lblMessage.Text = "Password must be at least 6 characters long.";
                txtPassword.Focus();
                return;
            }
            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string checkUserSql = "SELECT COUNT(*) FROM users WHERE Username = @username;";
                    using (var checkUserCmd = new MySqlCommand(checkUserSql, connection))
                    {
                        checkUserCmd.Parameters.AddWithValue("@username", username);
                        object? result = await checkUserCmd.ExecuteScalarAsync();
                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            lblMessage.Text = "Username already taken. Please choose another.";
                            txtUsername.Focus();
                            txtUsername.SelectAll();
                            return;
                        }
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    string insertUserSql = "INSERT INTO users (Username, PasswordHash, Role) VALUES (@username, @passwordHash, @role);";
                    using (var insertCmd = new MySqlCommand(insertUserSql, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                        insertCmd.Parameters.AddWithValue("@role", (int)UserRole.User);

                        int rowsAffected = await insertCmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful! You can now close this window and log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        }
                        else
                        {
                            lblMessage.Text = "Registration failed. Please try again.";
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                lblMessage.Text = "Database error. Please check connection or ensure username is unique.";
                MessageBox.Show($"MySQL Error [{ex.Number}]: {ex.Message}", "Database Error");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An unexpected error occurred. Please try again.";
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
        }
    }
}
