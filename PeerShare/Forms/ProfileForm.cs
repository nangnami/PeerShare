
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeerShare
{
    public partial class ProfileForm : Form
    {
        // 1 - CONSTRUCTOR
        public ProfileForm()
        {
            InitializeComponent();

            // SHARED DASHBOARD BACKGROUND
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            // FLOWER DECORATION
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                string flowerPath = Application.StartupPath +
                    @"\Assets\flower.png";

                if (System.IO.File.Exists(flowerPath))
                {
                    flowerPictureBox.Image = Image.FromFile(flowerPath);
                }

                ApplyRoundedCorners(profilePagePanel, 20);
                ApplyRoundedCorners(profileCard, 18);
                ApplyRoundedCorners(profileIconLabel, 25);
                ApplyRoundedCorners(changePasswordButton, 12);
                ApplyRoundedCorners(cancelButton, 12);
                ApplyRoundedCorners(saveChangesButton, 12);
            }

            ConnectEvents();
        }

        // 2 - BUTTON EVENTS
        private void ConnectEvents()
        {
            cancelPasswordButton.Click += cancelPasswordButton_Click;
            savePasswordButton.Click += savePasswordButton_Click;
            saveChangesButton.Click += saveChangesButton_Click;
            cancelButton.Click += cancelButton_Click;
            changePasswordButton.Click += changePasswordButton_Click;
        }

        // 3 - SAVE PROFILE
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(fullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show(
                    "Please complete all personal information fields.",
                    "Incomplete Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Your profile information has been validated.\n\n" +
                "Saving to your account will be available after database integration.",
                "Profile Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            profileNameLabel.Text = fullNameTextBox.Text.Trim();
        }

        // 4 - CANCEL
        private void cancelButton_Click(object sender, EventArgs e)
        {
            usernameTextBox.Clear();
            fullNameTextBox.Clear();
            emailTextBox.Clear();

            MessageBox.Show(
                "Changes have been cleared.",
                "Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // 5 - CHANGE PASSWORD
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            currentPasswordTextBox.Clear();
            newPasswordTextBox.Clear();
            confirmPasswordTextBox.Clear();

            passwordOverlayPanel.Visible = true;
            passwordOverlayPanel.BringToFront();

            currentPasswordTextBox.Focus();
        }

        private void cancelPasswordButton_Click(object sender, EventArgs e)
        {
            passwordOverlayPanel.Visible = false;
        }

        private void savePasswordButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentPasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(newPasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
            {
                MessageBox.Show(
                    "Please complete all password fields.",
                    "Incomplete Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (newPasswordTextBox.Text.Length < 8)
            {
                MessageBox.Show(
                    "Your new password must contain at least 8 characters.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (newPasswordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show(
                    "Your new passwords do not match.",
                    "Password Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Password fields validated successfully.\n\n" +
                "Actual password updating will be connected to the backend.",
                "PeerShare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // 6 - ROUNDED CORNERS
        private void ApplyRoundedCorners(Control control, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int diameter = radius * 2;

                Rectangle bounds = new Rectangle(
                    0, 0,
                    control.Width,
                    control.Height
                );

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
