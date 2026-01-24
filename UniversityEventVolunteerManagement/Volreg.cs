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
    public partial class Volreg : Form
    {
        private readonly UserService _userService;

        // Improved controls
        private MaskedTextBox mtbPhone;

        public Volreg()
        {
            InitializeComponent();
            _userService = new UserService();

            // Initialize improved controls
            InitializeImprovedControls();
        }

        private void InitializeImprovedControls()
        {
            // Replace txtPhoneNumber with MaskedTextBox
            mtbPhone = new MaskedTextBox
            {
                Location = txtPhoneNumber.Location,
                Size = txtPhoneNumber.Size,
                Mask = "0000-0000000",
                Font = txtPhoneNumber.Font
            };
            txtPhoneNumber.Parent.Controls.Add(mtbPhone);
            txtPhoneNumber.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(mtbPhone.Text.Replace("-", "").Trim()) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create username from email (part before @)
            string username = txtEmail.Text.Split('@')[0];

            // Check if username already exists
            if (_userService.GetUserByUsername(username) != null)
            {
                MessageBox.Show("An account with this email already exists. Please login instead.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new volunteer user
            var newVolunteer = new User
            {
                Username = username,
                Password = txtPassword.Text,
                Role = "Volunteer",
                Email = txtEmail.Text,
                FullName = txtFullName.Text
            };

            bool success = _userService.AddUser(newVolunteer);

            if (success)
            {
                MessageBox.Show($"Registration successful!\n\nWelcome, {txtFullName.Text}!\n\nYour login credentials:\nUsername: {username}\nPassword: {txtPassword.Text}\n\nPlease login to continue.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate back to login
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to register. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnklogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
