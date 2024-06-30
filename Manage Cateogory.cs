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

namespace Capstone
{
    public partial class Manage_Cateogory : Form
    {
        string ConnectionString = "server=localhost;port=3306;database=random;user=root;password=";

        public Manage_Cateogory()
        {
            InitializeComponent();
        }

        // GO BACK TO DASHBOARD 
        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        // CLOSE BOX BUTTON
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // PROFILE VIEWING
        private void profilePicBox_Click(object sender, EventArgs e)
        {
            new profileAdmin().Show();
        }

        // LOGOUT BUTTON
        private void BunifuButton8_Click(object sender, EventArgs e)
        {
            new loginForm().Show();
            this.Hide();
        }

        // NEW CATEGROY FORM
        private void loginBtn_Click(object sender, EventArgs e)
        {
            new New_Category().Show();
        }

        private void Manage_Cateogory_Load(object sender, EventArgs e)
        {
            string query = "SELECT Category_Name, Category_Description FROM categories";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            recentlyAddedDgv.DataSource = dt;
        }
    }
}
