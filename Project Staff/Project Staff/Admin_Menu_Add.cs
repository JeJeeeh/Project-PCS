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
    public partial class Admin_Menu_Add : Form
    {
        int menu_id;
        List<string> names = new List<string>();
        List<NumericUpDown> counts = new List<NumericUpDown>();
        Admin_Menu owner;

        MySqlConnection conn;
        string connString;
        DataSet dsMenu;
        DataTable dtMenu;

        public Admin_Menu_Add(int menu_id, Admin_Menu owner)
        {
            InitializeComponent();

            this.owner = owner;
            this.menu_id = menu_id;
            connectDB();
            loadIngredients();

            if (this.menu_id == 0)
            {
                btnDelete.Visible = false;
                genId();
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


        private Label createLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(10, 10);
            label.Font = new Font("Segoe UI", 12);

            return label;
        }

        private Panel createPanel(int x, int y)
        {
            Panel panel = new Panel();
            panel.Size = new Size(142, 80);
            panel.Location = new Point(10 * (x + 1) + x * 142, 10 * (y + 1) + y * 80);
            panel.BackColor = Color.White;

            return panel;
        }

        private NumericUpDown createNup()
        {
            NumericUpDown nup = new NumericUpDown();
            nup.Location = new Point(10, 40);

            return nup;
        }

        private void loadIngredients()
        {
            string query = $"select in_name as 'Name', in_id as 'ID' from ingredient";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            int x = 0, y = 0;

            while (rdr.Read())
            {
                string menu_name = rdr["Name"].ToString();
                string menu_id = rdr["ID"].ToString();

                Panel pnl = createPanel(x, y) ;
                Label lblName = createLabel(menu_name);
                NumericUpDown nup = createNup();
                
                pnl.Controls.Add(lblName);
                pnl.Controls.Add(nup);
                pnlContainer.Controls.Add(pnl);

                names.Add(menu_id);
                counts.Add(nup);

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
            pnlContainer.Controls.Clear();

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

            query = $"select mi_in_id as 'ingredient_id', mi_quantity as 'quantity' from menu_ingredient where mi_me_id = {menu_id}";

            cmd = new MySqlCommand(query, conn);

            conn.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names.ElementAt(i).Equals(rdr["ingredient_id"].ToString()))
                    {
                        counts.ElementAt(i).Value = Convert.ToInt32(rdr["quantity"].ToString());
                    }
                }
            }

            rdr.Close();
            conn.Close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void genId()
        {
            if (tbId.Text.Equals(""))
            {
                string query = "select (count(*) + 1) from menu";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                string count = cmd.ExecuteScalar().ToString();
                conn.Close();

                tbId.Text = count;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (menu_id > 0)
            {
                string query = $"update menu set me_name = '{tbName.Text}', me_price = {tbPrice.Text}, me_description = '{rtbDescription.Text}', me_ty_id = {cbType.SelectedValue} where me_id = {tbId.Text}";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    using (MySqlTransaction obTrans = conn.BeginTransaction())
                    {
                        try
                        {

                            query = $"delete from menu_ingredient where mi_me_id = {tbId.Text}";
                            try
                            {
                                cmd = new MySqlCommand(query, conn);
                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                conn.Close();
                            }

                            cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            for (int i = 0; i < counts.Count; i++)
                            {
                                if (counts.ElementAt(i).Value > 0)
                                {
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "insert into menu_ingredient(mi_me_id, mi_in_id, mi_quantity) values(@menu, @ingredient, @quantity)";
                                    cmd.Parameters.Add(new MySqlParameter("@menu", tbId.Text));
                                    cmd.Parameters.Add(new MySqlParameter("@ingredient", names.ElementAt(i).ToString()));
                                    cmd.Parameters.Add(new MySqlParameter("@quantity", counts.ElementAt(i).Value));
                                    cmd.ExecuteNonQuery();
                                }

                            }

                            obTrans.Commit();

                            MessageBox.Show("Menu Saved!");
                            Dispose();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);

                            obTrans.Rollback();
                        }
                    }
                    conn.Close();

                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else
            {
                conn.Open();
                using (MySqlTransaction obTrans = conn.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "insert into menu(me_id, me_name, me_price, me_stock, me_ty_id, me_status, me_description) values(@id, @name, @price, @stock, @type, @status, @description)";
                        cmd.Parameters.Add(new MySqlParameter("@id", tbId.Text));
                        cmd.Parameters.Add(new MySqlParameter("@name", tbName.Text));
                        cmd.Parameters.Add(new MySqlParameter("@price", Convert.ToInt32(tbPrice.Text)));
                        cmd.Parameters.Add(new MySqlParameter("@stock", "0"));
                        cmd.Parameters.Add(new MySqlParameter("@type", Convert.ToInt32(cbType.SelectedValue.ToString())));
                        cmd.Parameters.Add(new MySqlParameter("@status", "1"));
                        cmd.Parameters.Add(new MySqlParameter("@description", rtbDescription.Text));

                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < counts.Count; i++)
                        {
                            if (counts.ElementAt(i).Value > 0)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "insert into menu_ingredient(mi_me_id, mi_in_id, mi_quantity) values(@menu, @ingredient, @quantity)";
                                cmd.Parameters.Add(new MySqlParameter("@menu", tbId.Text));
                                cmd.Parameters.Add(new MySqlParameter("@ingredient", names.ElementAt(i).ToString()));
                                cmd.Parameters.Add(new MySqlParameter("@quantity", counts.ElementAt(i).Value));
                                cmd.ExecuteNonQuery();
                            }
                            
                        }

                        obTrans.Commit();

                        MessageBox.Show("Menu Added!");
                        Dispose();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);

                        obTrans.Rollback();
                    }
                }

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

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

                query = $"delete from menu_ingredient where mi_me_id = '{tbId.Text}'";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

                query = $"update bundle b join menu_bundle mb on b.bu_id = mb.mb_bu_id join menu m on m.me_id = mb.mb_me_id set b.bu_status = 0 where m.me_id = {tbId.Text}";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

                query = $"delete from menu_bundle where mb_me_id = '{tbId.Text}'";
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

        private void Admin_Menu_Add_FormClosed(object sender, FormClosedEventArgs e)
        {
            owner.loadDataGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();

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

            query = $"select mi_in_id as 'ingredient_id', mi_quantity as 'quantity' from menu_ingredient where mi_me_id = {menu_id}";

            cmd = new MySqlCommand(query, conn);

            conn.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names.ElementAt(i).Equals(rdr["ingredient_id"].ToString()))
                    {
                        counts.ElementAt(i).Value = Convert.ToInt32(rdr["quantity"].ToString());
                    }
                }
            }

            rdr.Close();
            conn.Close();
        }
    }
}
