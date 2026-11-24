using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeerShare
{
    partial class ViewResourcesForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel resourcesPagePanel;
        private Label resourcesTitleLabel;
        private Label resourcesSubtitleLabel;
        private PictureBox flowerPictureBox;
        private TextBox resourcesSearchTextBox;
        private ComboBox resourcesSubjectComboBox;
        private Label resourcesCountLabel;
        private FlowLayoutPanel resourcesFlowPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.resourcesPagePanel = new Panel();
            this.resourcesTitleLabel = new Label();
            this.resourcesSubtitleLabel = new Label();
            this.flowerPictureBox = new PictureBox();
            this.resourcesSearchTextBox = new TextBox();
            this.resourcesSubjectComboBox = new ComboBox();
            this.resourcesCountLabel = new Label();
            this.resourcesFlowPanel = new FlowLayoutPanel();

            this.resourcesPagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowerPictureBox)).BeginInit();
            this.SuspendLayout();

            // MAIN PANEL
            this.resourcesPagePanel.BackColor = Color.FromArgb(255, 249, 217);
            this.resourcesPagePanel.Location = new Point(25, 20);
            this.resourcesPagePanel.Name = "resourcesPagePanel";
            this.resourcesPagePanel.Size = new Size(660, 535);

            // TITLE
            this.resourcesTitleLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            this.resourcesTitleLabel.ForeColor = Color.FromArgb(90, 65, 75);
            this.resourcesTitleLabel.Location = new Point(30, 25);
            this.resourcesTitleLabel.Size = new Size(360, 40);
            this.resourcesTitleLabel.Text = "View Resources ♡";

            // SUBTITLE
            this.resourcesSubtitleLabel.Font = new Font("Segoe UI", 9F);
            this.resourcesSubtitleLabel.ForeColor = Color.FromArgb(130, 105, 115);
            this.resourcesSubtitleLabel.Location = new Point(33, 68);
            this.resourcesSubtitleLabel.Size = new Size(360, 25);
            this.resourcesSubtitleLabel.Text = "Explore learning materials shared by students.";

            // FLOWER DECORATION
            this.flowerPictureBox.Location = new Point(410, 20);
            this.flowerPictureBox.Size = new Size(225, 70);
            this.flowerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.flowerPictureBox.BackColor = Color.Transparent;
            this.flowerPictureBox.TabStop = false;

            // SEARCH
            this.resourcesSearchTextBox.Font = new Font("Segoe UI", 10F);
            this.resourcesSearchTextBox.Location = new Point(33, 110);
            this.resourcesSearchTextBox.Size = new Size(350, 30);

            // SUBJECT FILTER
            this.resourcesSubjectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.resourcesSubjectComboBox.Font = new Font("Segoe UI", 9F);
            this.resourcesSubjectComboBox.Items.AddRange(new object[]
            {
                "All Subjects",
                "Programming",
                "Database Management",
                "Networking",
                "Web Development",
                "Information Management"
            });
            this.resourcesSubjectComboBox.Location = new Point(400, 110);
            this.resourcesSubjectComboBox.Size = new Size(225, 30);
            this.resourcesSubjectComboBox.SelectedIndex = 0;

            // RESOURCE COUNT
            this.resourcesCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.resourcesCountLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.resourcesCountLabel.Location = new Point(33, 155);
            this.resourcesCountLabel.Size = new Size(400, 25);
            this.resourcesCountLabel.Text = "Available Resources (0)";

            // RESOURCE FLOW PANEL
            this.resourcesFlowPanel.AutoScroll = true;
            this.resourcesFlowPanel.BackColor = Color.Transparent;
            this.resourcesFlowPanel.FlowDirection = FlowDirection.TopDown;
            this.resourcesFlowPanel.Location = new Point(25, 185);
            this.resourcesFlowPanel.Name = "resourcesFlowPanel";
            this.resourcesFlowPanel.Padding = new Padding(5);
            this.resourcesFlowPanel.Size = new Size(610, 325);
            this.resourcesFlowPanel.WrapContents = false;

            // ADD CONTROLS
            this.resourcesPagePanel.Controls.Add(this.resourcesTitleLabel);
            this.resourcesPagePanel.Controls.Add(this.resourcesSubtitleLabel);
            this.resourcesPagePanel.Controls.Add(this.flowerPictureBox);
            this.resourcesPagePanel.Controls.Add(this.resourcesSearchTextBox);
            this.resourcesPagePanel.Controls.Add(this.resourcesSubjectComboBox);
            this.resourcesPagePanel.Controls.Add(this.resourcesCountLabel);
            this.resourcesPagePanel.Controls.Add(this.resourcesFlowPanel);

            // FORM
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 249, 240);
            this.ClientSize = new Size(710, 580);
            this.Controls.Add(this.resourcesPagePanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ViewResourcesForm";
            this.Text = "View Resources";

            this.resourcesPagePanel.ResumeLayout(false);
            this.resourcesPagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowerPictureBox)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
