namespace PennyWise
{
    partial class LoginSignup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

    
        private void InitializeComponent()
        {
            Username = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            Login = new Button();
            Signup = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
         
            Username.AutoSize = true;
            Username.Font = new Font("Yu Gothic", 10F, FontStyle.Bold);
            Username.Location = new Point(35, 60);
            Username.Name = "Username";
            Username.Size = new Size(100, 22);
            Username.TabIndex = 0;
            Username.Text = "Username:";
       
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 10F, FontStyle.Bold);
            label2.Location = new Point(35, 125);
            label2.Name = "label2";
            label2.Size = new Size(96, 22);
            label2.TabIndex = 1;
            label2.Text = "Password:";
          
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(35, 85);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(293, 32);
            txtUsername.TabIndex = 2;
           
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(35, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(293, 32);
            txtPassword.TabIndex = 3;
           
            Login.BackColor = Color.HotPink;
            Login.Font = new Font("Yu Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Login.Location = new Point(26, 220);
            Login.Name = "Login";
            Login.Size = new Size(152, 40);
            Login.TabIndex = 4;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = false;
            Login.Click += buttonLogin_Click;
         
            Signup.BackColor = Color.HotPink;
            Signup.BackgroundImageLayout = ImageLayout.None;
            Signup.FlatAppearance.BorderSize = 0;
            Signup.Font = new Font("Yu Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Signup.Location = new Point(204, 220);
            Signup.Name = "Signup";
            Signup.Size = new Size(152, 40);
            Signup.TabIndex = 5;
            Signup.Text = "Sign-up";
            Signup.UseVisualStyleBackColor = false;
            Signup.Click += buttonSignup_Click;
        
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(Signup);
            panel1.Controls.Add(Login);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(Username);
            panel1.Location = new Point(65, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 329);
            panel1.TabIndex = 6;
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginSignup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PennyWise";
            
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void CustomizeTitleBar()
        {
            
            this.FormBorderStyle = FormBorderStyle.None;

            Panel titleBar = new Panel();
            titleBar.BackColor = Color.FromArgb(247, 65, 143); 
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;


            Label titleLabel = new Label();
            titleLabel.Text = "PennyWise Login/SignUp"; 
            titleLabel.ForeColor = Color.White; 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            Button closeButton = new Button();
            closeButton.Text = "X";
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.ForeColor = Color.White;
            closeButton.Dock = DockStyle.Right;
            closeButton.Click += CloseButton_Click;
            closeButton.Size = new Size(40, 40);

            Button minimizeButton = new Button();
            minimizeButton.Text = "-";
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.ForeColor = Color.White;
            minimizeButton.Dock = DockStyle.Right;
            minimizeButton.Size = new Size(40, 40);
            minimizeButton.Click += MinimizeButton_Click;

            Button fullscreenButton = new Button();
            fullscreenButton.Text = "⬜";
            fullscreenButton.FlatStyle = FlatStyle.Flat;
            fullscreenButton.FlatAppearance.BorderSize = 0;
            fullscreenButton.ForeColor = Color.White;
            fullscreenButton.Dock = DockStyle.Right;
            fullscreenButton.Size = new Size(40, 40);
            fullscreenButton.Click += FullscreenButton_Click;


            
            titleBar.Controls.Add(titleLabel);
            titleBar.Controls.Add(fullscreenButton);
            titleBar.Controls.Add(minimizeButton);
            titleBar.Controls.Add(closeButton);
            this.Controls.Add(titleBar);
        }
        #endregion

        private Label Username;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button Login;
        private Button Signup;
        private Panel panel1;
    }
}

