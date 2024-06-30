using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Capstone.Message_Boxes;
using Guna.UI.WinForms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Capstone
{
    public partial class loginForm : Form
    {
        // Global connection string for MySQL database
        string connectionString = "server=localhost;port=3306;database=random;user=root;password=";

        // Declare global variables for MySQL command, data adapter, and data table
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable dt;

        public loginForm()
        {
            InitializeComponent();
        }

        // LOGIN BUTTON
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login();
        }

        // PUBLIC LOGIN CODE FUNCTION
        public void Login()
        {
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Username and Password are required!", "Information Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Using statement to ensure MySqlConnection is disposed properly
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Open the database connection
                        conn.Open();

                        // SQL query to select username and password from users table
                        string query = "SELECT username, password FROM users WHERE username = @uname AND password = @password LIMIT 1";

                        // Using statement to ensure MySqlCommand is disposed properly
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Add parameters to the SQL query to prevent SQL injection
                            cmd.Parameters.AddWithValue("@uname", username);
                            cmd.Parameters.AddWithValue("@password", password);

                            // Initialize MySqlDataAdapter with the command
                            adapter = new MySqlDataAdapter(cmd);

                            // Initialize DataTable to hold query results
                            dt = new DataTable();

                            // Fill DataTable with query results
                            adapter.Fill(dt);

                            // Check if any rows are returned (i.e., if the login credentials are valid)
                            if (dt.Rows.Count > 0)
                            {
                                // If valid, show the owner's login form and hide the current form
                                // MessageBox.Show("Logged In Successfully!", "Welcome to Soothing Cafe - Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                new ownerLogin().Show();
                                this.Hide();
                            }
                            else
                            {
                                // If invalid, show an error message and clear the input fields
                                MessageBox.Show("INVALID INFORMATION", "Login Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                usernameTxt.Clear();
                                passwordTxt.Clear();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Show any exception messages in a message box
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        // Ensure the connection is closed even if an exception occurs
                        conn.Close();
                    }
                }
            }
        }
    }
}
