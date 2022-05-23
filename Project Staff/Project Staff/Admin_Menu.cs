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
    public partial class Admin_Menu : Form
    {
        MySqlConnection conn;
        string connString;
        DataSet dsMenu;
        DataTable dtMenu;

        public Admin_Menu()
        {
            InitializeComponent();

            connectDB();
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

                loadDataGrid();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        public void loadDataGrid()
        {
            string query = "select me_id as 'ID', me_name as 'Name' from menu";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsMenu = new DataSet();
            da.Fill(dsMenu);
            dgvStaff.DataSource = dsMenu.Tables[0].DefaultView;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Admin_Menu_Add admin = new Admin_Menu_Add(0);
            admin.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
