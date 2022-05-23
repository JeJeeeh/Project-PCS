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
    public partial class Admin_Ingredient : Form
    {
        MySqlConnection conn;
        string connString;
        DataSet dsIngredient;
        DataTable dtIngredient;
        public Admin_Ingredient()
        {
            InitializeComponent();

            connectDB();
            loadDataGrid();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cbFilter.SelectedIndex = 0;
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
            string query = "select in_id as 'Ingredient', in_name as 'Name', in_price as 'Price', in_stock as 'Stock' from ingredient where in_status = 1 order by 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsIngredient = new DataSet();
            da.Fill(dsIngredient);
            dgvStaff.DataSource = dsIngredient.Tables[0].DefaultView;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void clear()
        {
            tbName.Text = "";
            tbName.Text = "";
            tbPrice.Text = "";
            nupStock.Value = 0;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            tbId.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string query = "insert into ingredient values(?Id,?Name,?price,?stock,?Status)";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("Id", tbId.Text));
                cmd.Parameters.Add(new MySqlParameter("Name", tbName.Text));
                cmd.Parameters.Add(new MySqlParameter("Price", tbPrice.Text));
                cmd.Parameters.Add(new MySqlParameter("Stock", nupStock.Value));
                cmd.Parameters.Add(new MySqlParameter("Status", "1"));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                loadDataGrid();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void genId()
        {
            if (tbId.Text.Equals(""))
            {
                string query = "select (count(*) + 1) from ingredient";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                string count = cmd.ExecuteScalar().ToString();
                conn.Close();

                tbId.Text = count;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void nupStock_ValueChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = $"update ingredient set in_name = '{tbName.Text}', in_price = {tbPrice.Text}, in_stock = {nupStock.Value} where in_id = {tbId.Text}";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                loadDataGrid();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"update ingredient set in_status = 0 where in_id = '{tbId.Text}'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                loadDataGrid();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void dgvStaff_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIdx = e.RowIndex;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnInsert.Enabled = false;

            if (rowIdx < dsIngredient.Tables[0].Rows.Count)
            {

                tbId.Text = dgvStaff.Rows[rowIdx].Cells[0].Value.ToString();
                tbName.Text = dgvStaff.Rows[rowIdx].Cells[1].Value.ToString();
                tbPrice.Text = dgvStaff.Rows[rowIdx].Cells[2].Value.ToString();
                nupStock.Value = Convert.ToInt32(dgvStaff.Rows[rowIdx].Cells[3].Value.ToString());

            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query;
            if (cbFilter.SelectedIndex == 0)
            {
                query = "select in_id as 'Ingredient', in_name as 'Name', in_price as 'Price', in_stock as 'Stock' from ingredient where in_stock > 0 and in_status = 1 order by 1";
            }
            else
            {
                query = "select in_id as 'Ingredient', in_name as 'Name', in_price as 'Price', in_stock as 'Stock' from ingredient where in_stock = 0 and in_status = 1 order by 1";
            }
            
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsIngredient = new DataSet();
            da.Fill(dsIngredient);
            dgvStaff.DataSource = dsIngredient.Tables[0].DefaultView;
        }
    }
}
