using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PeerShare.Services;

namespace PeerShare
{
    public partial class UploadForm : Form
    {
        private readonly List<string> selectedFilePaths = new List<string>();

        public UploadForm()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            flowerPictureBox.Image = Image.FromFile(
                Path.Combine(Application.StartupPath, "Assets", "flower.png"));
            ApplyRoundedCorners(uploadPagePanel, 20);
            ApplyRoundedCorners(uploadButton, 12);
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            browseButton.Click += browseButton_Click;
            uploadButton.Click += uploadButton_Click;
            removeFileButton.Click += removeFileButton_Click;
            Load += (sender, e) => LoadSubjects();
            RefreshSelectedFiles();
        }

        private void LoadSubjects()
        {
            try
            {
                subjectComboBox.DisplayMember = "SubjectName";
                subjectComboBox.ValueMember = "SubjectId";
                subjectComboBox.DataSource = ResourceService.GetSubjects();
                subjectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                subjectComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load subjects: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Learning Resources";
                dialog.Filter = "Supported Files|*.pdf;*.doc;*.docx;*.ppt;*.pptx";
                dialog.Multiselect = true;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                foreach (string path in dialog.FileNames)
                    if (!selectedFilePaths.Contains(path, StringComparer.OrdinalIgnoreCase))
                        selectedFilePaths.Add(path);
                RefreshSelectedFiles();
            }
        }

        private void removeFileButton_Click(object sender, EventArgs e)
        {
            foreach (int index in selectedFilesListBox.SelectedIndices.Cast<int>()
                .OrderByDescending(i => i).ToArray())
                selectedFilePaths.RemoveAt(index);
            RefreshSelectedFiles();
        }

        private void RefreshSelectedFiles()
        {
            selectedFilesListBox.Items.Clear();
            foreach (string path in selectedFilePaths)
                selectedFilesListBox.Items.Add(Path.GetFileName(path));
            int count = selectedFilePaths.Count;
            selectedFileLabel.Text = count == 0 ? "No files selected" : count + " file(s) selected";
            selectedFileLabel.ForeColor = count == 0 ? Color.Gray : Color.FromArgb(125, 55, 85);
            uploadButton.Text = count == 0 ? "Upload Resources" : "Upload " + count + " File(s)";
            removeFileButton.Enabled = count > 0;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            string title = resourceTitleTextBox.Text.Trim();
            string description = descriptionRichTextBox.Text.Trim();
            if (title.Length == 0) { MessageBox.Show("Please enter the resource title."); return; }
            if (!(subjectComboBox.SelectedValue is int)) { MessageBox.Show("Please select a subject."); return; }
            if (description.Length == 0) { MessageBox.Show("Please enter a description."); return; }
            if (selectedFilePaths.Count == 0) { MessageBox.Show("Please select files to upload."); return; }
            int subjectId = (int)subjectComboBox.SelectedValue;
            string[] paths = selectedFilePaths.ToArray();
            try
            {
                uploadPagePanel.Enabled = false;
                string result = ResourceService.UploadResources(title, subjectId, description, paths);
                if (result == "SUCCESS")
                {
                    MessageBox.Show(paths.Length + " file(s) uploaded successfully!", "Upload Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resourceTitleTextBox.Clear();
                    descriptionRichTextBox.Clear();
                    subjectComboBox.SelectedIndex = -1;
                    selectedFilePaths.Clear();
                    RefreshSelectedFiles();
                }
                else MessageBox.Show(result, "Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed: " + ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { uploadPagePanel.Enabled = true; }
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            using (var path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(control.Width - d, 0, d, d, 270, 90);
                path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
                path.AddArc(0, control.Height - d, d, d, 90, 90);
                path.CloseFigure();
                control.Region = new Region(path);
            }
        }
    }
}
