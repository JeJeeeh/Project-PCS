using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Staff
{
    public partial class Admin_Menu_Add : Form
    {
        int menu_id;
        public Admin_Menu_Add(int menu_id)
        {
            InitializeComponent();

            this.menu_id = menu_id;

            if (this.menu_id == 0)
            {
                btnDelete.Visible = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
