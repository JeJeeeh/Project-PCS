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
            List<string> list_in_id = new List<string>();
            List<string> list_qty = new List<string>();
            List<string> list_amount = new List<string>();
        
            for (int i = 0; i < dgvKitchenDetail.Rows.Count; i++)
            {
                string nama = dgvKitchenDetail.Rows[i].Cells[1].Value.ToString();
                string amount = dgvKitchenDetail.Rows[i].Cells[0].Value.ToString();


                string q = $"SELECT i.in_id, mi.mi_quantity FROM menu m JOIN menu_ingredient mi ON m.me_id = mi.mi_me_id JOIN ingredient i ON mi.mi_in_id = i.in_id WHERE m.me_name = '{nama}';";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(q, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                try
                {
                    while (rd.Read())
                    {
                        int in_id = rd.GetInt32(0);
                        int qty = rd.GetInt32(1);

                        list_in_id.Add(rd.GetString(0));
                        list_qty.Add(rd.GetString(1));
                        list_amount.Add(amount);
                    }
                }
                catch
                {
                    rd.Close();
                    conn.Close();
                }
                conn.Close();
            }

            for (int i = 0; i < list_in_id.Count; i++)
            {
                string q2 = $"UPDATE ingredient SET in_stock = (SELECT in_stock FROM ingredient WHERE in_id = {list_in_id[i]}) - ({list_qty[i]} * {list_amount[i]}) WHERE in_id = {list_in_id[i]};";

                try
                {
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }

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

            MessageBox.Show("Order has been cooked!!!");
            Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}
