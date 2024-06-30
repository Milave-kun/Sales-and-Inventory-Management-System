using Capstone.Message_Boxes;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capstone
{
    public partial class Dashboard : Form
    {
        // STRING CONNECTION DATABASE
        string ConnectionString = "server=localhost;port=3306;database=random;user=root;password=";

        public Dashboard()
        {
            InitializeComponent();
        }

        //PROFILE VIEWING
        private void profilePicBox_Click(object sender, EventArgs e)
        {
            new profileAdmin().Show();
        }

        //GO TO CATEGORIES DASHBOARD
        private void CategoriesBtn_Click(object sender, EventArgs e)
        {
            new Manage_Cateogory().Show();
            this.Hide();
        }

        // LOGOUT BUTTON
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            new loginForm().Show();
            this.Hide();
        }
    }
}
