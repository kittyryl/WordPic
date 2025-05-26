namespace FourPicsOneWordGame
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            lblDashboardTitle = new Label();
            lblTotalPlayers = new Label();
            lblTotalPuzzles = new Label();
            lblAverageScore = new Label();
            cartesianChartTopPlayers = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            btnCloseDashboard = new Button();
            SuspendLayout();
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.BackColor = Color.Transparent;
            lblDashboardTitle.Dock = DockStyle.Top;
            lblDashboardTitle.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.Location = new Point(0, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(800, 45);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Admin Dashboard";
            lblDashboardTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalPlayers
            // 
            lblTotalPlayers.BackColor = Color.Transparent;
            lblTotalPlayers.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPlayers.Location = new Point(12, 92);
            lblTotalPlayers.Name = "lblTotalPlayers";
            lblTotalPlayers.Size = new Size(150, 30);
            lblTotalPlayers.TabIndex = 1;
            lblTotalPlayers.Text = "Total Players: 0";
            lblTotalPlayers.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPuzzles
            // 
            lblTotalPuzzles.BackColor = Color.Transparent;
            lblTotalPuzzles.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPuzzles.Location = new Point(12, 269);
            lblTotalPuzzles.Name = "lblTotalPuzzles";
            lblTotalPuzzles.Size = new Size(150, 30);
            lblTotalPuzzles.TabIndex = 2;
            lblTotalPuzzles.Text = "Total Puzzles: 0";
            lblTotalPuzzles.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAverageScore
            // 
            lblAverageScore.BackColor = Color.Transparent;
            lblAverageScore.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAverageScore.Location = new Point(12, 183);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(172, 30);
            lblAverageScore.TabIndex = 3;
            lblAverageScore.Text = "Average Score: 0.0";
            lblAverageScore.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cartesianChartTopPlayers
            // 
            cartesianChartTopPlayers.BackColor = Color.MediumAquamarine;
            cartesianChartTopPlayers.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cartesianChartTopPlayers.ForeColor = SystemColors.ActiveCaptionText;
            cartesianChartTopPlayers.Location = new Point(204, 77);
            cartesianChartTopPlayers.Margin = new Padding(3, 4, 3, 4);
            cartesianChartTopPlayers.MatchAxesScreenDataRatio = false;
            cartesianChartTopPlayers.Name = "cartesianChartTopPlayers";
            cartesianChartTopPlayers.Size = new Size(584, 285);
            cartesianChartTopPlayers.TabIndex = 4;
            // 
            // btnCloseDashboard
            // 
            btnCloseDashboard.BackgroundImage = (Image)resources.GetObject("btnCloseDashboard.BackgroundImage");
            btnCloseDashboard.BackgroundImageLayout = ImageLayout.Stretch;
            btnCloseDashboard.FlatStyle = FlatStyle.Flat;
            btnCloseDashboard.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseDashboard.Location = new Point(713, 12);
            btnCloseDashboard.Name = "btnCloseDashboard";
            btnCloseDashboard.Size = new Size(75, 33);
            btnCloseDashboard.TabIndex = 5;
            btnCloseDashboard.Text = "Close";
            btnCloseDashboard.UseVisualStyleBackColor = true;
            btnCloseDashboard.Click += btnCloseDashboard_Click;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCloseDashboard);
            Controls.Add(cartesianChartTopPlayers);
            Controls.Add(lblAverageScore);
            Controls.Add(lblTotalPuzzles);
            Controls.Add(lblTotalPlayers);
            Controls.Add(lblDashboardTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDashboardForm";
            Load += AdminDashboardForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblDashboardTitle;
        private Label lblTotalPlayers;
        private Label lblTotalPuzzles;
        private Label lblAverageScore;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChartTopPlayers;
        private Button btnCloseDashboard;
    }
}