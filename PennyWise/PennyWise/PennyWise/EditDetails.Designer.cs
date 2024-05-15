namespace PennyWise
{
    partial class EditDetails
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
            descriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            amountLabel = new Label();
            amountTextBox = new TextBox();
            saveButton = new Button();
            transactionDateTimePicker = new DateTimePicker();
            label1 = new Label();
            SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(22, 108);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(88, 20);
            descriptionLabel.TabIndex = 0;
            descriptionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(129, 105);
            descriptionTextBox.Margin = new Padding(3, 4, 3, 4);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(261, 27);
            descriptionTextBox.TabIndex = 1;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(45, 157);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(65, 20);
            amountLabel.TabIndex = 2;
            amountLabel.Text = "Amount:";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(129, 157);
            amountTextBox.Margin = new Padding(3, 4, 3, 4);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(100, 27);
            amountTextBox.TabIndex = 3;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(233, 102, 160);
            saveButton.Location = new Point(157, 293);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(126, 39);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click_1;
            // 
            // transactionDateTimePicker
            // 
            transactionDateTimePicker.CalendarMonthBackground = Color.HotPink;
            transactionDateTimePicker.Location = new Point(129, 208);
            transactionDateTimePicker.Name = "transactionDateTimePicker";
            transactionDateTimePicker.Size = new Size(274, 27);
            transactionDateTimePicker.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 213);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 6;
            label1.Text = "Date:";
            // 
            // EditDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(466, 376);
            Controls.Add(transactionDateTimePicker);
            Controls.Add(saveButton);
            Controls.Add(amountTextBox);
            Controls.Add(amountLabel);
            Controls.Add(descriptionTextBox);
            Controls.Add(descriptionLabel);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditDetails";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Transaction Details";
            ResumeLayout(false);
            PerformLayout();
        }

        private void CustomizeTitleBar()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            Panel titleBar = new Panel();
            titleBar.BackColor = Color.FromArgb(247, 65, 143); 
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;


            Label titleLabel = new Label();
            titleLabel.Text = "PennyWise Edit Transactions"; 
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

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button saveButton;
        private DateTimePicker transactionDateTimePicker;
        private Label label1;
    }
}

