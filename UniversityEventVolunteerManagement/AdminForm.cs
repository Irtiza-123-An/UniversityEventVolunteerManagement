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
using System.Collections.Generic;

namespace UniversityEventVolunteerManagement
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            // This resets the password char to a standard dot and ensures black text
            txtPassword.PasswordChar = '●';
            txtPassword.ForeColor = Color.Black;
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Capture data from the textboxes in your Designer
            string fullName = txtFullName.Text; // Maps to Username or Eo_id context
            string email = txtEmail.Text;       // Eo_email
            string phone = txtPhone.Text;       // Eo_phone
            string password = txtPassword.Text; // Eo_pass

            // Simple validation to ensure no empty fields
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all registration fields.");
                return;
            }

            // Format the data line according to your Normalization table
            string organizerRecord = $"{fullName},{email},{phone},{password}";

            try
            {
                // Save to the text file acting as your database
                string filePath = "Organizers.txt";
                File.AppendAllText(filePath, organizerRecord + Environment.NewLine);

                MessageBox.Show("Event Organizer successfully registered!");

                // Clear fields after successful save
                txtFullName.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            // 1. Get the ID and Email from your textboxes
            string targetId = txtOrganizerId.Text;
            string targetEmail = txtEmail.Text;
            string filePath = "Organizers.txt";

            if (string.IsNullOrWhiteSpace(targetId))
            {
                MessageBox.Show("Please enter an Organizer ID to suspend.");
                return;
            }

            try
            {
                if (File.Exists(filePath))
                {
                    // 2. Read all current organizers
                    List<string> lines = File.ReadAllLines(filePath).ToList();
                    List<string> updatedLines = new List<string>();
                    bool found = false;

                    foreach (string line in lines)
                    {
                        // Assuming data format: ID,Email,Phone,Password
                        string[] parts = line.Split(',');

                        if (parts[0] == targetId)
                        {
                            found = true;
                            // By not adding this line to updatedLines, we effectively "delete" it
                            continue;
                        }
                        updatedLines.Add(line);
                    }

                    if (found)
                    {
                        // 3. Write the updated list back to the file system
                        File.WriteAllLines(filePath, updatedLines);
                        MessageBox.Show($"Organizer {targetId} has been suspended/removed from the system.");

                        // Clear fields
                        txtOrganizerId.Clear();
                        txtEmail.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Organizer ID not found in records.");
                    }
                }
                else
                {
                    MessageBox.Show("Database file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
