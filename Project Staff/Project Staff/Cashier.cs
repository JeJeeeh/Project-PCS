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
    public partial class Cashier : Form
    {
        MySqlConnection conn;
        string connString;
        public Cashier()
        {
            InitializeComponent();

            connectDB();
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

                loadDGVPay();
                loadDGVReady();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        DataTable dtPay;

        public void loadDGVPay()
        {
            string q = "SELECT ht_invoice AS 'Invoice Number', ht_total AS 'Total' FROM htrans WHERE ht_status = 0;";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtPay = new DataTable();
            da.Fill(dtPay);
            dgvCashPay.DataSource = dtPay;
        }

        DataTable dtReady;

        public void loadDGVReady()
        {
            string q = "SELECT ht_invoice AS 'Invoice Number', ht_total AS 'Total' FROM htrans WHERE ht_status = 1;";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtReady = new DataTable();
            da.Fill(dtReady);
            dgvReady.DataSource = dtReady;
        }
    }
}
