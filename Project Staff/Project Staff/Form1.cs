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
    public partial class Login : Form
    {
        MySqlConnection conn;
        string connString;

        public Login()
        {
            InitializeComponent();

            connectDB();
            btnLogin.Enabled = false;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            string query = "select count(*) from users where us_username = ?username and us_password = ?password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("username", username));
            cmd.Parameters.Add(new MySqlParameter("password", password));

            conn.Open();
            int valid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            conn.Close();

            if (valid > 0)
            {
                query = "select us_pr_id from users where us_username = ?username and us_password = ?password";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                cmd.Parameters.Add(new MySqlParameter("password", password));

                conn.Open();
                int privilege = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();

                if (privilege == 1)
                {
                    Admin admin = new Admin();
                    Hide();
                    admin.ShowDialog();
                    Show();
                }
                else if (privilege == 2)
                {
                    Kitchen kitchen = new Kitchen(username);
                    Hide();
                    kitchen.ShowDialog();
                    Show();
                }
                else if (privilege == 3)
                {
                    Cashier cashier = new Cashier(username);
                    Hide();
                    cashier.ShowDialog();
                    Show();
                }
            }
            else
            {
                MessageBox.Show("Username atau password salah!");
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text.Equals("") || tbPassword.Text.Equals(""))
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text.Equals("") || tbPassword.Text.Equals(""))
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
