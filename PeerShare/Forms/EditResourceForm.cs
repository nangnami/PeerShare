
using System;
using System.Drawing;
using System.Windows.Forms;
using PeerShare.Services;

namespace PeerShare
{
    public partial class EditResourceForm : Form
    {
        private int resourceId;

        private TextBox titleTextBox;
        private ComboBox subjectComboBox;
        private RichTextBox descriptionRichTextBox;
        private Label fileNameLabel;
        private Button saveButton;
        private Button cancelButton;

        private readonly Color creamColor =
            Color.FromArgb(255, 249, 220);

        private readonly Color pinkColor =
            Color.FromArgb(245, 183, 208);

        private readonly Color lavenderColor =
            Color.FromArgb(233, 220, 247);

        private readonly Color textColor =
            Color.FromArgb(101, 59, 80);

        // DEFAULT CONSTRUCTOR
        public EditResourceForm()
        {
            BuildInterface();
        }

        // CONSTRUCTOR WITH RESOURCE DATA
        public EditResourceForm(
            int resourceId,
            string title,
            string subject,
            string description,
            string fileName) : this()
        {
            this.resourceId = resourceId;

            titleTextBox.Text = title;
            descriptionRichTextBox.Text = description;
            fileNameLabel.Text = fileName;

            LoadSubjects(subject);
        }

        // BUILD USER INTERFACE
        private void BuildInterface()
        {
            this.SuspendLayout();

            this.Text = "PeerShare - Edit Resource";
            this.ClientSize = new Size(540, 510);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.BackColor = creamColor;
            this.Font = new Font("Segoe UI", 10F);
            this.ForeColor = textColor;

            // HEADER
            Label headerLabel = new Label
            {
                Text = "Edit Resource ♡",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(30, 20),
                AutoSize = true
            };

            Label subtitleLabel = new Label
            {
                Text = "Update your shared learning material.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(152, 103, 125),
                Location = new Point(32, 65),
                AutoSize = true
            };

            // RESOURCE TITLE
            Label titleLabel =
                CreateLabel("Resource Title", 30, 110);

            titleTextBox = new TextBox
            {
                Location = new Point(30, 135),
                Size = new Size(480, 30),
                MaxLength = 200,
                Font = new Font("Segoe UI", 11F),
                ForeColor = textColor
            };

            // SUBJECT
            Label subjectLabel =
                CreateLabel("Subject", 30, 180);

            subjectComboBox = new ComboBox
            {
                Location = new Point(30, 205),
                Size = new Size(480, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11F),
                ForeColor = textColor
            };

            // DESCRIPTION
            Label descriptionLabel =
                CreateLabel("Description", 30, 250);

            descriptionRichTextBox = new RichTextBox
            {
                Location = new Point(30, 275),
                Size = new Size(480, 100),
                MaxLength = 2000,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor,
                BorderStyle = BorderStyle.FixedSingle
            };

            // ORIGINAL FILE INFORMATION
            Panel filePanel = new Panel
            {
                Location = new Point(30, 390),
                Size = new Size(480, 55),
                BackColor = lavenderColor
            };

            fileNameLabel = new Label
            {
                Location = new Point(12, 7),
                Size = new Size(455, 22),
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor,
                AutoEllipsis = true
            };

            Label fileNoteLabel = new Label
            {
                Text = "The original file will be retained.",
                Location = new Point(12, 29),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = textColor
            };

            filePanel.Controls.Add(fileNameLabel);
            filePanel.Controls.Add(fileNoteLabel);

            // CANCEL BUTTON
            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new Point(250, 460),
                Size = new Size(115, 35),
                BackColor = lavenderColor,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };

            cancelButton.FlatAppearance.BorderSize = 0;

            // SAVE BUTTON
            saveButton = new Button
            {
                Text = "Save Changes",
                Location = new Point(375, 460),
                Size = new Size(135, 35),
                BackColor = pinkColor,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            saveButton.FlatAppearance.BorderSize = 0;

            saveButton.Click += saveButton_Click;

            this.AcceptButton = saveButton;
            this.CancelButton = cancelButton;

            this.Controls.AddRange(new Control[]
            {
                headerLabel,
                subtitleLabel,
                titleLabel,
                titleTextBox,
                subjectLabel,
                subjectComboBox,
                descriptionLabel,
                descriptionRichTextBox,
                filePanel,
                cancelButton,
                saveButton
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // LABEL HELPER
        private Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font(
                    "Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor
            };
        }

        // LOAD SUBJECTS
        private void LoadSubjects(string currentSubject)
        {
            try
            {
                var subjects = ResourceService.GetSubjects();

                subjectComboBox.DisplayMember = "SubjectName";
                subjectComboBox.ValueMember = "SubjectId";
                subjectComboBox.DataSource = subjects;

                subjectComboBox.SelectedIndex =
                    subjects.FindIndex(
                        s => s.SubjectName == currentSubject);
            }
            catch (Exception ex)
            {
                saveButton.Enabled = false;

                MessageBox.Show(
                    "Unable to load subjects: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // SAVE CHANGES
        private void saveButton_Click(
            object sender, EventArgs e)
        {
            string title = titleTextBox.Text.Trim();

            string description =
                descriptionRichTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show(
                    "Please enter the resource title.");

                titleTextBox.Focus();
                return;
            }

            if (!(subjectComboBox.SelectedValue is int))
            {
                MessageBox.Show("Please select a subject.");
                subjectComboBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    "Please enter a description.");

                descriptionRichTextBox.Focus();
                return;
            }

            int subjectId =
                (int)subjectComboBox.SelectedValue;

            try
            {
                saveButton.Enabled = false;

                string result =
                    ResourceService.UpdateResource(
                        resourceId,
                        title,
                        subjectId,
                        description);

                if (result == "SUCCESS")
                {
                    MessageBox.Show(
                        "Resource updated successfully!",
                        "Update Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        result,
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update resource: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                saveButton.Enabled = true;
            }
        }
    }
}