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
        public FormReport(CrystalReport1 cr)
        {
            InitializeComponent();
            this.cr = cr;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
