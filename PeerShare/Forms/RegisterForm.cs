
using System;
using System.Windows.Forms;
using PeerShare.Services;

namespace PeerShare
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            btnRegister.Enabled = false;

            try
            {
                string result = AuthService.Register(
                    username, email, password, confirm);

                if (result == "SUCCESS")
                {
                    MessageBox.Show(
                        "Account created successfully! You can now log in.",
                        "Registration Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        result,
                        "Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Registration could not be completed. " +
                    "Please check your database connection.",
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
            }
        }

        private void chkShowPassword_CheckedChanged(
            object sender, EventArgs e)
        {
            bool hidden = !chkShowPassword.Checked;

            txtPassword.UseSystemPasswordChar = hidden;
            txtConfirmPassword.UseSystemPasswordChar = hidden;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
