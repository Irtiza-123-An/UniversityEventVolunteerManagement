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

namespace UniversityEventVolunteerManagement
{
    public partial class OrganizerForm : Form
    {
        public OrganizerForm()
        {
            InitializeComponent();
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            // Validates that both IDs are provided
            if (string.IsNullOrWhiteSpace(txtAssignTaskId.Text) || string.IsNullOrWhiteSpace(txtVolunteerId.Text))
            {
                MessageBox.Show("Please enter both Task ID and Volunteer ID.");
                return;
            }

            string assignment = $"{txtAssignTaskId.Text},{txtVolunteerId.Text},{DateTime.Now}";
            File.AppendAllText("Assignments.txt", assignment + Environment.NewLine);

            MessageBox.Show($"Task {txtAssignTaskId.Text} assigned to Volunteer {txtVolunteerId.Text}");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string taskData = $"{txtTaskId.Text},{txtDescription.Text},{txtDueDate.Text},{txtPriority.Text},Pending";

                // Append to Tasks.txt (The File System storage)
                File.AppendAllText("Tasks.txt", taskData + Environment.NewLine);

                MessageBox.Show("Task successfully created in system.", "Success");

                // Clear fields
                txtTaskId.Clear();
                txtDescription.Clear();
                txtDueDate.Clear();
                txtPriority.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Error: " + ex.Message);
            }
        }
    }
}
