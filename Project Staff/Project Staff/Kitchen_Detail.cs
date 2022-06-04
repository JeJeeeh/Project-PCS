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
    public partial class Kitchen_Detail : Form
    {
        MySqlConnection conn;
        string connString;
        string invoice;

        public Kitchen_Detail(string invoice)
        {
            InitializeComponent();

            this.invoice = invoice;

            lTNum.Text = "Invoice Number = " + invoice;
            connectDB();

            dgvKitchenDetail.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKitchenDetail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

                loadDGVKitchenDetail();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        DataTable dtKitchenDetail;

        public void loadDGVKitchenDetail()
        {
            string q = $"SELECT dt.dt_amount AS 'Amount', m.me_name AS 'Nama Menu' FROM dtrans dt JOIN htrans ht ON dt.dt_ht_id = ht.ht_id JOIN menu m ON m.me_id = dt.dt_me_id WHERE ht.ht_invoice = '{invoice}'; ";
            MySqlCommand cmd = new MySqlCommand(q, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtKitchenDetail = new DataTable();
            da.Fill(dtKitchenDetail);
            dgvKitchenDetail.DataSource = dtKitchenDetail;
        }

        private void btnCook_Click(object sender, EventArgs e)
        {
            string query = $"UPDATE htrans SET ht_status = '1' WHERE ht_invoice = {invoice}; ";

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
