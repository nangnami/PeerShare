using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PeerShare
{
    public partial class UploadForm : Form
    {
        // ==========================================
        // 1 - VARIABLES
        // ==========================================

        private string selectedFilePath = "";

        public UploadForm()
        {
            InitializeComponent();

            flowerPictureBox.Image = Image.FromFile(
                Application.StartupPath + @"\Assets\flower.png"
            );

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ApplyRoundedCorners(uploadPagePanel, 20);
                ApplyRoundedCorners(uploadButton, 12);
            }

            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor, true
            );

            this.BackColor = Color.Transparent;

            ConnectEvents();
        }

        // ==========================================
        // 2 - CONNECT EVENTS
        // ==========================================

        private void ConnectEvents()
        {
            browseButton.Click += browseButton_Click;
            uploadButton.Click += uploadButton_Click;
        }

        // ==========================================
        // 3 - BROWSE FILE
        // ==========================================

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Learning Resource";

                openFileDialog.Filter =
                    "Supported Files|*.pdf;*.doc;*.docx;*.ppt;*.pptx";

                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;

                    selectedFileLabel.Text =
                        Path.GetFileName(selectedFilePath);

                    selectedFileLabel.ForeColor =
                        Color.FromArgb(125, 55, 85);
                }
            }
        }

        // ==========================================
        // 4 - UPLOAD RESOURCE
        // Temporary message until backend integration.
        // ==========================================

        private void uploadButton_Click(object sender, EventArgs e)
        {
            string resourceTitle = resourceTitleTextBox.Text.Trim();
            string subject = subjectComboBox.Text;
            string description = descriptionRichTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(resourceTitle))
            {
                MessageBox.Show(
                    "Please enter the resource title.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                resourceTitleTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                MessageBox.Show(
                    "Please select a subject.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                subjectComboBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    "Please enter a description.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                descriptionRichTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                MessageBox.Show(
                    "Please select a file to upload.",
                    "No File Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Resource information validated successfully!\n\n" +
                "Title: " + resourceTitle +
                "\nSubject: " + subject +
                "\nFile: " + Path.GetFileName(selectedFilePath) +
                "\n\nActual uploading will be available after backend integration.",
                "Upload Ready",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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