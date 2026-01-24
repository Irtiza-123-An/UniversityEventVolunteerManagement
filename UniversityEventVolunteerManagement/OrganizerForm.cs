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
using UniversityEventVolunteerManagement.Backend.Services;

namespace UniversityEventVolunteerManagement
{
    public partial class OrganizerForm : Form
    {
        private readonly UserService _userService;
        private readonly string _tasksFilePath;
        private readonly string _assignmentsFilePath;
        private List<TaskItem> _tasks;
        private List<Assignment> _assignments;

        // New improved controls
        private NumericUpDown numTaskId;
        private NumericUpDown numAssignTaskId;
        private NumericUpDown numVolunteerId;
        private DateTimePicker dtpDueDate;
        private ComboBox cmbPriority;
        private Button btnLogout;

        public OrganizerForm()
        {
            InitializeComponent();
            _userService = new UserService();

            // Set up data directory
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            _tasksFilePath = Path.Combine(dataDir, "tasks.json");
            _assignmentsFilePath = Path.Combine(dataDir, "assignments.json");

            // Initialize improved controls
            InitializeImprovedControls();

            // Add logout button
            InitializeLogoutButton();

            // Load existing data
            LoadTasks();
            LoadAssignments();
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
            // Replace txtTaskId with NumericUpDown
            numTaskId = new NumericUpDown
            {
                Location = txtTaskId.Location,
                Size = txtTaskId.Size,
                Minimum = 1,
                Maximum = 9999,
                Font = new Font("Segoe UI", 9F)
            };
            txtTaskId.Parent.Controls.Add(numTaskId);
            txtTaskId.Visible = false;

            // Replace txtDueDate with DateTimePicker
            dtpDueDate = new DateTimePicker
            {
                Location = txtDueDate.Location,
                Size = txtDueDate.Size,
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 9F)
            };
            txtDueDate.Parent.Controls.Add(dtpDueDate);
            txtDueDate.Visible = false;

            // Replace txtPriority with ComboBox
            cmbPriority = new ComboBox
            {
                Location = txtPriority.Location,
                Size = txtPriority.Size,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F)
            };
            cmbPriority.Items.AddRange(new object[] { "High", "Medium", "Low", "Critical" });
            cmbPriority.SelectedIndex = 1; // Default to Medium
            txtPriority.Parent.Controls.Add(cmbPriority);
            txtPriority.Visible = false;

            // Replace txtAssignTaskId with NumericUpDown
            numAssignTaskId = new NumericUpDown
            {
                Location = txtAssignTaskId.Location,
                Size = txtAssignTaskId.Size,
                Minimum = 1,
                Maximum = 9999,
                Font = new Font("Segoe UI", 9F)
            };
            txtAssignTaskId.Parent.Controls.Add(numAssignTaskId);
            txtAssignTaskId.Visible = false;

            // Replace txtVolunteerId with NumericUpDown
            numVolunteerId = new NumericUpDown
            {
                Location = txtVolunteerId.Location,
                Size = txtVolunteerId.Size,
                Minimum = 1,
                Maximum = 9999,
                Font = new Font("Segoe UI", 9F)
            };
            txtVolunteerId.Parent.Controls.Add(numVolunteerId);
            txtVolunteerId.Visible = false;
        }

        private void LoadTasks()
        {
            try
            {
                if (File.Exists(_tasksFilePath))
                {
                    string json = File.ReadAllText(_tasksFilePath);
                    _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
                }
                else
                {
                    _tasks = new List<TaskItem>();
                }
            }
            catch
            {
                _tasks = new List<TaskItem>();
            }
        }

        private void SaveTasks()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_tasks, options);
            File.WriteAllText(_tasksFilePath, json);
        }

        private void LoadAssignments()
        {
            try
            {
                if (File.Exists(_assignmentsFilePath))
                {
                    string json = File.ReadAllText(_assignmentsFilePath);
                    _assignments = JsonSerializer.Deserialize<List<Assignment>>(json) ?? new List<Assignment>();
                }
                else
                {
                    _assignments = new List<Assignment>();
                }
                RefreshAssignmentsGrid();
            }
            catch
            {
                _assignments = new List<Assignment>();
            }
        }

        private void SaveAssignments()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_assignments, options);
            File.WriteAllText(_assignmentsFilePath, json);
        }

        private void RefreshAssignmentsGrid()
        {
            guna2DataGridView2.Rows.Clear();
            foreach (var assignment in _assignments)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == assignment.TaskId);
                var volunteer = _userService.GetUserById(assignment.VolunteerId);
                string volunteerName = volunteer?.FullName ?? $"ID: {assignment.VolunteerId}";
                string taskDesc = task?.Description ?? $"Task {assignment.TaskId}";

                guna2DataGridView2.Rows.Add(
                    assignment.TaskId,
                    volunteerName,
                    assignment.Status,
                    assignment.Status == "Completed" ? "✓" : "",
                    assignment.Status != "Completed" ? "✗" : ""
                );
            }
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            RefreshAssignmentsGrid();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel6_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel8_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2HtmlLabel7_Click(object sender, EventArgs e) { }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int taskId = (int)numAssignTaskId.Value;
            int volunteerId = (int)numVolunteerId.Value;

            // Verify task exists
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                MessageBox.Show("Task ID not found. Please create the task first.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verify volunteer exists
            var volunteer = _userService.GetUserById(volunteerId);
            if (volunteer == null || volunteer.Role != "Volunteer")
            {
                MessageBox.Show("Volunteer ID not found or user is not a volunteer.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create assignment
            var assignment = new Assignment
            {
                Id = _assignments.Count > 0 ? _assignments.Max(a => a.Id) + 1 : 1,
                TaskId = taskId,
                VolunteerId = volunteerId,
                AssignedAt = DateTime.Now,
                Status = "Pending"
            };

            _assignments.Add(assignment);
            SaveAssignments();
            RefreshAssignmentsGrid();

            MessageBox.Show($"Task '{task.Description}' assigned to {volunteer.FullName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            numAssignTaskId.Value = 1;
            numVolunteerId.Value = 1;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please fill in the Description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int taskId = (int)numTaskId.Value;

            // Check for duplicate
            if (_tasks.Any(t => t.Id == taskId))
            {
                MessageBox.Show("A task with this ID already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newTask = new TaskItem
            {
                Id = taskId,
                Description = txtDescription.Text,
                DueDate = dtpDueDate.Value.ToString("yyyy-MM-dd"),
                Priority = cmbPriority.SelectedItem?.ToString() ?? "Medium",
                Status = "Pending",
                CreatedAt = DateTime.Now
            };

            _tasks.Add(newTask);
            SaveTasks();

            MessageBox.Show($"Task '{txtDescription.Text}' created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            numTaskId.Value = 1;
            txtDescription.Text = "";
            dtpDueDate.Value = DateTime.Now;
            cmbPriority.SelectedIndex = 1;
        }
    }

    // Helper classes for JSON serialization
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public string DueDate { get; set; } = "";
        public string Priority { get; set; } = "";
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
    }

    public class Assignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int VolunteerId { get; set; }
        public DateTime AssignedAt { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
