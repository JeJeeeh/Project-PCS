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
    public partial class Admin_Staff : Form
    {
        MySqlConnection conn;
        string connString;
        DataSet dsStaff;
        DataTable dtStaff;
        public Admin_Staff()
        {
            InitializeComponent();

            connectDB();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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
                loadComboBox();
                loadFilter();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        public void loadDataGrid()
        {
            string query = "select u.us_id as 'ID', ifnull(u.us_name, '-') as 'Name', u.us_username as 'Username', u.us_password as 'Password', p.pr_name as 'Role' from users u join privilege p on u.us_pr_id = p.pr_id where us_pr_id != 1 and us_status = 1 order by 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsStaff = new DataSet();
            da.Fill(dsStaff);
            dgvStaff.DataSource = dsStaff.Tables[0].DefaultView;
        }

        public void loadComboBox()
        {
            string query = "select pr_id as 'ID', pr_name as 'Name' from privilege where pr_id != 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtStaff = new DataTable();
            da.Fill(dtStaff);
            cbRole.ValueMember = "ID";
            cbRole.DisplayMember = "Name";
            cbRole.DataSource = dtStaff.DefaultView;
            cbRole.SelectedIndex = 0;
        }

        public void loadFilter()
        {
            string query = "select pr_id as 'ID', pr_name as 'Name' from privilege where pr_id != 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtStaff = new DataTable();
            da.Fill(dtStaff);
            cbFilter.ValueMember = "ID";
            cbFilter.DisplayMember = "Name";
            cbFilter.DataSource = dtStaff.DefaultView;
            cbFilter.SelectedIndex = 0;
        }

        private void dgvStaff_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIdx = e.RowIndex;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnInsert.Enabled = false;

            if (rowIdx < dsStaff.Tables[0].Rows.Count)
            {

                tbId.Text = dgvStaff.Rows[rowIdx].Cells[0].Value.ToString();
                tbName.Text = dgvStaff.Rows[rowIdx].Cells[1].Value.ToString();
                tbUsername.Text = dgvStaff.Rows[rowIdx].Cells[2].Value.ToString();
                tbPassword.Text = dgvStaff.Rows[rowIdx].Cells[3].Value.ToString();

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void clear()
        {
            tbName.Text = "";
            tbUsername.Text = "";
            tbPassword.Text = "";

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cbRole.SelectedIndex = 0;

            tbId.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Equals("") || tbUsername.Text.Equals("") || tbPassword.Text.Equals(""))
            {
                MessageBox.Show("All Field Must Be Filled!");
            }
            else
            {
                string query = "insert into users values(?Id,?Username,?Password,?Privilege,?Name,?Status)";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add(new MySqlParameter("Id", tbId.Text));
                    cmd.Parameters.Add(new MySqlParameter("Name", tbName.Text));
                    cmd.Parameters.Add(new MySqlParameter("Username", tbUsername.Text));
                    cmd.Parameters.Add(new MySqlParameter("Password", tbPassword.Text));
                    cmd.Parameters.Add(new MySqlParameter("Privilege", cbRole.SelectedValue));
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
            
        }

        private void genId()
        {
            if (tbId.Text.Equals(""))
            {
                string query = "select (count(*) + 1) from users";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                string count = cmd.ExecuteScalar().ToString();
                conn.Close();

                tbId.Text = count;
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = $"update users set us_name = '{tbName.Text}', us_username = '{tbUsername.Text}', us_password = '{tbPassword.Text}', us_pr_id = {cbRole.SelectedValue} where us_id = {tbId.Text}";
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
            string query = $"update users set us_status = 0 where us_id = '{tbId.Text}'";
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query = $"select u.us_id as 'ID', ifnull(u.us_name, '-') as 'Name', u.us_username as 'Username', u.us_password as 'Password', p.pr_name as 'Role' from users u join privilege p on u.us_pr_id = p.pr_id where us_pr_id != 1 and us_status = 1 and us_pr_id = {cbFilter.SelectedValue} order by 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dsStaff = new DataSet();
            da.Fill(dsStaff);
            dgvStaff.DataSource = dsStaff.Tables[0].DefaultView;
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            loadDataGrid();
        }
    }
}
