using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityEventVolunteerManagement.Backend.Services;
using UniversityEventVolunteerManagement.Backend.Models;

namespace UniversityEventVolunteerManagement
{
    public partial class AdminForm : Form
    {
        private readonly UserService _userService;

        // Improved controls
        private NumericUpDown numOrganizerId;
        private MaskedTextBox mtbPhone;
        private Button btnLogout;

        public AdminForm()
        {
            InitializeComponent();
            _userService = new UserService();

            // This resets the password char to a standard dot and ensures black text
            txtPassword.PasswordChar = '●';
            txtPassword.ForeColor = Color.Black;

            // Initialize improved controls
            InitializeImprovedControls();

            // Add logout button
            InitializeLogoutButton();

            // Load organizers into DataGridView
            LoadOrganizers();
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
            // Replace txtOrganizerId with NumericUpDown
            numOrganizerId = new NumericUpDown
            {
                Location = txtOrganizerId.Location,
                Size = txtOrganizerId.Size,
                Minimum = 1,
                Maximum = 9999,
                Font = txtOrganizerId.Font
            };
            txtOrganizerId.Parent.Controls.Add(numOrganizerId);
            txtOrganizerId.Visible = false;

            // Replace txtPhone with MaskedTextBox for phone format
            mtbPhone = new MaskedTextBox
            {
                Location = txtPhone.Location,
                Size = txtPhone.Size,
                Mask = "0000-0000000",
                Font = txtPhone.Font
            };
            txtPhone.Parent.Controls.Add(mtbPhone);
            txtPhone.Visible = false;
        }

        private void LoadOrganizers()
        {
            guna2DataGridView1.Rows.Clear();
            var organizers = _userService.GetUsersByRole("Organizer");
            foreach (var org in organizers)
            {
                guna2DataGridView1.Rows.Add(org.Id, org.FullName, org.Email, "", "Yes", "");
            }
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Capture data from the textboxes
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = mtbPhone.Text; // Use MaskedTextBox
            string password = txtPassword.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone.Replace("-", "").Trim()) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all registration fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create username from email (part before @)
            string username = email.Split('@')[0];

            // Check if username already exists
            if (_userService.GetUserByUsername(username) != null)
            {
                MessageBox.Show("An organizer with this email already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new organizer user
            var newOrganizer = new User
            {
                Username = username,
                Password = password,
                Role = "Organizer",
                Email = email,
                FullName = fullName
            };

            bool success = _userService.AddUser(newOrganizer);

            if (success)
            {
                MessageBox.Show($"Event Organizer '{fullName}' successfully registered!\n\nLogin credentials:\nUsername: {username}\nPassword: {password}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields and refresh grid
                txtFullName.Clear();
                txtEmail.Clear();
                mtbPhone.Clear();
                txtPassword.Clear();
                LoadOrganizers();
            }
            else
            {
                MessageBox.Show("Failed to register organizer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            int targetId = (int)numOrganizerId.Value;

            // Find the organizer
            var organizer = _userService.GetUserById(targetId);
            if (organizer == null)
            {
                MessageBox.Show("Organizer ID not found in records.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (organizer.Role != "Organizer")
            {
                MessageBox.Show("The specified ID does not belong to an Organizer.", "Invalid Role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm suspension
            var result = MessageBox.Show($"Are you sure you want to suspend organizer '{organizer.FullName}'?\n\nReason: {txtReason.Text}",
                "Confirm Suspension", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = _userService.DeleteUser(targetId);
                if (success)
                {
                    MessageBox.Show($"Organizer '{organizer.FullName}' has been suspended and removed from the system.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields and refresh grid
                    numOrganizerId.Value = 1;
                    txtOrganizerEmail.Clear();
                    txtReason.Clear();
                    LoadOrganizers();
                }
                else
                {
                    MessageBox.Show("Failed to suspend organizer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
