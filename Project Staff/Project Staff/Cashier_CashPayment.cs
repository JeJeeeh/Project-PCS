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

            lTNum.Text = "Invoice Number = " + invoice;
            connectDB();

            dgvCashier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCashier.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                loadTotal();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        DataTable dtPay;

        public void loadDGVCashPay()
        {
            string q = $"SELECT dt.dt_amount AS 'Amount', m.me_name AS 'Nama Menu', m.me_price AS 'Harga', (m.me_price * dt.dt_amount) AS 'Total' FROM dtrans dt JOIN htrans ht ON dt.dt_ht_id = ht.ht_id JOIN menu m ON m.me_id = dt.dt_me_id WHERE ht.ht_invoice = '{invoice}'; ";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtPay = new DataTable();
            da.Fill(dtPay);
            dgvCashier.DataSource = dtPay;
        }

        public void loadTotal()
        {
            string q = $"SELECT SUM(m.me_price * dt.dt_amount) AS 'Grand Total' FROM dtrans dt JOIN htrans ht ON dt.dt_ht_id = ht.ht_id JOIN menu m ON m.me_id = dt.dt_me_id WHERE ht.ht_invoice = '{invoice}'; ";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            string grandTotal = cmd.ExecuteScalar().ToString();
            conn.Close();

            lTotal.Text = "Total = Rp." + grandTotal;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string query = $"UPDATE htrans SET ht_status = '3' WHERE ht_invoice = {invoice}; ";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            MessageBox.Show("Transaction Has Been Paid!!!");
            Hide();
        }

    }
}
