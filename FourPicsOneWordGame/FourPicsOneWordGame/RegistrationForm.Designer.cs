namespace FourPicsOneWordGame
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            label4 = new Label();
            btnRegister = new Button();
            lblMessage = new Label();
            btnGoToLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(141, 144);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(141, 208);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(141, 272);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 2;
            label3.Text = "Confirm Password:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(141, 167);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(141, 231);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(141, 295);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(200, 23);
            txtConfirmPassword.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SimSun-ExtB", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(167, 97);
            label4.Name = "label4";
            label4.Size = new Size(151, 33);
            label4.TabIndex = 6;
            label4.Text = "Register";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Pink;
            btnRegister.BackgroundImage = (Image)resources.GetObject("btnRegister.BackgroundImage");
            btnRegister.BackgroundImageLayout = ImageLayout.Stretch;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnRegister.Location = new Point(188, 324);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(97, 32);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(97, 65);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(300, 20);
            lblMessage.TabIndex = 8;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGoToLogin
            // 
            btnGoToLogin.BackColor = Color.Pink;
            btnGoToLogin.BackgroundImage = (Image)resources.GetObject("btnGoToLogin.BackgroundImage");
            btnGoToLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnGoToLogin.FlatStyle = FlatStyle.Flat;
            btnGoToLogin.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold);
            btnGoToLogin.Location = new Point(372, 12);
            btnGoToLogin.Name = "btnGoToLogin";
            btnGoToLogin.Size = new Size(100, 30);
            btnGoToLogin.TabIndex = 9;
            btnGoToLogin.Text = "Login";
            btnGoToLogin.UseVisualStyleBackColor = false;
            btnGoToLogin.Click += btnGoToLogin_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(btnGoToLogin);
            Controls.Add(lblMessage);
            Controls.Add(btnRegister);
            Controls.Add(label4);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrationForm";
            Load += RegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Label label4;
        private Button btnRegister;
        private Label lblMessage;
        private Button btnGoToLogin;
    }
}