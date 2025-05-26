namespace FourPicsOneWordGame
{
    partial class GamePlayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePlayForm));
            pbImage1 = new PictureBox();
            pbImage2 = new PictureBox();
            pbImage3 = new PictureBox();
            pbImage4 = new PictureBox();
            flpAnswerSlots = new FlowLayoutPanel();
            flpLetterBank = new FlowLayoutPanel();
            btnShowHint = new Button();
            lblPlayerLevelDisplay = new Label();
            lblGameTotalScore = new Label();
            lblGameMessage = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pbImage1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImage2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImage3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImage4).BeginInit();
            SuspendLayout();
            // 
            // pbImage1
            // 
            pbImage1.BorderStyle = BorderStyle.FixedSingle;
            pbImage1.Location = new Point(174, 75);
            pbImage1.Name = "pbImage1";
            pbImage1.Size = new Size(150, 150);
            pbImage1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage1.TabIndex = 0;
            pbImage1.TabStop = false;
            // 
            // pbImage2
            // 
            pbImage2.BorderStyle = BorderStyle.FixedSingle;
            pbImage2.Location = new Point(359, 75);
            pbImage2.Name = "pbImage2";
            pbImage2.Size = new Size(150, 150);
            pbImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage2.TabIndex = 1;
            pbImage2.TabStop = false;
            // 
            // pbImage3
            // 
            pbImage3.BorderStyle = BorderStyle.FixedSingle;
            pbImage3.Location = new Point(174, 257);
            pbImage3.Name = "pbImage3";
            pbImage3.Size = new Size(150, 150);
            pbImage3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage3.TabIndex = 2;
            pbImage3.TabStop = false;
            // 
            // pbImage4
            // 
            pbImage4.BorderStyle = BorderStyle.FixedSingle;
            pbImage4.Location = new Point(359, 257);
            pbImage4.Name = "pbImage4";
            pbImage4.Size = new Size(150, 150);
            pbImage4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage4.TabIndex = 3;
            pbImage4.TabStop = false;
            // 
            // flpAnswerSlots
            // 
            flpAnswerSlots.Anchor = AnchorStyles.Top;
            flpAnswerSlots.AutoSize = true;
            flpAnswerSlots.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAnswerSlots.BackColor = Color.Transparent;
            flpAnswerSlots.Location = new Point(12, 431);
            flpAnswerSlots.Name = "flpAnswerSlots";
            flpAnswerSlots.Size = new Size(0, 0);
            flpAnswerSlots.TabIndex = 15;
            flpAnswerSlots.WrapContents = false;
            // 
            // flpLetterBank
            // 
            flpLetterBank.AutoSize = true;
            flpLetterBank.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpLetterBank.BackColor = Color.Transparent;
            flpLetterBank.Location = new Point(12, 520);
            flpLetterBank.Name = "flpLetterBank";
            flpLetterBank.Size = new Size(0, 0);
            flpLetterBank.TabIndex = 16;
            // 
            // btnShowHint
            // 
            btnShowHint.BackColor = Color.CornflowerBlue;
            btnShowHint.BackgroundImage = (Image)resources.GetObject("btnShowHint.BackgroundImage");
            btnShowHint.BackgroundImageLayout = ImageLayout.Stretch;
            btnShowHint.FlatStyle = FlatStyle.Flat;
            btnShowHint.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShowHint.Location = new Point(12, 616);
            btnShowHint.Name = "btnShowHint";
            btnShowHint.Size = new Size(75, 33);
            btnShowHint.TabIndex = 17;
            btnShowHint.Text = "Hint";
            btnShowHint.UseVisualStyleBackColor = false;
            btnShowHint.Click += btnShowHint_Click;
            // 
            // lblPlayerLevelDisplay
            // 
            lblPlayerLevelDisplay.AutoSize = true;
            lblPlayerLevelDisplay.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlayerLevelDisplay.Location = new Point(12, 9);
            lblPlayerLevelDisplay.Name = "lblPlayerLevelDisplay";
            lblPlayerLevelDisplay.Size = new Size(65, 19);
            lblPlayerLevelDisplay.TabIndex = 12;
            lblPlayerLevelDisplay.Text = "Level: 0";
            // 
            // lblGameTotalScore
            // 
            lblGameTotalScore.AutoSize = true;
            lblGameTotalScore.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameTotalScore.Location = new Point(553, 9);
            lblGameTotalScore.Name = "lblGameTotalScore";
            lblGameTotalScore.Size = new Size(104, 19);
            lblGameTotalScore.TabIndex = 13;
            lblGameTotalScore.Text = "Total Score: 0";
            // 
            // lblGameMessage
            // 
            lblGameMessage.BackColor = Color.Transparent;
            lblGameMessage.Location = new Point(12, 568);
            lblGameMessage.Name = "lblGameMessage";
            lblGameMessage.Size = new Size(660, 23);
            lblGameMessage.TabIndex = 5;
            lblGameMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblGameMessage.Click += lblGameMessage_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(597, 616);
            button1.Name = "button1";
            button1.Size = new Size(75, 33);
            button1.TabIndex = 18;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GamePlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 661);
            Controls.Add(button1);
            Controls.Add(lblGameMessage);
            Controls.Add(btnShowHint);
            Controls.Add(flpLetterBank);
            Controls.Add(lblGameTotalScore);
            Controls.Add(flpAnswerSlots);
            Controls.Add(lblPlayerLevelDisplay);
            Controls.Add(pbImage2);
            Controls.Add(pbImage4);
            Controls.Add(pbImage3);
            Controls.Add(pbImage1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GamePlayForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GamePlayForm";
            Load += GamePlayForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbImage1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImage2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImage3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImage4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImage1;
        private PictureBox pbImage2;
        private PictureBox pbImage3;
        private PictureBox pbImage4;
        private FlowLayoutPanel flpAnswerSlots;
        private FlowLayoutPanel flpLetterBank;
        private Button btnShowHint;
        private Label lblPlayerLevelDisplay;
        private Label lblGameTotalScore;
        private Label lblGameMessage;
        private Button button1;
    }
}