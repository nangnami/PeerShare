
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeerShare
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel profilePagePanel;
        private Label profileTitleLabel;
        private Label profileSubtitleLabel;

        private Panel profileCard;
        private Label profileIconLabel;
        private Label profileNameLabel;
        private Label profileRoleLabel;

        private Label personalInfoLabel;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label fullNameLabel;
        private TextBox fullNameTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;

        private Label securityLabel;
        private Button changePasswordButton;
        private Button saveChangesButton;
        private Button cancelButton;

        private PictureBox flowerPictureBox;

        // CHANGE PASSWORD OVERLAY
        private Panel passwordOverlayPanel;
        private Panel passwordDialogPanel;
        private Label passwordTitleLabel;
        private Label passwordSubtitleLabel;

        private Label currentPasswordLabel;
        private TextBox currentPasswordTextBox;

        private Label newPasswordLabel;
        private TextBox newPasswordTextBox;

        private Label confirmPasswordLabel;
        private TextBox confirmPasswordTextBox;

        private Button cancelPasswordButton;
        private Button savePasswordButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.profilePagePanel = new Panel();
            this.profileTitleLabel = new Label();
            this.profileSubtitleLabel = new Label();

            this.profileCard = new Panel();
            this.profileIconLabel = new Label();
            this.profileNameLabel = new Label();
            this.profileRoleLabel = new Label();

            this.personalInfoLabel = new Label();
            this.usernameLabel = new Label();
            this.usernameTextBox = new TextBox();
            this.fullNameLabel = new Label();
            this.fullNameTextBox = new TextBox();
            this.emailLabel = new Label();
            this.emailTextBox = new TextBox();

            this.securityLabel = new Label();
            this.changePasswordButton = new Button();
            this.saveChangesButton = new Button();
            this.cancelButton = new Button();

            this.flowerPictureBox = new PictureBox();

            // PASSWORD DIALOG CONTROLS
            this.passwordOverlayPanel = new Panel();
            this.passwordDialogPanel = new Panel();
            this.passwordTitleLabel = new Label();
            this.passwordSubtitleLabel = new Label();

            this.currentPasswordLabel = new Label();
            this.currentPasswordTextBox = new TextBox();

            this.newPasswordLabel = new Label();
            this.newPasswordTextBox = new TextBox();

            this.confirmPasswordLabel = new Label();
            this.confirmPasswordTextBox = new TextBox();

            this.cancelPasswordButton = new Button();
            this.savePasswordButton = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.flowerPictureBox)).BeginInit();

            this.profilePagePanel.SuspendLayout();
            this.profileCard.SuspendLayout();
            this.passwordOverlayPanel.SuspendLayout();
            this.passwordDialogPanel.SuspendLayout();
            this.SuspendLayout();

            // PROFILE PAGE PANEL
            this.profilePagePanel.BackColor = Color.FromArgb(255, 249, 217);
            this.profilePagePanel.Location = new Point(25, 20);
            this.profilePagePanel.Name = "profilePagePanel";
            this.profilePagePanel.Size = new Size(660, 535);

            // PROFILE TITLE
            this.profileTitleLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            this.profileTitleLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.profileTitleLabel.Location = new Point(30, 25);
            this.profileTitleLabel.Size = new Size(360, 38);
            this.profileTitleLabel.Text = "My Profile ♡";

            // PROFILE SUBTITLE
            this.profileSubtitleLabel.Font = new Font("Segoe UI", 9F);
            this.profileSubtitleLabel.ForeColor = Color.FromArgb(145, 128, 145);
            this.profileSubtitleLabel.Location = new Point(32, 65);
            this.profileSubtitleLabel.Size = new Size(360, 25);
            this.profileSubtitleLabel.Text = "Manage your PeerShare account.";

            // FLOWER DECORATION
            this.flowerPictureBox.BackColor = Color.Transparent;
            this.flowerPictureBox.Location = new Point(410, 20);
            this.flowerPictureBox.Size = new Size(225, 70);
            this.flowerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.flowerPictureBox.TabStop = false;

            // PROFILE CARD
            this.profileCard.BackColor = Color.FromArgb(250, 230, 240);
            this.profileCard.Location = new Point(35, 105);
            this.profileCard.Size = new Size(590, 85);

            // PROFILE ICON
            this.profileIconLabel.BackColor = Color.FromArgb(246, 228, 244);
            this.profileIconLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            this.profileIconLabel.ForeColor = Color.FromArgb(155, 105, 151);
            this.profileIconLabel.Location = new Point(20, 17);
            this.profileIconLabel.Size = new Size(50, 50);
            this.profileIconLabel.Text = "♡";
            this.profileIconLabel.TextAlign = ContentAlignment.MiddleCenter;

            // PROFILE NAME
            this.profileNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.profileNameLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.profileNameLabel.Location = new Point(85, 17);
            this.profileNameLabel.Size = new Size(300, 27);
            this.profileNameLabel.Text = "Student Name";

            // PROFILE ROLE
            this.profileRoleLabel.Font = new Font("Segoe UI", 8.5F);
            this.profileRoleLabel.ForeColor = Color.FromArgb(145, 128, 145);
            this.profileRoleLabel.Location = new Point(87, 45);
            this.profileRoleLabel.Size = new Size(250, 20);
            this.profileRoleLabel.Text = "PeerShare Member";

            // PERSONAL INFORMATION
            this.personalInfoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.personalInfoLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.personalInfoLabel.Location = new Point(35, 210);
            this.personalInfoLabel.Size = new Size(300, 28);
            this.personalInfoLabel.Text = "Personal Information";

            // USERNAME
            this.usernameLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.usernameLabel.ForeColor = Color.FromArgb(105, 76, 130);
            this.usernameLabel.Location = new Point(35, 248);
            this.usernameLabel.Size = new Size(250, 20);
            this.usernameLabel.Text = "Username";

            this.usernameTextBox.Font = new Font("Segoe UI", 9F);
            this.usernameTextBox.Location = new Point(35, 270);
            this.usernameTextBox.Size = new Size(280, 30);
            this.usernameTextBox.BorderStyle = BorderStyle.FixedSingle;

            // FULL NAME
            this.fullNameLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.fullNameLabel.ForeColor = Color.FromArgb(105, 76, 130);
            this.fullNameLabel.Location = new Point(345, 248);
            this.fullNameLabel.Size = new Size(250, 20);
            this.fullNameLabel.Text = "Full Name";

            this.fullNameTextBox.Font = new Font("Segoe UI", 9F);
            this.fullNameTextBox.Location = new Point(345, 270);
            this.fullNameTextBox.Size = new Size(280, 30);
            this.fullNameTextBox.BorderStyle = BorderStyle.FixedSingle;

            // EMAIL ADDRESS
            this.emailLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.emailLabel.ForeColor = Color.FromArgb(105, 76, 130);
            this.emailLabel.Location = new Point(35, 315);
            this.emailLabel.Size = new Size(250, 20);
            this.emailLabel.Text = "Email Address";

            this.emailTextBox.Font = new Font("Segoe UI", 9F);
            this.emailTextBox.Location = new Point(35, 337);
            this.emailTextBox.Size = new Size(590, 30);
            this.emailTextBox.BorderStyle = BorderStyle.FixedSingle;

            // ACCOUNT SECURITY
            this.securityLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.securityLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.securityLabel.Location = new Point(35, 385);
            this.securityLabel.Size = new Size(300, 28);
            this.securityLabel.Text = "Account Security";

            // CHANGE PASSWORD BUTTON
            this.changePasswordButton.BackColor = Color.FromArgb(235, 222, 250);
            this.changePasswordButton.FlatStyle = FlatStyle.Flat;
            this.changePasswordButton.FlatAppearance.BorderSize = 0;
            this.changePasswordButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.changePasswordButton.ForeColor = Color.FromArgb(105, 76, 130);
            this.changePasswordButton.Location = new Point(35, 420);
            this.changePasswordButton.Size = new Size(160, 38);
            this.changePasswordButton.Text = "CHANGE PASSWORD";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            this.changePasswordButton.Cursor = Cursors.Hand;

            // CANCEL PROFILE BUTTON
            this.cancelButton.BackColor = Color.FromArgb(255, 225, 220);
            this.cancelButton.FlatStyle = FlatStyle.Flat;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.cancelButton.ForeColor = Color.FromArgb(155, 83, 91);
            this.cancelButton.Location = new Point(365, 470);
            this.cancelButton.Size = new Size(120, 38);
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Cursor = Cursors.Hand;

            // SAVE PROFILE BUTTON
            this.saveChangesButton.BackColor = Color.FromArgb(235, 222, 250);
            this.saveChangesButton.FlatStyle = FlatStyle.Flat;
            this.saveChangesButton.FlatAppearance.BorderSize = 0;
            this.saveChangesButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.saveChangesButton.ForeColor = Color.FromArgb(105, 76, 130);
            this.saveChangesButton.Location = new Point(495, 470);
            this.saveChangesButton.Size = new Size(130, 38);
            this.saveChangesButton.Text = "SAVE CHANGES ♡";
            this.saveChangesButton.UseVisualStyleBackColor = false;
            this.saveChangesButton.Cursor = Cursors.Hand;

            // ADD PROFILE CONTROLS
            this.profileCard.Controls.Add(this.profileIconLabel);
            this.profileCard.Controls.Add(this.profileNameLabel);
            this.profileCard.Controls.Add(this.profileRoleLabel);

            this.profilePagePanel.Controls.Add(this.profileTitleLabel);
            this.profilePagePanel.Controls.Add(this.profileSubtitleLabel);
            this.profilePagePanel.Controls.Add(this.flowerPictureBox);
            this.profilePagePanel.Controls.Add(this.profileCard);
            this.profilePagePanel.Controls.Add(this.personalInfoLabel);
            this.profilePagePanel.Controls.Add(this.usernameLabel);
            this.profilePagePanel.Controls.Add(this.usernameTextBox);
            this.profilePagePanel.Controls.Add(this.fullNameLabel);
            this.profilePagePanel.Controls.Add(this.fullNameTextBox);
            this.profilePagePanel.Controls.Add(this.emailLabel);
            this.profilePagePanel.Controls.Add(this.emailTextBox);
            this.profilePagePanel.Controls.Add(this.securityLabel);
            this.profilePagePanel.Controls.Add(this.changePasswordButton);
            this.profilePagePanel.Controls.Add(this.cancelButton);
            this.profilePagePanel.Controls.Add(this.saveChangesButton);

            // PASSWORD OVERLAY
            this.passwordOverlayPanel.Name = "passwordOverlayPanel";
            this.passwordOverlayPanel.Dock = DockStyle.Fill;
            this.passwordOverlayPanel.BackColor = Color.FromArgb(150, 255, 192, 218);
            this.passwordOverlayPanel.Visible = false;

            // PASSWORD DIALOG
            this.passwordDialogPanel.Name = "passwordDialogPanel";
            this.passwordDialogPanel.Size = new Size(400, 310);
            this.passwordDialogPanel.Location = new Point(130, 112);
            this.passwordDialogPanel.BackColor = Color.FromArgb(255, 249, 240);

            // PASSWORD TITLE
            this.passwordTitleLabel.Text = "Change Password ♡";
            this.passwordTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.passwordTitleLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.passwordTitleLabel.Location = new Point(25, 20);
            this.passwordTitleLabel.Size = new Size(350, 30);

            // PASSWORD SUBTITLE
            this.passwordSubtitleLabel.Text = "Keep your account secure.";
            this.passwordSubtitleLabel.Font = new Font("Segoe UI", 8.5F);
            this.passwordSubtitleLabel.ForeColor = Color.FromArgb(145, 128, 145);
            this.passwordSubtitleLabel.Location = new Point(28, 52);
            this.passwordSubtitleLabel.Size = new Size(330, 22);

            // CURRENT PASSWORD
            this.currentPasswordLabel.Text = "Current Password";
            this.currentPasswordLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.currentPasswordLabel.ForeColor = Color.FromArgb(105, 76, 130);
            this.currentPasswordLabel.Location = new Point(30, 85);
            this.currentPasswordLabel.Size = new Size(340, 20);

            this.currentPasswordTextBox.Font = new Font("Segoe UI", 9F);
            this.currentPasswordTextBox.Location = new Point(30, 105);
            this.currentPasswordTextBox.Size = new Size(340, 28);
            this.currentPasswordTextBox.UseSystemPasswordChar = true;

            // NEW PASSWORD
            this.newPasswordLabel.Text = "New Password";
            this.newPasswordLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.newPasswordLabel.ForeColor = Color.FromArgb(105, 76, 130);
            this.newPasswordLabel.Location = new Point(30, 145);
            this.newPasswordLabel.Size = new Size(340, 20);

            this.newPasswordTextBox.Font = new Font("Segoe UI", 9F);
            this.newPasswordTextBox.Location = new Point(30, 165);
            this.newPasswordTextBox.Size = new Size(340, 28);
            this.newPasswordTextBox.UseSystemPasswordChar = true;

            // CONFIRM PASSWORD
            this.confirmPasswordLabel.Text = "Confirm New Password";
            this.confirmPasswordLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.confirmPasswordLabel.ForeColor = Color.FromArgb(105, 76, 130);
            this.confirmPasswordLabel.Location = new Point(30, 205);
            this.confirmPasswordLabel.Size = new Size(340, 20);

            this.confirmPasswordTextBox.Font = new Font("Segoe UI", 9F);
            this.confirmPasswordTextBox.Location = new Point(30, 225);
            this.confirmPasswordTextBox.Size = new Size(340, 28);
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;

            // CANCEL PASSWORD BUTTON
            this.cancelPasswordButton.Text = "CANCEL";
            this.cancelPasswordButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.cancelPasswordButton.BackColor = Color.FromArgb(255, 207, 200);
            this.cancelPasswordButton.ForeColor = Color.FromArgb(125, 55, 85);
            this.cancelPasswordButton.FlatStyle = FlatStyle.Flat;
            this.cancelPasswordButton.FlatAppearance.BorderSize = 0;
            this.cancelPasswordButton.Location = new Point(30, 265);
            this.cancelPasswordButton.Size = new Size(120, 32);
            this.cancelPasswordButton.Cursor = Cursors.Hand;

            // SAVE PASSWORD BUTTON
            this.savePasswordButton.Text = "SAVE PASSWORD";
            this.savePasswordButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.savePasswordButton.BackColor = Color.FromArgb(235, 222, 250);
            this.savePasswordButton.ForeColor = Color.FromArgb(105, 76, 130);
            this.savePasswordButton.FlatStyle = FlatStyle.Flat;
            this.savePasswordButton.FlatAppearance.BorderSize = 0;
            this.savePasswordButton.Location = new Point(220, 265);
            this.savePasswordButton.Size = new Size(150, 32);
            this.savePasswordButton.Cursor = Cursors.Hand;

            // ADD PASSWORD CONTROLS
            this.passwordDialogPanel.Controls.Add(this.passwordTitleLabel);
            this.passwordDialogPanel.Controls.Add(this.passwordSubtitleLabel);

            this.passwordDialogPanel.Controls.Add(this.currentPasswordLabel);
            this.passwordDialogPanel.Controls.Add(this.currentPasswordTextBox);

            this.passwordDialogPanel.Controls.Add(this.newPasswordLabel);
            this.passwordDialogPanel.Controls.Add(this.newPasswordTextBox);

            this.passwordDialogPanel.Controls.Add(this.confirmPasswordLabel);
            this.passwordDialogPanel.Controls.Add(this.confirmPasswordTextBox);

            this.passwordDialogPanel.Controls.Add(this.cancelPasswordButton);
            this.passwordDialogPanel.Controls.Add(this.savePasswordButton);

            this.passwordOverlayPanel.Controls.Add(this.passwordDialogPanel);

            // ROUNDED DIALOG
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 20;
                int diameter = radius * 2;

                Rectangle bounds = new Rectangle(
                    0, 0,
                    this.passwordDialogPanel.Width,
                    this.passwordDialogPanel.Height
                );

                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                this.passwordDialogPanel.Region = new Region(path);
            }

            // ADD OVERLAY TO FORM
            this.profilePagePanel.Controls.Add(this.passwordOverlayPanel);
            this.passwordOverlayPanel.BringToFront();

            // PROFILE FORM
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(255, 249, 240);
            this.ClientSize = new Size(710, 580);
            this.Controls.Add(this.profilePagePanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ProfileForm";
            this.Text = "My Profile";

            ((System.ComponentModel.ISupportInitialize)(this.flowerPictureBox)).EndInit();

            this.passwordDialogPanel.ResumeLayout(false);
            this.passwordOverlayPanel.ResumeLayout(false);
            this.profileCard.ResumeLayout(false);
            this.profilePagePanel.ResumeLayout(false);
            this.profilePagePanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
