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
            string query = "select m.me_id as 'ID', m.me_name as 'Name', m.me_price as 'Price', m.me_stock as 'Stock', t.ty_name as 'Type' from menu m join type t on m.me_ty_id = t.ty_id where m.me_status = 1 order by 1";
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
