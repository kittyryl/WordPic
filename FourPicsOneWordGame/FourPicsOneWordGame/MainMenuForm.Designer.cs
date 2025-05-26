namespace FourPicsOneWordGame
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            lblWelcomeMessage = new Label();
            btnLogout = new Button();
            btnManageLevels = new Button();
            btnViewProgress = new Button();
            btnPlayGame = new Button();
            btnShowLeaderboard = new Button();
            btnManageUsers = new Button();
            btnViewDashboard = new Button();
            btnInstructions = new Button();
            SuspendLayout();
            // 
            // lblWelcomeMessage
            // 
            lblWelcomeMessage.BackColor = Color.Transparent;
            lblWelcomeMessage.Font = new Font("SimSun-ExtB", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcomeMessage.ForeColor = SystemColors.ActiveCaptionText;
            lblWelcomeMessage.Location = new Point(12, 9);
            lblWelcomeMessage.Name = "lblWelcomeMessage";
            lblWelcomeMessage.Size = new Size(280, 23);
            lblWelcomeMessage.TabIndex = 0;
            lblWelcomeMessage.Text = "Welcome!";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.MediumAquamarine;
            btnLogout.BackgroundImage = (Image)resources.GetObject("btnLogout.BackgroundImage");
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnLogout.Location = new Point(397, 418);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 31);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageLevels
            // 
            btnManageLevels.BackColor = Color.MediumAquamarine;
            btnManageLevels.BackgroundImage = (Image)resources.GetObject("btnManageLevels.BackgroundImage");
            btnManageLevels.BackgroundImageLayout = ImageLayout.Stretch;
            btnManageLevels.FlatStyle = FlatStyle.Flat;
            btnManageLevels.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnManageLevels.Location = new Point(174, 287);
            btnManageLevels.Name = "btnManageLevels";
            btnManageLevels.Size = new Size(150, 30);
            btnManageLevels.TabIndex = 0;
            btnManageLevels.Text = "Manage Levels";
            btnManageLevels.UseVisualStyleBackColor = false;
            btnManageLevels.Click += btnManageLevels_Click;
            // 
            // btnViewProgress
            // 
            btnViewProgress.BackColor = Color.MediumAquamarine;
            btnViewProgress.BackgroundImage = (Image)resources.GetObject("btnViewProgress.BackgroundImage");
            btnViewProgress.BackgroundImageLayout = ImageLayout.Stretch;
            btnViewProgress.FlatStyle = FlatStyle.Flat;
            btnViewProgress.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewProgress.Location = new Point(174, 179);
            btnViewProgress.Name = "btnViewProgress";
            btnViewProgress.Size = new Size(150, 30);
            btnViewProgress.TabIndex = 3;
            btnViewProgress.Text = "View My Progress";
            btnViewProgress.UseVisualStyleBackColor = false;
            btnViewProgress.Click += btnViewProgress_Click;
            // 
            // btnPlayGame
            // 
            btnPlayGame.BackColor = Color.MediumAquamarine;
            btnPlayGame.BackgroundImage = (Image)resources.GetObject("btnPlayGame.BackgroundImage");
            btnPlayGame.BackgroundImageLayout = ImageLayout.Stretch;
            btnPlayGame.FlatStyle = FlatStyle.Flat;
            btnPlayGame.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlayGame.ForeColor = SystemColors.ControlText;
            btnPlayGame.Location = new Point(174, 107);
            btnPlayGame.Name = "btnPlayGame";
            btnPlayGame.Size = new Size(150, 30);
            btnPlayGame.TabIndex = 2;
            btnPlayGame.Text = "Play Game";
            btnPlayGame.UseVisualStyleBackColor = false;
            btnPlayGame.Click += btnPlayGame_Click;
            // 
            // btnShowLeaderboard
            // 
            btnShowLeaderboard.BackColor = Color.MediumAquamarine;
            btnShowLeaderboard.BackgroundImage = (Image)resources.GetObject("btnShowLeaderboard.BackgroundImage");
            btnShowLeaderboard.BackgroundImageLayout = ImageLayout.Stretch;
            btnShowLeaderboard.FlatStyle = FlatStyle.Flat;
            btnShowLeaderboard.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnShowLeaderboard.Location = new Point(174, 215);
            btnShowLeaderboard.Name = "btnShowLeaderboard";
            btnShowLeaderboard.Size = new Size(150, 30);
            btnShowLeaderboard.TabIndex = 5;
            btnShowLeaderboard.Text = "Leaderboard";
            btnShowLeaderboard.UseVisualStyleBackColor = false;
            btnShowLeaderboard.Click += button1_Click;
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.MediumAquamarine;
            btnManageUsers.BackgroundImage = (Image)resources.GetObject("btnManageUsers.BackgroundImage");
            btnManageUsers.BackgroundImageLayout = ImageLayout.Stretch;
            btnManageUsers.FlatStyle = FlatStyle.Flat;
            btnManageUsers.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnManageUsers.Location = new Point(174, 323);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(150, 30);
            btnManageUsers.TabIndex = 6;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += button1_Click_1;
            // 
            // btnViewDashboard
            // 
            btnViewDashboard.BackColor = Color.MediumAquamarine;
            btnViewDashboard.BackgroundImage = (Image)resources.GetObject("btnViewDashboard.BackgroundImage");
            btnViewDashboard.BackgroundImageLayout = ImageLayout.Stretch;
            btnViewDashboard.FlatStyle = FlatStyle.Flat;
            btnViewDashboard.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnViewDashboard.Location = new Point(174, 251);
            btnViewDashboard.Name = "btnViewDashboard";
            btnViewDashboard.Size = new Size(150, 30);
            btnViewDashboard.TabIndex = 7;
            btnViewDashboard.Text = "Dashboard";
            btnViewDashboard.UseVisualStyleBackColor = false;
            btnViewDashboard.Click += btnViewDashboard_Click;
            // 
            // btnInstructions
            // 
            btnInstructions.BackColor = Color.MediumAquamarine;
            btnInstructions.BackgroundImage = (Image)resources.GetObject("btnInstructions.BackgroundImage");
            btnInstructions.BackgroundImageLayout = ImageLayout.Stretch;
            btnInstructions.FlatStyle = FlatStyle.Flat;
            btnInstructions.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnInstructions.Location = new Point(174, 143);
            btnInstructions.Name = "btnInstructions";
            btnInstructions.Size = new Size(150, 30);
            btnInstructions.TabIndex = 9;
            btnInstructions.Text = "How to Play";
            btnInstructions.UseVisualStyleBackColor = false;
            btnInstructions.Click += btnInstructions_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(484, 461);
            Controls.Add(btnInstructions);
            Controls.Add(btnViewDashboard);
            Controls.Add(btnManageUsers);
            Controls.Add(btnShowLeaderboard);
            Controls.Add(btnViewProgress);
            Controls.Add(btnManageLevels);
            Controls.Add(btnPlayGame);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcomeMessage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenuForm";
            Activated += MainMenuForm_Activated;
            Load += MainMenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblWelcomeMessage;
        private Button btnLogout;
        private Button btnManageLevels;
        private Button btnViewProgress;
        private Button btnPlayGame;
        private Button btnShowLeaderboard;
        private Button btnManageUsers;
        private Button btnViewDashboard;
        private Button btnInstructions;
    }
}