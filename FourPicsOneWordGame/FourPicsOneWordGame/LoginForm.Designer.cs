namespace FourPicsOneWordGame
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblMessage = new Label();
            btnGoToRegister = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(160, 91);
            label1.Name = "label1";
            label1.Size = new Size(163, 48);
            label1.TabIndex = 0;
            label1.Text = "WordPic";
            // 
            // label2
            // 
            label2.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            label2.Location = new Point(138, 148);
            label2.Name = "label2";
            label2.Size = new Size(200, 20);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            label3.Location = new Point(138, 209);
            label3.Name = "label3";
            label3.Size = new Size(200, 20);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(138, 171);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(138, 232);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.GradientInactiveCaption;
            btnLogin.BackgroundImage = (Image)resources.GetObject("btnLogin.BackgroundImage");
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnLogin.Location = new Point(191, 270);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(93, 34);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(96, 60);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(300, 20);
            lblMessage.TabIndex = 6;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGoToRegister
            // 
            btnGoToRegister.BackColor = SystemColors.GradientInactiveCaption;
            btnGoToRegister.BackgroundImage = (Image)resources.GetObject("btnGoToRegister.BackgroundImage");
            btnGoToRegister.BackgroundImageLayout = ImageLayout.Stretch;
            btnGoToRegister.FlatStyle = FlatStyle.Flat;
            btnGoToRegister.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGoToRegister.Location = new Point(372, 12);
            btnGoToRegister.Name = "btnGoToRegister";
            btnGoToRegister.Size = new Size(100, 30);
            btnGoToRegister.TabIndex = 7;
            btnGoToRegister.Text = "Register";
            btnGoToRegister.UseVisualStyleBackColor = false;
            btnGoToRegister.Click += btnGoToRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(btnGoToRegister);
            Controls.Add(lblMessage);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblMessage;
        private Button btnGoToRegister;
    }
}