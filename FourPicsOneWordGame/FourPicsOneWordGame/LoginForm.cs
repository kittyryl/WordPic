using System;
using System.Drawing;
using System.Windows.Forms;
using FourPicsOneWordGame.Models;
using MySql.Data.MySqlClient;

namespace FourPicsOneWordGame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Red;

            if (string.IsNullOrEmpty(username))
            {
                lblMessage.Text = "Username cannot be empty.";
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Password cannot be empty.";
                txtPassword.Focus();
                return;
            }

            User? user = null;

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string sqlQuery = "SELECT UserId, Username, PasswordHash, Role FROM users WHERE Username = @username LIMIT 1;";
                    using (var command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                user = new User
                                {
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    UserName = reader.GetString(reader.GetOrdinal("Username")),
                                    PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    Role = (UserRole)reader.GetInt32(reader.GetOrdinal("Role"))
                                };
                            }
                        }
                    }
                }

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                    {
                        lblMessage.ForeColor = Color.Green;
                        MessageBox.Show($"Welcome {user.UserName}!\nRole: {user.Role}", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CurrentUser.LoggedInUser = user;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        lblMessage.Text = "Invalid username or password.";
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
            catch (MySqlException ex)
            {
                lblMessage.Text = "Database error. Please try again later.";
                MessageBox.Show($"MySQL Error: {ex.Message}", "Database Error");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An unexpected error occurred. Please try again.";
                MessageBox.Show(ex.ToString(), "General Error");
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();

            this.Hide();

            regForm.ShowDialog(this);

            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
