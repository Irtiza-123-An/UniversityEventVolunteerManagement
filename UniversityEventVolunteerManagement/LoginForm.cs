using System.Drawing;
using UniversityEventVolunteerManagement.Services;
using UniversityEventVolunteerManagement.Backend.Services;
using BackendUserService = UniversityEventVolunteerManagement.Backend.Services.UserService;

namespace UniversityEventVolunteerManagement
{
    public partial class LoginForm : Form
    {
        private readonly BackendUserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _userService = new BackendUserService();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Authenticate using backend service
            var user = _userService.Login(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid Login Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Route to appropriate form based on role
            Form nextForm;
            switch (user.Role)
            {
                case "Admin":
                    nextForm = new AdminForm();
                    break;
                case "Organizer":
                    nextForm = new OrganizerForm();
                    break;
                case "Volunteer":
                    nextForm = new VolunteerForm();
                    break;
                default:
                    MessageBox.Show("Invalid user role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            nextForm.FormClosed += (s, args) => this.Show();
            nextForm.Show();
            this.Hide();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Volreg registerScreen = new Volreg();
            registerScreen.FormClosed += (s, args) => this.Show();
            registerScreen.Show();
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
