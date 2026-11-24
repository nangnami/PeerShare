
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeerShare
{
    partial class AboutUsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel aboutPagePanel;
        private Label aboutTitleLabel;
        private Label aboutSubtitleLabel;
        private Label aboutDescriptionLabel;
        private Label aboutTaglineLabel;
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
            this.aboutPagePanel = new Panel();
            this.aboutTitleLabel = new Label();
            this.aboutSubtitleLabel = new Label();
            this.aboutDescriptionLabel = new Label();
            this.aboutTaglineLabel = new Label();

            this.aboutPagePanel.SuspendLayout();
            this.SuspendLayout();

            // MAIN PANEL
            this.aboutPagePanel.BackColor = Color.FromArgb(255, 249, 217);
            this.aboutPagePanel.Location = new Point(25, 20);
            this.aboutPagePanel.Name = "aboutPagePanel";
            this.aboutPagePanel.Size = new Size(660, 535);

            // TITLE
            this.aboutTitleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.aboutTitleLabel.ForeColor = Color.FromArgb(125, 55, 85);
            this.aboutTitleLabel.Location = new Point(35, 45);
            this.aboutTitleLabel.Size = new Size(560, 45);
            this.aboutTitleLabel.Text = "About PeerShare ♡";

            // SUBTITLE
            this.aboutSubtitleLabel.Font = new Font("Segoe UI", 10F);
            this.aboutSubtitleLabel.ForeColor = Color.FromArgb(145, 128, 145);
            this.aboutSubtitleLabel.Location = new Point(38, 95);
            this.aboutSubtitleLabel.Size = new Size(560, 30);
            this.aboutSubtitleLabel.Text = "A little space for students to learn and share together.";

            // DESCRIPTION
            this.aboutDescriptionLabel.Font = new Font("Segoe UI", 11F);
            this.aboutDescriptionLabel.ForeColor = Color.FromArgb(93, 70, 112);
            this.aboutDescriptionLabel.Location = new Point(40, 175);
            this.aboutDescriptionLabel.Size = new Size(560, 190);
            this.aboutDescriptionLabel.Text =
                "PeerShare is a student-centered resource-sharing platform where students can upload, share, and discover learning materials.\n\n" +
                "Our goal is to make sharing academic resources easier and encourage students to learn from one another.\n\n" +
                "Through PeerShare, students can help each other access useful reviewers, notes, and other educational materials.";

            // TAGLINE
            this.aboutTaglineLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.aboutTaglineLabel.ForeColor = Color.FromArgb(125, 55, 85);
            this.aboutTaglineLabel.Location = new Point(40, 405);
            this.aboutTaglineLabel.Size = new Size(560, 35);
            this.aboutTaglineLabel.Text = "Share a little. Learn a lot.";
            this.aboutTaglineLabel.TextAlign = ContentAlignment.MiddleCenter;

            // FLOWER DECORATION
            this.flowerPictureBox.Location = new Point(217, 445);
            this.flowerPictureBox.Size = new Size(225, 70);
            this.flowerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.flowerPictureBox.BackColor = Color.Transparent;
            this.flowerPictureBox.TabStop = false;

            // ADD CONTROLS
            this.aboutPagePanel.Controls.Add(this.aboutTitleLabel);
            this.aboutPagePanel.Controls.Add(this.aboutSubtitleLabel);
            this.aboutPagePanel.Controls.Add(this.aboutDescriptionLabel);
            this.aboutPagePanel.Controls.Add(this.aboutTaglineLabel);
            this.aboutPagePanel.Controls.Add(this.flowerPictureBox);

            // FORM
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(255, 249, 240);
            this.ClientSize = new Size(710, 580);
            this.Controls.Add(this.aboutPagePanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "AboutUsForm";
            this.Text = "About Us";

            this.aboutPagePanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
