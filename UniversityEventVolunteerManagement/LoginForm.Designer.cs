
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
            btnLogin = new Button();
            linkLabel1 = new LinkLabel();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(123, 93);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(99, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LOGIN:";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(46, 153);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(107, 24);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.Menu;
            txtUsername.Location = new Point(155, 154);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(133, 23);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.BackColor = Color.Transparent;
            lblpassword.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpassword.Location = new Point(46, 205);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(103, 24);
            lblpassword.TabIndex = 3;
            lblpassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Menu;
            txtPassword.Location = new Point(155, 205);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(133, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Gold;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ControlText;
            btnLogin.Location = new Point(132, 261);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(80, 31);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.White;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(68, 325);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(207, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Don't have an account? Register Here!";
            linkLabel1.VisitedLinkColor = Color.White;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(180, 235, 255, 255);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lblpassword);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(436, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 375);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Elephant", 21.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(21, 140);
            label1.Name = "label1";
            label1.Size = new Size(158, 38);
            label1.TabIndex = 8;
            label1.Text = "     AIUB \r\n";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.aiub_seeklogo;
            pictureBox1.Location = new Point(0, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Elephant", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(39, 178);
            label2.Name = "label2";
            label2.Size = new Size(156, 31);
            label2.TabIndex = 10;
            label2.Text = "Event Hub";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(150, 30, 30, 30);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(409, 426);
            panel2.TabIndex = 11;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._601363886_1296678569159060_3161592934374379085_n;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "LoginForm";
            Text = "AIUB Event Hub - Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblpassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel linkLabel1;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel2;
    }
}
