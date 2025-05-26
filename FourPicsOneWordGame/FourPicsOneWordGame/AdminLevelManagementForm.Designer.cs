namespace FourPicsOneWordGame
{
    partial class AdminLevelManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLevelManagementForm));
            dgvGameLevels = new DataGridView();
            label2 = new Label();
            txtCorrectWord = new TextBox();
            txtImagePath1 = new TextBox();
            label3 = new Label();
            txtImagePath2 = new TextBox();
            label4 = new Label();
            txtImagePath3 = new TextBox();
            label5 = new Label();
            txtImagePath4 = new TextBox();
            label6 = new Label();
            btnAddLevel = new Button();
            btnSaveChanges = new Button();
            btnDeleteLevel = new Button();
            btnClearFields = new Button();
            lblEditingGameLevelId = new Label();
            btnBrowseImage1 = new Button();
            btnBrowseImage2 = new Button();
            btnBrowseImage3 = new Button();
            btnBrowseImage4 = new Button();
            ofdSelectImage = new OpenFileDialog();
            btnALMBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGameLevels).BeginInit();
            SuspendLayout();
            // 
            // dgvGameLevels
            // 
            dgvGameLevels.AllowUserToAddRows = false;
            dgvGameLevels.AllowUserToDeleteRows = false;
            dgvGameLevels.BackgroundColor = Color.MediumAquamarine;
            dgvGameLevels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGameLevels.Location = new Point(17, 179);
            dgvGameLevels.Name = "dgvGameLevels";
            dgvGameLevels.ReadOnly = true;
            dgvGameLevels.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvGameLevels.Size = new Size(632, 295);
            dgvGameLevels.TabIndex = 0;
            dgvGameLevels.CellClick += dgvGameLevels_CellClick;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(317, 23);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 3;
            label2.Text = "Correct Word:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCorrectWord
            // 
            txtCorrectWord.Location = new Point(423, 20);
            txtCorrectWord.MaxLength = 14;
            txtCorrectWord.Name = "txtCorrectWord";
            txtCorrectWord.Size = new Size(150, 23);
            txtCorrectWord.TabIndex = 4;
            // 
            // txtImagePath1
            // 
            txtImagePath1.Location = new Point(423, 49);
            txtImagePath1.Name = "txtImagePath1";
            txtImagePath1.Size = new Size(150, 23);
            txtImagePath1.TabIndex = 6;
            txtImagePath1.TextChanged += txtImagePath1_TextChanged;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sitka Small", 9F, FontStyle.Bold);
            label3.Location = new Point(317, 52);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 5;
            label3.Text = "Image Path 1:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtImagePath2
            // 
            txtImagePath2.Location = new Point(423, 78);
            txtImagePath2.Name = "txtImagePath2";
            txtImagePath2.Size = new Size(150, 23);
            txtImagePath2.TabIndex = 8;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Sitka Small", 9F, FontStyle.Bold);
            label4.Location = new Point(317, 81);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 7;
            label4.Text = "Image Path 2:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtImagePath3
            // 
            txtImagePath3.Location = new Point(423, 107);
            txtImagePath3.Name = "txtImagePath3";
            txtImagePath3.Size = new Size(150, 23);
            txtImagePath3.TabIndex = 10;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Sitka Small", 9F, FontStyle.Bold);
            label5.Location = new Point(317, 110);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 9;
            label5.Text = "Image Path 3:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtImagePath4
            // 
            txtImagePath4.Location = new Point(423, 136);
            txtImagePath4.Name = "txtImagePath4";
            txtImagePath4.Size = new Size(150, 23);
            txtImagePath4.TabIndex = 12;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Sitka Small", 9F, FontStyle.Bold);
            label6.Location = new Point(317, 139);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 11;
            label6.Text = "Image Path 4:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAddLevel
            // 
            btnAddLevel.BackgroundImage = (Image)resources.GetObject("btnAddLevel.BackgroundImage");
            btnAddLevel.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddLevel.FlatStyle = FlatStyle.Flat;
            btnAddLevel.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddLevel.Location = new Point(22, 54);
            btnAddLevel.Name = "btnAddLevel";
            btnAddLevel.Size = new Size(129, 30);
            btnAddLevel.TabIndex = 17;
            btnAddLevel.Text = "Add New Level";
            btnAddLevel.UseVisualStyleBackColor = true;
            btnAddLevel.Click += btnAddLevel_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackgroundImage = (Image)resources.GetObject("btnSaveChanges.BackgroundImage");
            btnSaveChanges.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveChanges.Location = new Point(22, 102);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(129, 30);
            btnSaveChanges.TabIndex = 19;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnDeleteLevel
            // 
            btnDeleteLevel.BackgroundImage = (Image)resources.GetObject("btnDeleteLevel.BackgroundImage");
            btnDeleteLevel.BackgroundImageLayout = ImageLayout.Stretch;
            btnDeleteLevel.FlatStyle = FlatStyle.Flat;
            btnDeleteLevel.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteLevel.Location = new Point(169, 54);
            btnDeleteLevel.Name = "btnDeleteLevel";
            btnDeleteLevel.Size = new Size(129, 30);
            btnDeleteLevel.TabIndex = 18;
            btnDeleteLevel.Text = "Delete Selected";
            btnDeleteLevel.UseVisualStyleBackColor = true;
            btnDeleteLevel.Click += btnDeleteLevel_Click;
            // 
            // btnClearFields
            // 
            btnClearFields.BackgroundImage = (Image)resources.GetObject("btnClearFields.BackgroundImage");
            btnClearFields.BackgroundImageLayout = ImageLayout.Stretch;
            btnClearFields.FlatStyle = FlatStyle.Flat;
            btnClearFields.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearFields.Location = new Point(169, 102);
            btnClearFields.Name = "btnClearFields";
            btnClearFields.Size = new Size(129, 30);
            btnClearFields.TabIndex = 20;
            btnClearFields.Text = "Clear Fields";
            btnClearFields.UseVisualStyleBackColor = true;
            btnClearFields.Click += btnClearFields_Click;
            // 
            // lblEditingGameLevelId
            // 
            lblEditingGameLevelId.AutoSize = true;
            lblEditingGameLevelId.Location = new Point(119, 449);
            lblEditingGameLevelId.Name = "lblEditingGameLevelId";
            lblEditingGameLevelId.Size = new Size(0, 15);
            lblEditingGameLevelId.TabIndex = 21;
            lblEditingGameLevelId.UseWaitCursor = true;
            lblEditingGameLevelId.Visible = false;
            // 
            // btnBrowseImage1
            // 
            btnBrowseImage1.BackgroundImage = (Image)resources.GetObject("btnBrowseImage1.BackgroundImage");
            btnBrowseImage1.BackgroundImageLayout = ImageLayout.Stretch;
            btnBrowseImage1.FlatStyle = FlatStyle.Flat;
            btnBrowseImage1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowseImage1.Location = new Point(579, 48);
            btnBrowseImage1.Name = "btnBrowseImage1";
            btnBrowseImage1.Size = new Size(70, 23);
            btnBrowseImage1.TabIndex = 23;
            btnBrowseImage1.Text = "Browse...";
            btnBrowseImage1.UseVisualStyleBackColor = true;
            btnBrowseImage1.Click += btnBrowseImage1_Click;
            // 
            // btnBrowseImage2
            // 
            btnBrowseImage2.BackgroundImage = (Image)resources.GetObject("btnBrowseImage2.BackgroundImage");
            btnBrowseImage2.BackgroundImageLayout = ImageLayout.Stretch;
            btnBrowseImage2.FlatStyle = FlatStyle.Flat;
            btnBrowseImage2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseImage2.Location = new Point(579, 77);
            btnBrowseImage2.Name = "btnBrowseImage2";
            btnBrowseImage2.Size = new Size(70, 23);
            btnBrowseImage2.TabIndex = 24;
            btnBrowseImage2.Text = "Browse...";
            btnBrowseImage2.UseVisualStyleBackColor = true;
            btnBrowseImage2.Click += btnBrowseImage2_Click;
            // 
            // btnBrowseImage3
            // 
            btnBrowseImage3.BackgroundImage = (Image)resources.GetObject("btnBrowseImage3.BackgroundImage");
            btnBrowseImage3.BackgroundImageLayout = ImageLayout.Stretch;
            btnBrowseImage3.FlatStyle = FlatStyle.Flat;
            btnBrowseImage3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseImage3.Location = new Point(579, 106);
            btnBrowseImage3.Name = "btnBrowseImage3";
            btnBrowseImage3.Size = new Size(70, 23);
            btnBrowseImage3.TabIndex = 25;
            btnBrowseImage3.Text = "Browse...";
            btnBrowseImage3.UseVisualStyleBackColor = true;
            btnBrowseImage3.Click += btnBrowseImage3_Click;
            // 
            // btnBrowseImage4
            // 
            btnBrowseImage4.BackgroundImage = (Image)resources.GetObject("btnBrowseImage4.BackgroundImage");
            btnBrowseImage4.BackgroundImageLayout = ImageLayout.Stretch;
            btnBrowseImage4.FlatStyle = FlatStyle.Flat;
            btnBrowseImage4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseImage4.Location = new Point(579, 135);
            btnBrowseImage4.Name = "btnBrowseImage4";
            btnBrowseImage4.Size = new Size(70, 23);
            btnBrowseImage4.TabIndex = 26;
            btnBrowseImage4.Text = "Browse...";
            btnBrowseImage4.UseVisualStyleBackColor = true;
            btnBrowseImage4.Click += btnBrowseImage4_Click;
            // 
            // ofdSelectImage
            // 
            ofdSelectImage.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";
            ofdSelectImage.Title = "Select Image File";
            // 
            // btnALMBack
            // 
            btnALMBack.BackgroundImage = (Image)resources.GetObject("btnALMBack.BackgroundImage");
            btnALMBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnALMBack.FlatStyle = FlatStyle.Flat;
            btnALMBack.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnALMBack.Location = new Point(12, 12);
            btnALMBack.Name = "btnALMBack";
            btnALMBack.Size = new Size(75, 31);
            btnALMBack.TabIndex = 27;
            btnALMBack.Text = "Back";
            btnALMBack.UseVisualStyleBackColor = true;
            btnALMBack.Click += btnALMBack_Click;
            // 
            // AdminLevelManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(665, 591);
            Controls.Add(btnALMBack);
            Controls.Add(btnBrowseImage4);
            Controls.Add(btnBrowseImage3);
            Controls.Add(btnBrowseImage2);
            Controls.Add(btnBrowseImage1);
            Controls.Add(lblEditingGameLevelId);
            Controls.Add(btnClearFields);
            Controls.Add(btnDeleteLevel);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnAddLevel);
            Controls.Add(txtImagePath4);
            Controls.Add(label6);
            Controls.Add(txtImagePath3);
            Controls.Add(label5);
            Controls.Add(txtImagePath2);
            Controls.Add(label4);
            Controls.Add(txtImagePath1);
            Controls.Add(label3);
            Controls.Add(txtCorrectWord);
            Controls.Add(label2);
            Controls.Add(dgvGameLevels);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AdminLevelManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminLevelManagementForm";
            Load += AdminLevelManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGameLevels).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGameLevels;
        private Label label2;
        private TextBox txtCorrectWord;
        private TextBox txtImagePath1;
        private Label label3;
        private TextBox txtImagePath2;
        private Label label4;
        private TextBox txtImagePath3;
        private Label label5;
        private TextBox txtImagePath4;
        private Label label6;
        private Button btnAddLevel;
        private Button btnSaveChanges;
        private Button btnDeleteLevel;
        private Button btnClearFields;
        private Label lblEditingGameLevelId;
        private Button btnBrowseImage1;
        private Button btnBrowseImage2;
        private Button btnBrowseImage3;
        private Button btnBrowseImage4;
        private OpenFileDialog ofdSelectImage;
        private Button btnALMBack;
    }
}