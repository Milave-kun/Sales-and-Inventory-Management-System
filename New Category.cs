using Capstone.Message_Boxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Capstone
{
    public partial class New_Category : Form
    {
        string ConnectionString = "server=localhost;port=3306;database=random;user=root;password=";

        public New_Category()
        {
            InitializeComponent();
        }

        // PROFILE VIEWNING
        private void profilePicBox_Click(object sender, EventArgs e)
        {
            new profileAdmin().Show();
        }

        // GO BACK TO DASHBOARD
        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        // CATEGORY DASHBOARD
        private void CategoriesBtn_Click(object sender, EventArgs e)
        {
            new Manage_Cateogory().Show();
            this.Hide();
        }

        // LOGOUT BUTTON
        private void BunifuButton8_Click(object sender, EventArgs e)
        {
            new loginForm().Show();
            this.Hide();
        }

        // GO BACK TO MANAGE CATEGORY FORM
        private void loginBtn_Click(object sender, EventArgs e)
        {
            new Manage_Cateogory().Show();
            this.Hide();
        }

        // ADD CATEGORY BUTTON
        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            string catName = categoryNameTxt.Text.Trim();
            string catDesc = categoryDescTxt.Text.Trim();

            if (catName == "" || catDesc == "")
            {
                MessageBox.Show("Category name and description are required!", "Information Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {
                try
                {
                    MySqlConnection connection = new MySqlConnection(ConnectionString);
                    using (connection)
                    {
                        connection.Open();
                        string query = "INSERT INTO categories(Category_Name, Category_Description)VALUES('" + this.categoryNameTxt.Text + "', '" + this.categoryDescTxt.Text + "')";
                        MySqlConnection conn = new MySqlConnection(ConnectionString);
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader;

                        conn.Open();
                        reader = cmd.ExecuteReader();
                        MessageBox.Show("Added Category!");
                        categoryNameTxt.Clear();
                        categoryDescTxt.Clear();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
