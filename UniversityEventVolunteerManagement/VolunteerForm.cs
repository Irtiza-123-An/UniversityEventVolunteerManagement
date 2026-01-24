using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace UniversityEventVolunteerManagement
{
    public partial class VolunteerForm : Form
    {
        private readonly string _studentsFilePath;
        private readonly string _assignmentsFilePath;
        private readonly string _tasksFilePath;
        private List<StudentRecord> _students;

        // Improved controls
        private MaskedTextBox mtbPhone;
        private ComboBox cmbSemester;
        private ComboBox cmbDepartment;
        private Button btnLogout;

        public VolunteerForm()
        {
            InitializeComponent();

            // Set up data directory
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            _studentsFilePath = Path.Combine(dataDir, "students.json");
            _assignmentsFilePath = Path.Combine(dataDir, "assignments.json");
            _tasksFilePath = Path.Combine(dataDir, "tasks.json");

            // Initialize improved controls
            InitializeImprovedControls();

            // Add logout button
            InitializeLogoutButton();

            LoadStudents();
        }

        private void InitializeLogoutButton()
        {
            btnLogout = new Button
            {
                Text = "Logout",
                Size = new Size(80, 30),
                Location = new Point(this.ClientSize.Width - 95, 10),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => this.Close();
            this.Controls.Add(btnLogout);
            btnLogout.BringToFront();
        }

        private void InitializeImprovedControls()
        {
            // Replace txtPhoneNumber with MaskedTextBox
            mtbPhone = new MaskedTextBox
            {
                Location = txtPhoneNumber.Location,
                Size = txtPhoneNumber.Size,
                Mask = "0000-0000000",
                Font = new Font("Segoe UI", 9F)
            };
            txtPhoneNumber.Parent.Controls.Add(mtbPhone);
            txtPhoneNumber.Visible = false;

            // Replace txtSemester with ComboBox
            cmbSemester = new ComboBox
            {
                Location = txtSemester.Location,
                Size = txtSemester.Size,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F)
            };
            for (int i = 1; i <= 12; i++)
            {
                cmbSemester.Items.Add(i.ToString());
            }
            cmbSemester.SelectedIndex = 0;
            txtSemester.Parent.Controls.Add(cmbSemester);
            txtSemester.Visible = false;

            // Replace txtDepartment with ComboBox
            cmbDepartment = new ComboBox
            {
                Location = txtDepartment.Location,
                Size = txtDepartment.Size,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F)
            };
            cmbDepartment.Items.AddRange(new object[] {
                "CSE", "EEE", "BBA", "English", "Law", "Architecture",
                "Civil Engineering", "Pharmacy", "Economics", "Mathematics"
            });
            cmbDepartment.SelectedIndex = 0;
            txtDepartment.Parent.Controls.Add(cmbDepartment);
            txtDepartment.Visible = false;
        }

        private void LoadStudents()
        {
            try
            {
                if (File.Exists(_studentsFilePath))
                {
                    string json = File.ReadAllText(_studentsFilePath);
                    _students = JsonSerializer.Deserialize<List<StudentRecord>>(json) ?? new List<StudentRecord>();
                }
                else
                {
                    _students = new List<StudentRecord>();
                }
                RefreshStudentGrid();
            }
            catch
            {
                _students = new List<StudentRecord>();
            }
        }

        private void SaveStudents()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_students, options);
            File.WriteAllText(_studentsFilePath, json);
        }

        private void RefreshStudentGrid()
        {
            guna2DataGridView1.Rows.Clear();
            foreach (var student in _students)
            {
                guna2DataGridView1.Rows.Add(
                    student.StudentId,
                    student.FullName,
                    student.Department,
                    student.Semester,
                    student.Phone,
                    student.Email,
                    student.Skills
                );
            }
        }

        private void LoadMyTasks()
        {
            guna2DataGridView2.Rows.Clear();
            try
            {
                if (File.Exists(_assignmentsFilePath) && File.Exists(_tasksFilePath))
                {
                    var assignments = JsonSerializer.Deserialize<List<Assignment>>(File.ReadAllText(_assignmentsFilePath)) ?? new List<Assignment>();
                    var tasks = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(_tasksFilePath)) ?? new List<TaskItem>();

                    // For now, show all assignments (in real app, filter by logged-in user)
                    foreach (var assignment in assignments)
                    {
                        var task = tasks.FirstOrDefault(t => t.Id == assignment.TaskId);
                        if (task != null)
                        {
                            guna2DataGridView2.Rows.Add(
                                task.Description,
                                task.DueDate,
                                "", // Delay
                                assignment.Status == "Completed" ? "✓" : "",
                                assignment.Status != "Completed" ? "✗" : ""
                            );
                        }
                    }
                }
            }
            catch { }
        }

        private void VolunteerForm_Load(object sender, EventArgs e)
        {
            RefreshStudentGrid();
            LoadMyTasks();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please fill in the Student ID and Full Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate
            if (_students.Any(s => s.StudentId == txtStudentID.Text))
            {
                MessageBox.Show("A student with this ID already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newStudent = new StudentRecord
            {
                StudentId = txtStudentID.Text,
                FullName = txtFullName.Text,
                Phone = mtbPhone.Text,
                Email = txtEmail.Text,
                Semester = cmbSemester.SelectedItem?.ToString() ?? "",
                Department = cmbDepartment.SelectedItem?.ToString() ?? "",
                Skills = txtSkills.Text,
                CreatedAt = DateTime.Now
            };

            _students.Add(newStudent);
            SaveStudents();
            RefreshStudentGrid();

            MessageBox.Show($"Student '{txtFullName.Text}' registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearRegistrationForm();
        }

        private void ClearRegistrationForm()
        {
            txtFullName.Text = "";
            txtStudentID.Text = "";
            mtbPhone.Clear();
            txtEmail.Text = "";
            cmbSemester.SelectedIndex = 0;
            cmbDepartment.SelectedIndex = 0;
            txtSkills.Text = "";
        }
    }

    // Helper class for student records
    public class StudentRecord
    {
        public string StudentId { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Semester { get; set; } = "";
        public string Department { get; set; } = "";
        public string Skills { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
