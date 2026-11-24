using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PeerShare.Services;

namespace PeerShare
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            usernameTextBox.MaxLength = 50;
            emailTextBox.MaxLength = 100;
            currentPasswordTextBox.MaxLength = 128;
            newPasswordTextBox.MaxLength = 128;
            confirmPasswordTextBox.MaxLength = 128;
            passwordOverlayPanel.Visible = false;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                string flowerPath = Application.StartupPath + @"\Assets\flower.png";
                if (System.IO.File.Exists(flowerPath))
                    flowerPictureBox.Image = Image.FromFile(flowerPath);

                ApplyRoundedCorners(profilePagePanel, 20);
                ApplyRoundedCorners(profileCard, 18);
                ApplyRoundedCorners(profileIconLabel, 25);
                ApplyRoundedCorners(changePasswordButton, 12);
                ApplyRoundedCorners(cancelButton, 12);
                ApplyRoundedCorners(saveChangesButton, 12);
                ConnectEvents();
                Load += (sender, e) => LoadProfile();
            }
        }

        private void ConnectEvents()
        {
            cancelPasswordButton.Click += cancelPasswordButton_Click;
            savePasswordButton.Click += savePasswordButton_Click;
            saveChangesButton.Click += saveChangesButton_Click;
            cancelButton.Click += cancelButton_Click;
            changePasswordButton.Click += changePasswordButton_Click;
        }

        private void LoadProfile()
        {
            try
            {
                string[] profile = ProfileService.GetProfile();
                usernameTextBox.Text = profile[0];
                emailTextBox.Text = profile[1];
                profileNameLabel.Text = profile[0];
                profileRoleLabel.Text = "PeerShare Member";
                SessionService.UpdateProfile(profile[0], profile[1]);
                saveChangesButton.Enabled = true;
                changePasswordButton.Enabled = true;
            }
            catch (Exception ex)
            {
                saveChangesButton.Enabled = false;
                changePasswordButton.Enabled = false;
                MessageBox.Show("Unable to load profile: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveChangesButton.Enabled = false;
                string result = ProfileService.UpdateProfile(
                    usernameTextBox.Text, emailTextBox.Text);
                if (result == "SUCCESS")
                {
                    usernameTextBox.Text = SessionService.Username;
                    emailTextBox.Text = SessionService.Email;
                    profileNameLabel.Text = SessionService.Username;
                    MessageBox.Show("Profile updated successfully!", "Profile Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(result, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update profile: " + ex.Message,
                    "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { saveChangesButton.Enabled = true; }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ClearPasswordFields();
            passwordOverlayPanel.Visible = true;
            passwordOverlayPanel.BringToFront();
            currentPasswordTextBox.Focus();
        }

        private void cancelPasswordButton_Click(object sender, EventArgs e)
        {
            ClearPasswordFields();
            passwordOverlayPanel.Visible = false;
        }

        private void savePasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                savePasswordButton.Enabled = false;
                string result = ProfileService.ChangePassword(currentPasswordTextBox.Text,
                    newPasswordTextBox.Text, confirmPasswordTextBox.Text);
                if (result == "SUCCESS")
                {
                    ClearPasswordFields();
                    passwordOverlayPanel.Visible = false;
                    MessageBox.Show("Password changed successfully!", "Password Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(result, "Password Change Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to change password: " + ex.Message,
                    "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { savePasswordButton.Enabled = true; }
        }

        private void ClearPasswordFields()
        {
            currentPasswordTextBox.Clear();
            newPasswordTextBox.Clear();
            confirmPasswordTextBox.Clear();
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int diameter = radius * 2;
                Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();
                control.Region = new Region(path);
            }
        }
    }
}
