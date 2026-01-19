
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


        private void btnlogin_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();

            var user = userService.Login(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            MessageBox.Show("Login Successful! Role: " + user.Role);
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
