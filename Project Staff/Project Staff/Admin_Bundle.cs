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
            string query = "select bu_id as 'ID', bu_name as 'Name', bu_price as 'Price', bu_description as 'Description' from bundle where bu_status = 1 order by 1";
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
    }
}
