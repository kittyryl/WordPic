namespace FourPicsOneWordGame
{
    partial class LeaderboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaderboardForm));
            lblLeaderboardTitle = new Label();
            btnCloseLeaderboard = new Button();
            flpLeaderboardEntries = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblLeaderboardTitle
            // 
            lblLeaderboardTitle.BackColor = Color.Transparent;
            lblLeaderboardTitle.Dock = DockStyle.Top;
            lblLeaderboardTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLeaderboardTitle.Location = new Point(0, 0);
            lblLeaderboardTitle.Name = "lblLeaderboardTitle";
            lblLeaderboardTitle.Size = new Size(484, 62);
            lblLeaderboardTitle.TabIndex = 0;
            lblLeaderboardTitle.Text = "Top Players - Leaderboard";
            lblLeaderboardTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCloseLeaderboard
            // 
            btnCloseLeaderboard.BackgroundImage = (Image)resources.GetObject("btnCloseLeaderboard.BackgroundImage");
            btnCloseLeaderboard.BackgroundImageLayout = ImageLayout.Stretch;
            btnCloseLeaderboard.FlatStyle = FlatStyle.Flat;
            btnCloseLeaderboard.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnCloseLeaderboard.Location = new Point(401, 12);
            btnCloseLeaderboard.Name = "btnCloseLeaderboard";
            btnCloseLeaderboard.Size = new Size(71, 31);
            btnCloseLeaderboard.TabIndex = 2;
            btnCloseLeaderboard.Text = "Close";
            btnCloseLeaderboard.UseVisualStyleBackColor = true;
            btnCloseLeaderboard.Click += btnCloseLeaderboard_Click;
            // 
            // flpLeaderboardEntries
            // 
            flpLeaderboardEntries.AutoScroll = true;
            flpLeaderboardEntries.BackColor = Color.MediumTurquoise;
            flpLeaderboardEntries.BorderStyle = BorderStyle.FixedSingle;
            flpLeaderboardEntries.FlowDirection = FlowDirection.TopDown;
            flpLeaderboardEntries.Location = new Point(12, 65);
            flpLeaderboardEntries.Name = "flpLeaderboardEntries";
            flpLeaderboardEntries.Size = new Size(460, 307);
            flpLeaderboardEntries.TabIndex = 3;
            flpLeaderboardEntries.WrapContents = false;
            // 
            // LeaderboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(484, 461);
            Controls.Add(flpLeaderboardEntries);
            Controls.Add(btnCloseLeaderboard);
            Controls.Add(lblLeaderboardTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LeaderboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LeaderboardForm";
            Load += LeaderboardForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblLeaderboardTitle;
        private Button btnCloseLeaderboard;
        private FlowLayoutPanel flpLeaderboardEntries;
    }
}