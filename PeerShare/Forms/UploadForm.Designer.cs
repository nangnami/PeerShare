using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeerShare
{
    partial class UploadForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel uploadPagePanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label resourceTitleLabel;
        private TextBox resourceTitleTextBox;
        private Label subjectLabel;
        private ComboBox subjectComboBox;
        private Label descriptionLabel;
        private RichTextBox descriptionRichTextBox;
        private Button browseButton;
        private Label selectedFileLabel;
        private ListBox selectedFilesListBox;
        private Button removeFileButton;
        private Button uploadButton;
        private PictureBox flowerPictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowerPictureBox = new PictureBox();
            this.uploadPagePanel = new Panel();
            this.titleLabel = new Label();
            this.subtitleLabel = new Label();
            this.resourceTitleLabel = new Label();
            this.resourceTitleTextBox = new TextBox();
            this.subjectLabel = new Label();
            this.subjectComboBox = new ComboBox();
            this.descriptionLabel = new Label();
            this.descriptionRichTextBox = new RichTextBox();
            this.browseButton = new Button();
            this.selectedFileLabel = new Label();
            this.selectedFilesListBox = new ListBox();
            this.removeFileButton = new Button();
            this.uploadButton = new Button();

            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(255, 249, 240);
            this.ClientSize = new Size(710, 580);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "UploadForm";
            this.Text = "Upload Resource";

            // MAIN YELLOW CARD
            this.uploadPagePanel.Location = new Point(25, 20);
            this.uploadPagePanel.Size = new Size(660, 535);
            this.uploadPagePanel.BackColor = Color.FromArgb(255, 249, 217);
            this.uploadPagePanel.Controls.Add(this.titleLabel);
            this.uploadPagePanel.Controls.Add(this.subtitleLabel);
            this.uploadPagePanel.Controls.Add(this.resourceTitleLabel);
            this.uploadPagePanel.Controls.Add(this.resourceTitleTextBox);
            this.uploadPagePanel.Controls.Add(this.subjectLabel);
            this.uploadPagePanel.Controls.Add(this.subjectComboBox);
            this.uploadPagePanel.Controls.Add(this.descriptionLabel);
            this.uploadPagePanel.Controls.Add(this.descriptionRichTextBox);
            this.uploadPagePanel.Controls.Add(this.browseButton);
            this.uploadPagePanel.Controls.Add(this.selectedFileLabel);
            this.uploadPagePanel.Controls.Add(this.selectedFilesListBox);
            this.uploadPagePanel.Controls.Add(this.removeFileButton);
            this.uploadPagePanel.Controls.Add(this.uploadButton);

            // TITLE
            this.titleLabel.Location = new Point(30, 25);
            this.titleLabel.Size = new Size(360, 35);
            this.titleLabel.Text = "Upload Resource ♡";
            this.titleLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            this.titleLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.titleLabel.BackColor = Color.Transparent;

            // SUBTITLE
            this.subtitleLabel.Location = new Point(32, 65);
            this.subtitleLabel.Size = new Size(360, 22);
            this.subtitleLabel.Text = "Share your learning materials with other students!";
            this.subtitleLabel.Font = new Font("Segoe UI", 9F);
            this.subtitleLabel.ForeColor = Color.FromArgb(145, 128, 145);
            this.subtitleLabel.BackColor = Color.Transparent;

            // RESOURCE TITLE LABEL
            this.resourceTitleLabel.Location = new Point(35, 110);
            this.resourceTitleLabel.Size = new Size(200, 20);
            this.resourceTitleLabel.Text = "Resource Title";
            this.resourceTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.resourceTitleLabel.ForeColor = Color.FromArgb(93, 70, 112);

            // RESOURCE TITLE TEXTBOX
            this.resourceTitleTextBox.Location = new Point(35, 135);
            this.resourceTitleTextBox.Size = new Size(575, 30);
            this.resourceTitleTextBox.Font = new Font("Segoe UI", 9F);
            this.resourceTitleTextBox.BorderStyle = BorderStyle.FixedSingle;

            // SUBJECT LABEL
            this.subjectLabel.Location = new Point(35, 180);
            this.subjectLabel.Size = new Size(200, 20);
            this.subjectLabel.Text = "Subject";
            this.subjectLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.subjectLabel.ForeColor = Color.FromArgb(93, 70, 112);

            // SUBJECT COMBOBOX
            this.subjectComboBox.Location = new Point(35, 205);
            this.subjectComboBox.Size = new Size(575, 28);
            this.subjectComboBox.Font = new Font("Segoe UI", 9F);
            this.subjectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.subjectComboBox.Items.AddRange(new object[]
            {
                "Programming",
                "Database Management",
                "Networking",
                "Web Development",
                "Information Management",
                "Other"
            });

            // DESCRIPTION LABEL
            this.descriptionLabel.Location = new Point(35, 250);
            this.descriptionLabel.Size = new Size(200, 20);
            this.descriptionLabel.Text = "Description";
            this.descriptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.descriptionLabel.ForeColor = Color.FromArgb(93, 70, 112);

            // DESCRIPTION TEXTBOX
            this.descriptionRichTextBox.Location = new Point(35, 275);
            this.descriptionRichTextBox.Size = new Size(575, 55);
            this.descriptionRichTextBox.Font = new Font("Segoe UI", 9F);
            this.descriptionRichTextBox.BorderStyle = BorderStyle.FixedSingle;

            // BROWSE BUTTON
            this.browseButton.Location = new Point(35, 345);
            this.browseButton.Size = new Size(130, 35);
            this.browseButton.Text = "Browse Files";
            this.browseButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.browseButton.BackColor = Color.FromArgb(255, 207, 200);
            this.browseButton.ForeColor = Color.FromArgb(125, 55, 85);
            this.browseButton.FlatStyle = FlatStyle.Flat;
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.Cursor = Cursors.Hand;

            // SELECTED FILE LABEL
            this.selectedFileLabel.Location = new Point(180, 350);
            this.selectedFileLabel.Size = new Size(420, 25);
            this.selectedFileLabel.Text = "No files selected";
            this.selectedFileLabel.Font = new Font("Segoe UI", 8.5F);
            this.selectedFileLabel.ForeColor = Color.FromArgb(145, 128, 145);
            this.selectedFileLabel.TextAlign = ContentAlignment.MiddleLeft;

            this.selectedFilesListBox.Location = new Point(35, 390);
            this.selectedFilesListBox.Size = new Size(575, 75);
            this.selectedFilesListBox.Font = new Font("Segoe UI", 9F);
            this.selectedFilesListBox.HorizontalScrollbar = true;
            this.selectedFilesListBox.SelectionMode = SelectionMode.MultiExtended;
            this.removeFileButton.Location = new Point(35, 475);
            this.removeFileButton.Size = new Size(160, 42);
            this.removeFileButton.Text = "Remove Selected";
            this.removeFileButton.BackColor = Color.FromArgb(255, 207, 200);
            this.removeFileButton.ForeColor = Color.FromArgb(125, 55, 85);
            this.removeFileButton.FlatStyle = FlatStyle.Flat;
            this.removeFileButton.FlatAppearance.BorderSize = 0;

            // UPLOAD BUTTON
            this.uploadButton.Location = new Point(420, 475);
            this.uploadButton.Size = new Size(190, 42);
            this.uploadButton.Text = "Upload Resource";
            this.uploadButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.uploadButton.BackColor = Color.FromArgb(255, 155, 232);
            this.uploadButton.ForeColor = Color.FromArgb(105, 48, 83);
            this.uploadButton.FlatStyle = FlatStyle.Flat;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.Cursor = Cursors.Hand;

            // FLOWER DECORATION
            this.flowerPictureBox.Location = new Point(410, 20);
            this.flowerPictureBox.Size = new Size(225, 70);
            this.flowerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.flowerPictureBox.BackColor = Color.Transparent;
            this.flowerPictureBox.TabStop = false;
            this.uploadPagePanel.Controls.Add(this.flowerPictureBox);

            // ADD BACKGROUND AND MAIN CARD
            this.Controls.Add(this.uploadPagePanel);

            this.uploadPagePanel.BringToFront();

            this.ResumeLayout(false);
        }
    }
}