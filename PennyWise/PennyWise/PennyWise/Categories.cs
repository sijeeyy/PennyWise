using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PennyWise
{
    public partial class Categories : Form
    {
        private User currentUser;
        private IDatabaseManager databaseManager;

        public Categories(User user)
        {
            InitializeComponent();
            this.currentUser = user;
            this.databaseManager = new MySqlDatabaseManager("127.0.0.1", "pennywise", "root", "");

            DisplayCategories("expense", flowLayoutPanel1);
            DisplayCategories("budget", flowLayoutPanel2);
            CustomizeTitleBar(); 
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
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void DisplayCategories(string categoryType, FlowLayoutPanel panel)
        {
            List<Category> categories = databaseManager.GetCategories(categoryType, currentUser.UserId);

            foreach (var category in categories)
            {
                AddCategoryCheckBox(category.CategoryName, panel);
            }

            Button btnAddCategory = new Button();
            btnAddCategory.Text = "+";
            btnAddCategory.AutoSize = true;
            btnAddCategory.BackColor = Color.FromArgb(233, 102, 160); 
            btnAddCategory.ForeColor = Color.White; 
            btnAddCategory.FlatStyle = FlatStyle.Flat; 
            btnAddCategory.FlatAppearance.BorderSize = 0;
            btnAddCategory.Padding = new Padding(10, 15, 15, 15);
            btnAddCategory.Margin = new Padding(110, 20, 110, 0);
            btnAddCategory.Width = 110;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.WrapContents = true;
            btnAddCategory.Click += (sender, e) =>
            {
                TextBox textBox = new TextBox();
                textBox.BackColor = Color.LightGray;
                textBox.ForeColor = Color.Black; 
                textBox.Font = new Font("Arial", 15); 
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Width = 310; 
                textBox.Margin = new Padding(15, 30, 10, 10);
                panel.Controls.Add(textBox);
            };
            panel.Controls.Add(btnAddCategory);
        }

        private void AddCategoryCheckBox(string category, FlowLayoutPanel panel)
        {
            
            CheckBox checkBox = new CheckBox();
            checkBox.Text = category;
            checkBox.AutoSize = false; 
            checkBox.Size = new Size(80, 80); 
            checkBox.Font = new Font("Arial", 12); 
            checkBox.ForeColor = Color.FromArgb(64, 64, 64);
            checkBox.BackColor = Color.White; 
            checkBox.Padding = new Padding(10, 5, 50, 5); 
            checkBox.Margin = new Padding(10); 
            checkBox.TextAlign = ContentAlignment.MiddleCenter;
          
            checkBox.FlatStyle = FlatStyle.Flat; 
            checkBox.FlatAppearance.BorderColor = Color.FromArgb(189, 189, 189); 
            checkBox.FlatAppearance.CheckedBackColor = Color.FromArgb(247, 65, 143); 

            panel.Controls.Add(checkBox);

            panel.Controls.Add(checkBox);

            checkBox.CheckedChanged += (sender, e) =>
            {
                
                if (checkBox.Checked)
                {
                    checkBox.ForeColor = Color.FromArgb(233, 102, 160); 
                }
                else
                {
                    
                    checkBox.ForeColor = Color.FromArgb(64, 64, 64); 
                }
            };

            
            panel.Controls.Add(checkBox);

            panel.WrapContents = true; 
            panel.AutoScroll = true;

         
            int columns = 3;
            int availableWidth = panel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth; 
            int checkBoxWidth = (availableWidth - (columns + 1) * checkBox.Margin.Horizontal) / columns;
            checkBox.Size = new Size(checkBoxWidth, checkBox.Height); 

            panel.HorizontalScroll.Enabled = false;
            panel.HorizontalScroll.Visible = false;
        }





        private void Save_Click(object sender, EventArgs e)
        {
            SaveSelectedCategories(flowLayoutPanel1, "expense", "userselectedexpensecategories");
            SaveSelectedCategories(flowLayoutPanel2, "budget", "userselectedbudgetcategories");

            this.Close();

            Homepage homepageForm = new Homepage(currentUser);
            homepageForm.Show();
        }

        private void SaveSelectedCategories(FlowLayoutPanel panel, string categoryType, string userSelectedTable)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    string categoryName = checkBox.Text;
                    string categoryId = databaseManager.GetCategoryId(categoryName, categoryType);

                    if (!string.IsNullOrEmpty(categoryId))
                    {
                        InsertUserSelectedCategory(userSelectedTable, categoryId);
                    }
                }
                else if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string categoryName = textBox.Text;

                    int categoryCount = databaseManager.GetCategoryCount(categoryType) + 1000;
                    string categoryId = (categoryType == "expense") ? $"CY{categoryCount}" : $"BY{categoryCount}";

                    databaseManager.InsertCategory(categoryId, categoryName, categoryType);
                    InsertUserSelectedCategory(userSelectedTable, categoryId);
                }
            }
        }

        private void InsertUserSelectedCategory(string userSelectedTable, string categoryId)
        {
            string categoryType = (userSelectedTable == "userselectedexpensecategories") ? "ES" : "BS";

            int selectionCount = databaseManager.GetSelectionCount(userSelectedTable) + 1000;
            string selectionId = $"{categoryType}{selectionCount}";

            databaseManager.InsertUserSelectedCategory(selectionId, categoryId, userSelectedTable, currentUser.UserId);
        }

        
        private void CustomizeTitleBar()
        {
           
            this.FormBorderStyle = FormBorderStyle.None;

           
            Panel titleBar = new Panel();
            titleBar.BackColor = Color.FromArgb(247, 65, 143); 
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;


            Label titleLabel = new Label();
            titleLabel.Text = "PennyWise Categories"; 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class ExpenseCategory : Category
    {
        public string CategoryType { get; } = "expense";
    }

    public class BudgetCategory : Category
    {
        public string CategoryType { get; } = "budget";
    }
}

