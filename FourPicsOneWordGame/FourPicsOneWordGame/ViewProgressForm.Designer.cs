namespace FourPicsOneWordGame
{
    partial class ViewProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProgressForm));
            lblTitle = new Label();
            btnClose = new Button();
            lblOverallTotalScore = new Label();
            flpProgressEntries = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Sitka Small", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(164, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Progress";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnClose.Location = new Point(688, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblOverallTotalScore
            // 
            lblOverallTotalScore.AutoSize = true;
            lblOverallTotalScore.BackColor = Color.Transparent;
            lblOverallTotalScore.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOverallTotalScore.Location = new Point(337, 26);
            lblOverallTotalScore.Name = "lblOverallTotalScore";
            lblOverallTotalScore.Size = new Size(126, 24);
            lblOverallTotalScore.TabIndex = 3;
            lblOverallTotalScore.Text = "Total Score: 0";
            // 
            // flpProgressEntries
            // 
            flpProgressEntries.BackColor = Color.MediumTurquoise;
            flpProgressEntries.BorderStyle = BorderStyle.FixedSingle;
            flpProgressEntries.FlowDirection = FlowDirection.TopDown;
            flpProgressEntries.Location = new Point(12, 62);
            flpProgressEntries.Name = "flpProgressEntries";
            flpProgressEntries.Size = new Size(776, 301);
            flpProgressEntries.TabIndex = 4;
            flpProgressEntries.WrapContents = false;
            // 
            // ViewProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(flpProgressEntries);
            Controls.Add(lblOverallTotalScore);
            Controls.Add(btnClose);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ViewProgressForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewProgressForm";
            Load += ViewProgressForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnClose;
        private Label lblOverallTotalScore;
        private FlowLayoutPanel flpProgressEntries;
    }
}