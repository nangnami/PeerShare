namespace PeerShare
{
    partial class SignupForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel signupCard;
        private System.Windows.Forms.PictureBox bookPicture;

        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Label loginLink;

        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;

        private System.Windows.Forms.Button signupButton;

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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.brandLabel = new System.Windows.Forms.Label();
            this.bookPicture = new System.Windows.Forms.PictureBox();
            this.signupCard = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.signupButton = new System.Windows.Forms.Button();
            this.loginLink = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookPicture)).BeginInit();
            this.signupCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.brandLabel);
            this.mainPanel.Controls.Add(this.bookPicture);
            this.mainPanel.Controls.Add(this.signupCard);
            this.mainPanel.Location = new System.Drawing.Point(-2, -1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(944, 647);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // brandLabel
            // 
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.brandLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.brandLabel.Location = new System.Drawing.Point(55, 35);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(179, 46);
            this.brandLabel.TabIndex = 0;
            this.brandLabel.Text = "PeerShare";
            this.brandLabel.BackColor = System.Drawing.Color.Transparent;
            // 
            // bookPicture
            // 
            this.bookPicture.Location = new System.Drawing.Point(55, 155);
            this.bookPicture.Size = new System.Drawing.Size(360, 300);
            this.bookPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookPicture.BackColor = System.Drawing.Color.Transparent;
            this.bookPicture.TabStop = false;
            // 
            // signupCard
            // 
            this.signupCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.signupCard.Controls.Add(this.titleLabel);
            this.signupCard.Controls.Add(this.subtitleLabel);
            this.signupCard.Controls.Add(this.emailLabel);
            this.signupCard.Controls.Add(this.emailTextBox);
            this.signupCard.Controls.Add(this.usernameLabel);
            this.signupCard.Controls.Add(this.usernameTextBox);
            this.signupCard.Controls.Add(this.passwordLabel);
            this.signupCard.Controls.Add(this.passwordTextBox);
            this.signupCard.Controls.Add(this.confirmPasswordLabel);
            this.signupCard.Controls.Add(this.confirmPasswordTextBox);
            this.signupCard.Controls.Add(this.signupButton);
            this.signupCard.Controls.Add(this.loginLink);
            this.signupCard.Location = new System.Drawing.Point(475, 65);
            this.signupCard.Name = "signupCard";
            this.signupCard.Size = new System.Drawing.Size(370, 475);
            this.signupCard.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.titleLabel.Location = new System.Drawing.Point(35, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(217, 38);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Create Account";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.Gray;
            this.subtitleLabel.Location = new System.Drawing.Point(37, 65);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(230, 15);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Join PeerShare and start sharing resources.";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.emailLabel.Location = new System.Drawing.Point(38, 105);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(83, 15);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email Address";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.emailTextBox.Location = new System.Drawing.Point(38, 130);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(294, 25);
            this.emailTextBox.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.Location = new System.Drawing.Point(38, 165);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(64, 15);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.usernameTextBox.Location = new System.Drawing.Point(38, 190);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(294, 25);
            this.usernameTextBox.TabIndex = 5;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.passwordLabel.Location = new System.Drawing.Point(38, 225);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(59, 15);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.passwordTextBox.Location = new System.Drawing.Point(38, 250);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(294, 25);
            this.passwordTextBox.TabIndex = 7;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.confirmPasswordLabel.Location = new System.Drawing.Point(38, 285);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(107, 15);
            this.confirmPasswordLabel.TabIndex = 8;
            this.confirmPasswordLabel.Text = "Confirm Password";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(38, 310);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(294, 25);
            this.confirmPasswordTextBox.TabIndex = 9;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // signupButton
            // 
            this.signupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(130)))), ((int)(((byte)(185)))));
            this.signupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signupButton.FlatAppearance.BorderSize = 0;
            this.signupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signupButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.signupButton.ForeColor = System.Drawing.Color.White;
            this.signupButton.Location = new System.Drawing.Point(38, 365);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(294, 42);
            this.signupButton.TabIndex = 10;
            this.signupButton.Text = "CREATE ACCOUNT";
            this.signupButton.UseVisualStyleBackColor = false;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // loginLink
            // 
            this.loginLink.AutoSize = true;
            this.loginLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loginLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(90)))), ((int)(((byte)(145)))));
            this.loginLink.Location = new System.Drawing.Point(90, 425);
            this.loginLink.Name = "loginLink";
            this.loginLink.Size = new System.Drawing.Size(178, 15);
            this.loginLink.TabIndex = 11;
            this.loginLink.Text = "Already have an account? Log in";
            this.loginLink.Click += new System.EventHandler(this.loginLink_Click);
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SignupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PeerShare - Sign Up";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookPicture)).EndInit();
            this.signupCard.ResumeLayout(false);
            this.signupCard.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
