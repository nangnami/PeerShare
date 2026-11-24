
using System.Drawing;
using System.Windows.Forms;

namespace PeerShare
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private Panel sidebarPanel;
        private Panel contentPanel;
        private Panel headerPanel;
        private Panel statsPanel;
        private Panel recentPanel;

        private Label brandLabel;
        private Label brandSubtitleLabel;

        private Button homeButton;
        private Button uploadButton;
        private Button myUploadsButton;
        private Button resourcesButton;
        private Button aboutButton;
        private Button logoutButton;

        private Label greetingLabel;
        private Label greetingSubtitleLabel;
        private Label profileIconLabel;
        private Label profileNameLabel;
        private Label profileRoleLabel;

        private ListView recentUploadsListView;

        private PictureBox fairyPictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.fairyPictureBox = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.greetingSubtitleLabel = new System.Windows.Forms.Label();
            this.profileIconLabel = new System.Windows.Forms.Label();
            this.profileNameLabel = new System.Windows.Forms.Label();
            this.profileRoleLabel = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.totalCard = new System.Windows.Forms.Panel();
            this.totalTitle = new System.Windows.Forms.Label();
            this.totalValue = new System.Windows.Forms.Label();
            this.totalSymbol = new System.Windows.Forms.Label();
            this.myResourcesCard = new System.Windows.Forms.Panel();
            this.resourcesTitle = new System.Windows.Forms.Label();
            this.resourcesValue = new System.Windows.Forms.Label();
            this.resourcesSymbol = new System.Windows.Forms.Label();
            this.availableCard = new System.Windows.Forms.Panel();
            this.availableTitle = new System.Windows.Forms.Label();
            this.availableValue = new System.Windows.Forms.Label();
            this.availableSymbol = new System.Windows.Forms.Label();
            this.recentPanel = new System.Windows.Forms.Panel();
            this.recentTitleLabel = new System.Windows.Forms.Label();
            this.recentUploadsListView = new System.Windows.Forms.ListView();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.brandLabel = new System.Windows.Forms.Label();
            this.brandSubtitleLabel = new System.Windows.Forms.Label();
            this.homeButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.myUploadsButton = new System.Windows.Forms.Button();
            this.resourcesButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fairyPictureBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.totalCard.SuspendLayout();
            this.myResourcesCard.SuspendLayout();
            this.availableCard.SuspendLayout();
            this.recentPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fairyPictureBox
            // 
            this.fairyPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.fairyPictureBox.Location = new System.Drawing.Point(18, 396);
            this.fairyPictureBox.Name = "fairyPictureBox";
            this.fairyPictureBox.Size = new System.Drawing.Size(154, 108);
            this.fairyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fairyPictureBox.TabIndex = 0;
            this.fairyPictureBox.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.sidebarPanel);
            this.mainPanel.Location = new System.Drawing.Point(20, 20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(900, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.contentPanel.Controls.Add(this.headerPanel);
            this.contentPanel.Controls.Add(this.statsPanel);
            this.contentPanel.Controls.Add(this.recentPanel);
            this.contentPanel.Location = new System.Drawing.Point(190, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(710, 580);
            this.contentPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.greetingLabel);
            this.headerPanel.Controls.Add(this.greetingSubtitleLabel);
            this.headerPanel.Controls.Add(this.profileIconLabel);
            this.headerPanel.Controls.Add(this.profileNameLabel);
            this.headerPanel.Controls.Add(this.profileRoleLabel);
            this.headerPanel.Location = new System.Drawing.Point(25, 20);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(660, 65);
            this.headerPanel.TabIndex = 0;
            // 
            // greetingLabel
            // 
            this.greetingLabel.BackColor = System.Drawing.Color.Transparent;
            this.greetingLabel.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.greetingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.greetingLabel.Location = new System.Drawing.Point(0, 0);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(350, 35);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Hello, Student! ✨";
            // 
            // greetingSubtitleLabel
            // 
            this.greetingSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.greetingSubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.greetingSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(128)))), ((int)(((byte)(145)))));
            this.greetingSubtitleLabel.Location = new System.Drawing.Point(2, 38);
            this.greetingSubtitleLabel.Name = "greetingSubtitleLabel";
            this.greetingSubtitleLabel.Size = new System.Drawing.Size(370, 22);
            this.greetingSubtitleLabel.TabIndex = 1;
            this.greetingSubtitleLabel.Text = "Ready to share and discover something new?";
            // 
            // profileIconLabel
            // 
            this.profileIconLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.profileIconLabel.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.profileIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(105)))), ((int)(((byte)(151)))));
            this.profileIconLabel.Location = new System.Drawing.Point(475, 8);
            this.profileIconLabel.Name = "profileIconLabel";
            this.profileIconLabel.Size = new System.Drawing.Size(40, 40);
            this.profileIconLabel.TabIndex = 2;
            this.profileIconLabel.Text = "♡";
            this.profileIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // profileNameLabel
            // 
            this.profileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.profileNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.profileNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.profileNameLabel.Location = new System.Drawing.Point(520, 10);
            this.profileNameLabel.Name = "profileNameLabel";
            this.profileNameLabel.Size = new System.Drawing.Size(120, 20);
            this.profileNameLabel.TabIndex = 3;
            this.profileNameLabel.Text = "Student";
            // 
            // profileRoleLabel
            // 
            this.profileRoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.profileRoleLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.profileRoleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(128)))), ((int)(((byte)(145)))));
            this.profileRoleLabel.Location = new System.Drawing.Point(520, 31);
            this.profileRoleLabel.Name = "profileRoleLabel";
            this.profileRoleLabel.Size = new System.Drawing.Size(130, 18);
            this.profileRoleLabel.TabIndex = 4;
            this.profileRoleLabel.Text = "PeerShare Member";
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Transparent;
            this.statsPanel.Controls.Add(this.totalCard);
            this.statsPanel.Controls.Add(this.myResourcesCard);
            this.statsPanel.Controls.Add(this.availableCard);
            this.statsPanel.Location = new System.Drawing.Point(25, 110);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(660, 135);
            this.statsPanel.TabIndex = 1;
            // 
            // totalCard
            // 
            this.totalCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.totalCard.Controls.Add(this.totalTitle);
            this.totalCard.Controls.Add(this.totalValue);
            this.totalCard.Controls.Add(this.totalSymbol);
            this.totalCard.Location = new System.Drawing.Point(0, 5);
            this.totalCard.Name = "totalCard";
            this.totalCard.Size = new System.Drawing.Size(210, 115);
            this.totalCard.TabIndex = 0;
            // 
            // totalTitle
            // 
            this.totalTitle.BackColor = System.Drawing.Color.Transparent;
            this.totalTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.totalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(105)))), ((int)(((byte)(130)))));
            this.totalTitle.Location = new System.Drawing.Point(17, 20);
            this.totalTitle.Name = "totalTitle";
            this.totalTitle.Size = new System.Drawing.Size(125, 20);
            this.totalTitle.TabIndex = 0;
            this.totalTitle.Text = "TOTAL UPLOADS";
            // 
            // totalValue
            // 
            this.totalValue.BackColor = System.Drawing.Color.Transparent;
            this.totalValue.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.totalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.totalValue.Location = new System.Drawing.Point(15, 48);
            this.totalValue.Name = "totalValue";
            this.totalValue.Size = new System.Drawing.Size(100, 42);
            this.totalValue.TabIndex = 1;
            this.totalValue.Text = "12";
            // 
            // totalSymbol
            // 
            this.totalSymbol.BackColor = System.Drawing.Color.Transparent;
            this.totalSymbol.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.totalSymbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(105)))), ((int)(((byte)(155)))));
            this.totalSymbol.Location = new System.Drawing.Point(155, 12);
            this.totalSymbol.Name = "totalSymbol";
            this.totalSymbol.Size = new System.Drawing.Size(40, 40);
            this.totalSymbol.TabIndex = 2;
            this.totalSymbol.Text = "▤";
            // 
            // myResourcesCard
            // 
            this.myResourcesCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.myResourcesCard.Controls.Add(this.resourcesTitle);
            this.myResourcesCard.Controls.Add(this.resourcesValue);
            this.myResourcesCard.Controls.Add(this.resourcesSymbol);
            this.myResourcesCard.Location = new System.Drawing.Point(225, 5);
            this.myResourcesCard.Name = "myResourcesCard";
            this.myResourcesCard.Size = new System.Drawing.Size(210, 115);
            this.myResourcesCard.TabIndex = 1;
            // 
            // resourcesTitle
            // 
            this.resourcesTitle.BackColor = System.Drawing.Color.Transparent;
            this.resourcesTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.resourcesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(105)))), ((int)(((byte)(130)))));
            this.resourcesTitle.Location = new System.Drawing.Point(17, 20);
            this.resourcesTitle.Name = "resourcesTitle";
            this.resourcesTitle.Size = new System.Drawing.Size(125, 20);
            this.resourcesTitle.TabIndex = 0;
            this.resourcesTitle.Text = "MY RESOURCES";
            // 
            // resourcesValue
            // 
            this.resourcesValue.BackColor = System.Drawing.Color.Transparent;
            this.resourcesValue.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.resourcesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.resourcesValue.Location = new System.Drawing.Point(15, 48);
            this.resourcesValue.Name = "resourcesValue";
            this.resourcesValue.Size = new System.Drawing.Size(100, 42);
            this.resourcesValue.TabIndex = 1;
            this.resourcesValue.Text = "05";
            // 
            // resourcesSymbol
            // 
            this.resourcesSymbol.BackColor = System.Drawing.Color.Transparent;
            this.resourcesSymbol.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.resourcesSymbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(105)))), ((int)(((byte)(155)))));
            this.resourcesSymbol.Location = new System.Drawing.Point(155, 12);
            this.resourcesSymbol.Name = "resourcesSymbol";
            this.resourcesSymbol.Size = new System.Drawing.Size(40, 40);
            this.resourcesSymbol.TabIndex = 2;
            this.resourcesSymbol.Text = "♡";
            // 
            // availableCard
            // 
            this.availableCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(215)))));
            this.availableCard.Controls.Add(this.availableTitle);
            this.availableCard.Controls.Add(this.availableValue);
            this.availableCard.Controls.Add(this.availableSymbol);
            this.availableCard.Location = new System.Drawing.Point(450, 5);
            this.availableCard.Name = "availableCard";
            this.availableCard.Size = new System.Drawing.Size(210, 115);
            this.availableCard.TabIndex = 2;
            // 
            // availableTitle
            // 
            this.availableTitle.BackColor = System.Drawing.Color.Transparent;
            this.availableTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.availableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(105)))), ((int)(((byte)(130)))));
            this.availableTitle.Location = new System.Drawing.Point(17, 20);
            this.availableTitle.Name = "availableTitle";
            this.availableTitle.Size = new System.Drawing.Size(125, 20);
            this.availableTitle.TabIndex = 0;
            this.availableTitle.Text = "AVAILABLE";
            // 
            // availableValue
            // 
            this.availableValue.BackColor = System.Drawing.Color.Transparent;
            this.availableValue.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.availableValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.availableValue.Location = new System.Drawing.Point(15, 48);
            this.availableValue.Name = "availableValue";
            this.availableValue.Size = new System.Drawing.Size(100, 42);
            this.availableValue.TabIndex = 1;
            this.availableValue.Text = "08";
            // 
            // availableSymbol
            // 
            this.availableSymbol.BackColor = System.Drawing.Color.Transparent;
            this.availableSymbol.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.availableSymbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(105)))), ((int)(((byte)(155)))));
            this.availableSymbol.Location = new System.Drawing.Point(155, 12);
            this.availableSymbol.Name = "availableSymbol";
            this.availableSymbol.Size = new System.Drawing.Size(40, 40);
            this.availableSymbol.TabIndex = 2;
            this.availableSymbol.Text = "✿";
            // 
            // recentPanel
            // 
            this.recentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(217)))));
            this.recentPanel.Controls.Add(this.recentTitleLabel);
            this.recentPanel.Controls.Add(this.recentUploadsListView);
            this.recentPanel.Location = new System.Drawing.Point(25, 275);
            this.recentPanel.Name = "recentPanel";
            this.recentPanel.Size = new System.Drawing.Size(660, 280);
            this.recentPanel.TabIndex = 2;
            // 
            // recentTitleLabel
            // 
            this.recentTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentTitleLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.recentTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.recentTitleLabel.Location = new System.Drawing.Point(20, 15);
            this.recentTitleLabel.Name = "recentTitleLabel";
            this.recentTitleLabel.Size = new System.Drawing.Size(300, 30);
            this.recentTitleLabel.TabIndex = 0;
            this.recentTitleLabel.Text = "Recently Shared ♡";
            // 
            // recentUploadsListView
            // 
            this.recentUploadsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(217)))));
            this.recentUploadsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentUploadsListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.recentUploadsListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.recentUploadsListView.FullRowSelect = true;
            this.recentUploadsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.recentUploadsListView.HideSelection = false;
            this.recentUploadsListView.Location = new System.Drawing.Point(20, 58);
            this.recentUploadsListView.Name = "recentUploadsListView";
            this.recentUploadsListView.Size = new System.Drawing.Size(620, 195);
            this.recentUploadsListView.TabIndex = 1;
            this.recentUploadsListView.UseCompatibleStateImageBehavior = false;
            this.recentUploadsListView.View = System.Windows.Forms.View.Details;
            this.recentUploadsListView.Columns.AddRange(
            new System.Windows.Forms.ColumnHeader[]
            {
                new System.Windows.Forms.ColumnHeader(),
                new System.Windows.Forms.ColumnHeader(),
                new System.Windows.Forms.ColumnHeader(),
                new System.Windows.Forms.ColumnHeader()
            });

                    this.recentUploadsListView.Columns[0].Text = "Resource";
                    this.recentUploadsListView.Columns[0].Width = 210;

                    this.recentUploadsListView.Columns[1].Text = "Subject";
                    this.recentUploadsListView.Columns[1].Width = 125;

                    this.recentUploadsListView.Columns[2].Text = "Uploaded By";
                    this.recentUploadsListView.Columns[2].Width = 150;

                    this.recentUploadsListView.Columns[3].Text = "Date";
                    this.recentUploadsListView.Columns[3].Width = 115;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.Transparent;
            this.sidebarPanel.Controls.Add(this.fairyPictureBox);
            this.sidebarPanel.Controls.Add(this.brandLabel);
            this.sidebarPanel.Controls.Add(this.brandSubtitleLabel);
            this.sidebarPanel.Controls.Add(this.homeButton);
            this.sidebarPanel.Controls.Add(this.uploadButton);
            this.sidebarPanel.Controls.Add(this.myUploadsButton);
            this.sidebarPanel.Controls.Add(this.resourcesButton);
            this.sidebarPanel.Controls.Add(this.aboutButton);
            this.sidebarPanel.Controls.Add(this.logoutButton);
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(190, 580);
            this.sidebarPanel.TabIndex = 1;
            // 
            // brandLabel
            // 
            this.brandLabel.BackColor = System.Drawing.Color.Transparent;
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.brandLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(83)))));
            this.brandLabel.Location = new System.Drawing.Point(20, 25);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(160, 35);
            this.brandLabel.TabIndex = 1;
            this.brandLabel.Text = "PeerShare ♡";
            // 
            // brandSubtitleLabel
            // 
            this.brandSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.brandSubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.brandSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(72)))), ((int)(((byte)(105)))));
            this.brandSubtitleLabel.Location = new System.Drawing.Point(22, 61);
            this.brandSubtitleLabel.Name = "brandSubtitleLabel";
            this.brandSubtitleLabel.Size = new System.Drawing.Size(155, 20);
            this.brandSubtitleLabel.TabIndex = 2;
            this.brandSubtitleLabel.Text = "your little study corner";
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.homeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.homeButton.Location = new System.Drawing.Point(18, 105);
            this.homeButton.Name = "homeButton";
            this.homeButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.homeButton.Size = new System.Drawing.Size(154, 42);
            this.homeButton.TabIndex = 3;
            this.homeButton.Text = "⌂   HOME";
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.UseVisualStyleBackColor = false;
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.uploadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.uploadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.uploadButton.Location = new System.Drawing.Point(18, 158);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.uploadButton.Size = new System.Drawing.Size(154, 42);
            this.uploadButton.TabIndex = 4;
            this.uploadButton.Text = "＋   UPLOAD";
            this.uploadButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uploadButton.UseVisualStyleBackColor = false;
            // 
            // myUploadsButton
            // 
            this.myUploadsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.myUploadsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myUploadsButton.FlatAppearance.BorderSize = 0;
            this.myUploadsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myUploadsButton.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.myUploadsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.myUploadsButton.Location = new System.Drawing.Point(18, 211);
            this.myUploadsButton.Name = "myUploadsButton";
            this.myUploadsButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.myUploadsButton.Size = new System.Drawing.Size(154, 42);
            this.myUploadsButton.TabIndex = 5;
            this.myUploadsButton.Text = "♡   MY UPLOADS";
            this.myUploadsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myUploadsButton.UseVisualStyleBackColor = false;
            // 
            // resourcesButton
            // 
            this.resourcesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.resourcesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resourcesButton.FlatAppearance.BorderSize = 0;
            this.resourcesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resourcesButton.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.resourcesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.resourcesButton.Location = new System.Drawing.Point(18, 264);
            this.resourcesButton.Name = "resourcesButton";
            this.resourcesButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.resourcesButton.Size = new System.Drawing.Size(154, 42);
            this.resourcesButton.TabIndex = 6;
            this.resourcesButton.Text = "▤   VIEW RESOURCES";
            this.resourcesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resourcesButton.UseVisualStyleBackColor = false;
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.aboutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.aboutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.aboutButton.Location = new System.Drawing.Point(18, 317);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.aboutButton.Size = new System.Drawing.Size(154, 42);
            this.aboutButton.TabIndex = 7;
            this.aboutButton.Text = "✿   ABOUT US";
            this.aboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aboutButton.UseVisualStyleBackColor = false;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(220)))));
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.logoutButton.Location = new System.Drawing.Point(18, 510);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(154, 42);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "↪   LOG OUT";
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PeerShare - Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.fairyPictureBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.statsPanel.ResumeLayout(false);
            this.totalCard.ResumeLayout(false);
            this.myResourcesCard.ResumeLayout(false);
            this.availableCard.ResumeLayout(false);
            this.recentPanel.ResumeLayout(false);
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel totalCard;
        private Label totalTitle;
        private Label totalValue;
        private Label totalSymbol;
        private Panel myResourcesCard;
        private Label resourcesTitle;
        private Label resourcesValue;
        private Label resourcesSymbol;
        private Panel availableCard;
        private Label availableTitle;
        private Label availableValue;
        private Label availableSymbol;
        private Label recentTitleLabel;
    }
}
