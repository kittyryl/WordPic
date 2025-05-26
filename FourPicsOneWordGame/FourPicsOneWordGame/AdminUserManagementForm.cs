using System;
using System.Data; 
using System.Drawing;
using System.Linq; 
using System.Threading.Tasks; 
using System.Windows.Forms;
using FourPicsOneWordGame.Models;
using MySql.Data.MySqlClient;

namespace FourPicsOneWordGame
{
    public partial class AdminUserManagementForm : Form
    {
        public AdminUserManagementForm()
        {
            InitializeComponent();
        }

        private async void AdminUserManagementForm_Load(object sender, EventArgs e)
        {
            cmbSelectedUserRole.DataSource = Enum.GetValues(typeof(UserRole));
            cmbSelectedUserRole.SelectedIndex = -1;

            await LoadUsersAsync();
            ClearSelectedUserDetails();
        }

        private async Task LoadUsersAsync()
        {
            dgvUsers.DataSource = null;

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT UserId, Username, Role FROM users ORDER BY UserId ASC;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable usersTable = new DataTable();
                            await Task.Run(() => adapter.Fill(usersTable));

                            DataColumn roleTextCol = new DataColumn("RoleText", typeof(string));
                            usersTable.Columns.Add(roleTextCol);

                            foreach (DataRow row in usersTable.Rows)
                            {
                                if (row["Role"] != DBNull.Value)
                                {
                                    int roleValue = Convert.ToInt32(row["Role"]);
                                    row["RoleText"] = ((UserRole)roleValue).ToString();
                                }
                                else
                                {
                                    row["RoleText"] = "Unknown";
                                }
                            }

                            dgvUsers.DataSource = usersTable;

                            // Customize DataGridView column headers and visibility
                            if (dgvUsers.Columns["UserId"] != null)
                            {
                                dgvUsers.Columns["UserId"].HeaderText = "ID";
                                dgvUsers.Columns["UserId"].Width = 50;
                            }
                            if (dgvUsers.Columns["Username"] != null)
                            {
                                dgvUsers.Columns["Username"].HeaderText = "Username";
                                dgvUsers.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                            if (dgvUsers.Columns["RoleText"] != null)
                            {
                                dgvUsers.Columns["RoleText"].HeaderText = "Role";
                                dgvUsers.Columns["RoleText"].Width = 100;
                            }
                            if (dgvUsers.Columns["Role"] != null) // The original integer Role column
                            {
                                dgvUsers.Columns["Role"].Visible = false; // Hide the raw integer Role
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading users: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearSelectedUserDetails()
        {
            lblSelectedUserId.Text = "";
            txtSelectedUsername.Clear();
            cmbSelectedUserRole.SelectedIndex = -1;
            btnUpdateRole.Enabled = false;
            btnDeleteUser.Enabled = false;
            dgvUsers.ClearSelection();
        }

        private void btnCloseUserManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].Cells["UserId"].Value != null && dgvUsers.Rows[e.RowIndex].Cells["UserId"].Value != DBNull.Value)
            {
                DataGridViewRow selectedRow = dgvUsers.Rows[e.RowIndex];

                lblSelectedUserId.Text = selectedRow.Cells["UserId"].Value.ToString();

                if (selectedRow.Cells["Username"].Value != null)
                    txtSelectedUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                else
                    txtSelectedUsername.Text = "";

                if (selectedRow.Cells["Role"] != null && selectedRow.Cells["Role"].Value != DBNull.Value)
                {
                    int roleValue = Convert.ToInt32(selectedRow.Cells["Role"].Value);
                    cmbSelectedUserRole.SelectedItem = (UserRole)roleValue;
                }
                else
                {
                    cmbSelectedUserRole.SelectedIndex = -1;
                }

                btnUpdateRole.Enabled = true;
                btnDeleteUser.Enabled = true;
            }
        }

        private async void btnUpdateRole_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblSelectedUserId.Text) || !int.TryParse(lblSelectedUserId.Text, out int selectedUserId))
            {
                MessageBox.Show("Please select a user from the grid first.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSelectedUserRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a new role for the user.", "Role Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserRole newRole = (UserRole)cmbSelectedUserRole.SelectedItem;

            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to change the role for user '{txtSelectedUsername.Text}' to '{newRole}'?",
                "Confirm Role Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return; // User cancelled
            }

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "UPDATE users SET Role = @NewRole WHERE UserId = @UserId;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewRole", (int)newRole);
                        command.Parameters.AddWithValue("@UserId", selectedUserId);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User role updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsersAsync();
                            ClearSelectedUserDetails();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the user role. The user might no longer exist or an unknown error occurred.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error updating role: {ex.Message}\nError Code: {ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while updating role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblSelectedUserId.Text) || !int.TryParse(lblSelectedUserId.Text, out int selectedUserId))
            {
                MessageBox.Show("Please select a user from the grid to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentUser.LoggedInUser != null && CurrentUser.LoggedInUser.UserId == selectedUserId)
            {
                MessageBox.Show("You cannot delete your own account while you are logged in.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Are you absolutely sure you want to permanently delete user '{txtSelectedUsername.Text}' (ID: {selectedUserId})?\n\n" +
                "ALL THEIR GAME PROGRESS WILL ALSO BE DELETED.\n" +
                "This action cannot be undone.",
                "Confirm User Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop, // Use a more severe icon like Stop or Exclamation
                MessageBoxDefaultButton.Button2);

            if(confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                    {
                        await connection.OpenAsync();

                        string query = "DELETE FROM users WHERE UserId = @UserId;";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", selectedUserId);

                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            if(rowsAffected > 0)
                            {
                                MessageBox.Show($"User '{txtSelectedUsername.Text}' and all their progress have been deleted successfully.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadUsersAsync();  
                                ClearSelectedUserDetails();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete the user. They might have already been deleted or an unknown error occurred.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error deleting user: {ex.Message}\nError Code: {ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
