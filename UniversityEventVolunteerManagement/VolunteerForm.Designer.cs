namespace UniversityEventVolunteerManagement
{
    partial class VolunteerForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dgvStudent = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtStudentID = new TextBox();
            txtStudentName = new TextBox();
            txtStudentPhone = new TextBox();
            txtStudentEmail = new TextBox();
            txtSkill = new TextBox();
            cmbDept = new ComboBox();
            btnAddStudent = new Button();
            txtSemester = new TextBox();
            colID = new DataGridViewTextBoxColumn();
            ColName = new DataGridViewTextBoxColumn();
            ColDept = new DataGridViewTextBoxColumn();
            ColSems = new DataGridViewTextBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColSkills = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(761, 402);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvStudent);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(753, 374);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Student List";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtSemester);
            tabPage2.Controls.Add(btnAddStudent);
            tabPage2.Controls.Add(cmbDept);
            tabPage2.Controls.Add(txtSkill);
            tabPage2.Controls.Add(txtStudentEmail);
            tabPage2.Controls.Add(txtStudentPhone);
            tabPage2.Controls.Add(txtStudentName);
            tabPage2.Controls.Add(txtStudentID);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(753, 374);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Register New Student";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvStudent
            // 
            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudent.Columns.AddRange(new DataGridViewColumn[] { colID, ColName, ColDept, ColSems, colPhoneNumber, ColEmail, ColSkills });
            dgvStudent.Dock = DockStyle.Fill;
            dgvStudent.Location = new Point(3, 3);
            dgvStudent.Name = "dgvStudent";
            dgvStudent.Size = new Size(747, 368);
            dgvStudent.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 60);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Student ID: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(364, 60);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Full Name: ";
           
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 121);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 2;
            label3.Text = "Phone: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(389, 116);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 185);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 4;
            label5.Text = "Department: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(365, 185);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 5;
            label6.Text = "Semester:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(100, 257);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 6;
            label7.Text = "Skill: ";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(141, 52);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(100, 23);
            txtStudentID.TabIndex = 7;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(438, 52);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(100, 23);
            txtStudentName.TabIndex = 8;
            txtStudentName.TextChanged += textBox2_TextChanged;
            // 
            // txtStudentPhone
            // 
            txtStudentPhone.Location = new Point(140, 113);
            txtStudentPhone.Name = "txtStudentPhone";
            txtStudentPhone.Size = new Size(100, 23);
            txtStudentPhone.TabIndex = 9;
            // 
            // txtStudentEmail
            // 
            txtStudentEmail.Location = new Point(438, 113);
            txtStudentEmail.Name = "txtStudentEmail";
            txtStudentEmail.Size = new Size(100, 23);
            txtStudentEmail.TabIndex = 10;
            txtStudentEmail.TextChanged += textBox4_TextChanged;
            // 
            // txtSkill
            // 
            txtSkill.Location = new Point(140, 249);
            txtSkill.Name = "txtSkill";
            txtSkill.Size = new Size(100, 23);
            txtSkill.TabIndex = 11;
            // 
            // cmbDept
            // 
            cmbDept.FormattingEnabled = true;
            cmbDept.Items.AddRange(new object[] { "Computer Science And Engineering ", "Electrical Engineering ", "Business Administration ", "Architecture ", "Arts and Social Science ", "Science and Technology " });
            cmbDept.Location = new Point(140, 177);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(121, 23);
            cmbDept.TabIndex = 12;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(258, 316);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(173, 34);
            btnAddStudent.TabIndex = 14;
            btnAddStudent.Text = "Add Student ";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(438, 182);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(100, 23);
            txtSemester.TabIndex = 15;
            txtSemester.TextChanged += textBox1_TextChanged;
            // 
            // colID
            // 
            colID.HeaderText = "Student ID";
            colID.Name = "colID";
            // 
            // ColName
            // 
            ColName.HeaderText = "Student Name";
            ColName.Name = "ColName";
            // 
            // ColDept
            // 
            ColDept.HeaderText = "Department";
            ColDept.Name = "ColDept";
            // 
            // ColSems
            // 
            ColSems.HeaderText = "Semester";
            ColSems.Name = "ColSems";
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.HeaderText = "Phone Number";
            colPhoneNumber.Name = "colPhoneNumber";
            // 
            // ColEmail
            // 
            ColEmail.HeaderText = "Email";
            ColEmail.Name = "ColEmail";
            // 
            // ColSkills
            // 
            ColSkills.HeaderText = "Skills";
            ColSkills.Name = "ColSkills";
            // 
            // VolunteerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "VolunteerForm";
            Text = "VolunteerForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvStudent;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox cmbDept;
        private TextBox txtSkill;
        private TextBox txtStudentEmail;
        private TextBox txtStudentPhone;
        private TextBox txtStudentName;
        private TextBox txtStudentID;
        private Button btnAddStudent;
        private TextBox txtSemester;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn ColName;
        private DataGridViewTextBoxColumn ColDept;
        private DataGridViewTextBoxColumn ColSems;
        private DataGridViewTextBoxColumn colPhoneNumber;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColSkills;
    }
}