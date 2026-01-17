
using System.Drawing;
using UniversityEventVolunteerManagement.Services;

namespace UniversityEventVolunteerManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
    }
}
