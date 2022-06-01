using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_Staff
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Hide();
            Admin_Staff admin = new Admin_Staff();
            admin.ShowDialog();
            Show();
        }

        private void btnIngredient_Click(object sender, EventArgs e)
        {
            Hide();
            Admin_Ingredient admin = new Admin_Ingredient();
            admin.ShowDialog();
            Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Admin_Menu admin = new Admin_Menu();
            admin.ShowDialog();
            Show();
        }

        private void btnBundle_Click(object sender, EventArgs e)
        {
            Hide();
            Admin_Bundle admin = new Admin_Bundle();
            admin.ShowDialog();
            Show();
        }
    }
}
