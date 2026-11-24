
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeerShare
{
    partial class MyUploadsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel myUploadsPagePanel;
        private Label myUploadsTitleLabel;
        private Label myUploadsSubtitleLabel;
        private Label searchLabel;
        private TextBox searchTextBox;
        private Label subjectFilterLabel;
        private ComboBox subjectFilterComboBox;
        private Label myUploadsCountLabel;
        private ListView myUploadsListView;
        private ColumnHeader resourceColumn;
        private ColumnHeader subjectColumn;
        private ColumnHeader dateUploadedColumn;
        private ColumnHeader statusColumn;
        private Button viewResourceButton;
        private Button deleteButton;
        private PictureBox flowerPictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowerPictureBox = new PictureBox();
            this.myUploadsPagePanel = new Panel();
            this.myUploadsTitleLabel = new Label();
            this.myUploadsSubtitleLabel = new Label();
            this.searchLabel = new Label();
            this.searchTextBox = new TextBox();
            this.subjectFilterLabel = new Label();
            this.subjectFilterComboBox = new ComboBox();
            this.myUploadsCountLabel = new Label();
            this.myUploadsListView = new ListView();
            this.resourceColumn = new ColumnHeader();
            this.subjectColumn = new ColumnHeader();
            this.dateUploadedColumn = new ColumnHeader();
            this.statusColumn = new ColumnHeader();
            this.viewResourceButton = new Button();
            this.deleteButton = new Button();

            this.myUploadsPagePanel.SuspendLayout();
            this.SuspendLayout();

            // MAIN PANEL
            this.myUploadsPagePanel.BackColor = Color.FromArgb(255, 249, 217);
            this.myUploadsPagePanel.Location = new Point(25, 20);
            this.myUploadsPagePanel.Name = "myUploadsPagePanel";
            this.myUploadsPagePanel.Size = new Size(660, 535);
            this.myUploadsPagePanel.TabIndex = 0;

            // TITLE
            this.myUploadsTitleLabel.AutoSize = false;
            this.myUploadsTitleLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            this.myUploadsTitleLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.myUploadsTitleLabel.Location = new Point(30, 25);
            this.myUploadsTitleLabel.Size = new Size(360, 35);
            this.myUploadsTitleLabel.Text = "My Uploads ♡";

            // SUBTITLE
            this.myUploadsSubtitleLabel.AutoSize = false;
            this.myUploadsSubtitleLabel.Font = new Font("Segoe UI", 9F);
            this.myUploadsSubtitleLabel.ForeColor = Color.Gray;
            this.myUploadsSubtitleLabel.Location = new Point(32, 65);
            this.myUploadsSubtitleLabel.Size = new Size(360, 25);
            this.myUploadsSubtitleLabel.Text = "Keep track of the learning materials you've shared.";

            // SEARCH LABEL
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.searchLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.searchLabel.Location = new Point(35, 110);
            this.searchLabel.Text = "Search Resource";

            // SEARCH TEXTBOX
            this.searchTextBox.Font = new Font("Segoe UI", 9F);
            this.searchTextBox.Location = new Point(35, 135);
            this.searchTextBox.Size = new Size(350, 30);

            // SUBJECT FILTER LABEL
            this.subjectFilterLabel.AutoSize = true;
            this.subjectFilterLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.subjectFilterLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.subjectFilterLabel.Location = new Point(405, 110);
            this.subjectFilterLabel.Text = "Filter by Subject";

            // SUBJECT FILTER
            this.subjectFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.subjectFilterComboBox.Font = new Font("Segoe UI", 9F);
            this.subjectFilterComboBox.Items.AddRange(new object[]
            {
                "All Subjects",
                "Programming",
                "Database Management",
                "Networking",
                "Web Development",
                "Information Systems",
                "Other"
            });
            this.subjectFilterComboBox.Location = new Point(405, 135);
            this.subjectFilterComboBox.Size = new Size(220, 30);
            this.subjectFilterComboBox.SelectedIndex = 0;

            // COUNT LABEL
            this.myUploadsCountLabel.AutoSize = false;
            this.myUploadsCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.myUploadsCountLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.myUploadsCountLabel.Location = new Point(35, 185);
            this.myUploadsCountLabel.Size = new Size(300, 25);
            this.myUploadsCountLabel.Text = "My Resources (0)";

            // LIST VIEW
            this.myUploadsListView.Columns.AddRange(new ColumnHeader[]
            {
                this.resourceColumn,
                this.subjectColumn,
                this.dateUploadedColumn,
                this.statusColumn
            });

            this.myUploadsListView.Font = new Font("Segoe UI", 9F);
            this.myUploadsListView.ForeColor = Color.FromArgb(93, 70, 112);
            this.myUploadsListView.BackColor = Color.FromArgb(255, 249, 217);
            this.myUploadsListView.FullRowSelect = true;
            this.myUploadsListView.GridLines = false;
            this.myUploadsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.myUploadsListView.HideSelection = false;
            this.myUploadsListView.MultiSelect = false;
            this.myUploadsListView.BorderStyle = BorderStyle.None;
            this.myUploadsListView.Location = new Point(35, 220);
            this.myUploadsListView.Size = new Size(590, 210);
            this.myUploadsListView.View = View.Details;

            this.resourceColumn.Text = "Resource";
            this.resourceColumn.Width = 200;

            this.subjectColumn.Text = "Subject";
            this.subjectColumn.Width = 150;

            this.dateUploadedColumn.Text = "Date Uploaded";
            this.dateUploadedColumn.Width = 125;

            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 110;

            // VIEW BUTTON
            this.viewResourceButton.BackColor = Color.FromArgb(235, 222, 250);
            this.viewResourceButton.FlatStyle = FlatStyle.Flat;
            this.viewResourceButton.FlatAppearance.BorderSize = 0;
            this.viewResourceButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.viewResourceButton.ForeColor = Color.FromArgb(105, 76, 130);
            this.viewResourceButton.Location = new Point(320, 455);
            this.viewResourceButton.Size = new Size(145, 40);
            this.viewResourceButton.Text = "View Resource";
            this.viewResourceButton.UseVisualStyleBackColor = false;

            // DELETE BUTTON
            this.deleteButton.BackColor = Color.FromArgb(255, 207, 200);
            this.deleteButton.FlatStyle = FlatStyle.Flat;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.deleteButton.ForeColor = Color.FromArgb(125, 55, 85);
            this.deleteButton.Location = new Point(480, 455);
            this.deleteButton.Size = new Size(145, 40);
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;

            // FLOWER DECORATION
            this.flowerPictureBox.Location = new Point(410, 20);
            this.flowerPictureBox.Size = new Size(225, 70);
            this.flowerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.flowerPictureBox.BackColor = Color.Transparent;
            this.flowerPictureBox.TabStop = false;

            this.myUploadsPagePanel.Controls.Add(this.flowerPictureBox);

            // ADD CONTROLS
            this.myUploadsPagePanel.Controls.Add(this.myUploadsTitleLabel);
            this.myUploadsPagePanel.Controls.Add(this.myUploadsSubtitleLabel);
            this.myUploadsPagePanel.Controls.Add(this.searchLabel);
            this.myUploadsPagePanel.Controls.Add(this.searchTextBox);
            this.myUploadsPagePanel.Controls.Add(this.subjectFilterLabel);
            this.myUploadsPagePanel.Controls.Add(this.subjectFilterComboBox);
            this.myUploadsPagePanel.Controls.Add(this.myUploadsCountLabel);
            this.myUploadsPagePanel.Controls.Add(this.myUploadsListView);
            this.myUploadsPagePanel.Controls.Add(this.viewResourceButton);
            this.myUploadsPagePanel.Controls.Add(this.deleteButton);

            // FORM
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 249, 240);
            this.ClientSize = new Size(710, 580);
            this.Controls.Add(this.myUploadsPagePanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MyUploadsForm";
            this.Text = "My Uploads";

            this.myUploadsPagePanel.ResumeLayout(false);
            this.myUploadsPagePanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
