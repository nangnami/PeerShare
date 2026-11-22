
using System;
using System.Windows.Forms;
using PeerShare.Services;

namespace PeerShare
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // LOGIN BUTTON
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(usernameOrEmail) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter your username/email and password.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                var user = AuthService.Login(
                    usernameOrEmail,
                    password
                );

                if (user == null)
                {
                    MessageBox.Show(
                        "Invalid username/email or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                MessageBox.Show(
                    "Login successful! Welcome, " + user.Username + "!",
                    "PeerShare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Open main menu
                this.Hide();

                using (MainMenuForm main =
                    new MainMenuForm(user.Username))
                {
                    main.ShowDialog();
                }

                // Return to login after logout
                txtPassword.Clear();
                this.Show();
                txtUsername.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to connect to PeerShareDB. " +
                    "Please check your SQL Server connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // REGISTER BUTTON
        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm register = new RegisterForm())
            {
                register.ShowDialog(this);
            }
        }

        // SHOW / HIDE PASSWORD
        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }
    }
}
