using System.Drawing;
using UniversityEventVolunteerManagement.Services;

namespace UniversityEventVolunteerManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
           
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // These credentials should eventually be checked against your File System
            if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            {
                new AdminForm().Show();
                this.Hide();
            }
            else if (txtUsername.Text == "organizer" && txtPassword.Text == "1234")
            {
                // Opens the Organizer Dashboard you designed
                new OrganizerForm().Show();
                this.Hide();
            }
            else if (txtUsername.Text == "volunteer" && txtPassword.Text == "12345")
            {
                new VolunteerForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Volreg registerScreen = new Volreg();
            registerScreen.Show(); // This opens the new window
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
