using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UniversityEventVolunteerManagement
{
    public partial class Volreg : Form
    {
        public Volreg()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string volunteerName = txtFullName.Text;
            MessageBox.Show("Success! Volunteer " + volunteerName + " has been recorded.");
        }

        private void lnklogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginScreen = new LoginForm();
            loginScreen.Show();
            this.Close();
        }
    }
}
