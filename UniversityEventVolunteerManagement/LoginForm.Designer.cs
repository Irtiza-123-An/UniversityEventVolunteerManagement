namespace UniversityEventVolunteerManagement
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblpassword = new Label();
            txtPassword = new TextBox();
            btnlogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(328, 68);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Login:";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(228, 156);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 22);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "username:";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(328, 155);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(197, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpassword.Location = new Point(227, 202);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(95, 22);
            lblpassword.TabIndex = 3;
            lblpassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(330, 205);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(195, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnlogin
            // 
            btnlogin.BackColor = SystemColors.ControlLightLight;
            btnlogin.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogin.Location = new Point(356, 268);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(75, 23);
            btnlogin.TabIndex = 5;
            btnlogin.Text = "login";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnlogin);
            Controls.Add(txtPassword);
            Controls.Add(lblpassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblpassword;
        private TextBox txtPassword;
        private Button btnlogin;
    }
}
