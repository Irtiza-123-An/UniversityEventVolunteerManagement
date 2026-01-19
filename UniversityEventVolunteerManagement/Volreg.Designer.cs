namespace UniversityEventVolunteerManagement
{
    partial class Volreg
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            label5 = new Label();
            lnklogin = new LinkLabel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(46, 95);
            label1.Name = "label1";
            label1.Size = new Size(87, 19);
            label1.TabIndex = 0;
            label1.Text = "Full Name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(71, 149);
            label2.Name = "label2";
            label2.Size = new Size(56, 19);
            label2.TabIndex = 1;
            label2.Text = "Email: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(19, 194);
            label3.Name = "label3";
            label3.Size = new Size(117, 19);
            label3.TabIndex = 2;
            label3.Text = "Phone Number: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label4.Location = new Point(50, 246);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 3;
            label4.Text = "Password: ";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(142, 92);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(144, 23);
            txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(142, 141);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(144, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(142, 194);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(144, 23);
            txtPhoneNumber.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ButtonHighlight;
            txtPassword.Location = new Point(142, 238);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(144, 23);
            txtPassword.TabIndex = 7;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 255, 192);
            btnRegister.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(122, 296);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(107, 27);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(60, 17);
            label5.Name = "label5";
            label5.Size = new Size(238, 31);
            label5.TabIndex = 9;
            label5.Text = "Registration Form ";
            // 
            // lnklogin
            // 
            lnklogin.AutoSize = true;
            lnklogin.BackColor = Color.White;
            lnklogin.LinkColor = Color.Black;
            lnklogin.Location = new Point(86, 364);
            lnklogin.Name = "lnklogin";
            lnklogin.Size = new Size(200, 15);
            lnklogin.TabIndex = 10;
            lnklogin.TabStop = true;
            lnklogin.Text = "Already have an account? Click here!";
            lnklogin.LinkClicked += lnklogin_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(150, 235, 255, 255);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lnklogin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(txtPhoneNumber);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(151, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(349, 391);
            panel1.TabIndex = 11;
            // 
            // Volreg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources._492072851_1151955406731062_4674252519964508692_n;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(652, 450);
            Controls.Add(panel1);
            Name = "Volreg";
            Text = "Volreg";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtPassword;
        private Button btnRegister;
        private Label label5;
        private LinkLabel lnklogin;
        private Panel panel1;
    }
}