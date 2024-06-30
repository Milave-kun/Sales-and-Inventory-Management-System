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

namespace Capstone.Message_Boxes
{
    public partial class profileAdmin : Form
    {
        string ConnectionString = "server=localhost;port=3306;database=random;user=root;password=";
        public profileAdmin()
        {
            InitializeComponent();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Dashboard().Hide();
        }
    }
}
