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
            btnOrganizerSuspend.Click += btnOrganizerSuspend_Click;
            btnVolunteerSuspend.Click += btnVolunteerSuspend_Click_1;
            btnStudentSuspend.Click += btnStudentSuspend_Click_1;

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
            string phone = txtPhoneNumber.Text;       // Eo_phone
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
                txtPhoneNumber.Clear();
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

        private void txtStudentSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdminLogout_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // 2. Create an instance of your Login Form
                // Ensure LoginForm.cs exists in your Solution Explorer
                LoginForm login = new LoginForm();

                // 3. Show the login screen and close/hide this admin dashboard
                login.Show();
                this.Close(); // Use .Close() to fully release the AdminForm memory
            }
        }

        private void btnOrganizerSuspend_Click(object sender, EventArgs e)
        {
            // 1. Get the ID from the specific textbox in your design
            string targetId = txtOrganizerId.Text.Trim();
            string filePath = "Organizers.txt";

            if (string.IsNullOrEmpty(targetId))
            {
                MessageBox.Show("Please enter an Organizer ID to suspend.");
                return;
            }

            try
            {
                if (File.Exists(filePath))
                {
                    // 2. Read all lines from the text file
                    List<string> allOrganizers = File.ReadAllLines(filePath).ToList();
                    List<string> remainingOrganizers = new List<string>();
                    bool isFound = false;

                    foreach (string line in allOrganizers)
                    {
                        // Splitting by comma as per your record format
                        string[] data = line.Split(',');

                        if (data.Length > 0 && data[0] == targetId)
                        {
                            isFound = true;
                            // By skipping this line, we effectively "Suspend" (delete) them
                            continue;
                        }
                        remainingOrganizers.Add(line);
                    }

                    if (isFound)
                    {
                        // 3. Write the cleaned list back to the file
                        File.WriteAllLines(filePath, remainingOrganizers);
                        MessageBox.Show($"Organizer with ID {targetId} has been successfully suspended.");

                        // 4. Clear the ID field
                        txtOrganizerId.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Organizer ID not found in the database.");
                    }
                }
                else
                {
                    MessageBox.Show("Database file (Organizers.txt) not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnVolunteerSuspend_Click(object sender, EventArgs e)
        {

        }

        private void btnStudentSuspend_Click(object sender, EventArgs e)
        {

        }

        private void btnVolunteerSuspend_Click_1(object sender, EventArgs e)
        {
            // 1. Get ID from your Student/Volunteer ID textbox
            string targetId = txtVolunteerId.Text.Trim();
            string filePath = "Volunteers.txt";

            if (string.IsNullOrEmpty(targetId))
            {
                MessageBox.Show("Please enter a Volunteer ID.");
                return;
            }

            try
            {
                if (File.Exists(filePath)) // If this is false, the button "does nothing"
                {
                    List<string> lines = File.ReadAllLines(filePath).ToList();
                    List<string> remainingVolunteers = new List<string>();
                    bool found = false;

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        if (data.Length > 0 && data[0] == targetId)
                        {
                            found = true;
                            continue;
                        }
                        remainingVolunteers.Add(line); // MUST be inside this bracket!
                    }

                    if (found)
                    {
                        File.WriteAllLines(filePath, remainingVolunteers);
                        MessageBox.Show($"Volunteer {targetId} suspended!");
                    }
                    else
                    {
                        MessageBox.Show("ID not found in the file.");
                    }
                }
                else
                {
                    // THIS will tell you why it "stops working"
                    MessageBox.Show("ERROR: Volunteers.txt not found in Debug folder!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Crash error: " + ex.Message);
            }
        }

        private void btnStudentSuspend_Click_1(object sender, EventArgs e)
        {
            // 1. Get Student ID from the UI
            string targetId = txtStudentId.Text.Trim();
            string filePath = "Students.txt";

            if (string.IsNullOrEmpty(targetId))
            {
                MessageBox.Show("Please enter a Student ID to suspend.");
                return;
            }

            try
            {
                if (File.Exists(filePath))
                {
                    // 2. Read and filter the student list
                    List<string> lines = File.ReadAllLines(filePath).ToList();
                    List<string> remainingStudents = new List<string>();
                    bool found = false;

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        // Check if ID matches first column
                        if (data.Length > 0 && data[0] == targetId)
                        {
                            found = true;
                            continue; // Skip this student to "suspend" them
                        }
                        remainingStudents.Add(line); // Ensure this is INSIDE the loop!
                    }

                    if (found)
                    {
                        File.WriteAllLines(filePath, remainingStudents);
                        MessageBox.Show($"Student {targetId} suspended successfully.");
                        txtStudentId.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Student ID not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnOrganizerSearch_Click(object sender, EventArgs e)
        {
            string targetId = txtOrganizerSearch.Text.Trim();
            string filePath = "Organizers.txt"; // From your Debug folder

            // Clear the grid before showing new results
            guna2DataGridView1.Rows.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    // If search is empty, show all. If ID matches, show that specific one.
                    if (string.IsNullOrEmpty(targetId) || data[0] == targetId)
                    {
                        // Ensure indices match your Columns: ID, Name, Email, Phone, Status
                        guna2DataGridView1.Rows.Add(data[0], data[1], data[2], data[3], data[4]);
                        found = true;
                    }
                }

                if (!found) MessageBox.Show("No matching Organizer found.");
            }
            else
            {
                MessageBox.Show("Organizer database file missing.");
            }
        }

        private void btnVolunteerSearch_Click(object sender, EventArgs e)
        {
            string targetId = txtOrganizerSearch.Text.Trim();
            string filePath = "Organizers.txt"; // From your Debug folder

            // Clear the grid before showing new results
            guna2DataGridView1.Rows.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    // If search is empty, show all. If ID matches, show that specific one.
                    if (string.IsNullOrEmpty(targetId) || data[0] == targetId)
                    {
                        // Ensure indices match your Columns: ID, Name, Email, Phone, Status
                        guna2DataGridView1.Rows.Add(data[0], data[1], data[2], data[3], data[4]);
                        found = true;
                    }
                }

                if (!found) MessageBox.Show("No matching Organizer found.");
            }
            else
            {
                MessageBox.Show("Organizer database file missing.");
            }
        }

        private void btnStudentSearch_Click(object sender, EventArgs e)
        {
            string targetId = txtOrganizerSearch.Text.Trim();
            string filePath = "Organizers.txt"; // From your Debug folder

            // Clear the grid before showing new results
            guna2DataGridView1.Rows.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    // If search is empty, show all. If ID matches, show that specific one.
                    if (string.IsNullOrEmpty(targetId) || data[0] == targetId)
                    {
                        // Ensure indices match your Columns: ID, Name, Email, Phone, Status
                        guna2DataGridView1.Rows.Add(data[0], data[1], data[2], data[3], data[4]);
                        found = true;
                    }
                }

                if (!found) MessageBox.Show("No matching Organizer found.");
            }
            else
            {
                MessageBox.Show("Organizer database file missing.");
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtVolunteerReason_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
