using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PeerShare.Services;
namespace PeerShare
{
    public partial class DashboardForm : Form
    {
        // 1 - ACTIVE CHILD FORM
        private Form activeChildForm;

        // 2 - CONSTRUCTOR
        public DashboardForm()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null,
                contentPanel,
                new object[] { true }
            );

            fairyPictureBox.Image = Image.FromFile(
                Application.StartupPath + @"\Assets\fairy.png"
            );

            this.DoubleBuffered = true;

            mainPanel.BackgroundImage = Image.FromFile(
                Application.StartupPath + @"\Assets\background.jpg"
            );

            mainPanel.BackgroundImageLayout = ImageLayout.Stretch;

            contentPanel.BackColor = Color.Transparent;
            headerPanel.BackColor = Color.Transparent;
            statsPanel.BackColor = Color.Transparent;

            ApplyDashboardRoundedCorners();

            ConnectNavigation();
            LoadDashboardData();
        }

        // 3 - NAVIGATION EVENTS
        private void ConnectNavigation()
        {
            profileIconLabel.Click += profileButton_Click;
            profileNameLabel.Click += profileButton_Click;

            profileIconLabel.Cursor = Cursors.Hand;
            profileNameLabel.Cursor = Cursors.Hand;
            homeButton.Click += homeButton_Click;
            uploadButton.Click += uploadButton_Click;
            myUploadsButton.Click += myUploadsButton_Click;
            resourcesButton.Click += resourcesButton_Click;
            aboutButton.Click += aboutButton_Click;
            logoutButton.Click += logoutButton_Click;

            sidebarPanel.Paint += sidebarPanel_Paint;
        }

        // 4 - DASHBOARD DATA
        private void LoadDashboardData()
        {
            greetingLabel.Text = "Hello, " + SessionService.Username + "! ✨";
            profileNameLabel.Text = SessionService.Username;
            profileRoleLabel.Text = "PeerShare Member";

            int[] statistics = ResourceService.GetDashboardStatistics();
            totalValue.Text = statistics[0].ToString();
            resourcesValue.Text = statistics[1].ToString();
            availableValue.Text = statistics[2].ToString();

            LoadRecentUploads();
        }

        private void LoadRecentUploads()
        {
            recentUploadsListView.Items.Clear();
            foreach (string[] resource in ResourceService.GetRecentUploads())
            {
                recentUploadsListView.Items.Add(new ListViewItem(resource));
            }
        }

        // 5 - OPEN CHILD FORMS
        private void OpenChildForm(Form childForm)
        {
            contentPanel.SuspendLayout();

            Form previousChild = activeChildForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(childForm);

            headerPanel.Visible = false;
            statsPanel.Visible = false;
            recentPanel.Visible = false;

            childForm.Show();
            childForm.BringToFront();

            if (previousChild != null)
            {
                contentPanel.Controls.Remove(previousChild);
                previousChild.Close();
                previousChild.Dispose();
            }

            activeChildForm = childForm;

            contentPanel.ResumeLayout(true);
        }

        // 6 - SHOW HOME PAGE
        private void ShowHomePage()
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
                activeChildForm.Dispose();
                activeChildForm = null;
            }

            headerPanel.Visible = true;
            statsPanel.Visible = true;
            recentPanel.Visible = true;

            headerPanel.BringToFront();
            statsPanel.BringToFront();
            recentPanel.BringToFront();

            LoadDashboardData();
        }

        // 7 - NAVIGATION BUTTON METHODS
        private void homeButton_Click(object sender, EventArgs e)
        {
            ShowHomePage();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UploadForm());
        }

        private void myUploadsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MyUploadsForm());
        }

        private void resourcesButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViewResourcesForm());
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AboutUsForm());
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProfileForm());
        }

        // 8 - LOGOUT
        private void logoutButton_Click(object sender, EventArgs e)
        {
            SessionService.EndSession();
            this.Close();
            
        }

        // 9 - SIDEBAR GRADIENT
        private void sidebarPanel_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    sidebarPanel.ClientRectangle,
                    Color.FromArgb(255, 249, 190),
                    Color.FromArgb(255, 155, 232),
                    LinearGradientMode.Vertical))
            {
                ColorBlend blend = new ColorBlend();

                blend.Colors = new Color[]
                {
                    Color.FromArgb(255, 249, 190),
                    Color.FromArgb(255, 207, 200),
                    Color.FromArgb(255, 155, 232)
                };

                blend.Positions = new float[] { 0f, 0.5f, 1f };

                brush.InterpolationColors = blend;

                e.Graphics.FillRectangle(
                    brush,
                    sidebarPanel.ClientRectangle);
            }
        }

        // 10 - DASHBOARD ROUNDED CORNERS
        private void ApplyDashboardRoundedCorners()
        {
            ApplyRoundedCorners(mainPanel, 25);
            ApplyRoundedCorners(sidebarPanel, 25);

            // NAVIGATION BUTTONS
            ApplyRoundedCorners(homeButton, 15);
            ApplyRoundedCorners(uploadButton, 15);
            ApplyRoundedCorners(myUploadsButton, 15);
            ApplyRoundedCorners(resourcesButton, 15);
            ApplyRoundedCorners(aboutButton, 15);

            // OTHER ELEMENTS
            ApplyRoundedCorners(logoutButton, 15);
            ApplyRoundedCorners(profileIconLabel, 20);
            ApplyRoundedCorners(recentPanel, 20);

            foreach (Control control in statsPanel.Controls)
            {
                if (control is Panel)
                {
                    ApplyRoundedCorners(control, 20);
                }
            }
        }

        // 11 - ROUNDED CORNERS HELPER
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