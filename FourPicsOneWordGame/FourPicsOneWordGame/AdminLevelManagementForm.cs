using FourPicsOneWordGame.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace FourPicsOneWordGame
{
    public partial class AdminLevelManagementForm : Form
    {
        public AdminLevelManagementForm()
        {
            InitializeComponent();
        }

        private void AdminLevelManagementForm_Load(object sender, EventArgs e)
        {
            LoadGameLevels();
        }

        private async void LoadGameLevels()
        {
            dgvGameLevels.DataSource = null;

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT GameLevelId AS ID, CorrectWord AS Answer, ImagePath1 AS Img1, ImagePath2 AS Img2, ImagePath3 AS Img3, ImagePath4 AS Img4 FROM gamelevels ORDER BY ID ASC;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable gameLevelsTable = new DataTable();
                            await Task.Run(() => adapter.Fill(gameLevelsTable));

                            DataColumn displayLevelCol = new DataColumn("DisplayLevel", typeof(int));
                            gameLevelsTable.Columns.Add(displayLevelCol);
                            displayLevelCol.SetOrdinal(0); // Make it the first column

                            for (int i = 0; i < gameLevelsTable.Rows.Count; i++)
                            {
                                gameLevelsTable.Rows[i]["DisplayLevel"] = i + 1;
                            }

                            dgvGameLevels.DataSource = gameLevelsTable;

                            if (dgvGameLevels.Columns["DisplayLevel"] != null)
                                dgvGameLevels.Columns["DisplayLevel"].HeaderText = "Level #";
                            if (dgvGameLevels.Columns["ID"] != null)
                                dgvGameLevels.Columns["ID"].Visible = false;
                            if (dgvGameLevels.Columns["Category"] != null)
                                dgvGameLevels.Columns["Category"].HeaderText = "Game Topic";
                            if (dgvGameLevels.Columns["Answer"] != null)
                                dgvGameLevels.Columns["Answer"].HeaderText = "Correct Word";
                            if (dgvGameLevels.Columns["Img1"] != null)
                                dgvGameLevels.Columns["Img1"].HeaderText = "Image 1";
                            if (dgvGameLevels.Columns["Img2"] != null)
                                dgvGameLevels.Columns["Img2"].HeaderText = "Image 2";
                            if (dgvGameLevels.Columns["Img3"] != null)
                                dgvGameLevels.Columns["Img3"].HeaderText = "Image 3";
                            if (dgvGameLevels.Columns["Img4"] != null)
                                dgvGameLevels.Columns["Img4"].HeaderText = "Image 4";
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading levels: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddLevel_Click(object sender, EventArgs e)
        {
            // Basic Validations
            if (string.IsNullOrWhiteSpace(txtCorrectWord.Text) ||
                string.IsNullOrWhiteSpace(txtImagePath1.Text) ||
                string.IsNullOrWhiteSpace(txtImagePath2.Text) ||
                string.IsNullOrWhiteSpace(txtImagePath3.Text) ||
                string.IsNullOrWhiteSpace(txtImagePath4.Text))
            {
                MessageBox.Show("Please fill in all required fields (Topic, Correct Word, All Image Paths, and Difficulty).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string correctWord = txtCorrectWord.Text.Trim();
            string imagePath1 = txtImagePath1.Text.Trim();
            string imagePath2 = txtImagePath2.Text.Trim();
            string imagePath3 = txtImagePath3.Text.Trim();
            string imagePath4 = txtImagePath4.Text.Trim();

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = @"INSERT INTO gamelevels
                                    (CorrectWord, ImagePath1, ImagePath2, ImagePath3, ImagePath4)
                                    VALUES
                                    (@CorrectWord, @ImagePath1, @ImagePath2, @ImagePath3, @ImagePath4);
                                   ";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CorrectWord", correctWord);
                        command.Parameters.AddWithValue("@ImagePath1", imagePath1);
                        command.Parameters.AddWithValue("@ImagePath2", imagePath2);
                        command.Parameters.AddWithValue("@ImagePath3", imagePath3);
                        command.Parameters.AddWithValue("@ImagePath4", imagePath4);

                        int result = await command.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            MessageBox.Show("New game level added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGameLevels();
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the new game level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error adding level: {ex.Message}\nError Code: {ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtCorrectWord.Clear();
            txtImagePath1.Clear();
            txtImagePath2.Clear();
            txtImagePath3.Clear();
            txtImagePath4.Clear();
            dgvGameLevels.ClearSelection();
            lblEditingGameLevelId.Text = "";
            btnSaveChanges.Enabled = false;
            btnDeleteLevel.Enabled = false;
            btnAddLevel.Enabled = true;
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void dgvGameLevels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGameLevels.Rows[e.RowIndex].Cells["ID"].Value != null && dgvGameLevels.Rows[e.RowIndex].Cells["ID"].Value != DBNull.Value)
            {
                DataGridViewRow selectedRow = dgvGameLevels.Rows[e.RowIndex];

                if (selectedRow.Cells["ID"].Value != null)
                    lblEditingGameLevelId.Text = selectedRow.Cells["ID"].Value.ToString();

                if (selectedRow.Cells["Answer"].Value != null)
                    txtCorrectWord.Text = selectedRow.Cells["Answer"].Value.ToString();

                if (selectedRow.Cells["Img1"].Value != null)
                    txtImagePath1.Text = selectedRow.Cells["Img1"].Value.ToString();
                if (selectedRow.Cells["Img2"].Value != null)
                    txtImagePath2.Text = selectedRow.Cells["Img2"].Value.ToString();
                if (selectedRow.Cells["Img3"].Value != null)
                    txtImagePath3.Text = selectedRow.Cells["Img3"].Value.ToString();
                if (selectedRow.Cells["Img4"].Value != null)
                    txtImagePath4.Text = selectedRow.Cells["Img4"].Value.ToString();

                btnSaveChanges.Enabled = true;
                btnDeleteLevel.Enabled = true;
                btnAddLevel.Enabled = false;
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Validate a level is selected
            if (string.IsNullOrWhiteSpace(lblEditingGameLevelId.Text) || !int.TryParse(lblEditingGameLevelId.Text, out int gameLevelId))
            {
                MessageBox.Show("Please select a level from the grid to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Basic validation
            if (string.IsNullOrWhiteSpace(txtCorrectWord.Text) ||
               string.IsNullOrWhiteSpace(txtImagePath1.Text) ||
               string.IsNullOrWhiteSpace(txtImagePath2.Text) ||
               string.IsNullOrWhiteSpace(txtImagePath3.Text) ||
               string.IsNullOrWhiteSpace(txtImagePath4.Text)
               )
            {
                MessageBox.Show("Please ensure all required fields are filled (Topic, Correct Word, All Image Paths, and Difficulty).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get updated values from input fields
            string correctWord = txtCorrectWord.Text.Trim();
            string imagePath1 = txtImagePath1.Text.Trim();
            string imagePath2 = txtImagePath2.Text.Trim();
            string imagePath3 = txtImagePath3.Text.Trim();
            string imagePath4 = txtImagePath4.Text.Trim();

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = @"UPDATE gameLevels SET CorrectWord = @CorrectWord, 
                                     ImagePath1 = @ImagePath1, ImagePath2 = @ImagePath2, ImagePath3 = @ImagePath3, ImagePath4 = @ImagePath4
                                     WHERE GameLevelId = @GameLevelId;
                                    ";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CorrectWord", correctWord);
                        command.Parameters.AddWithValue("@ImagePath1", imagePath1);
                        command.Parameters.AddWithValue("@ImagePath2", imagePath2);
                        command.Parameters.AddWithValue("@ImagePath3", imagePath3);
                        command.Parameters.AddWithValue("@ImagePath4", imagePath4);
                        command.Parameters.AddWithValue("@GameLevelId", gameLevelId);

                        int result = await command.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            MessageBox.Show("Game level updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGameLevels();
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the game level. The level might have been deleted by another user or an unknown error occurred.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error updating level: {ex.Message}\nError Code: {ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while updating level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteLevel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblEditingGameLevelId.Text) || !int.TryParse(lblEditingGameLevelId.Text, out int gameLevelId))
            {
                MessageBox.Show("Please select a level from the grid to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete Level ID: {gameLevelId}?\nThis action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                    {
                        await connection.OpenAsync();

                        string query = "DELETE FROM gameLevels WHERE GameLevelId = @GameLevelId;";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@GameLevelId", gameLevelId);

                            int result = await command.ExecuteNonQueryAsync();

                            if (result > 0)
                            {
                                MessageBox.Show("Game level deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadGameLevels();
                                ClearInputFields();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete the game level. It might have already been deleted or an unknown error occurred.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error deleting level: {ex.Message}\nError Code: {ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while deleting level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtImagePath1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseImage1_Click(object sender, EventArgs e)
        {
            if (ofdSelectImage.ShowDialog() == DialogResult.OK)
            {
                txtImagePath1.Text = ofdSelectImage.FileName;
            }
        }

        private void btnBrowseImage2_Click(object sender, EventArgs e)
        {
            if (ofdSelectImage.ShowDialog() == DialogResult.OK)
            {
                txtImagePath2.Text = ofdSelectImage.FileName;
            }
        }

        private void btnBrowseImage3_Click(object sender, EventArgs e)
        {
            if (ofdSelectImage.ShowDialog() == DialogResult.OK)
            {
                txtImagePath3.Text = ofdSelectImage.FileName;
            }
        }

        private void btnBrowseImage4_Click(object sender, EventArgs e)
        {
            if (ofdSelectImage.ShowDialog() == DialogResult.OK)
            {
                txtImagePath4.Text = ofdSelectImage.FileName;
            }
        }

        private void btnALMBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
