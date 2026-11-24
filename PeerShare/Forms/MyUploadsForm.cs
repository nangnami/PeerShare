
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using PeerShare.Services;

namespace PeerShare
{
    public partial class MyUploadsForm : Form
    {
        // ==========================================
        // 1. RESOURCE DATA
        // ==========================================

        private Button editButton;

        private List<string[]> myUploadsData =
            new List<string[]>();

        public MyUploadsForm()
        {
            InitializeComponent();

            flowerPictureBox.Image = Image.FromFile(
                Application.StartupPath + @"\Assets\flower.png"
            );

            if (LicenseManager.UsageMode !=
                LicenseUsageMode.Designtime)
            {
                ApplyRoundedCorners(myUploadsPagePanel, 20);
            }

            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor,
                true
            );

            this.BackColor = Color.Transparent;

            CreateEditButton();
            LoadSubjects();
            LoadMyUploads();
            ConnectEvents();
            DisplayUploads(myUploadsData);
        }

        // ==========================================
        // 2. LOAD SUBJECTS FROM DATABASE
        // ==========================================

        private void CreateEditButton()
        {
            editButton = new Button
            {
                Name = "editButton",
                Text = "Edit Resource",
                Size = viewResourceButton.Size,
                Location = new Point(
                    viewResourceButton.Left - viewResourceButton.Width - 15,
                    viewResourceButton.Top),
                BackColor = viewResourceButton.BackColor,
                ForeColor = viewResourceButton.ForeColor,
                Font = viewResourceButton.Font,
                FlatStyle = FlatStyle.Flat,
                Anchor = viewResourceButton.Anchor,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            editButton.FlatAppearance.BorderSize = 0;
            viewResourceButton.Parent.Controls.Add(editButton);
            editButton.BringToFront();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string[] upload = GetSelectedUpload();
            if (upload == null)
                return;

            int resourceId;
            if (!int.TryParse(upload[4], out resourceId))
            {
                MessageBox.Show("Invalid resource ID.");
                return;
            }

            using (var editForm = new EditResourceForm(
                resourceId, upload[0], upload[1], upload[5], upload[6]))
            {
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadMyUploads();
                    FilterUploads();
                }
            }
        }

