namespace FourPicsOneWordGame
{
    partial class AdminUserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUserManagementForm));
            dgvUsers = new DataGridView();
            label1 = new Label();
            usernameLabel = new Label();
            txtSelectedUsername = new TextBox();
            label2 = new Label();
            cmbSelectedUserRole = new ComboBox();
            lblSelectedUserId = new Label();
            btnCloseUserManagement = new Button();
            btnUpdateRole = new Button();
            btnDeleteUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.BackgroundColor = Color.MediumAquamarine;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 46);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(560, 297);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(163, 31);
            label1.TabIndex = 1;
            label1.Text = "Manage Users";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLabel.Location = new Point(12, 370);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(100, 23);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSelectedUsername
            // 
            txtSelectedUsername.Location = new Point(118, 372);
            txtSelectedUsername.Name = "txtSelectedUsername";
            txtSelectedUsername.ReadOnly = true;
            txtSelectedUsername.Size = new Size(121, 23);
            txtSelectedUsername.TabIndex = 3;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 420);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 4;
            label2.Text = "Role:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbSelectedUserRole
            // 
            cmbSelectedUserRole.FormattingEnabled = true;
            cmbSelectedUserRole.Location = new Point(118, 422);
            cmbSelectedUserRole.Name = "cmbSelectedUserRole";
            cmbSelectedUserRole.Size = new Size(121, 23);
            cmbSelectedUserRole.TabIndex = 5;
            // 
            // lblSelectedUserId
            // 
            lblSelectedUserId.AutoSize = true;
            lblSelectedUserId.Location = new Point(14, 105);
            lblSelectedUserId.Name = "lblSelectedUserId";
            lblSelectedUserId.Size = new Size(0, 15);
            lblSelectedUserId.TabIndex = 6;
            lblSelectedUserId.Visible = false;
            // 
            // btnCloseUserManagement
            // 
            btnCloseUserManagement.BackgroundImage = (Image)resources.GetObject("btnCloseUserManagement.BackgroundImage");
            btnCloseUserManagement.BackgroundImageLayout = ImageLayout.Stretch;
            btnCloseUserManagement.FlatStyle = FlatStyle.Flat;
            btnCloseUserManagement.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseUserManagement.Location = new Point(493, 9);
            btnCloseUserManagement.Name = "btnCloseUserManagement";
            btnCloseUserManagement.Size = new Size(79, 31);
            btnCloseUserManagement.TabIndex = 7;
            btnCloseUserManagement.Text = "Close";
            btnCloseUserManagement.UseVisualStyleBackColor = true;
            btnCloseUserManagement.Click += btnCloseUserManagement_Click;
            // 
            // btnUpdateRole
            // 
            btnUpdateRole.BackColor = SystemColors.Control;
            btnUpdateRole.BackgroundImage = (Image)resources.GetObject("btnUpdateRole.BackgroundImage");
            btnUpdateRole.BackgroundImageLayout = ImageLayout.Stretch;
            btnUpdateRole.FlatStyle = FlatStyle.Flat;
            btnUpdateRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateRole.Location = new Point(460, 365);
            btnUpdateRole.Name = "btnUpdateRole";
            btnUpdateRole.Size = new Size(112, 34);
            btnUpdateRole.TabIndex = 8;
            btnUpdateRole.Text = "Update Role";
            btnUpdateRole.UseVisualStyleBackColor = false;
            btnUpdateRole.Click += btnUpdateRole_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackgroundImage = (Image)resources.GetObject("btnDeleteUser.BackgroundImage");
            btnDeleteUser.BackgroundImageLayout = ImageLayout.Stretch;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteUser.Location = new Point(460, 415);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(112, 34);
            btnDeleteUser.TabIndex = 9;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // AdminUserManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(584, 461);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnUpdateRole);
            Controls.Add(btnCloseUserManagement);
            Controls.Add(lblSelectedUserId);
            Controls.Add(cmbSelectedUserRole);
            Controls.Add(label2);
            Controls.Add(txtSelectedUsername);
            Controls.Add(usernameLabel);
            Controls.Add(label1);
            Controls.Add(dgvUsers);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AdminUserManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminUserManagementForm";
            Load += AdminUserManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private Label label1;
        private Label usernameLabel;
        private TextBox txtSelectedUsername;
        private Label label2;
        private ComboBox cmbSelectedUserRole;
        private Label lblSelectedUserId;
        private Button btnCloseUserManagement;
        private Button btnUpdateRole;
        private Button btnDeleteUser;
    }
}