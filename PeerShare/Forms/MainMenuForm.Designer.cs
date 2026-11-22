
namespace PeerShare
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Text = "Welcome to PeerShare!";
            this.lblWelcome.Font = new System.Drawing.Font(
                "Segoe UI", 22F,
                System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor =
                System.Drawing.Color.SteelBlue;
            this.lblWelcome.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Location =
                new System.Drawing.Point(50, 80);
            this.lblWelcome.Size =
                new System.Drawing.Size(580, 80);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.Location =
                new System.Drawing.Point(250, 240);
            this.btnLogout.Size =
                new System.Drawing.Size(180, 45);
            this.btnLogout.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnLogout.ForeColor =
                System.Drawing.Color.White;
            this.btnLogout.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click +=
                new System.EventHandler(this.btnLogout_Click);

            // MainMenuForm
            this.ClientSize =
                new System.Drawing.Size(700, 400);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);

            this.Text = "PeerShare - Main Menu";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            this.ResumeLayout(false);
        }
    }
}
