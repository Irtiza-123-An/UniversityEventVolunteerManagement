using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO; // Required for File System operations


namespace UniversityEventVolunteerManagement
{
    public partial class VolunteerForm : Form
    {
        public VolunteerForm()
        {
            InitializeComponent();
        }

        private void VolunteerForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }


        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


private void btnAdd_Click(object sender, EventArgs e)
    {
        // 1. Define the file path
        string filePath = "StudentRecords.txt";

        try
        {
            // 2. Simple Validation: Check if ID and Name are filled
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please fill in the Student ID and Full Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Gather data from all TextBoxes
            string fullName = txtFullName.Text;
            string studentID = txtStudentID.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string semester = txtSemester.Text;
            string dept = txtDepartment.Text; // Changed from ComboBox to TextBox
            string skills = txtSkills.Text;

            // 4. Format the line for the File System (Matches your ER attributes)
            // Format: ID, Name, Phone, Email, Semester, Dept, Skills
            string record = $"{studentID},{fullName},{phone},{email},{semester},{dept},{skills}";

            // 5. Append to the text file
            File.AppendAllText(filePath, record + Environment.NewLine);

            // 6. Notify user
            MessageBox.Show("Student registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 7. Clear the UI
            ClearRegistrationForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Helper method to clear all TextBoxes
    private void ClearRegistrationForm()
    {
        txtFullName.Clear();
        txtStudentID.Clear();
        txtPhoneNumber.Clear();
        txtEmail.Clear();
        txtSemester.Clear();
        txtDepartment.Clear(); // Clears the new Department TextBox
        txtSkills.Clear();
    }
}
}
