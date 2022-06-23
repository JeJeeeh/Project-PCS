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
    public partial class FormReport : Form
    {
        CrystalReport1 cr;
        MySqlConnection conn;
        string connString;
        DataSet dsTransaction;
        DataTable dtTransaction;
        string htransId;

        public FormReport(string htransId)
        {
            InitializeComponent();
            connectDB();

            this.htransId = htransId;
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDatabaseLogon("root", "", "localhost", "project_pcs");
            rpt.SetParameterValue("htransid", Convert.ToInt32(htransId));
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
