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
    public partial class Report_Menu : Form
    {
        public Report_Menu()
        {
            InitializeComponent();
            loadReport();
        }

        private void loadReport()
        {
            /*Menu_Report rpt = new Menu_Report();
            rpt.SetDatabaseLogon("localhost", "", "root", "project_pcs");
            crystalReportViewer1.ReportSource = rpt;*/
        }
    }
}
