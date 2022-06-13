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
        MySqlConnection conn;
        string connString;
        DataSet dsTransaction;
        DataTable dtTransaction;

        public Admin()
        {
            InitializeComponent();

            connectDB();
            dgvTransaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string query = "select ht_id as 'ID', ht_invoice as 'Invoice', ht_total as 'Total', ht_date as 'Date' from htrans where ht_status = 1 order by 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsTransaction = new DataSet();
            da.Fill(dsTransaction);
            dgvTransaction.DataSource = dsTransaction.Tables[0].DefaultView;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dateFinish.Value >= dateStart.Value)
            {
                string startDate = dateStart.Value.ToString("yyyy-MM-dd");
                string finishDate = dateFinish.Value.ToString("yyyy-MM-dd");

                string query = $"select ht_id as 'ID', ht_invoice as 'Invoice', ht_total as 'Total', ht_date as 'Date' from htrans where ht_status = 1 and ht_date between '{startDate}' and '{finishDate}' order by 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteReader();
                conn.Close();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dsTransaction = new DataSet();
                da.Fill(dsTransaction);
                dgvTransaction.DataSource = dsTransaction.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("Tanggal ke-2 harus lebih kecil!");
            }
        }

        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIdx = e.RowIndex;

      

            if (rowIdx < dsTransaction.Tables[0].Rows.Count)
            {
                CrystalReport1 rpt = new CrystalReport1();
                rpt.SetDatabaseLogon("root", "", "localhost", "project_pcs");
                rpt.SetParameterValue("htransid", Convert.ToInt32(dgvTransaction.Rows[rowIdx].Cells[0].Value.ToString()));
                FormReport reportt = new FormReport(rpt);
                reportt.ShowDialog();
                Show();




            }
        }
    }
}
