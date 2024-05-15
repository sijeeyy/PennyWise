namespace PennyWise
{
    partial class Categories
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
            label1 = new Label();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            Save = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(92, 61);
            label1.Name = "label1";
            label1.Size = new Size(144, 36);
            label1.TabIndex = 1;
            label1.Text = "Expenses";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(92, 493);
            label2.Name = "label2";
            label2.Size = new Size(115, 36);
            label2.TabIndex = 8;
            label2.Text = "Income";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(159, 97);
            flowLayoutPanel1.Margin = new Padding(0, 0, 0, 10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1055, 372);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(159, 543);
            flowLayoutPanel2.Margin = new Padding(0, 50, 0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1055, 236);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // Save
            // 
            Save.BackColor = Color.FromArgb(233, 102, 160);
            Save.Font = new Font("Yu Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Save.ForeColor = Color.White;
            Save.Location = new Point(1109, 830);
            Save.Name = "Save";
            Save.Size = new Size(146, 57);
            Save.TabIndex = 13;
            Save.Text = "SAVE";
            Save.UseVisualStyleBackColor = false;
            Save.Click += Save_Click;
            // 
            // Categories
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(1385, 923);
            Controls.Add(Save);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Name = "Categories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categories";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button Save;
    }
}

