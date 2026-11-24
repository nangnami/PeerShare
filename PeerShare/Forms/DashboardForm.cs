using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
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

            LoadRecentUploads();
            ConnectNavigation();
        }

        // 3 - NAVIGATION EVENTS
        private void ConnectNavigation()
        {
            homeButton.Click += homeButton_Click;
            uploadButton.Click += uploadButton_Click;
            myUploadsButton.Click += myUploadsButton_Click;
            resourcesButton.Click += resourcesButton_Click;
            aboutButton.Click += aboutButton_Click;
            logoutButton.Click += logoutButton_Click;

            sidebarPanel.Paint += sidebarPanel_Paint;
        }

        // 4 - RECENT UPLOADS
        private void LoadRecentUploads()
        {
            recentUploadsListView.Items.Clear();

            recentUploadsListView.Items.Add(
                new ListViewItem(new string[]
                {
                    "Introduction to Programming.pdf",
                    "Programming",
                    "John Doe",
                    "Nov 20, 2026"
                }));

            recentUploadsListView.Items.Add(
                new ListViewItem(new string[]
                {
                    "Database Fundamentals.pdf",
                    "Database",
                    "Jane Smith",
                    "Nov 19, 2026"
                }));

            recentUploadsListView.Items.Add(
                new ListViewItem(new string[]
                {
                    "Networking Basics.pdf",
                    "Networking",
                    "Alex Cruz",
                    "Nov 18, 2026"
                }));

            recentUploadsListView.Items.Add(
                new ListViewItem(new string[]
                {
                    "Web Development Notes.pdf",
                    "Web Development",
                    "Sam Lee",
                    "Nov 17, 2026"
                }));
        }

        // 5 - OPEN CHILD FORMS
        private void OpenChildForm(Form childForm)
        {
            contentPanel.SuspendLayout();

            Form previousChild = activeChildForm;

            // Prepare the new child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add and display the new page
            activeChildForm = childForm;
            contentPanel.Controls.Add(childForm);

            headerPanel.Visible = false;
            statsPanel.Visible = false;
            recentPanel.Visible = false;

            childForm.BringToFront();
            childForm.Show();

            // Close the previous page
            if (previousChild != null)
            {
                contentPanel.Controls.Remove(previousChild);
                previousChild.Close();
                previousChild.Dispose();
            }

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

        // 8 - LOGOUT
        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

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