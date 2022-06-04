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
    public partial class Cashier_CashPayment : Form
    {
        MySqlConnection conn;
        string connString;
        string invoice;

        public Cashier_CashPayment(string invoice)
        {
            InitializeComponent();
            this.invoice = invoice;

            lTNum.Text = "Welcome " + invoice;
            connectDB();

            dgvCashier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCashier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

                loadDGVCashPay();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        DataTable dtPay;

        public void loadDGVCashPay()
        {
            string q = $"SELECT ht_invoice AS 'Invoice Number', ht_total AS 'Total' FROM dtrans dt, htrans ht WHERE dt.dt_ht_id = ht.ht_id AND ht.ht_invoice = {invoice};";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtPay = new DataTable();
            da.Fill(dtPay);
            dgvCashier.DataSource = dtPay;
        }
    }
}
