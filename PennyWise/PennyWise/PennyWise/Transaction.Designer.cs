namespace PennyWise
{
    partial class Transaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Logout = new Button();
            totalincome = new Panel();
            labelIncome = new Label();
            totalexpense = new Panel();
            labelExpense = new Label();
            totalbalance = new Panel();
            labelBalance = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBoxMonth = new ComboBox();
            comboBoxYear = new ComboBox();
            panel2 = new Panel();
            flowLayoutPanelTransactions = new FlowLayoutPanel();
            label1 = new Label();
            panel4 = new Panel();
            panel1 = new Panel();
            categories2 = new PictureBox();
            transaction2 = new PictureBox();
            home2 = new PictureBox();
            totalincome.SuspendLayout();
            totalexpense.SuspendLayout();
            totalbalance.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categories2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transaction2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)home2).BeginInit();
            SuspendLayout();
            // 
            // Logout
            // 
            Logout.BackColor = Color.FromArgb(233, 102, 160);
            Logout.Location = new Point(1208, 808);
            Logout.Name = "Logout";
            Logout.Size = new Size(142, 52);
            Logout.TabIndex = 7;
            Logout.Text = "LOGOUT";
            Logout.UseVisualStyleBackColor = false;
            Logout.Click += Logout_Click;
            // 
            // totalincome
            // 
            totalincome.Controls.Add(labelIncome);
            totalincome.Location = new Point(458, 96);
            totalincome.Name = "totalincome";
            totalincome.Size = new Size(392, 43);
            totalincome.TabIndex = 17;
            // 
            // labelIncome
            // 
            labelIncome.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIncome.ForeColor = Color.FromArgb(51, 93, 45);
            labelIncome.Location = new Point(6, 7);
            labelIncome.Name = "labelIncome";
            labelIncome.Size = new Size(383, 31);
            labelIncome.TabIndex = 0;
            labelIncome.Text = "label6";
            labelIncome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalexpense
            // 
            totalexpense.Controls.Add(labelExpense);
            totalexpense.Location = new Point(46, 96);
            totalexpense.Name = "totalexpense";
            totalexpense.Size = new Size(395, 43);
            totalexpense.TabIndex = 18;
            // 
            // labelExpense
            // 
            labelExpense.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelExpense.ForeColor = Color.FromArgb(183, 4, 4);
            labelExpense.Location = new Point(3, 5);
            labelExpense.Name = "labelExpense";
            labelExpense.Size = new Size(389, 31);
            labelExpense.TabIndex = 1;
            labelExpense.Text = "label6";
            labelExpense.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalbalance
            // 
            totalbalance.Controls.Add(labelBalance);
            totalbalance.Location = new Point(867, 98);
            totalbalance.Name = "totalbalance";
            totalbalance.Size = new Size(392, 43);
            totalbalance.TabIndex = 18;
            // 
            // labelBalance
            // 
            labelBalance.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBalance.ForeColor = Color.Black;
            labelBalance.Location = new Point(3, 7);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(389, 31);
            labelBalance.TabIndex = 2;
            labelBalance.Text = "label6";
            labelBalance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(224, 224, 224);
            label3.Font = new Font("Yu Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(458, 54);
            label3.Name = "label3";
            label3.Size = new Size(392, 42);
            label3.TabIndex = 14;
            label3.Text = "Income";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(224, 224, 224);
            label4.Font = new Font("Yu Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(49, 54);
            label4.Name = "label4";
            label4.Padding = new Padding(10);
            label4.Size = new Size(392, 42);
            label4.TabIndex = 15;
            label4.Text = "Expense";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(224, 224, 224);
            label5.Font = new Font("Yu Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(867, 53);
            label5.Name = "label5";
            label5.Size = new Size(392, 42);
            label5.TabIndex = 16;
            label5.Text = "Balance";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(369, 13);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(188, 28);
            comboBoxMonth.TabIndex = 19;
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(713, 13);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(188, 28);
            comboBoxYear.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(233, 102, 160);
            panel2.Controls.Add(comboBoxMonth);
            panel2.Controls.Add(comboBoxYear);
            panel2.Location = new Point(46, 171);
            panel2.Name = "panel2";
            panel2.Size = new Size(1213, 54);
            panel2.TabIndex = 21;
            // 
            // flowLayoutPanelTransactions
            // 
            flowLayoutPanelTransactions.Location = new Point(16, 38);
            flowLayoutPanelTransactions.Name = "flowLayoutPanelTransactions";
            flowLayoutPanelTransactions.Size = new Size(982, 608);
            flowLayoutPanelTransactions.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 26);
            label1.TabIndex = 8;
            label1.Text = "Transactions";
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(flowLayoutPanelTransactions);
            panel4.Location = new Point(139, 247);
            panel4.Name = "panel4";
            panel4.Size = new Size(1021, 664);
            panel4.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(categories2);
            panel1.Controls.Add(transaction2);
            panel1.Controls.Add(home2);
            panel1.Location = new Point(1272, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(101, 237);
            panel1.TabIndex = 21;
            // 
            // categories2
            // 
            categories2.Image = Properties.Resources.categories_icon;
            categories2.Location = new Point(32, 159);
            categories2.Name = "categories2";
            categories2.Size = new Size(46, 36);
            categories2.SizeMode = PictureBoxSizeMode.CenterImage;
            categories2.TabIndex = 2;
            categories2.TabStop = false;
            // 
            // transaction2
            // 
            transaction2.BackgroundImageLayout = ImageLayout.Center;
            transaction2.Image = Properties.Resources.transaction_icon;
            transaction2.Location = new Point(32, 94);
            transaction2.Name = "transaction2";
            transaction2.Size = new Size(46, 36);
            transaction2.SizeMode = PictureBoxSizeMode.CenterImage;
            transaction2.TabIndex = 1;
            transaction2.TabStop = false;
            // 
            // home2
            // 
            home2.BackgroundImageLayout = ImageLayout.Center;
            home2.Image = Properties.Resources.home_icon;
            home2.Location = new Point(32, 19);
            home2.Name = "home2";
            home2.Size = new Size(46, 36);
            home2.SizeMode = PictureBoxSizeMode.CenterImage;
            home2.TabIndex = 0;
            home2.TabStop = false;
            // 
            // Transaction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(1385, 923);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(totalbalance);
            Controls.Add(totalexpense);
            Controls.Add(totalincome);
            Controls.Add(panel4);
            Controls.Add(Logout);
            Name = "Transaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transaction";
            totalincome.ResumeLayout(false);
            totalexpense.ResumeLayout(false);
            totalbalance.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)categories2).EndInit();
            ((System.ComponentModel.ISupportInitialize)transaction2).EndInit();
            ((System.ComponentModel.ISupportInitialize)home2).EndInit();
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
            titleLabel.Text = "PennyWise Transactions";
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
        private Button Logout;
        private Panel totalincome;
        private Panel totalexpense;
        private Panel totalbalance;
        private Label labelIncome;
        private Label labelExpense;
        private Label labelBalance;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxMonth;
        private ComboBox comboBoxYear;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanelTransactions;
        private Label label1;
        private Panel panel4;
        private Panel panel1;
        private PictureBox transaction2;
        private PictureBox home2;
        private PictureBox categories2;
    }
}

