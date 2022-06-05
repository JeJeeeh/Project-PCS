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
    public partial class Admin_Bundle_Add : Form
    {
        int bundle_id;
        List<string> names = new List<string>();
        List<NumericUpDown> counts = new List<NumericUpDown>();

        MySqlConnection conn;
        string connString;
        DataSet dsMenu;
        DataTable dtMenu;

        public Admin_Bundle_Add(int bundle_id)
        {
            InitializeComponent();

            this.bundle_id = bundle_id;
            connectDB();
            loadMenuCards();

            if (bundle_id > 0)
            {
                loadMenu(bundle_id);
            }
            else
            {
                btnDelete.Visible = false;
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

                
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void loadMenu(int menu_id)
        {
            string query = $"select bu_id as 'ID', bu_name as 'Name', bu_price as 'Price', bu_description as 'Desc' from bundle where bu_status = 1 order by 1";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tbId.Text = rdr["ID"].ToString();
                tbName.Text = rdr["Name"].ToString();
                tbPrice.Text = rdr["Price"].ToString();
                rtbDescription.Text = rdr["Desc"].ToString();
            }

            rdr.Close();
            conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void loadMenuCards()
        {
            pnlContainer.Controls.Clear();
            string query = $"select me_name as 'Name', me_id as 'ID' from menu";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            int x = 0, y = 0;

            while (rdr.Read())
            {
                string menu_name = rdr["Name"].ToString();
                string menu_id = rdr["ID"].ToString();

                Panel pnl = createPanel(x, y);
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

            query = $"select mb_me_id as 'menu_id', mb_quantity as 'quantity' from menu_bundle where mb_bu_id = {bundle_id}";

            cmd = new MySqlCommand(query, conn);

            conn.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names.ElementAt(i).Equals(rdr["menu_id"].ToString()))
                    {
                        counts.ElementAt(i).Value = Convert.ToInt32(rdr["quantity"].ToString());
                    }
                }
            }

            rdr.Close();
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bundle_id > 0)
            {
                string query = $"update bundle set bu_name = '{tbName.Text}', bu_price = {tbPrice.Text}, bu_description = '{rtbDescription.Text}' where bu_id = {tbId.Text}";
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

                            query = $"delete from menu_bundle where mb_bu_id = {tbId.Text}";
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
                                    cmd.CommandText = "insert into menu_bundle(mb_me_id, mb_bu_id, mb_quantity) values(@menu, @bundle, @quantity)";
                                    cmd.Parameters.Add(new MySqlParameter("@menu", names.ElementAt(i).ToString()));
                                    cmd.Parameters.Add(new MySqlParameter("@bundle", tbId.Text));
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
                        cmd.CommandText = "insert into bundle(bu_id, bu_name, bu_price, bu_status, bu_description) values(@id, @name, @price, @status, @description)";
                        cmd.Parameters.Add(new MySqlParameter("@id", tbId.Text));
                        cmd.Parameters.Add(new MySqlParameter("@name", tbName.Text));
                        cmd.Parameters.Add(new MySqlParameter("@price", Convert.ToInt32(tbPrice.Text)));
                        cmd.Parameters.Add(new MySqlParameter("@status", "1"));
                        cmd.Parameters.Add(new MySqlParameter("@description", rtbDescription.Text));

                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < counts.Count; i++)
                        {
                            if (counts.ElementAt(i).Value > 0)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "insert into menu_bundle(mb_me_id, mb_bu_id, mb_quantity) values(@menu, @bundle, @quantity)";
                                cmd.Parameters.Add(new MySqlParameter("@menu", names.ElementAt(i).ToString()));
                                cmd.Parameters.Add(new MySqlParameter("@bundle", tbId.Text));
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

        private void genId()
        {
            if (tbId.Text.Equals(""))
            {
                string query = "select (count(*) + 1) from bundle";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                string count = cmd.ExecuteScalar().ToString();
                conn.Close();

                tbId.Text = count;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            genId();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            loadMenuCards();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete bundle?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = $"update bundle set bu_status = 0 where bu_id = '{tbId.Text}'";
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

                query = $"delete from menu_bundle where mb_bu_id = '{tbId.Text}'";
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!tbSearch.Equals(""))
            {
                pnlContainer.Controls.Clear();
                string query = $"select me_name as 'Name', me_id as 'ID' from menu where me_name like '%{tbSearch.Text}%'";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                int x = 0, y = 0;

                while (rdr.Read())
                {
                    string menu_name = rdr["Name"].ToString();
                    string menu_id = rdr["ID"].ToString();

                    Panel pnl = createPanel(x, y);
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

                query = $"select mb_me_id as 'menu_id', mb_quantity as 'quantity' from menu_bundle where mb_bu_id = {bundle_id}";

                cmd = new MySqlCommand(query, conn);

                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names.ElementAt(i).Equals(rdr["menu_id"].ToString()))
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
}
