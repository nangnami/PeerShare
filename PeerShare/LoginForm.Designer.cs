
namespace PeerShare
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox chkShowPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();

            this.SuspendLayout();

            this.lblTitle.Text = "PeerShare";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(35, 85, 135);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location =
                new System.Drawing.Point(65, 35);
            this.lblTitle.Size =
                new System.Drawing.Size(330, 60);

            this.lblSubtitle.Text = "Sign in to your account";
            this.lblSubtitle.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Location =
                new System.Drawing.Point(65, 95);
            this.lblSubtitle.Size =
                new System.Drawing.Size(330, 30);

            this.lblUsername.Text = "Username or Email";
            this.lblUsername.Location =
                new System.Drawing.Point(75, 155);
            this.lblUsername.AutoSize = true;

            this.txtUsername.Location =
                new System.Drawing.Point(75, 180);
            this.txtUsername.Size =
                new System.Drawing.Size(310, 28);
            this.txtUsername.MaxLength = 100;

            this.lblPassword.Text = "Password";
            this.lblPassword.Location =
                new System.Drawing.Point(75, 230);
            this.lblPassword.AutoSize = true;

            this.txtPassword.Location =
                new System.Drawing.Point(75, 255);
            this.txtPassword.Size =
                new System.Drawing.Size(310, 28);
            this.txtPassword.UseSystemPasswordChar = true;

            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.Location =
                new System.Drawing.Point(75, 295);
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.CheckedChanged +=
                new System.EventHandler(
                    this.chkShowPassword_CheckedChanged);

            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Location =
                new System.Drawing.Point(75, 340);
            this.btnLogin.Size =
                new System.Drawing.Size(310, 42);
            this.btnLogin.BackColor =
                System.Drawing.Color.FromArgb(35, 85, 135);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click +=
                new System.EventHandler(this.btnLogin_Click);

            this.btnRegister.Text = "Create an Account";
            this.btnRegister.Location =
                new System.Drawing.Point(75, 395);
            this.btnRegister.Size =
                new System.Drawing.Size(310, 35);
            this.btnRegister.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Click +=
                new System.EventHandler(this.btnRegister_Click);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(460, 480);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor =
                System.Drawing.Color.FromArgb(245, 248, 252);
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "PeerShare - Login";
            this.AcceptButton = this.btnLogin;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
