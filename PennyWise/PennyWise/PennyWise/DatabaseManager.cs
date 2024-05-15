using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;

namespace PennyWise
{
    public interface IDatabaseManager
    {
        List<Category> GetCategories(string categoryType, string userId);
        string GetCategoryId(string categoryName, string categoryType);
        void InsertCategory(string categoryId, string categoryName, string categoryType);
        void InsertUserSelectedCategory(string selectionId, string categoryId, string userSelectedTable, string userId);
        int GetCategoryCount(string categoryType);
        int GetSelectionCount(string userSelectedTable);
        List<Category> GetUserSelectedCategories(string categoryType, string userId);
        void InsertExpense(decimal amount, DateTime expenseDate, string description, string categoryId, string userId);
        void InsertBudget(decimal amount, DateTime budgetDate, string description, string categoryId, string userId);
        List<TransactionDetails> GetTransactions(int year, int month, string userId);
        List<TransactionDetails> GetBudgetTransactions(int year, int month, string userId);
        List<TransactionDetails> GetExpenseTransactions(int year, int month, string userId);
        bool DeleteTransaction(string transactionId);
        void UpdateExpense(string expenseId, decimal amount, DateTime expenseDate, string description, string categoryId);
        void UpdateBudget(string budgetId, decimal amount, DateTime budgetDate, string description, string categoryId);
    }

    public class MySqlDatabaseManager : IDatabaseManager
    {
        private MySqlConnection connection;
        private string connectionString;

        public MySqlDatabaseManager(string server, string database, string uid, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};";
        }

        public List<Category> GetCategories(string categoryType, string userId)
        {
            List<Category> categories = new List<Category>();

            string query = $"SELECT categoryid, category_name FROM {categoryType}_category " +
                           $"WHERE category_type = 'predefined' " +
                           $"AND categoryid NOT IN " +
                           $"(SELECT categoryid FROM userselected{categoryType}categories WHERE userid = @UserId)";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Category category = new Category
                    {
                        CategoryId = dataReader["categoryid"].ToString(),
                        CategoryName = dataReader["category_name"].ToString()
                    };

                    categories.Add(category);
                }

