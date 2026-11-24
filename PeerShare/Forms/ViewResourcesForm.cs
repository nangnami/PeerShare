
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using PeerShare.Services;

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

            LoadSubjects();
            LoadResources();
            ConnectEvents();
            DisplayResources(resourcesData);
        }


        private void LoadResources()
        {
            try
            {
                resourcesData =
                    ResourceService.GetAvailableResources();
            }
            catch (Exception ex)
            {
                resourcesData.Clear();

                MessageBox.Show(
                    "Unable to load resources: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                resourcesSubjectComboBox.DataSource = null;
                resourcesSubjectComboBox.Items.Clear();

                resourcesSubjectComboBox.Items.Add("All Subjects");

                foreach (var subject in ResourceService.GetSubjects())
                {
                    resourcesSubjectComboBox.Items.Add(
                        subject.SubjectName);
                }

                resourcesSubjectComboBox.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                resourcesSubjectComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load subjects: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
            while (resourcesFlowPanel.Controls.Count > 0)
            {
                resourcesFlowPanel.Controls[0].Dispose();
            }

            if (resources.Count == 0)
            {
                Label emptyLabel = new Label
                {
                    Text = "No resources found.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Gray,
                    Margin = new Padding(20)
                };

                resourcesFlowPanel.Controls.Add(emptyLabel);
            }

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
                detailsButton.Size = new Size(85, 28);
                detailsButton.Location = new Point(445, 6);
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
                downloadButton.Size = new Size(85, 28);
                downloadButton.Location = new Point(445, 78);
                downloadButton.BackColor = Color.FromArgb(255, 207, 200);
                downloadButton.ForeColor = Color.FromArgb(125, 55, 85);
                downloadButton.FlatStyle = FlatStyle.Flat;
                downloadButton.FlatAppearance.BorderSize = 0;
                downloadButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                downloadButton.Cursor = Cursors.Hand;
                downloadButton.Tag = resource;

                ApplyRoundedCorners(downloadButton, 10);

                downloadButton.Click += downloadButton_Click;

                Button previewButton = new Button
                {
                    Text = "Preview",
                    Size = new Size(85, 28),
                    Location = new Point(445, 42),
                    BackColor = Color.FromArgb(235, 222, 250),
                    ForeColor = Color.FromArgb(105, 76, 130),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Tag = resource
                };
                previewButton.FlatAppearance.BorderSize = 0;
                ApplyRoundedCorners(previewButton, 10);
                previewButton.Click += previewButton_Click;
                card.Controls.Add(previewButton);

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
                resourcesSearchTextBox.Text.Trim().ToLowerInvariant();

            string selectedSubject =
                resourcesSubjectComboBox.SelectedItem == null
                ? "All Subjects"
                : resourcesSubjectComboBox.SelectedItem.ToString();

            List<string[]> filteredResources = resourcesData
                .Where(resource =>
                    (resource[0].ToLowerInvariant().Contains(searchText) ||
                     resource[1].ToLowerInvariant().Contains(searchText) ||
                     resource[2].ToLowerInvariant().Contains(searchText) ||
                     resource[4].ToLowerInvariant().Contains(searchText) ||
                     resource[6].ToLowerInvariant().Contains(searchText))
                    &&
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

            if (clickedButton == null)
                return;

            string[] resource = clickedButton.Tag as string[];

            if (resource == null)
                return;

            int resourceId = int.Parse(resource[5]);
            string fileName = resource[6];

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Download Resource";
                saveDialog.FileName = Path.GetFileName(fileName);
                saveDialog.Filter = "All Files (*.*)|*.*";
                saveDialog.OverwritePrompt = true;

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    clickedButton.Enabled = false;

                    byte[] fileBytes =
                        ResourceService.GetResourceFile(resourceId);

                    File.WriteAllBytes(
                        saveDialog.FileName,
                        fileBytes);

                    try
                    {
                        ResourceService.RecordDownload(resourceId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "File saved, but download history could not be recorded."
                            + "\n\n" + ex.Message,
                            "Download History",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    MessageBox.Show(
                        "Resource downloaded successfully!",
                        "Download Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Unable to download the resource.\n\n"
                        + ex.Message,
                        "Download Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    clickedButton.Enabled = true;
                }
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string[] resource = button == null ? null : button.Tag as string[];
            if (resource == null) return;

            try
            {
                button.Enabled = false;
                byte[] bytes = ResourceService.GetResourceFile(int.Parse(resource[5]));
                using (var preview = new ResourcePreviewForm(resource[6], bytes))
                    preview.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to preview the resource: " + ex.Message,
                    "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { button.Enabled = true; }
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
