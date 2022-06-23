using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace User
{
    public partial class Form1 : Form
    {
        ArrayList listmakanan = new ArrayList();
        ArrayList listmakanan2 = new ArrayList();
        ArrayList listdtrans = new ArrayList();
        ArrayList in_id = new ArrayList();
        ArrayList in_stock = new ArrayList();
        ArrayList mi_in_id = new ArrayList();
        ArrayList ma_id = new ArrayList();
        MySqlConnection conn;
        List<Button> buttons = new List<Button>();
        List<Button> buttons2 = new List<Button>();
        List<Label> labels = new List<Label>();
        int totaluang = 0;
        int htid = 0;
        int dtid = 0;
        int press = 0;
        int counter = 0;
        int hitung = 0;
        int reset = 0;
        string [] makanan = new string[100];
        string[] statusm = new string[100];
        string textmakanan = " ";
        int pertamakali = 0;
        int sama = 0;
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
        private void getid()
        {
            in_id.Clear();
            string query = $"SELECT in_id as texts FROM ingredient";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                in_id.Add(rdr["texts"].ToString());

            }
            conn.Close();
        }
        private void getstok()
        {
            in_stock.Clear();
            string query = $"SELECT in_stock as texts FROM ingredient";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                in_stock.Add(rdr["texts"].ToString());
             
            }
            conn.Close();
        }
        private void btnpesan_Click(object sender, EventArgs e)
        {

            getid();
            getstok();
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

                string qs = $"SELECT me_status as texts FROM menu where me_ty_id = " + press + "";

                MySqlCommand cs = new MySqlCommand(qs, conn);

                conn.Open();
                MySqlDataReader rs = cs.ExecuteReader();

                int iss = 0;

                while (rs.Read())
                {
                    statusm[iss] = rs["texts"].ToString();
                    iss++;
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


                string qs = $"SELECT bu_status as texts FROM bundle WHERE bu_id > 0;";

                MySqlCommand cs = new MySqlCommand(qs, conn);

                conn.Open();
                MySqlDataReader rs = cs.ExecuteReader();

                int iss = 0;

                while (rs.Read())
                {
                    statusm[iss] = rs["texts"].ToString();
                    iss++;
                }
                conn.Close();

            }
        }

        private void generateButton()
        {
            reset = 0;
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
                    if (Int32.Parse(statusm[count]) != 1)
                    {
                        newButton.Enabled = false;
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
            textmakanan = button.Text;
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
            lbdescription.Text = "";
            if (press > 0 && press < 4)
            {
                string idds = "";
                string q0 = $"SELECT me_id as texts FROM menu WHERE me_name = '" + button.Text + "'";

                MySqlCommand c0 = new MySqlCommand(q0, conn);

                conn.Open();
                MySqlDataReader r0 = c0.ExecuteReader();

                while (r0.Read())
                {
                    idds=r0["texts"].ToString();
                }
                conn.Close();

                mi_in_id.Clear();
                string q1 = $"SELECT mi_in_id AS texts FROM menu_ingredient WHERE mi_me_id = (SELECT me_id FROM menu WHERE me_name = '"+button.Text+"')";

                MySqlCommand c1 = new MySqlCommand(q1, conn);

                conn.Open();
                MySqlDataReader r1 = c1.ExecuteReader();

                while (r1.Read())
                {
                 mi_in_id.Add(r1["texts"].ToString());
                }
                conn.Close();

                int quit = 1;
                int ccount = 1;
                while (quit != 0)
                {
                    foreach (string item in mi_in_id)
                    {
                        string q2 = $"SELECT mi_quantity AS texts FROM menu_ingredient WHERE mi_in_id = '" + item + "' and mi_me_id = '" + idds + "'";

                        MySqlCommand c2 = new MySqlCommand(q2, conn);

                        conn.Open();
                        MySqlDataReader r2 = c2.ExecuteReader();

                        while (r2.Read())
                        {
                            int numup = 0;
                            int cks = 0;
                            int minus = 0;
                            foreach (string ingid in in_id)
                            {
                                if (ingid.Equals(item))
                                {
                                    numup = Int32.Parse(r2["texts"].ToString()) * ccount;
                                    minus = Int32.Parse(in_stock[cks].ToString()) - numup;

                                    if (minus < Int32.Parse(r2["texts"].ToString()))
                                    {
                                        quit = 0;
                                    }
                                }
                                cks++;
                            }
                        }
                        conn.Close();
                    }
                    if (quit > 0)
                    {
                        ccount++;
                    }
                }
                nuobjek.Maximum = ccount;





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

                string querys = $"SELECT  me_price as texts FROM menu WHERE me_name = '" + button.Text + "';";

                MySqlCommand cmds = new MySqlCommand(querys, conn);

                conn.Open();
                MySqlDataReader rdrs = cmds.ExecuteReader();



                while (rdrs.Read())
                {
                    lbtotal.Text ="Total : "+ rdrs["texts"].ToString();
                    reset = Int32.Parse(rdrs["texts"].ToString());
                }
                conn.Close();

            }
            if (press == 4)
            {

                lbdescription.Text = "Paket ini berisi ";
                string query = $"SELECT me_name as texts FROM menu ,(SELECT mb_me_id AS idbud FROM bundle,menu_bundle WHERE bu_name = '" + button.Text + "' ORDER BY mb_me_id ASC) mn WHERE me_id = mn.idbud;";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                int i = 0;

                while (rdr.Read())
                {
                    if (i == 0)
                    {
                        lbdescription.Text = lbdescription.Text + rdr["texts"].ToString();
                    }
                    else
                    {
                        lbdescription.Text = lbdescription.Text + ", " + rdr["texts"].ToString();
                    }
                    i++;
                }
                conn.Close();


                string querys = $"SELECT  bu_price as texts FROM bundle WHERE bu_name =  '" + button.Text + "';";

                MySqlCommand cmds = new MySqlCommand(querys, conn);

                conn.Open();
                MySqlDataReader rdrs = cmds.ExecuteReader();



                while (rdrs.Read())
                {
                    lbtotal.Text = "Total : " + rdrs["texts"].ToString();
                    reset = Int32.Parse(rdrs["texts"].ToString());
                }
                conn.Close();






                ma_id.Clear();
                string qs = $"SELECT me_name as texts FROM menu ,(SELECT mb_me_id AS idbud FROM bundle,menu_bundle WHERE bu_name = '" + button.Text + "' ORDER BY mb_me_id ASC) mn WHERE me_id = mn.idbud;";

                MySqlCommand cs = new MySqlCommand(qs, conn);

                conn.Open();
                MySqlDataReader rs = cs.ExecuteReader();

                while (rs.Read())
                {
                    ma_id.Add(rs["texts"].ToString());
                }
                conn.Close();
                int quit = 1;
                int ccount = 1;
                while (quit != 0)
                {
                    foreach (string maid in ma_id)
                    {
                    string idds = "";
                    string q0 = $"SELECT me_id as texts FROM menu WHERE me_name = '" + maid + "'";

                    MySqlCommand c0 = new MySqlCommand(q0, conn);

                    conn.Open();
                    MySqlDataReader r0 = c0.ExecuteReader();

                    while (r0.Read())
                    {
                        idds = r0["texts"].ToString();
                    }
                    conn.Close();

                    mi_in_id.Clear();
                    string q1 = $"SELECT mi_in_id AS texts FROM menu_ingredient WHERE mi_me_id = (SELECT me_id FROM menu WHERE me_name = '" + maid + "')";

                    MySqlCommand c1 = new MySqlCommand(q1, conn);

                    conn.Open();
                    MySqlDataReader r1 = c1.ExecuteReader();

                    while (r1.Read())
                    {
                        mi_in_id.Add(r1["texts"].ToString());
                    }
                    conn.Close();

                        foreach (string item in mi_in_id)
                        {
                            string q2 = $"SELECT mi_quantity AS texts FROM menu_ingredient WHERE mi_in_id = '" + item + "' and mi_me_id = '" + idds + "'";

                            MySqlCommand c2 = new MySqlCommand(q2, conn);

                            conn.Open();
                            MySqlDataReader r2 = c2.ExecuteReader();

                            while (r2.Read())
                            {
                                int numup = 0;
                                int cks = 0;
                                int minus = 0;
                                foreach (string ingid in in_id)
                                {
                                    if (ingid.Equals(item))
                                    {
                                        numup = Int32.Parse(r2["texts"].ToString()) * ccount;
                                        minus = Int32.Parse(in_stock[cks].ToString()) - numup;

                                        if (minus < Int32.Parse(r2["texts"].ToString()))
                                        {
                                            quit = 0;
                                        }
                                    }
                                    cks++;
                                }
                            }
                            conn.Close();
                        }
                    }
                    if (quit > 0)
                    {
                        ccount++;
                    }
                }

                nuobjek.Maximum = ccount;
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
            lbtot.Text = "Total : Rp. ";
            foreach (Label lb in labels)
            {
                this.Controls.Remove(lb);
                lb.Dispose();
            }
            foreach (Button bb in buttons2)
            {
                this.Controls.Remove(bb);
                bb.Dispose();
            }
            int ly = 20;
            int lx = 40;

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
            lbtot.Visible = true;
            pbcart.Visible = true;
            pbtanya.Visible = true;




            if (pertamakali == 0)
            {
                listmakanan2.Add(textmakanan);
                listmakanan.Add(textmakanan + " x" + nuobjek.Value + " : " + (Convert.ToInt32(nuobjek.Value) * reset));
                pertamakali = 1;
            }
            for (int x = 0; x < this.listmakanan.Count; x++)
            {
                if (listmakanan[x].ToString().Contains(textmakanan) == true)
                {
                    sama = 1;
                    this.listmakanan[x] = textmakanan + " x" + nuobjek.Value + " : " + (Convert.ToInt32(nuobjek.Value) * reset);
                }
            }
            if (sama == 0)
            {
                listmakanan2.Add(textmakanan);
                listmakanan.Add(textmakanan + " x" + nuobjek.Value +" : "+ (Convert.ToInt32(nuobjek.Value) * reset));
            }
            else
            {
                sama = 0;
            }
            int hitungs = 0;
            int countss =0;
            foreach (var item in listmakanan)
            {
                string[] parts = item.ToString().Split(' ');
                string lastWord = parts[parts.Length - 1];


                int index = lastWord.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                string chars = lastWord.Substring(0, index);
                int num = Int32.Parse(lastWord.Substring(index));

                hitungs = hitungs + num;

                Label newlabel = new Label();
                labels.Add(newlabel);
                pbcart.Controls.Add(newlabel);
                newlabel.Text = item.ToString();
                newlabel.Location = new Point(lx, ly);
                newlabel.Size = new Size(300, 20);

                Button newButtons = new Button();
                buttons2.Add(newButtons);
                pbcart.Controls.Add(newButtons);
                newButtons.Text = "Delete";
                newButtons.Tag = countss;
                newButtons.Location = new Point(lx+300, ly-5);
                newButtons.Size = new Size(100, 25);
                newButtons.Click += new EventHandler(Clicks2);

                countss++;
                ly = ly + 40;

            }
            totaluang = hitungs;
            lbtot.Text = lbtot.Text + hitungs;
            nuobjek.Value = 1;
        }

        public void Clicks2(object sender, EventArgs e)
        {
            lbtot.Text = "Total : Rp. ";
            int ly = 20;
            int lx = 40;
            Button button = sender as Button;
            foreach (Button btn in buttons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            listmakanan2.RemoveAt(Int32.Parse(button.Tag.ToString()));
            listmakanan.RemoveAt(Int32.Parse(button.Tag.ToString()));
            foreach (Label lb in labels)
            {
                this.Controls.Remove(lb);
                lb.Dispose();
            }
            foreach (Button bb in buttons2)
            {
                this.Controls.Remove(bb);
                bb.Dispose();
            }
            int hitungs = 0;
            int countss = 0;
            foreach (var item in listmakanan)
            {
                string[] parts = item.ToString().Split(' ');
                string lastWord = parts[parts.Length - 1];


                int index = lastWord.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                string chars = lastWord.Substring(0, index);
                int num = Int32.Parse(lastWord.Substring(index));

                hitungs = hitungs + num;

                Label newlabel = new Label();
                labels.Add(newlabel);
                pbcart.Controls.Add(newlabel);
                newlabel.Text = item.ToString();
                newlabel.Location = new Point(lx, ly);
                newlabel.Size = new Size(300, 20);

                Button newButtons = new Button();
                buttons2.Add(newButtons);
                pbcart.Controls.Add(newButtons);
                newButtons.Text = "Delete";
                newButtons.Tag = countss;
                newButtons.Location = new Point(lx + 300, ly - 5);
                newButtons.Size = new Size(100, 25);
                newButtons.Click += new EventHandler(Clicks2);

                countss++;
                ly = ly + 40;

            }
            lbtot.Text = lbtot.Text + hitungs;
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
            pertamakali = 0;
            if (pertamakali == 0)
            {
                string query = $"SELECT COUNT(ht_id)+1 as texts FROM htrans;";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    htid = Int32.Parse(rdr["texts"].ToString());
                }
                conn.Close();


                string querys = $"SELECT COUNT(dt_id)+1 as texts FROM dtrans;";

                MySqlCommand cmds = new MySqlCommand(querys, conn);

                conn.Open();
                MySqlDataReader rdrs = cmds.ExecuteReader();

                while (rdrs.Read())
                {
                    dtid = Int32.Parse(rdrs["texts"].ToString());
                }
                conn.Close();

                string htrans = "";

                string querys1 = $"SELECT CONCAT(LPAD(DAY(CURDATE()), 2, '0'), LPAD(MONTH(CURDATE()),2 , '0'), YEAR(CURDATE())) AS texts FROM DUAL";

                MySqlCommand cmds1 = new MySqlCommand(querys1, conn);

                conn.Open();
                MySqlDataReader rdrs1 = cmds1.ExecuteReader();

                while (rdrs1.Read())
                {
                    htrans = rdrs1["texts"].ToString();
                }
                conn.Close();

                string htrans2 = "";
                string querys2 = $"SELECT (COUNT(*) + 1) as texts FROM htrans WHERE ht_invoice LIKE CONCAT('%','"+htrans+"','%') ";

                MySqlCommand cmds2 = new MySqlCommand(querys2, conn);

                conn.Open();
                MySqlDataReader rdrs2 = cmds2.ExecuteReader();

                while (rdrs2.Read())
                {
                    htrans2 = rdrs2["texts"].ToString();
                }
                conn.Close();
                if (Int32.Parse(htrans2) < 10)
                {
                    htrans = htrans + "0" + htrans2;
                }
                else if (Int32.Parse(htrans2) > 10)
                {
                    htrans = htrans +  htrans2;
                }

                string date = "";
                string querys3 = $"SELECT CURDATE() AS texts FROM DUAL";

                MySqlCommand cmds3 = new MySqlCommand(querys3, conn);

                conn.Open();
                MySqlDataReader rdrs3 = cmds3.ExecuteReader();

                while (rdrs3.Read())
                {
                    date = rdrs3["texts"].ToString();
                }
                conn.Close();

                try
                {

                    string Query = "INSERT INTO htrans VALUES ('"+htid+"','"+htrans+"','"+totaluang+"',CURDATE(),3);";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    conn.Open();
                    MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();    
                    while (MyReader2.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            int sama = 0;
            foreach (var item in listmakanan)
            {

                string[] parts = item.ToString().Split(' ');
                string lastWord = parts[parts.Length - 3];


                int index = lastWord.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                string chars = lastWord.Substring(0, index);
                int num = Int32.Parse(lastWord.Substring(index));

                foreach (var items in listmakanan2)
                {
                    int check = 0;
                    int idmebud = 0;
                    string querys = $"SELECT count(bu_id) as texts FROM bundle WHERE bu_name = '" + items.ToString() + "';";

                    MySqlCommand cmds = new MySqlCommand(querys, conn);

                    conn.Open();
                    MySqlDataReader rdrs = cmds.ExecuteReader();

                    while (rdrs.Read())
                    {
                        check = Int32.Parse(rdrs["texts"].ToString());
                    }
                    conn.Close();

                    string querys3 = $"SELECT bu_id as texts FROM bundle WHERE bu_name = '" + items.ToString() + "';";

                    MySqlCommand cmds3 = new MySqlCommand(querys3, conn);

                    conn.Open();
                    MySqlDataReader rdrs3 = cmds3.ExecuteReader();

                    while (rdrs3.Read())
                    {
                        idmebud = Int32.Parse(rdrs3["texts"].ToString());
                    }
                    conn.Close();

                    if (item.ToString().Contains(items.ToString()) == true)
                    {
                        if (check > 0)
                        {
                            string query = $"SELECT mb_me_id as texts FROM menu_bundle WHERE mb_bu_id = "+ idmebud + ";";

                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            conn.Open();
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                listdtrans.Add(rdr["texts"].ToString());
                            }
                            conn.Close();

                            foreach (var dt in listdtrans)
                            {
                                try
                                {

                                    string Query = "INSERT INTO dtrans VALUES ('" + dtid + "','" + htid + "','" + dt.ToString()+ "','" + num + "',1);";
                                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                                    conn.Open();
                                    MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                                    while (MyReader2.Read())
                                    {
                                    }
                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                dtid = dtid + 1;
                            }
                            listdtrans.Clear();
                        }
                        else
                        {
                            string ids = "";
                            string query = $"SELECT me_id as texts FROM menu WHERE me_name = '" + items.ToString() + "';";

                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            conn.Open();
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                ids = rdr["texts"].ToString();
                            }
                            conn.Close();


                            try
                            {
                                if (sama != Int32.Parse(ids))
                                {
                                    sama = Int32.Parse(ids);
                                    string Query = "INSERT INTO dtrans VALUES ('" + dtid + "','" + htid + "','" + ids + "','" + num + "',1);";
                                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                                    conn.Open();
                                    MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                                    while (MyReader2.Read())
                                    {
                                    }
                                    conn.Close();
                                    dtid = dtid + 1;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        
                        }
                    }
                }

            }

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
            pertamakali = 0;
            if (pertamakali == 0)
            {
                string query = $"SELECT COUNT(ht_id)+1 as texts FROM htrans;";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    htid = Int32.Parse(rdr["texts"].ToString());
                }
                conn.Close();


                string querys = $"SELECT COUNT(dt_id)+1 as texts FROM dtrans;";

                MySqlCommand cmds = new MySqlCommand(querys, conn);

                conn.Open();
                MySqlDataReader rdrs = cmds.ExecuteReader();

                while (rdrs.Read())
                {
                    dtid = Int32.Parse(rdrs["texts"].ToString());
                }
                conn.Close();

                string htrans = "";

                string querys1 = $"SELECT CONCAT(LPAD(DAY(CURDATE()), 2, '0'), LPAD(MONTH(CURDATE()),2 , '0'), YEAR(CURDATE())) AS texts FROM DUAL";

                MySqlCommand cmds1 = new MySqlCommand(querys1, conn);

                conn.Open();
                MySqlDataReader rdrs1 = cmds1.ExecuteReader();

                while (rdrs1.Read())
                {
                    htrans = rdrs1["texts"].ToString();
                }
                conn.Close();

                string htrans2 = "";
                string querys2 = $"SELECT (COUNT(*) + 1) as texts FROM htrans WHERE ht_invoice LIKE CONCAT('%','" + htrans + "','%') ";

                MySqlCommand cmds2 = new MySqlCommand(querys2, conn);

                conn.Open();
                MySqlDataReader rdrs2 = cmds2.ExecuteReader();

                while (rdrs2.Read())
                {
                    htrans2 = rdrs2["texts"].ToString();
                }
                conn.Close();
                if (Int32.Parse(htrans2) < 10)
                {
                    htrans = htrans + "0" + htrans2;
                }
                else if (Int32.Parse(htrans2) > 10)
                {
                    htrans = htrans + htrans2;
                }

                string date = "";
                string querys3 = $"SELECT CURDATE() AS texts FROM DUAL";

                MySqlCommand cmds3 = new MySqlCommand(querys3, conn);

                conn.Open();
                MySqlDataReader rdrs3 = cmds3.ExecuteReader();

                while (rdrs3.Read())
                {
                    date = rdrs3["texts"].ToString();
                }
                conn.Close();

                try
                {

                    string Query = "INSERT INTO htrans VALUES ('" + htid + "','" + htrans + "','" + totaluang + "',CURDATE(),2);";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    conn.Open();
                    MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            int sama = 0;
            foreach (var item in listmakanan)
            {

                string[] parts = item.ToString().Split(' ');
                string lastWord = parts[parts.Length - 3];


                int index = lastWord.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                string chars = lastWord.Substring(0, index);
                int num = Int32.Parse(lastWord.Substring(index));

                foreach (var items in listmakanan2)
                {
                    int check = 0;
                    int idmebud = 0;
                    string querys = $"SELECT count(bu_id) as texts FROM bundle WHERE bu_name = '" + items.ToString() + "';";

                    MySqlCommand cmds = new MySqlCommand(querys, conn);

                    conn.Open();
                    MySqlDataReader rdrs = cmds.ExecuteReader();

                    while (rdrs.Read())
                    {
                        check = Int32.Parse(rdrs["texts"].ToString());
                    }
                    conn.Close();
  
                    string querys3 = $"SELECT bu_id as texts FROM bundle WHERE bu_name = '" + items.ToString() + "';";

                    MySqlCommand cmds3 = new MySqlCommand(querys3, conn);

                    conn.Open();
                    MySqlDataReader rdrs3 = cmds3.ExecuteReader();

                    while (rdrs3.Read())
                    {
                        idmebud = Int32.Parse(rdrs3["texts"].ToString());
                    }
                    conn.Close();

                    if (item.ToString().Contains(items.ToString()) == true)
                    {
                        if (check > 0)
                        {
                            string query = $"SELECT mb_me_id as texts FROM menu_bundle WHERE mb_bu_id = " + idmebud + ";";

                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            conn.Open();
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                listdtrans.Add(rdr["texts"].ToString());
                              
                            }
                            conn.Close();

                            foreach (var dt in listdtrans)
                            {
                                try
                                {

                                    string Query = "INSERT INTO dtrans VALUES ('" + dtid + "','" + htid + "','" + dt.ToString() + "','" + num + "',1);";
                                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                                    conn.Open();
                                    MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                                    while (MyReader2.Read())
                                    {
                                    }
                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                dtid = dtid + 1;
                            }
                            listdtrans.Clear();
                        }
                        else
                        {
                  
                            string ids = "";
                            string query = $"SELECT me_id as texts FROM menu WHERE me_name = '" + items.ToString() + "';";

                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            conn.Open();
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                ids = rdr["texts"].ToString();
                            }
                            conn.Close();


                            try
                            {
                                if (sama != Int32.Parse(ids))
                                {
                                    sama = Int32.Parse(ids);
                                    string Query = "INSERT INTO dtrans VALUES ('" + dtid + "','" + htid + "','" + ids + "','" + num + "',1);";
                                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                                    conn.Open();
                                    MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();
                                    while (MyReader2.Read())
                                    {
                                    }
                                    conn.Close();
                                    dtid = dtid + 1;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }

            }
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
            foreach (Label lb in labels)
            {
                this.Controls.Remove(lb);
                lb.Dispose();
            }
            foreach (Button bb in buttons2)
            {
                this.Controls.Remove(bb);
                bb.Dispose();
            }
            htid = 0;
            dtid = 0;
            press = 0;
            counter = 0;
            hitung = 0;
            reset = 0;
            textmakanan = " ";
            pertamakali = 0;
            sama = 0;
            totaluang = 0;
            listmakanan.Clear();
            listmakanan2.Clear();
            labels.Clear();
            buttons.Clear();
            buttons2.Clear();
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

            lbtot.Visible = false;
            pbcart.Visible = false;
            btnback.Visible = false;

            bdessert.Visible = true;
            bmakanan.Visible = true;
            bminuman.Visible = true;
            bpaket.Visible = true;
            pictureBox1.Visible = true;
            nuobjek.Value = 1;
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

        private void nuobjek_ValueChanged(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(nuobjek.Value) * reset;
            lbtotal.Text ="Total : " + total.ToString();

        }
    }
}
