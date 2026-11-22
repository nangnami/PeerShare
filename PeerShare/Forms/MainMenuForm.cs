
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PeerShare
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm(string username)
        {
            InitializeComponent();

            lblWelcome.Text = "Welcome, " + username + "!";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
