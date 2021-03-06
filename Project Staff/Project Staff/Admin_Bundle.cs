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
    public partial class Admin_Bundle : Form
    {
        MySqlConnection conn;
        string connString;
        DataSet dsBundle;
        public Admin_Bundle()
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
            string query = "select bu_id as 'ID', bu_name as 'Name', bu_price as 'Price' from bundle where bu_status = 1 order by 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsBundle = new DataSet();
            da.Fill(dsBundle);
            dgvStaff.DataSource = dsBundle.Tables[0].DefaultView;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Admin_Bundle_Add admin = new Admin_Bundle_Add(0);
            admin.ShowDialog();
        }

        private void dgvStaff_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIdx = e.RowIndex;

            if (rowIdx < dsBundle.Tables[0].Rows.Count)
            {
                int menu_id = Convert.ToInt32(dgvStaff.Rows[rowIdx].Cells[0].Value.ToString());

                Admin_Bundle_Add admin = new Admin_Bundle_Add(menu_id);
                admin.ShowDialog();
                loadDataGrid();
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            loadDataGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!tbSearch.Text.Equals(""))
            {
                string query = $"select bu_id as 'ID', bu_name as 'Name', bu_price as 'Price' from bundle where bu_status = 1 and bu_name like '%{tbSearch.Text}%' order by 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteReader();
                conn.Close();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dsBundle = new DataSet();
                da.Fill(dsBundle);
                dgvStaff.DataSource = dsBundle.Tables[0].DefaultView;
            }
        }
    }
}
