
namespace PeerShare
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();

            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();

            this.chkShowPassword =
                new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.lblTitle.Text = "Create Account";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(35, 85, 135);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location =
                new System.Drawing.Point(55, 25);
            this.lblTitle.Size =
                new System.Drawing.Size(350, 65);

            this.lblUsername.Text = "Username";
            this.lblUsername.Location =
                new System.Drawing.Point(75, 110);
            this.lblUsername.AutoSize = true;

            this.txtUsername.Location =
                new System.Drawing.Point(75, 135);
            this.txtUsername.Size =
                new System.Drawing.Size(310, 28);
            this.txtUsername.MaxLength = 50;

            this.lblEmail.Text = "Email Address";
            this.lblEmail.Location =
                new System.Drawing.Point(75, 180);
            this.lblEmail.AutoSize = true;

            this.txtEmail.Location =
                new System.Drawing.Point(75, 205);
            this.txtEmail.Size =
                new System.Drawing.Size(310, 28);
            this.txtEmail.MaxLength = 100;

            this.lblPassword.Text = "Password";
            this.lblPassword.Location =
                new System.Drawing.Point(75, 250);
            this.lblPassword.AutoSize = true;

            this.txtPassword.Location =
                new System.Drawing.Point(75, 275);
            this.txtPassword.Size =
                new System.Drawing.Size(310, 28);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.MaxLength = 128;

            this.lblConfirm.Text = "Confirm Password";
            this.lblConfirm.Location =
                new System.Drawing.Point(75, 320);
            this.lblConfirm.AutoSize = true;

            this.txtConfirmPassword.Location =
                new System.Drawing.Point(75, 345);
            this.txtConfirmPassword.Size =
                new System.Drawing.Size(310, 28);
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.MaxLength = 128;

            this.chkShowPassword.Text = "Show passwords";
            this.chkShowPassword.Location =
                new System.Drawing.Point(75, 385);
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.CheckedChanged +=
                new System.EventHandler(
                    this.chkShowPassword_CheckedChanged);

            this.btnRegister.Text = "REGISTER";
            this.btnRegister.Location =
                new System.Drawing.Point(75, 425);
            this.btnRegister.Size =
                new System.Drawing.Size(310, 42);
            this.btnRegister.BackColor =
                System.Drawing.Color.FromArgb(35, 85, 135);
            this.btnRegister.ForeColor =
                System.Drawing.Color.White;
            this.btnRegister.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Click +=
                new System.EventHandler(this.btnRegister_Click);

            this.btnBack.Text = "Back to Login";
            this.btnBack.Location =
                new System.Drawing.Point(75, 480);
            this.btnBack.Size =
                new System.Drawing.Size(310, 35);
            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click +=
                new System.EventHandler(this.btnBack_Click);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(460, 550);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnBack);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor =
                System.Drawing.Color.FromArgb(245, 248, 252);
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "PeerShare - Registration";
            this.AcceptButton = this.btnRegister;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
