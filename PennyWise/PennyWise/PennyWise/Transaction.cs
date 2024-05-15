using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Transactions;
using System.Windows.Forms;

namespace PennyWise
{
    public partial class Transaction : Form
    {
        private User currentUser;
        private IDatabaseManager databaseManager;

        public Transaction(User user)
        {
            CustomizeTitleBar();
            InitializeComponent();
            this.currentUser = user;
            this.databaseManager = new MySqlDatabaseManager("127.0.0.1", "pennywise", "root", "");
            PopulateComboBoxes();
            comboBoxMonth.SelectedIndexChanged += comboBoxMonth_SelectedIndexChanged;
            comboBoxYear.SelectedIndexChanged += comboBoxYear_SelectedIndexChanged;

            home2.Click += (sender, e) =>
            {
                this.Hide();
                Homepage homepageForm = new Homepage(currentUser);
                homepageForm.Show();
            };

            transaction2.Click += (sender, e) =>
            {
                this.Show();
            };
            home2.MouseEnter += (sender, e) =>
            {
                home2.Location = new Point(home2.Location.X - 10, home2.Location.Y - 10);
            };

            home2.MouseLeave += (sender, e) =>
            {
                home2.Location = new Point(home2.Location.X + 10, home2.Location.Y + 10);
            };

            transaction2.MouseEnter += (sender, e) =>
            {
                transaction2.Location = new Point(transaction2.Location.X - 10, transaction2.Location.Y - 10);
            };

            transaction2.MouseLeave += (sender, e) =>
            {
                transaction2.Location = new Point(transaction2.Location.X + 10, transaction2.Location.Y + 10);
            };

            categories2.MouseEnter += (sender, e) =>
            {
                categories2.Location = new Point(categories2.Location.X - 10, categories2.Location.Y - 10);
            };

            categories2.MouseLeave += (sender, e) =>
            {
                categories2.Location = new Point(categories2.Location.X + 10, categories2.Location.Y + 10);
            };

            categories2.Click += (sender, e) =>
            {
                this.Hide();
                Categories categoriesForm = new Categories(currentUser);
                categoriesForm.Show();
            };

            DisplayTransactions();
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

        private void PopulateComboBoxes()
        {
            string[] months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            comboBoxMonth.Items.AddRange(months);

            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 5; year--)
            {
                comboBoxYear.Items.Add(year);
            }

            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1; 
            comboBoxYear.SelectedItem = currentYear; 
        }
        private void DisplayTransactions()
        {
            flowLayoutPanelTransactions.Controls.Clear();
            if (currentUser != null && comboBoxMonth.SelectedItem != null && comboBoxYear.SelectedItem != null)
            {
                int month = comboBoxMonth.SelectedIndex + 1;
                int year = Convert.ToInt32(comboBoxYear.SelectedItem);

                List<TransactionDetails> transactions = databaseManager.GetTransactions(year, month, currentUser.UserId);
                transactions.Sort((t1, t2) => t2.Date.CompareTo(t1.Date));

                decimal totalIncome = 0;
                decimal totalExpense = 0;

                foreach (var transaction in transactions)
                {
                    if (transaction.TransactionID.StartsWith("BU"))
                    {
                        totalIncome += transaction.Amount;
                    }
                    else if (transaction.TransactionID.StartsWith("EX"))
                    {
                        totalExpense += Math.Abs(transaction.Amount);
                    }
                }

                decimal totalBalance = totalIncome - totalExpense;

                labelIncome.Text = $" ₱{totalIncome}";
                labelExpense.Text = $" ₱{totalExpense}";
                labelBalance.Text = $" ₱{totalBalance}";

                Dictionary<DateTime, List<TransactionDetails>> transactionsByDate = new Dictionary<DateTime, List<TransactionDetails>>();

                foreach (var transaction in transactions)
                {
                    DateTime transactionDate = transaction.Date.Date; 

                    if (!transactionsByDate.ContainsKey(transactionDate))
                    {
                        transactionsByDate[transactionDate] = new List<TransactionDetails>();
                    }

                    transactionsByDate[transactionDate].Add(transaction);
                }
;
                flowLayoutPanelTransactions.AutoScroll = true;
                flowLayoutPanelTransactions.FlowDirection = FlowDirection.TopDown; 
                flowLayoutPanelTransactions.WrapContents = false;

                foreach (var date in transactionsByDate.Keys)
                {
                    TableLayoutPanel dateTable = new TableLayoutPanel();
                    dateTable.AutoSize = true; 
                    dateTable.AutoSizeMode = AutoSizeMode.GrowOnly; 
                    dateTable.BackColor = Color.FromArgb(224, 224, 224);
                    dateTable.Padding = new Padding(50, 0, 100, 20);

                    flowLayoutPanelTransactions.Controls.Add(dateTable);

                    Control yourControl = new Control(); 
                    yourControl.Dock = DockStyle.Fill; 
                    dateTable.Controls.Add(yourControl); 

                    Label dateLabel = new Label();
                    dateLabel.AutoSize = true;
                    dateLabel.Font = new Font(dateLabel.Font, FontStyle.Bold);
                    dateLabel.Text = date.ToShortDateString();
                    dateLabel.BackColor = Color.FromArgb(253, 229, 236); 
                    dateLabel.Padding = new Padding(100, 5, 100, 5); 
                    dateLabel.Margin = new Padding(10, 10, 10, 10); 

                    dateTable.Controls.Add(dateLabel, 0, 0);

                    FlowLayoutPanel labelPanel = new FlowLayoutPanel();
                    labelPanel.FlowDirection = FlowDirection.LeftToRight;
                    labelPanel.AutoSize = true;
                    labelPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right; 

                    decimal dateTotalIncome = 0;
                    decimal dateTotalExpense = 0;

                    foreach (var transaction in transactionsByDate[date])
                    {
                        if (transaction.TransactionID.StartsWith("BU"))
                        {
                            dateTotalIncome += transaction.Amount;
                        }
                        else if (transaction.TransactionID.StartsWith("EX"))
                        {
                            dateTotalExpense += Math.Abs(transaction.Amount); 
                        }
                    }

                    Label incomeLabel = new Label();
                    incomeLabel.AutoSize = true;
                    incomeLabel.Text = $"IN: ₱{dateTotalIncome}";
                    incomeLabel.Margin = new Padding(250, 0, 0, 0);
                    incomeLabel.ForeColor = Color.FromArgb(51, 93, 45);
                    incomeLabel.Font = new Font("Arial", 11, FontStyle.Bold);

                    labelPanel.Controls.Add(incomeLabel); 

                    Label expenseLabel = new Label();
                    expenseLabel.AutoSize = true;
                    expenseLabel.Text = $"OUT: ₱{dateTotalExpense}";
                    expenseLabel.ForeColor = Color.FromArgb(183, 4, 4);
                    expenseLabel.Margin = new Padding(250, 0, 0, 0);
                    expenseLabel.Font = new Font("Arial", 11, FontStyle.Bold);

                    labelPanel.Controls.Add(expenseLabel);
                    dateTable.Controls.Add(labelPanel, 1, 0); 

                    FlowLayoutPanel transactionPanel = new FlowLayoutPanel();
                    transactionPanel.FlowDirection = FlowDirection.TopDown;
                    transactionPanel.AutoSize = true; 

                    foreach (var transaction in transactionsByDate[date])
                    {
                        Label transactionLabel1 = new Label();
                        transactionLabel1.AutoSize = true;
                        transactionLabel1.Text = $"{transaction.CategoryName}";
                        transactionLabel1.Font = new Font("Arial", 10, FontStyle.Bold);
                        transactionLabel1.Padding = new Padding(0, 0, 20, 0); 

                        transactionPanel.Controls.Add(transactionLabel1);

                        Label transactionLabel = new Label();
                        transactionLabel.AutoSize = true;
                        transactionLabel.Text = $"{transaction.Description} - ₱{transaction.Amount}";
                        transactionLabel.Padding = new Padding(0, 0, 20, 0); 

                        if (transaction.TransactionID.StartsWith("EX"))
                        {
                            transactionLabel.ForeColor = Color.FromArgb(183, 4, 4); 
                            transactionLabel.Font = new Font("Arial", 10, FontStyle.Bold); 
                        }
                        else if (transaction.TransactionID.StartsWith("BU"))
                        {
                            transactionLabel.ForeColor = Color.FromArgb(34, 177, 76);
                            transactionLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                        }

                        transactionPanel.Controls.Add(transactionLabel);

                        TableLayoutPanel buttonLayoutPanel = new TableLayoutPanel();

                        buttonLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); 
                        buttonLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                        Button editButton = new Button();
                        editButton.Text = "Edit";
                        editButton.Tag = transaction;
                        editButton.Click += EditButton_Click;
                        editButton.Size = new Size(152, 40);
                        editButton.BackColor = Color.FromArgb(233, 102, 160);

                        Button deleteButton = new Button();
                        deleteButton.Text = "Delete";
                        deleteButton.Tag = transaction;
                        deleteButton.Click += DeleteButton_Click;
                        deleteButton.Size = new Size(152, 40);
                        deleteButton.BackColor = Color.FromArgb(233, 102, 160);

                        buttonLayoutPanel.Controls.Add(editButton, 0, 0); 
                        buttonLayoutPanel.Controls.Add(deleteButton, 1, 0); 

                        transactionPanel.Controls.Add(buttonLayoutPanel);
                    }

                    dateTable.Controls.Add(transactionPanel, 0, 1); 

                    flowLayoutPanelTransactions.Controls.Add(dateTable);
                }
            }
            else
            {
                MessageBox.Show("No transactions found for the selected month and year.", "Information");

                labelIncome.Text = "Total Income: ₱0";
                labelExpense.Text = "Total Expense: ₱0";
                labelBalance.Text = "Balance: ₱0";
            }
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
            Button editButton = (Button)sender;
            TransactionDetails transaction = (TransactionDetails)editButton.Tag;

