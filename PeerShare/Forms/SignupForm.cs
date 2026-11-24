using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PeerShare
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();

            LoadBookImage();
            ApplyRoundedCorners();
        }

        // ==========================================
        // LOAD BOOK IMAGE
        // ==========================================

        private void LoadBookImage()
        {
            string imagePath = Path.Combine(
                Application.StartupPath,
                "Assets",
                "book.png"
            );

            if (File.Exists(imagePath))
            {
                bookPicture.Image = Image.FromFile(imagePath);
            }
        }

        // ==========================================
        // GRADIENT BACKGROUND
        // ==========================================

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                mainPanel.ClientRectangle,
                Color.FromArgb(255, 249, 190),
                Color.FromArgb(255, 155, 232),
                LinearGradientMode.Horizontal))
            {
                ColorBlend blend = new ColorBlend();

                blend.Colors = new Color[]
                {
                    Color.FromArgb(255, 249, 190),
                    Color.FromArgb(255, 207, 200),
                    Color.FromArgb(255, 155, 232)
                };

                blend.Positions = new float[] { 0f, 0.5f, 1f };

                brush.InterpolationColors = blend;

                e.Graphics.FillRectangle(
                    brush,
                    mainPanel.ClientRectangle
                );
            }
        }

        // ==========================================
        // ROUNDED SIGNUP CARD
        // ==========================================

        private void ApplyRoundedCorners()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 25;

                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(
                    signupCard.Width - radius,
                    0,
                    radius,
                    radius,
                    270,
                    90
                );

                path.AddArc(
                    signupCard.Width - radius,
                    signupCard.Height - radius,
                    radius,
                    radius,
                    0,
                    90
                );

                path.AddArc(
                    0,
                    signupCard.Height - radius,
                    radius,
                    radius,
                    90,
                    90
                );

                path.CloseFigure();

                signupCard.Region = new Region(path);
            }
        }

        // ==========================================
        // CREATE ACCOUNT BUTTON
        // ==========================================

        private void signupButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please complete all fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Signup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Signup form completed successfully!",
                "PeerShare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // BACK TO LOGIN
        // ==========================================

        private void loginLink_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = Application.OpenForms
                .OfType<LoginForm>()
                .FirstOrDefault();

            if (loginForm != null)
            {
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
