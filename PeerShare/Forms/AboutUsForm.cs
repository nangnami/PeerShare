
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PeerShare
{
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();

            flowerPictureBox.Image = Image.FromFile(
                Application.StartupPath + @"\Assets\flower.png"
            );

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ApplyRoundedCorners(aboutPagePanel, 20);
            }

            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor, true
            );

            this.BackColor = Color.Transparent;
        }

        // ROUNDED CORNERS HELPER
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
