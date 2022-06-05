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
    public partial class Kitchen : Form
    {
        MySqlConnection conn;
        string connString;
        string username;

        public Kitchen(string username)
        {
            InitializeComponent();

            this.username = username;

            lWelcome.Text = "Welcome " + username;
            connectDB();

            dgvKitchen.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKitchen.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

                loadDGVKitchen();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        DataTable dtKitchen;

        public void loadDGVKitchen()
        {
            string q = "SELECT ht_invoice AS 'Invoice Number', ht_total AS 'Total' FROM htrans WHERE ht_status = 3;";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtKitchen = new DataTable();
            da.Fill(dtKitchen);
            dgvKitchen.DataSource = dtKitchen;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void dgvKitchen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string invoiceNum = dgvKitchen.CurrentRow.Cells[0].Value.ToString();

            Kitchen_Detail f = new Kitchen_Detail(invoiceNum);
            Hide();
            f.ShowDialog();
            Show();
            loadDGVKitchen();
        }
    }
}
