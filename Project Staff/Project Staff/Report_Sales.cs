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
    public partial class Report_Sales : Form
    {
        public Report_Sales()
        {
            InitializeComponent();
            loadReport();
        }

        private void loadReport()
        {
            Sales_Report rpt = new Sales_Report();
            rpt.SetDatabaseLogon("root", "", "localhost", "project_pcs");
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
