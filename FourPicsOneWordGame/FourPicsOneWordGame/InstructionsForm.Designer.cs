namespace FourPicsOneWordGame
{
    partial class InstructionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionsForm));
            label1 = new Label();
            richTextBoxInstructions = new RichTextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(484, 64);
            label1.TabIndex = 0;
            label1.Text = "How to Play";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBoxInstructions
            // 
            richTextBoxInstructions.BackColor = Color.MediumTurquoise;
            richTextBoxInstructions.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxInstructions.Location = new Point(12, 67);
            richTextBoxInstructions.Name = "richTextBoxInstructions";
            richTextBoxInstructions.Size = new Size(460, 385);
            richTextBoxInstructions.TabIndex = 1;
            richTextBoxInstructions.Text = "";
            // 
            // btnClose
            // 
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnClose.Location = new Point(397, 518);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 31);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // InstructionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(484, 561);
            Controls.Add(btnClose);
            Controls.Add(richTextBoxInstructions);
            Controls.Add(label1);
            Name = "InstructionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InstructionsForm";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBoxInstructions;
        private Button btnClose;
    }
}