        private void LoadSubjects()
        {
            try
            {
                subjectFilterComboBox.DataSource = null;
                subjectFilterComboBox.Items.Clear();

                subjectFilterComboBox.Items.Add("All Subjects");

                foreach (var subject in ResourceService.GetSubjects())
                {
                    subjectFilterComboBox.Items.Add(
                        subject.SubjectName);
                }

                subjectFilterComboBox.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                subjectFilterComboBox.SelectedIndex = 0;
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
        // 3. LOAD MY UPLOADS FROM DATABASE
        // ==========================================

        private void LoadMyUploads()
        {
            try
            {
                myUploadsData =
                    ResourceService.GetMyUploads();
            }
            catch (Exception ex)
            {
                myUploadsData.Clear();

                MessageBox.Show(
                    "Unable to load your resources: " +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 4. CONNECT EVENTS
        // ==========================================

        private void ConnectEvents()
        {
            searchTextBox.TextChanged +=
                searchTextBox_TextChanged;

            subjectFilterComboBox.SelectedIndexChanged +=
                subjectFilterComboBox_SelectedIndexChanged;

            viewResourceButton.Click +=
                viewResourceButton_Click;

            editButton.Click += editButton_Click;

            deleteButton.Click +=
                deleteButton_Click;

            myUploadsListView.SelectedIndexChanged +=
                myUploadsListView_SelectedIndexChanged;

            myUploadsListView.DoubleClick +=
                viewResourceButton_Click;

            myUploadsListView.FullRowSelect = true;
            myUploadsListView.MultiSelect = false;
            myUploadsListView.HideSelection = false;

            UpdateActionButtons();
        }

        // ==========================================
        // 5. DISPLAY UPLOADS
        // ==========================================

        private void DisplayUploads(List<string[]> uploads)
        {
            myUploadsListView.BeginUpdate();

            try
            {
                myUploadsListView.Items.Clear();

                foreach (string[] upload in uploads)
                {
                    ListViewItem item =
                        new ListViewItem(upload[0]);

                    item.SubItems.Add(upload[1]);
                    item.SubItems.Add(upload[2]);
                    item.SubItems.Add(upload[3]);

                    item.Tag = upload;

                    myUploadsListView.Items.Add(item);
                }

                myUploadsCountLabel.Text =
                    "My Resources (" + uploads.Count + ")";
            }
            finally
            {
                myUploadsListView.EndUpdate();
            }

            UpdateActionButtons();
        }

        // ==========================================
        // 6. SEARCH AND FILTER
        // ==========================================

        private void FilterUploads()
        {
            string searchText =
                searchTextBox.Text.Trim().ToLowerInvariant();

            string selectedSubject =
                subjectFilterComboBox.SelectedItem == null
                ? "All Subjects"
                : subjectFilterComboBox.SelectedItem.ToString();

            List<string[]> filteredUploads = myUploadsData
                .Where(upload =>
                    (
                        upload[0].ToLowerInvariant()
                            .Contains(searchText) ||

                        upload[1].ToLowerInvariant()
                            .Contains(searchText) ||

                        upload[5].ToLowerInvariant()
                            .Contains(searchText) ||

                        upload[6].ToLowerInvariant()
                            .Contains(searchText)
                    )
                    &&
                    (
                        selectedSubject == "All Subjects" ||
                        upload[1] == selectedSubject
                    ))
                .ToList();

            DisplayUploads(filteredUploads);
        }

        private void searchTextBox_TextChanged(
            object sender, EventArgs e)
        {
            FilterUploads();
        }

        private void subjectFilterComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            FilterUploads();
        }

        // ==========================================
        // 7. SELECTED RESOURCE
        // ==========================================

        private string[] GetSelectedUpload()
        {
            if (myUploadsListView.SelectedItems.Count == 0)
                return null;

            return myUploadsListView.SelectedItems[0]
                .Tag as string[];
        }

        private void myUploadsListView_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            UpdateActionButtons();
        }

        private void UpdateActionButtons()
        {
            bool hasSelection =
                myUploadsListView.SelectedItems.Count > 0;

            viewResourceButton.Enabled = hasSelection;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
        }

        // ==========================================
        // 8. VIEW RESOURCE DETAILS
        // ==========================================

        private void viewResourceButton_Click(
            object sender, EventArgs e)
        {
            string[] upload = GetSelectedUpload();

            if (upload == null)
            {
                MessageBox.Show(
                    "Please select a resource first.",
                    "No Resource Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            long fileSize;

            long.TryParse(upload[7], out fileSize);

            MessageBox.Show(
                "Resource ID: " + upload[4] +
                "\nTitle: " + upload[0] +
                "\nSubject: " + upload[1] +
                "\nDate Uploaded: " + upload[2] +
                "\nStatus: " + upload[3] +
                "\nFile Name: " + upload[6] +
                "\nFile Size: " + FormatFileSize(fileSize) +
                "\n\nDescription:\n" + upload[5],
                "Resource Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // 9. DELETE RESOURCE
        // ==========================================

        private void deleteButton_Click(
            object sender, EventArgs e)
        {
            string[] selectedUpload = GetSelectedUpload();

            if (selectedUpload == null)
            {
                MessageBox.Show(
                    "Please select a resource to delete.",
                    "No Resource Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Are you sure you want to delete this resource?" +
                "\n\nTitle: " + selectedUpload[0] +
                "\nFile: " + selectedUpload[6] +
                "\n\nThe resource and its download history " +
                "will be permanently deleted.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
                return;

            int resourceId;

            if (!int.TryParse(selectedUpload[4], out resourceId))
            {
                MessageBox.Show("Invalid resource ID.");
                return;
            }

            try
            {
                deleteButton.Enabled = false;

                string result =
                    ResourceService.DeleteResource(resourceId);

                if (result == "SUCCESS")
                {
                    LoadMyUploads();
                    FilterUploads();

                    MessageBox.Show(
                        "Resource deleted successfully!",
                        "Delete Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        result,
                        "Delete Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete resource: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                UpdateActionButtons();
            }
        }

        // ==========================================
        // 10. FORMAT FILE SIZE
        // ==========================================

        private string FormatFileSize(long bytes)
        {
            if (bytes >= 1024 * 1024)
            {
                return (bytes / (1024.0 * 1024.0))
                    .ToString("0.00") + " MB";
            }

            if (bytes >= 1024)
            {
                return (bytes / 1024.0)
                    .ToString("0.00") + " KB";
            }

            return bytes + " bytes";
        }

        // ==========================================
        // 11. ROUNDED CORNERS HELPER
        // ==========================================

        private void ApplyRoundedCorners(
            Control control, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int diameter = radius * 2;

                Rectangle bounds = new Rectangle(
                    0, 0,
                    control.Width,
                    control.Height
                );

                path.AddArc(
                    bounds.X,
                    bounds.Y,
                    diameter,
                    diameter,
                    180, 90);

                path.AddArc(
                    bounds.Right - diameter,
                    bounds.Y,
                    diameter,
                    diameter,
                    270, 90);

                path.AddArc(
                    bounds.Right - diameter,
                    bounds.Bottom - diameter,
                    diameter,
                    diameter,
                    0, 90);

                path.AddArc(
                    bounds.X,
                    bounds.Bottom - diameter,
                    diameter,
                    diameter,
                    90, 90);

                path.CloseFigure();

                control.Region = new Region(path);
            }
        }
    }
}
