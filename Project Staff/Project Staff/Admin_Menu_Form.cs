﻿using System;
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
    public partial class Admin_Menu_Form : Form
    {
        public Admin_Menu_Form()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CrystalReport3 rpt = new CrystalReport3();
            rpt.SetDatabaseLogon("root", "", "localhost", "project_pcs");
            crystalReportViewer1.ReportSource = rpt;
        }
    }

}
