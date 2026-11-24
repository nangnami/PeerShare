using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PeerShare
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            LoadBookImage();

            RoundPanelCorners(loginCard, 25);
        }

        // =====================================
        // LOAD BOOK IMAGE
        // =====================================

        private void LoadBookImage()
        {
            string imagePath = Path.Combine(
                Application.StartupPath,
                "Assets",
                "book.png"
            );

            if (File.Exists(imagePath))
            {
                using (Image source = Image.FromFile(imagePath))
                {
                    pictureBoxBook.Image = new Bitmap(source);
                }
            }
            else
            {
                MessageBox.Show(
                    "book.png was not found. Please check your Assets folder.",
                    "Image Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================
        // ROUND PANEL CORNERS
        // =====================================

        private void RoundPanelCorners(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.StartFigure();

            path.AddArc(0, 0, diameter, diameter, 180, 90);

            path.AddArc(
                panel.Width - diameter,
                0,
                diameter,
                diameter,
                270,
                90
            );

            path.AddArc(
                panel.Width - diameter,
                panel.Height - diameter,
                diameter,
                diameter,
                0,
                90
            );

            path.AddArc(
                0,
                panel.Height - diameter,
                diameter,
                diameter,
                90,
                90
            );

            path.CloseFigure();

            panel.Region = new Region(path);
        }

        // =====================================
        // GRADIENT BACKGROUND
        // =====================================

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = mainPanel.ClientRectangle;

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    rect,
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

                blend.Positions = new float[]
                {
                    0F,
                    0.5F,
                    1F
                };

                brush.InterpolationColors = blend;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void linkCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.Show();

            this.Hide();
        }
    }
}
