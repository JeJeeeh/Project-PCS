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
    public partial class Admin_Menu_Add : Form
    {
        int menu_id;

        MySqlConnection conn;
        string connString;
        DataSet dsMenu;
        DataTable dtMenu;

        public Admin_Menu_Add(int menu_id)
        {
            InitializeComponent();

            this.menu_id = menu_id;
            connectDB();
            loadIngredients();

            if (this.menu_id == 0)
            {
                btnDelete.Visible = false;
            }
            else
            {
                loadMenu(this.menu_id);
            }
        }

        public void connectDB()
        {
            connString = "server = localhost; uid = root; database = project_pcs";
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                conn.Close();

                loadComboBox();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        public void loadComboBox()
        {
            string query = "select ty_id as 'ID', ty_name as 'Name' from type";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dtMenu = new DataTable();
            da.Fill(dtMenu);
            cbType.ValueMember = "ID";
            cbType.DisplayMember = "Name";
            cbType.DataSource = dtMenu.DefaultView;
            cbType.SelectedIndex = 0;
        }

        private void loadIngredients()
        {
            string query = $"select in_name as 'Name' from ingredient";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            int x = 0, y = 0;

            while (rdr.Read())
            {
                string menu_name = rdr["Name"].ToString();

                Panel pnl = new Panel();
                Label lblName = new Label();
                lblName.Text = menu_name;
                lblName.Location = new Point(10, 10);
                lblName.Font = new Font("Segoe UI", 12);
                pnl.Controls.Add(lblName);
                pnl.Size = new Size(142, 80);
                pnl.Location = new Point(10 * (x + 1) + x * 142, 10 * (y + 1) + y * 80);
                pnl.BackColor = Color.White;
                pnlContainer.Controls.Add(pnl);

                x++;
                if (x == 4)
                {
                    y++;
                    x = x % 4;
                }
            }

            conn.Close();
        }

        private void loadMenu(int menu_id)
        {
            string query = $"select m.me_id as 'ID', m.me_name as 'Name', m.me_price as 'Price', m.me_description 'Desc', t.ty_name as 'Type' from menu m join type t on m.me_ty_id = t.ty_id where me_id = {menu_id}";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tbId.Text = rdr["ID"].ToString();
                tbName.Text = rdr["Name"].ToString();
                tbPrice.Text = rdr["Price"].ToString();
                rtbDescription.Text = rdr["Desc"].ToString();

                string type = rdr["Type"].ToString();
                int i;
                for (i = 0; i < cbType.Items.Count; i++)
                {
                    string value = cbType.GetItemText(cbType.Items[i]);
                    if (type.Equals(value))
                    {
                        break;
                    }
                }
                cbType.SelectedIndex = i;
            }

            conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = $"update menu set me_name = '{tbName.Text}', me_price = {tbPrice.Text}, me_description = '{rtbDescription.Text}', me_ty_id = {cbType.SelectedValue} where me_id = {tbId.Text}";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete menu?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = $"update menu set me_status = 0 where me_id = '{tbId.Text}'";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
        }
    }
}