                dataReader.Close();
                CloseConnection();
            }

            return categories;
        }


        public string GetCategoryId(string categoryName, string categoryType)
        {
            string categoryId = null;

            string query = $"SELECT categoryid FROM {categoryType}_category WHERE category_name = @CategoryName";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    categoryId = result.ToString();
                }

                CloseConnection();
            }

            return categoryId;
        }

        public void InsertCategory(string categoryId, string categoryName, string categoryType)
        {
            string query = $"INSERT INTO {categoryType}_category (categoryid, category_name, category_type) " +
                           $"VALUES (@CategoryId, @CategoryName, 'user-added')";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void InsertUserSelectedCategory(string selectionId, string categoryId, string userSelectedTable, string userId)
        {
            string query = $"INSERT INTO {userSelectedTable} (selectionid, categoryid, userid) " +
                           $"VALUES (@SelectionId, @CategoryId, @UserId)";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SelectionId", selectionId);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public int GetCategoryCount(string categoryType)
        {
            int count = 0;

            string query = $"SELECT COUNT(*) FROM {categoryType}_category";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                CloseConnection();
            }

            return count;
        }

        public int GetSelectionCount(string userSelectedTable)
        {
            int count = 0;

            string query = $"SELECT COUNT(*) FROM {userSelectedTable}";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                CloseConnection();
            }

            return count;
        }
        public List<Category> GetUserSelectedCategories(string categoryType, string userId)
        {
            List<Category> userSelectedCategories = new List<Category>();

            string userSelectedTable = (categoryType == "expense") ? "userselectedexpensecategories" : "userselectedbudgetcategories";

            string query = $"SELECT c.categoryid, c.category_name " +
                           $"FROM {userSelectedTable} u " +
                           $"INNER JOIN {categoryType}_category c ON u.categoryid = c.categoryid " +
                           $"WHERE u.userid = @UserId";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Category category = new Category
                    {
                        CategoryId = dataReader["categoryid"].ToString(),
                        CategoryName = dataReader["category_name"].ToString()
                    };

                    userSelectedCategories.Add(category);
                }

                dataReader.Close();
                CloseConnection();
            }

            return userSelectedCategories;
        }

        public void InsertExpense(decimal amount, DateTime expenseDate, string description, string categoryId, string userId)
        {
            string expenseId = GenerateExpenseId();

            string query = "INSERT INTO Expenses (ExpenseID, CategoryID, UserID, Description, Amount, Expense_Date) " +
                           "VALUES (@ExpenseID, @CategoryID, @UserID, @Description, @Amount, @ExpenseDate)";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ExpenseID", expenseId);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@ExpenseDate", expenseDate);

                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void InsertBudget(decimal amount, DateTime budgetDate, string description, string categoryId, string userId)
        {
            string budgetId = GenerateBudgetId();

            string query = "INSERT INTO Budgets (BudgetID, CategoryID, UserID, Description, Amount, Budget_Date) " +
                           "VALUES (@BudgetID, @CategoryID, @UserID, @Description, @Amount, @BudgetDate)";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BudgetID", budgetId);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@BudgetDate", budgetDate);

                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        private bool OpenConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error opening database connection: {ex.Message}");
                return false;
            }
        }

        private void CloseConnection()
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error closing database connection: {ex.Message}");
            }
        }
        private string GenerateExpenseId()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(ExpenseID, 3) AS UNSIGNED)) AS MaxId FROM Expenses";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                object result = cmd.ExecuteScalar();
                CloseConnection();

                if (result != null && result != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(result);
                    return "EX" + (maxId + 1).ToString();
                }
            }

            return "EX1000"; 
        }

        private string GenerateBudgetId()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(BudgetID, 3) AS UNSIGNED)) AS MaxId FROM Budgets";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                object result = cmd.ExecuteScalar();
                CloseConnection();

                if (result != null && result != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(result);
                    return "BU" + (maxId + 1).ToString();
                }
            }

            return "BU1000"; 
        }
        public List<TransactionDetails> GetTransactions(int year, int month, string userId)
        {
            List<TransactionDetails> transactions = new List<TransactionDetails>();

            try
            {
                List<TransactionDetails> expenseTransactions = GetExpenseTransactions(year, month, userId);
                transactions.AddRange(expenseTransactions);

                List<TransactionDetails> budgetTransactions = GetBudgetTransactions(year, month, userId);
                transactions.AddRange(budgetTransactions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return transactions;
        }

        public List<TransactionDetails> GetExpenseTransactions(int year, int month, string userId)
        {
            List<TransactionDetails> transactions = new List<TransactionDetails>();

            string query = @"SELECT e.Description, e.Amount, e.Expense_Date, c.category_name, e.ExpenseID
                 FROM Expenses e
                 JOIN expense_category c ON e.CategoryID = c.categoryid
                 WHERE YEAR(e.Expense_Date) = @Year
                 AND MONTH(e.Expense_Date) = @Month
                 AND e.UserID = @UserId";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@UserId", userId);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string description = dataReader["Description"].ToString();
                    decimal amount = Convert.ToDecimal(dataReader["Amount"]);
                    DateTime expenseDate = Convert.ToDateTime(dataReader["Expense_Date"]);
                    string categoryName = dataReader["category_name"].ToString();

                    string expenseId = dataReader["ExpenseID"].ToString();
                    if (!string.IsNullOrEmpty(expenseId))
                    {
                        TransactionDetails transaction = new TransactionDetails(description, amount, expenseDate, categoryName, expenseId);
                        transactions.Add(transaction);
                    }

                }
                dataReader.Close();
                CloseConnection();
            }

            return transactions;
        }
        public List<TransactionDetails> GetBudgetTransactions(int year, int month, string userId)
        {
            List<TransactionDetails> transactions = new List<TransactionDetails>();
            string query = @"SELECT b.Description, b.Amount, b.Budget_Date, c.category_name, b.BudgetID
                 FROM Budgets b
                 JOIN budget_category c ON b.CategoryID = c.categoryid
                 WHERE YEAR(b.Budget_Date) = @Year
                 AND MONTH(b.Budget_Date) = @Month
                 AND b.UserID = @UserId";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@UserId", userId);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string description = dataReader["Description"].ToString();
                    decimal amount = Convert.ToDecimal(dataReader["Amount"]);
                    DateTime budgetDate = Convert.ToDateTime(dataReader["Budget_Date"]);
                    string categoryName = dataReader["category_name"].ToString();
                    string budgetId = dataReader["BudgetID"].ToString();
                    if (!string.IsNullOrEmpty(budgetId))
                    {
                        TransactionDetails transaction = new TransactionDetails(description, amount, budgetDate, categoryName, budgetId);
                        transactions.Add(transaction);
                    }
                }

                dataReader.Close();
                CloseConnection();
            }

            return transactions;
        }
        public bool DeleteTransaction(string transactionId)
        {
            bool deleted = false;

            try
            {
                if (OpenConnection())
                {
                    string deleteExpenseQuery = "DELETE FROM Expenses WHERE ExpenseID = @ExpenseId";
                    MySqlCommand deleteExpenseCmd = new MySqlCommand(deleteExpenseQuery, connection);
                    deleteExpenseCmd.Parameters.AddWithValue("@ExpenseId", transactionId);
                    int expenseRowsAffected = deleteExpenseCmd.ExecuteNonQuery();

                    string deleteBudgetQuery = "DELETE FROM Budgets WHERE BudgetID = @BudgetId";
                    MySqlCommand deleteBudgetCmd = new MySqlCommand(deleteBudgetQuery, connection);
                    deleteBudgetCmd.Parameters.AddWithValue("@BudgetId", transactionId);
                    int budgetRowsAffected = deleteBudgetCmd.ExecuteNonQuery();

                    if (expenseRowsAffected > 0 || budgetRowsAffected > 0)
                    {
                        deleted = true;
                    }

                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting transaction: {ex.Message}");
            }

            return deleted;
        }

        public void UpdateExpense(string expenseId, decimal amount, DateTime expenseDate, string description, string categoryId)
        {
            string query = "UPDATE Expenses " +
                           "SET Amount = @Amount, Expense_Date = @ExpenseDate, Description = @Description " +
                           "WHERE ExpenseID = @ExpenseId";
            try
            {
                if (OpenConnection())
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ExpenseId", expenseId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@ExpenseDate", expenseDate);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateBudget(string budgetId, decimal amount, DateTime budgetDate, string description, string categoryId)
        {
            string query = "UPDATE Budgets " +
                           "SET Amount = @Amount, Budget_Date = @BudgetDate, Description = @Description " +
                           "WHERE BudgetID = @BudgetId";
            try
            {
                if (OpenConnection())
                {
                    

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@BudgetId", budgetId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@BudgetDate", budgetDate);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    CloseConnection();

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating budget: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}