            EditDetails editForm = new EditDetails(transaction);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                TransactionDetails updatedTransaction = editForm.GetEditedTransaction();

                bool updated = UpdateTransaction(updatedTransaction);

                if (updated)
                {
                    MessageBox.Show("Transaction updated successfully.", "Information");
                   
                    DisplayTransactions();
                }
                else
                {
                    MessageBox.Show("Failed to update the transaction.", "Error");
                }
            }
        }



        private bool UpdateTransaction(TransactionDetails updatedTransaction)
        {
            try
            {
                if (updatedTransaction.TransactionID.StartsWith("EX"))
                {
                    
                    databaseManager.UpdateExpense(
                        updatedTransaction.TransactionID, 
                        updatedTransaction.Amount,       
                        updatedTransaction.Date,          
                        updatedTransaction.Description,   
                        updatedTransaction.CategoryName   
                    );
                }
                else if (updatedTransaction.TransactionID.StartsWith("BU"))
                {
                    databaseManager.UpdateBudget(
                        updatedTransaction.TransactionID,
                        updatedTransaction.Amount,        
                        updatedTransaction.Date,          
                        updatedTransaction.Description,  
                        updatedTransaction.CategoryName   
                    );
                }

                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating transaction: {ex.Message}");
                return false; 
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            TransactionDetails transaction = (TransactionDetails)deleteButton.Tag;

            bool deleted = databaseManager.DeleteTransaction(transaction.TransactionID);

            if (deleted)
            {
                MessageBox.Show("Transaction deleted successfully.", "Information");
            
                DisplayTransactions();
            }
            else
            {
                MessageBox.Show("Failed to delete the transaction.", "Error");
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTransactions();
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTransactions();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            currentUser = null;
            LoginSignup loginForm = new LoginSignup();
            loginForm.Show();
            this.Hide();
        }
    }

    public class TransactionDetails
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }
        public string TransactionID { get; set; }  

        public TransactionDetails(string description, decimal amount, DateTime transactionDate, string categoryName, string transactionID)
        {
            Description = description;
            Amount = amount;
            Date = transactionDate;
            CategoryName = categoryName;
            TransactionID = transactionID;
        }
    }

}

