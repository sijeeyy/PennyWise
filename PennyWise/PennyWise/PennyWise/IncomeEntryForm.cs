using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PennyWise
{
    public partial class IncomeEntryForm : Form
    {
        private MySqlDatabaseManager databaseManager;
        private string userId;
        private string categoryId;

        public IncomeEntryForm(string userId, string categoryId)
        {
            InitializeComponent();
            CustomizeTitleBar(); 
            databaseManager = new MySqlDatabaseManager("127.0.0.1", "pennywise", "root", "");
            this.userId = userId;
            this.categoryId = categoryId;

            submitButton.BackColor = Color.HotPink;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal amount))
            {
                try
                {
                    databaseManager.InsertBudget(amount, dateTimePicker1.Value, textBox2.Text, categoryId, userId);
                    MessageBox.Show("Budget added successfully!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void CustomizeTitleBar()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            Panel titleBar = new Panel();
            titleBar.BackColor = Color.FromArgb(247, 65, 143);
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;

            Label titleLabel = new Label();
            titleLabel.Text = "PennyWise Income Entry";
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FullscreenButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
