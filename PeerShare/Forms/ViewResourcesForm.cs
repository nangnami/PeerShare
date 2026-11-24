
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PeerShare
{
    public partial class ViewResourcesForm : Form
    {
        // ==========================================
        // 1. RESOURCE DATA
        // ==========================================

        private List<string[]> resourcesData = new List<string[]>();

        public ViewResourcesForm()
        {
            InitializeComponent();

            flowerPictureBox.Image = Image.FromFile(
                Application.StartupPath + @"\Assets\flower.png"
            );

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ApplyRoundedCorners(resourcesPagePanel, 20);
            }


            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor, true
            );

            this.BackColor = Color.Transparent;

            LoadSampleResources();
            ConnectEvents();
            DisplayResources(resourcesData);
        }

        // ==========================================
        // 2. LOAD SAMPLE RESOURCES
        // ==========================================

        private void LoadSampleResources()
        {
            // Format:
            // Title, Subject, Uploader, Date, Description, File Path

            resourcesData.Add(new string[]
            {
                "Introduction to C# Programming",
                "Programming",
                "Maria Santos",
                "November 20, 2026",
                "A beginner-friendly guide to C# fundamentals.",
                ""
            });

            resourcesData.Add(new string[]
            {
                "Database Normalization Notes",
                "Database Management",
                "John Reyes",
                "November 19, 2026",
                "Study notes covering 1NF, 2NF, and 3NF.",
                ""
            });

            resourcesData.Add(new string[]
            {
                "Computer Networks Reviewer",
                "Networking",
                "Angela Cruz",
                "November 18, 2026",
                "A reviewer covering network concepts and protocols.",
                ""
            });

            resourcesData.Add(new string[]
            {
                "HTML and CSS Fundamentals",
                "Web Development",
                "Mark Dela Torre",
                "November 17, 2026",
                "Learning materials for basic website development.",
                ""
            });

            resourcesData.Add(new string[]
            {
                "Information Systems Overview",
                "Information Management",
                "Sofia Garcia",
                "November 15, 2026",
                "An overview of information systems and their components.",
                ""
            });
        }

        // ==========================================
        // 3. CONNECT EVENTS
        // ==========================================

        private void ConnectEvents()
        {
            resourcesSearchTextBox.TextChanged += resourcesSearchTextBox_TextChanged;

            resourcesSubjectComboBox.SelectedIndexChanged +=
                resourcesSubjectComboBox_SelectedIndexChanged;
        }

        // ==========================================
        // 4. DISPLAY RESOURCE CARDS
        // ==========================================

        private void DisplayResources(List<string[]> resources)
        {
            resourcesFlowPanel.Controls.Clear();

            foreach (string[] resource in resources)
            {
                // RESOURCE CARD
                Panel card = new Panel();

                card.Size = new Size(550, 115);
                card.BackColor = Color.White;
                card.Margin = new Padding(5, 5, 5, 10);

                ApplyRoundedCorners(card, 18);

                // RESOURCE TITLE
                Label titleLabel = new Label();

                titleLabel.Text = resource[0];
                titleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                titleLabel.ForeColor = Color.FromArgb(93, 70, 112);
                titleLabel.Location = new Point(15, 10);
                titleLabel.Size = new Size(400, 25);

                // SUBJECT
                Label subjectLabel = new Label();

                subjectLabel.Text = "Subject: " + resource[1];
                subjectLabel.Font = new Font("Segoe UI", 8.5F);
                subjectLabel.ForeColor = Color.FromArgb(130, 105, 115);
                subjectLabel.Location = new Point(15, 38);
                subjectLabel.Size = new Size(300, 20);

                // UPLOADER
                Label uploaderLabel = new Label();

                uploaderLabel.Text = "Uploaded by: " + resource[2];
                uploaderLabel.Font = new Font("Segoe UI", 8.5F);
                uploaderLabel.ForeColor = Color.Gray;
                uploaderLabel.Location = new Point(15, 60);
                uploaderLabel.Size = new Size(300, 20);

                // DATE
                Label dateLabel = new Label();

                dateLabel.Text = resource[3];
                dateLabel.Font = new Font("Segoe UI", 8F);
                dateLabel.ForeColor = Color.Gray;
                dateLabel.Location = new Point(15, 83);
                dateLabel.Size = new Size(200, 18);

                // DETAILS BUTTON
                Button detailsButton = new Button();

                detailsButton.Text = "Details";
                detailsButton.Size = new Size(85, 30);
                detailsButton.Location = new Point(445, 15);
                detailsButton.BackColor = Color.FromArgb(235, 222, 250);
                detailsButton.ForeColor = Color.FromArgb(105, 76, 130);
                detailsButton.FlatStyle = FlatStyle.Flat;
                detailsButton.FlatAppearance.BorderSize = 0;
                detailsButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                detailsButton.Cursor = Cursors.Hand;
                detailsButton.Tag = resource;

                ApplyRoundedCorners(detailsButton, 10);

                detailsButton.Click += detailsButton_Click;

                // DOWNLOAD BUTTON
                Button downloadButton = new Button();

                downloadButton.Text = "Download";
                downloadButton.Size = new Size(85, 30);
                downloadButton.Location = new Point(445, 57);
                downloadButton.BackColor = Color.FromArgb(255, 207, 200);
                downloadButton.ForeColor = Color.FromArgb(125, 55, 85);
                downloadButton.FlatStyle = FlatStyle.Flat;
                downloadButton.FlatAppearance.BorderSize = 0;
                downloadButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                downloadButton.Cursor = Cursors.Hand;
                downloadButton.Tag = resource;

                ApplyRoundedCorners(downloadButton, 10);

                downloadButton.Click += downloadButton_Click;

                // ADD CONTROLS TO CARD
                card.Controls.Add(titleLabel);
                card.Controls.Add(subjectLabel);
                card.Controls.Add(uploaderLabel);
                card.Controls.Add(dateLabel);
                card.Controls.Add(detailsButton);
                card.Controls.Add(downloadButton);

                resourcesFlowPanel.Controls.Add(card);
            }

            resourcesCountLabel.Text =
                "Available Resources (" + resources.Count + ")";
        }

        // ==========================================
        // 5. SEARCH AND FILTER
        // ==========================================

        private void FilterResources()
        {
            string searchText =
                resourcesSearchTextBox.Text.Trim().ToLower();

            string selectedSubject =
                resourcesSubjectComboBox.SelectedItem == null
                ? "All Subjects"
                : resourcesSubjectComboBox.SelectedItem.ToString();

            List<string[]> filteredResources = resourcesData
                .Where(resource =>
                    (resource[0].ToLower().Contains(searchText) ||
                     resource[1].ToLower().Contains(searchText) ||
                     resource[2].ToLower().Contains(searchText)) &&
                    (selectedSubject == "All Subjects" ||
                     resource[1] == selectedSubject))
                .ToList();

            DisplayResources(filteredResources);
        }

        private void resourcesSearchTextBox_TextChanged(
            object sender, EventArgs e)
        {
            FilterResources();
        }

        private void resourcesSubjectComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            FilterResources();
        }

        // ==========================================
        // 6. RESOURCE DETAILS
        // ==========================================

        private void detailsButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string[] resource = clickedButton.Tag as string[];

            MessageBox.Show(
                "Resource: " + resource[0] +
                "\nSubject: " + resource[1] +
                "\nUploaded By: " + resource[2] +
                "\nDate Uploaded: " + resource[3] +
                "\n\nDescription:\n" + resource[4],
                "Resource Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // 7. DOWNLOAD RESOURCE
        // ==========================================

        private void downloadButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string[] resource = clickedButton.Tag as string[];

            string filePath = resource[5];

            if (string.IsNullOrWhiteSpace(filePath) ||
                !File.Exists(filePath))
            {
                MessageBox.Show(
                    "This resource does not have an attached file yet.",
                    "File Not Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Download Resource";
                saveDialog.FileName = Path.GetFileName(filePath);
                saveDialog.Filter = "All Files (*.*)|*.*";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(filePath, saveDialog.FileName, true);

                        MessageBox.Show(
                            "Resource downloaded successfully!",
                            "Download Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Unable to download the resource.\n\n" + ex.Message,
                            "Download Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
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
