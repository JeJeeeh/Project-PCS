using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace User
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        List<Button> buttons = new List<Button>();
        int press = 0;
        int counter = 0;
        int hitung = 0;
        string [] makanan = new string[100];
        string [] tipem = new string[100];
        public Form1()
        {
            InitializeComponent();
        }
        private void connn()
        {
            conn = new MySqlConnection("server = localhost ; uid = root ; database = project_pcs");
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
        private void btnpesan_Click(object sender, EventArgs e)
        {
            btnpesan.Visible = false;
            PbMenu.Visible = false;
            this.BackColor = Color.White;
            bdessert.Visible = true;
            bmakanan.Visible = true;
            bminuman.Visible = true;
            bpaket.Visible = true;
            pictureBox1.Visible = true;
            bpaket.BackColor = Color.Red;
            press = 4;
            generateButton();
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connn();
            /*            string sURL = "https://asset.kompas.com/crops/AnzPGqRxpoD-26G__5fPh6ooZSk=/0x28:640x455/750x500/data/photo/2020/12/12/5fd44cf8e94b1.jpg";
                        WebRequest req = WebRequest.Create(sURL);
                        WebResponse res = req.GetResponse();
                        Stream imgStream = res.GetResponseStream();
                        Image img1 = Image.FromStream(imgStream);
                        imgStream.Close();
                        img1 = resizeImage(img1, new Size(50, 50));
                        btnpesan.Image = img1;*/
        }

        private void getmenu()
        {
            if (press < 4 && press > 0)
            {
                string query = $"SELECT me_name as texts FROM menu where me_ty_id = " + press + "";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                int i = 0;

                while (rdr.Read())
                {
                    makanan[i] = rdr["texts"].ToString();
                    hitung++;
                    i++;
                }
                conn.Close();
            }
            else if ( press == 4)
            {
                string query = $"SELECT bu_name as texts FROM bundle WHERE bu_id > 0;";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                int i = 0;

                while (rdr.Read())
                {
                    makanan[i] = rdr["texts"].ToString();
                    hitung++;
                    i++;
                }
                conn.Close();
               
            }
        }

        private void generateButton()
        {
            hitung = 0;
            foreach (Button btn in buttons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            int iny = 50;
            int inx = 200;
            getmenu();
            int ys = 2;
            int xs = 5;
            if (hitung < 5)
            {
                xs = hitung;
            }
            if (hitung > 5)
            {
                ys = 3;
            }
            if (hitung > 10)
            {
                ys = 4;
            }
            if (hitung > 15)
            {
                ys = 5;
            }
            if (hitung > 20)
            {
                ys = 6;
            }
            if (hitung > 25)
            {
                ys = 7;
            }

            int count = 0;
            for ( int y = 1; y < ys; y++)
            {
                for (int x = 1; x <= xs; x++)
                {
                    Button newButton = new Button();
                    buttons.Add(newButton);
                    this.Controls.Add(newButton);
                    if (press == 1)
                    {
                        newButton.Text = makanan[count];
                    }
                    else if (press == 2)
                    {
                        newButton.Text = makanan[count];
                    }
                    else if (press == 3)
                    {
                        newButton.Text = makanan[count];
                    }
                    else if (press == 4)
                    {
                        newButton.Text = makanan[count];
                    }
                    newButton.Location = new Point(inx, iny);
                    newButton.Size = new Size(100, 100);
                    inx = inx + 150;
                    newButton.Click += new EventHandler(Clicks);
                    count++;
                    if (count == hitung)
                    {
                        break;
                        y = ys;
                    }
                }
                inx = 200;
                iny = iny + 150;
            }
            hitung = 0;
            
        }
        public void Clicks(object sender, EventArgs e)
        {
            
            Button button = sender as Button;
            foreach (Button btn in buttons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            bdessert.Visible = false;
            bmakanan.Visible = false;
            bminuman.Visible = false;
            bpaket.Visible = false;
            pictureBox1.Visible = false;
            pbgambar.Visible = true;
            lbdescription.Visible = true;
            lbtotal.Visible = true;
            nuobjek.Visible = true;
            btnback.Visible = true;
            bbuy.Visible = true;
            pbbuy.Visible = true;
            string textBox1 = "";
            if (press == 1)
            {
                 textBox1 = Directory.GetCurrentDirectory() + "\\Resources\\makanan.jpg";
            }
            if (press == 2)
            {
                 textBox1 = Directory.GetCurrentDirectory() + "\\Resources\\minuman.jpg";
            }
            if (press == 3)
            {
                 textBox1 = Directory.GetCurrentDirectory() + "\\Resources\\dessert.jpg";
            }
            if (press == 4)
            {
                 textBox1 = Directory.GetCurrentDirectory() + "\\Resources\\paket.jpg";
            }
            Bitmap bitmap = new Bitmap(textBox1);
            pbgambar.Image = bitmap;

            if (press > 0 && press < 4)
            {
                string query = $"SELECT me_description as texts FROM menu WHERE me_name = '" + button.Text + "';";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                int i = 0;

                while (rdr.Read())
                {
                    lbdescription.Text = rdr["texts"].ToString();
                    i++;
                }
                conn.Close();
            }

        }
        private void bmakanan_Click(object sender, EventArgs e)
        {

            bdessert.BackColor = Color.White;
            bmakanan.BackColor = Color.Red;
            bminuman.BackColor = Color.White;
            bpaket.BackColor = Color.White;
            press = 1;
            generateButton();


        }

        private void bminuman_Click(object sender, EventArgs e)
        {
            bdessert.BackColor = Color.White;
            bmakanan.BackColor = Color.White;
            bminuman.BackColor = Color.Red;
            bpaket.BackColor = Color.White;
            press = 2;
            generateButton();

        }

        private void bdessert_Click(object sender, EventArgs e)
        {
            bdessert.BackColor = Color.Red;
            bmakanan.BackColor = Color.White;
            bminuman.BackColor = Color.White;
            bpaket.BackColor = Color.White;
            press = 3;
            generateButton();
        }

        private void bpaket_Click(object sender, EventArgs e)
        {
            bdessert.BackColor = Color.White;
            bmakanan.BackColor = Color.White;
            bminuman.BackColor = Color.White;
            bpaket.BackColor = Color.Red;
            press = 4;
            generateButton();
        }

        private void bbuy_Click(object sender, EventArgs e)
        {
            pbgambar.Visible = false;
            lbdescription.Visible = false;
            lbtotal.Visible = false;
            nuobjek.Visible = false;
            bbuy.Visible = false;
            pbbuy.Visible = false;
            btnback.Visible = false;

            bya.Visible = true;
            btidak.Visible = true;
            lbnambah.Visible = true;
            lblist1.Visible = true;
            lblist2.Visible = true;
            lbtot.Visible = true;
            pbcart.Visible = true;
            pbtanya.Visible = true;
        }

        private void bntunai_Click(object sender, EventArgs e)
        {
            pbgambar.Visible = false;
            lbdescription.Visible = false;
            lbtotal.Visible = false;
            nuobjek.Visible = false;
            bbuy.Visible = false;
            pbbuy.Visible = false;
            bya.Visible = false;
            btidak.Visible = false;
            lbnambah.Visible = false;
            pbtanya.Visible = false;
            bntunai.Visible = false;
            btunai.Visible = false;
            lbpilihpembayaran.Visible = false;

            pbkartu.Visible = true;
            pbverify.Visible = true;
            timer1.Start();

        }

        private void btunai_Click(object sender, EventArgs e)
        {
            pbgambar.Visible = false;
            lbdescription.Visible = false;
            lbtotal.Visible = false;
            nuobjek.Visible = false;
            bbuy.Visible = false;
            pbbuy.Visible = false;
            bya.Visible = false;
            btidak.Visible = false;
            lbnambah.Visible = false;
            pbtanya.Visible = false;
            bntunai.Visible = false;
            btunai.Visible = false;
            lbpilihpembayaran.Visible = false;

            lproses.Visible = true;
            bkembali.Visible = true;
        }

        private void bya_Click(object sender, EventArgs e)
        {
            bdessert.BackColor = Color.White;
            bmakanan.BackColor = Color.White;
            bminuman.BackColor = Color.White;
            bpaket.BackColor = Color.Red;
            press = 4;
            generateButton();
            bya.Visible = false;
            btidak.Visible = false;
            lbnambah.Visible = false;
            pbtanya.Visible = false;

            lblist1.Visible = false;
            lblist2.Visible = false;
            lbtot.Visible = false;
            pbcart.Visible = false;

            bdessert.Visible = true;
            bmakanan.Visible = true;
            bminuman.Visible = true;
            bpaket.Visible = true;
            pictureBox1.Visible = true;
        }

        private void btidak_Click(object sender, EventArgs e)
        {
            pbgambar.Visible = false;
            lbdescription.Visible = false;
            lbtotal.Visible = false;
            nuobjek.Visible = false;
            bbuy.Visible = false;
            pbbuy.Visible = false;
            bya.Visible = false;
            btidak.Visible = false;
            lbnambah.Visible = false;
            pbtanya.Visible = false;

            lblist1.Visible = false;
            lblist2.Visible = false;
            lbtot.Visible = false;
            pbcart.Visible = false;

            bntunai.Visible = true;
            btunai.Visible = true;
            lbpilihpembayaran.Visible = true;
        }

        private void lproses_Click(object sender, EventArgs e)
        {

        }

        private void bkembali_Click(object sender, EventArgs e)
        {
            lbprosses2.Visible = false;
            pbgambar.Visible = false;
            lbdescription.Visible = false;
            lbtotal.Visible = false;
            nuobjek.Visible = false;
            bbuy.Visible = false;
            pbbuy.Visible = false;
            bya.Visible = false;
            btidak.Visible = false;
            lbnambah.Visible = false;
            pbtanya.Visible = false;
            bntunai.Visible = false;
            btunai.Visible = false;
            lbpilihpembayaran.Visible = false;

            lproses.Visible = false;
            bkembali.Visible = false;

            btnpesan.Visible = true;
            PbMenu.Visible = true;
            this.BackColor = Color.DarkRed;
            bdessert.BackColor = Color.White;
            bmakanan.BackColor = Color.White;
            bminuman.BackColor = Color.White;
            bpaket.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter == 4)
            {
                pbkartu.Visible = false;
                pbverify.Visible = false;
                tbpin.Visible = true;
                lbpin.Visible = true;
                pbpin.Visible = true;
 
                counter = 0;
                timer1.Stop();
            }
            
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            bdessert.BackColor = Color.White;
            bmakanan.BackColor = Color.White;
            bminuman.BackColor = Color.White;
            bpaket.BackColor = Color.Red;
            press = 4;
            generateButton();
            pbgambar.Visible = false;
            lbdescription.Visible = false;
            lbtotal.Visible = false;
            nuobjek.Visible = false;
            bbuy.Visible = false;
            pbbuy.Visible = false;

            bya.Visible = false;
            btidak.Visible = false;
            lbnambah.Visible = false;
            pbtanya.Visible = false;

            lblist1.Visible = false;
            lblist2.Visible = false;
            lbtot.Visible = false;
            pbcart.Visible = false;
            btnback.Visible = false;

            bdessert.Visible = true;
            bmakanan.Visible = true;
            bminuman.Visible = true;
            bpaket.Visible = true;
            pictureBox1.Visible = true;
        }

        private void tbpin_TextChanged(object sender, EventArgs e)
        {
            if(tbpin.Text.Length == 1)
            {
                tbpin.Text = "*";
            }
            if (tbpin.Text.Length == 2)
            {
                tbpin.Text = "**";
            }
            if (tbpin.Text.Length == 3)
            {
                tbpin.Text = "***";
            }
            if (tbpin.Text.Length == 4)
            {
                tbpin.Text = "****";
            }
            if (tbpin.Text.Length == 5)
            {
                tbpin.Text = "*****";
            }
            if (tbpin.Text.Length >= 6)
            {
                tbpin.Text = "";
                tbpin.Visible = false;
                lbpin.Visible = false;
                pbpin.Visible = false;
                pbgambar.Visible = false;
                lbdescription.Visible = false;
                lbtotal.Visible = false;
                nuobjek.Visible = false;
                bbuy.Visible = false;
                pbbuy.Visible = false;
                bya.Visible = false;
                btidak.Visible = false;
                lbnambah.Visible = false;
                pbtanya.Visible = false;
                bntunai.Visible = false;
                btunai.Visible = false;
                lbpilihpembayaran.Visible = false;
                lbprosses2.Visible = true;
                bkembali.Visible = true;
            }

        }
    }
}
