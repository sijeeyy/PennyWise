namespace PennyWise
{
    partial class Homepage
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
            flowLayoutPanelExpense = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            flowLayoutPanelBudget = new FlowLayoutPanel();
            Logout = new Button();
            panel1 = new Panel();
            categories1 = new PictureBox();
            transaction1 = new PictureBox();
            home1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categories1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transaction1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)home1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelExpense
            // 
            flowLayoutPanelExpense.Location = new Point(235, 129);
            flowLayoutPanelExpense.Name = "flowLayoutPanelExpense";
            flowLayoutPanelExpense.Size = new Size(865, 248);
            flowLayoutPanelExpense.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(74, 77);
            label1.Name = "label1";
            label1.Size = new Size(141, 35);
            label1.TabIndex = 1;
            label1.Text = "Expenses";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Pink;
            label2.Font = new Font("Yu Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 432);
            label2.Name = "label2";
            label2.Size = new Size(113, 35);
            label2.TabIndex = 2;
            label2.Text = "Income";
            // 
            // flowLayoutPanelBudget
            // 
            flowLayoutPanelBudget.Location = new Point(235, 493);
            flowLayoutPanelBudget.Name = "flowLayoutPanelBudget";
            flowLayoutPanelBudget.Size = new Size(865, 248);
            flowLayoutPanelBudget.TabIndex = 3;
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
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(categories1);
            panel1.Controls.Add(transaction1);
            panel1.Controls.Add(home1);
            panel1.Location = new Point(1272, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(101, 229);
            panel1.TabIndex = 5;
            // 
            // categories1
            // 
            categories1.Image = Properties.Resources.categories_icon;
            categories1.Location = new Point(32, 159);
            categories1.Name = "categories1";
            categories1.Size = new Size(46, 36);
            categories1.SizeMode = PictureBoxSizeMode.CenterImage;
            categories1.TabIndex = 2;
            categories1.TabStop = false;
            // 
            // transaction1
            // 
            transaction1.BackgroundImageLayout = ImageLayout.Center;
            transaction1.Image = Properties.Resources.transaction_icon;
            transaction1.Location = new Point(32, 94);
            transaction1.Name = "transaction1";
            transaction1.Size = new Size(46, 36);
            transaction1.SizeMode = PictureBoxSizeMode.CenterImage;
            transaction1.TabIndex = 1;
            transaction1.TabStop = false;
            // 
            // home1
            // 
            home1.BackgroundImageLayout = ImageLayout.Center;
            home1.Image = Properties.Resources.home_icon;
            home1.Location = new Point(32, 19);
            home1.Name = "home1";
            home1.Size = new Size(46, 36);
            home1.SizeMode = PictureBoxSizeMode.CenterImage;
            home1.TabIndex = 0;
            home1.TabStop = false;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(1385, 923);
            Controls.Add(Logout);
            Controls.Add(flowLayoutPanelBudget);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanelExpense);
            Controls.Add(panel1);
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)categories1).EndInit();
            ((System.ComponentModel.ISupportInitialize)transaction1).EndInit();
            ((System.ComponentModel.ISupportInitialize)home1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelExpense;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanelBudget;
        private Button Logout;
        private Panel panel1;
        private PictureBox transaction1;
        private PictureBox home1;
        private PictureBox categories1;
    }
}