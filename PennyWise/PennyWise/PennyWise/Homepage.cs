using System;
using System.Collections.Generic;
using System.Drawing;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using PennyWise;

namespace PennyWise
{
    public partial class Homepage : Form
    {
        private User currentUser;
        private IDatabaseManager databaseManager;
        private object buttonBox2;
        private object buttonBox1;

        public int ButtonBoxSize { get; private set; }

        public Homepage(User user)
        {
            InitializeComponent();
            this.currentUser = user;
            this.databaseManager = new MySqlDatabaseManager("127.0.0.1", "pennywise", "root", "");
            this.Logout.BackColor = Color.FromArgb(233, 102, 160);
            
            CustomizeTitleBar();

            DisplayUserSelectedCategories("expense", flowLayoutPanelExpense);
            DisplayUserSelectedCategories("budget", flowLayoutPanelBudget);


            home1.BackgroundImageLayout = ImageLayout.Stretch;
            home1.Size = new Size(60, 60);
            home1.BackColor = Color.Transparent;


            transaction1.BackgroundImageLayout = ImageLayout.Stretch;
            transaction1.Size = new Size(60, 60);
            transaction1.BackColor = Color.Transparent;

            categories1.BackgroundImageLayout = ImageLayout.Stretch;
            categories1.Size = new Size(60, 60);
            categories1.BackColor = Color.Transparent;

            home1.MouseEnter += (sender, e) =>
            {
                home1.Location = new Point(home1.Location.X - 10, home1.Location.Y - 10);
            };

            home1.MouseLeave += (sender, e) =>
            {
                home1.Location = new Point(home1.Location.X + 10, home1.Location.Y + 10);
            };

            transaction1.MouseEnter += (sender, e) =>
            {
                transaction1.Location = new Point(transaction1.Location.X - 10, transaction1.Location.Y - 10);
            };

            transaction1.MouseLeave += (sender, e) =>
            {
                transaction1.Location = new Point(transaction1.Location.X + 10, transaction1.Location.Y + 10);
            };
            categories1.MouseEnter += (sender, e) =>
            {
                categories1.Location = new Point(categories1.Location.X - 10, categories1.Location.Y - 10);
            };

            categories1.MouseLeave += (sender, e) =>
            {
                categories1.Location = new Point(categories1.Location.X + 10, categories1.Location.Y + 10);
            };
            home1.Click += (sender, e) =>
            {
                this.Show();
            };

            transaction1.Click += (sender, e) =>
            {
                this.Hide();
                Transaction transactionForm = new Transaction(currentUser);
                transactionForm.Show();
            };

            categories1.Click += (sender, e) =>
            {
                this.Hide();
                Categories categoriesForm = new Categories(currentUser);
                categoriesForm.Show();
            };

        }

        private void DisplayUserSelectedCategories(string categoryType, FlowLayoutPanel panel)
        {
            List<Category> userSelectedCategories = databaseManager.GetUserSelectedCategories(categoryType, currentUser.UserId);

            panel.Controls.Clear();

            panel.WrapContents = true;
            panel.FlowDirection = FlowDirection.LeftToRight; 

            int panelWidth = panel.ClientSize.Width;
            int panelHeight = panel.ClientSize.Height;
            int columns = 4;
            int rows = 3;
            int buttonWidth = (panelWidth - (columns + 1) * panel.Margin.Horizontal) / columns;
            int buttonHeight = (panelHeight - (rows + 1) * panel.Margin.Vertical) / rows;

            foreach (var category in userSelectedCategories)
            {
                AddCategoryButton(category.CategoryName, categoryType, panel, buttonWidth, buttonHeight);
            }

            panel.AutoScroll = true;
        }


        private void AddCategoryButton(string categoryName, string categoryType, FlowLayoutPanel panel, int width, int height)
        {
            Panel buttonBox = new Panel();
            buttonBox.Size = new Size(width, height);
            buttonBox.Margin = new Padding(8);
            buttonBox.BorderStyle = BorderStyle.FixedSingle; 
            buttonBox.BackColor = Color.White; 

            Button categoryButton = new Button();
            categoryButton.Text = categoryName;
            categoryButton.AutoSize = false;
            categoryButton.TextAlign = ContentAlignment.MiddleCenter;
            categoryButton.Dock = DockStyle.Fill;
            categoryButton.BackColor = Color.Transparent; 

            string capturedCategoryType = categoryType;
            string userId = currentUser.UserId; 
            string categoryId = databaseManager.GetCategoryId(categoryName, categoryType);

            categoryButton.MouseEnter += (sender, e) =>
            {
                categoryButton.BackColor = Color.FromArgb(238, 153, 194); 
            };

            categoryButton.MouseLeave += (sender, e) =>
            {
                categoryButton.BackColor = Color.Transparent; 
            };

            categoryButton.Click += (sender, e) =>
            {
                if (capturedCategoryType == "expense")
                {
                    ExpenseEntryForm expenseEntryForm = new ExpenseEntryForm(userId, categoryId);
                    expenseEntryForm.ShowDialog();
                }
                else if (capturedCategoryType == "budget")
                {
                    IncomeEntryForm incomeEntryForm = new IncomeEntryForm(userId, categoryId); 
                    incomeEntryForm.ShowDialog();
                }
            };

            buttonBox.Controls.Add(categoryButton);
            panel.Controls.Add(buttonBox);
        }


        private void Logout_Click(object sender, EventArgs e)
        {
            currentUser = null;
            LoginSignup loginForm = new LoginSignup();
            loginForm.Show();
            this.Hide();
        }


        private void CustomizeTitleBar()
        {
           
            this.FormBorderStyle = FormBorderStyle.None;

            Panel titleBar = new Panel();
            titleBar.BackColor = Color.FromArgb(247, 65, 143); 
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;

            Label titleLabel = new Label();
            titleLabel.Text = "PennyWise Homepage"; 
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