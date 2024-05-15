using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PennyWise
{
    public partial class LoginSignup : Form
    {
        private Point lastPoint;
        private DatabaseManager databaseManager;
        private User currentUser;

        public LoginSignup()
        {
            InitializeComponent();
            Initialize();
            txtPassword.PasswordChar = '*';
            CustomizeTitleBar();

        }
        private void Initialize()
        {
            databaseManager = new DatabaseManager("127.0.0.1", "pennywise", "root", "");
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
        private void buttonSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = PasswordHasher.HashPassword(txtPassword.Text);

            int userCount = databaseManager.GetUserCount() + 1000;
            string userId = "PW" + userCount;

            if (databaseManager.UserExists(username))
            {
                MessageBox.Show("Username already exists. Please choose another one.");
            }
            else
            {
                if (databaseManager.InsertUser(userId, username, password))
                {
                    MessageBox.Show("Sign up successful. You can now login.");
                }
                else
                {
                    MessageBox.Show("Failed to sign up. Please try again later.");
                }
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = PasswordHasher.HashPassword(txtPassword.Text);

            if (databaseManager.ValidateUser(username, password))
            {
                string userId = databaseManager.GetUserId(username);

                if (!databaseManager.UserHasSelectedCategories(userId))
                {
                    currentUser = new User
                    {
                        UserId = userId,
                        Username = username
                    };

                    Categories form = new Categories(currentUser);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    currentUser = new User
                    {
                        UserId = userId,
                        Username = username
                    };

                    Homepage homepageForm = new Homepage(currentUser);
                    homepageForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
      
    }
    public class DatabaseManager
    {
        private MySqlConnection connection;

        public DatabaseManager(string server, string database, string uid, string password)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
        public bool UserExists(string username)
        {
            string query = $"SELECT * FROM users WHERE username='{username}'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                bool exists = dataReader.HasRows;
                dataReader.Close();
                CloseConnection();
                return exists;
            }
            else
            {
                return false;
            }
        }
        public string GetUserId(string username)
        {
            string userId = null;
            string query = $"SELECT userid FROM users WHERE username='{username}'";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    userId = result.ToString();
                }

                CloseConnection();
            }

            return userId;
        }
        public bool UserHasSelectedCategories(string userId)
        {
            bool hasSelectedCategories = false;
            string query = $"SELECT COUNT(*) FROM userselectedexpensecategories WHERE userId = '{userId}' " +
                           $"UNION ALL " +
                           $"SELECT COUNT(*) FROM userselectedbudgetcategories WHERE userId = '{userId}'";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int count = Convert.ToInt32(reader[0]);

                    if (count > 0)
                    {
                        hasSelectedCategories = true;
                        break;
                    }
                }

                reader.Close();
                CloseConnection();
            }

            return hasSelectedCategories;
        }
        public bool InsertUser(string userId, string username, string password)
        {
            string query = $"INSERT INTO users (userid, username, password) VALUES ('{userId}', '{username}', '{password}')";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();
                CloseConnection();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateUser(string username, string password)
        {
            string query = $"SELECT * FROM users WHERE username='{username}' AND password='{password}'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                bool exists = dataReader.HasRows;
                dataReader.Close();
                CloseConnection();
                return exists;
            }
            else
            {
                return false;
            }
        }

        public int GetUserCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM users";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                CloseConnection();
            }
            return count;
        }
    }

    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public class User
    {
        public required string UserId { get; set; }
        public required string Username { get; set; }
    }
}
