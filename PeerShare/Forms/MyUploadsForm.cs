
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PeerShare
{
    public partial class MyUploadsForm : Form
    {
        // ==========================================
        // 1. SAMPLE UPLOAD DATA
        // ==========================================

        private List<string[]> myUploadsData = new List<string[]>();

        public MyUploadsForm()
        {
            InitializeComponent();

            flowerPictureBox.Image = Image.FromFile(
                Application.StartupPath + @"\Assets\flower.png"
            );

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ApplyRoundedCorners(myUploadsPagePanel, 20);
            }

            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor, true
            );

            this.BackColor = Color.Transparent;

            LoadSampleUploads();
            ConnectEvents();
            DisplayUploads(myUploadsData);
        }

        // ==========================================
        // 2. LOAD SAMPLE UPLOADS
        // ==========================================

        private void LoadSampleUploads()
        {
            myUploadsData.Add(new string[]
            {
                "Introduction to C#.pdf",
                "Programming",
                "Nov 20, 2026",
                "Available"
            });

            myUploadsData.Add(new string[]
            {
                "Database Normalization.docx",
                "Database Management",
                "Nov 19, 2026",
                "Available"
            });

            myUploadsData.Add(new string[]
            {
                "OSI Model.pptx",
                "Networking",
                "Nov 18, 2026",
                "Available"
            });

            myUploadsData.Add(new string[]
            {
                "HTML and CSS Notes.pdf",
                "Web Development",
                "Nov 17, 2026",
                "Available"
            });

            myUploadsData.Add(new string[]
            {
                "System Analysis Reviewer.pdf",
                "Information Systems",
                "Nov 16, 2026",
                "Available"
            });
        }

        // ==========================================
        // 3. CONNECT EVENTS
        // ==========================================

        private void ConnectEvents()
        {
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            subjectFilterComboBox.SelectedIndexChanged += subjectFilterComboBox_SelectedIndexChanged;

            viewResourceButton.Click += viewResourceButton_Click;
            deleteButton.Click += deleteButton_Click;
        }

        // ==========================================
        // 4. DISPLAY UPLOADS
        // ==========================================

        private void DisplayUploads(List<string[]> uploads)
        {
            myUploadsListView.Items.Clear();

            foreach (string[] upload in uploads)
            {
                ListViewItem item = new ListViewItem(upload[0]);

                item.SubItems.Add(upload[1]);
                item.SubItems.Add(upload[2]);
                item.SubItems.Add(upload[3]);

                item.Tag = upload;

                myUploadsListView.Items.Add(item);
            }

            myUploadsCountLabel.Text = "My Resources (" + uploads.Count + ")";
        }

        // ==========================================
        // 5. SEARCH AND FILTER
        // ==========================================

        private void FilterUploads()
        {
            string searchText = searchTextBox.Text.Trim().ToLower();

            string selectedSubject = subjectFilterComboBox.SelectedItem == null
                ? "All Subjects"
                : subjectFilterComboBox.SelectedItem.ToString();

            List<string[]> filteredUploads = myUploadsData
                .Where(upload =>
                    (upload[0].ToLower().Contains(searchText) ||
                     upload[1].ToLower().Contains(searchText)) &&
                    (selectedSubject == "All Subjects" ||
                     upload[1] == selectedSubject))
                .ToList();

            DisplayUploads(filteredUploads);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterUploads();
        }

        private void subjectFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterUploads();
        }

        // ==========================================
        // 6. VIEW RESOURCE
        // ==========================================

        private void viewResourceButton_Click(object sender, EventArgs e)
        {
            if (myUploadsListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Please select a resource first.",
                    "No Resource Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            string[] upload = myUploadsListView.SelectedItems[0].Tag as string[];

            MessageBox.Show(
                "Resource: " + upload[0] +
                "\nSubject: " + upload[1] +
                "\nDate Uploaded: " + upload[2] +
                "\nStatus: " + upload[3],
                "Resource Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // 7. DELETE RESOURCE
        // ==========================================

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (myUploadsListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Please select a resource to delete.",
                    "No Resource Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this resource?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string[] selectedUpload =
                    myUploadsListView.SelectedItems[0].Tag as string[];

                myUploadsData.Remove(selectedUpload);

                FilterUploads();
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
