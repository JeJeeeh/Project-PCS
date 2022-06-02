
namespace User
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.btnpesan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bmakanan = new System.Windows.Forms.Button();
            this.bminuman = new System.Windows.Forms.Button();
            this.bdessert = new System.Windows.Forms.Button();
            this.bpaket = new System.Windows.Forms.Button();
            this.pbbuy = new System.Windows.Forms.PictureBox();
            this.pbgambar = new System.Windows.Forms.PictureBox();
            this.nuobjek = new System.Windows.Forms.NumericUpDown();
            this.lbdescription = new System.Windows.Forms.Label();
            this.lbtotal = new System.Windows.Forms.Label();
            this.bbuy = new System.Windows.Forms.Button();
            this.bntunai = new System.Windows.Forms.Button();
            this.btunai = new System.Windows.Forms.Button();
            this.lbpilihpembayaran = new System.Windows.Forms.Label();
            this.pbtanya = new System.Windows.Forms.PictureBox();
            this.lbnambah = new System.Windows.Forms.Label();
            this.bya = new System.Windows.Forms.Button();
            this.btidak = new System.Windows.Forms.Button();
            this.lproses = new System.Windows.Forms.Label();
            this.bkembali = new System.Windows.Forms.Button();
            this.lblist1 = new System.Windows.Forms.Label();
            this.lblist2 = new System.Windows.Forms.Label();
            this.lbtot = new System.Windows.Forms.Label();
            this.pbcart = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnback = new System.Windows.Forms.Button();
            this.pbverify = new System.Windows.Forms.PictureBox();
            this.pbkartu = new System.Windows.Forms.PictureBox();
            this.tbpin = new System.Windows.Forms.TextBox();
            this.lbpin = new System.Windows.Forms.Label();
            this.pbpin = new System.Windows.Forms.PictureBox();
            this.lbprosses2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbgambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuobjek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtanya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbverify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbkartu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PbMenu
            // 
            this.PbMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.PbMenu.Location = new System.Drawing.Point(233, 251);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(573, 194);
            this.PbMenu.TabIndex = 1;
            this.PbMenu.TabStop = false;
            // 
            // btnpesan
            // 
            this.btnpesan.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20F);
            this.btnpesan.Location = new System.Drawing.Point(240, 258);
            this.btnpesan.Name = "btnpesan";
            this.btnpesan.Size = new System.Drawing.Size(558, 180);
            this.btnpesan.TabIndex = 2;
            this.btnpesan.Text = "Pesan Sekarang";
            this.btnpesan.UseVisualStyleBackColor = true;
            this.btnpesan.Click += new System.EventHandler(this.btnpesan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Linen;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 705);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // bmakanan
            // 
            this.bmakanan.Location = new System.Drawing.Point(20, 55);
            this.bmakanan.Name = "bmakanan";
            this.bmakanan.Size = new System.Drawing.Size(141, 55);
            this.bmakanan.TabIndex = 4;
            this.bmakanan.Text = "Makanan";
            this.bmakanan.UseVisualStyleBackColor = true;
            this.bmakanan.Visible = false;
            this.bmakanan.Click += new System.EventHandler(this.bmakanan_Click);
            // 
            // bminuman
            // 
            this.bminuman.Location = new System.Drawing.Point(20, 116);
            this.bminuman.Name = "bminuman";
            this.bminuman.Size = new System.Drawing.Size(141, 55);
            this.bminuman.TabIndex = 5;
            this.bminuman.Text = "Minuman";
            this.bminuman.UseVisualStyleBackColor = true;
            this.bminuman.Visible = false;
            this.bminuman.Click += new System.EventHandler(this.bminuman_Click);
            // 
            // bdessert
            // 
            this.bdessert.Location = new System.Drawing.Point(20, 177);
            this.bdessert.Name = "bdessert";
            this.bdessert.Size = new System.Drawing.Size(141, 55);
            this.bdessert.TabIndex = 6;
            this.bdessert.Text = "Dessert";
            this.bdessert.UseVisualStyleBackColor = true;
            this.bdessert.Visible = false;
            this.bdessert.Click += new System.EventHandler(this.bdessert_Click);
            // 
            // bpaket
            // 
            this.bpaket.Location = new System.Drawing.Point(20, 238);
            this.bpaket.Name = "bpaket";
            this.bpaket.Size = new System.Drawing.Size(141, 55);
            this.bpaket.TabIndex = 7;
            this.bpaket.Text = "Paket";
            this.bpaket.UseVisualStyleBackColor = true;
            this.bpaket.Visible = false;
            this.bpaket.Click += new System.EventHandler(this.bpaket_Click);
            // 
            // pbbuy
            // 
            this.pbbuy.BackColor = System.Drawing.Color.Linen;
            this.pbbuy.Location = new System.Drawing.Point(-3, -2);
            this.pbbuy.Name = "pbbuy";
            this.pbbuy.Size = new System.Drawing.Size(1037, 752);
            this.pbbuy.TabIndex = 8;
            this.pbbuy.TabStop = false;
            this.pbbuy.Visible = false;
            // 
            // pbgambar
            // 
            this.pbgambar.BackColor = System.Drawing.Color.Gainsboro;
            this.pbgambar.Location = new System.Drawing.Point(12, 12);
            this.pbgambar.Name = "pbgambar";
            this.pbgambar.Size = new System.Drawing.Size(500, 500);
            this.pbgambar.TabIndex = 9;
            this.pbgambar.TabStop = false;
            this.pbgambar.Visible = false;
            // 
            // nuobjek
            // 
            this.nuobjek.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuobjek.Location = new System.Drawing.Point(12, 518);
            this.nuobjek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuobjek.Name = "nuobjek";
            this.nuobjek.Size = new System.Drawing.Size(500, 48);
            this.nuobjek.TabIndex = 10;
            this.nuobjek.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nuobjek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuobjek.Visible = false;
            // 
            // lbdescription
            // 
            this.lbdescription.AutoSize = true;
            this.lbdescription.BackColor = System.Drawing.Color.Linen;
            this.lbdescription.Location = new System.Drawing.Point(538, 50);
            this.lbdescription.Name = "lbdescription";
            this.lbdescription.Size = new System.Drawing.Size(210, 20);
            this.lbdescription.TabIndex = 11;
            this.lbdescription.Text = "Description.................";
            this.lbdescription.Visible = false;
            // 
            // lbtotal
            // 
            this.lbtotal.AutoSize = true;
            this.lbtotal.BackColor = System.Drawing.Color.Linen;
            this.lbtotal.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotal.Location = new System.Drawing.Point(14, 582);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(84, 32);
            this.lbtotal.TabIndex = 12;
            this.lbtotal.Text = "Total:";
            this.lbtotal.Visible = false;
            // 
            // bbuy
            // 
            this.bbuy.Location = new System.Drawing.Point(12, 631);
            this.bbuy.Name = "bbuy";
            this.bbuy.Size = new System.Drawing.Size(485, 85);
            this.bbuy.TabIndex = 13;
            this.bbuy.Text = "Buy";
            this.bbuy.UseVisualStyleBackColor = true;
            this.bbuy.Visible = false;
            this.bbuy.Click += new System.EventHandler(this.bbuy_Click);
            // 
            // bntunai
            // 
            this.bntunai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntunai.BackgroundImage")));
            this.bntunai.Location = new System.Drawing.Point(126, 177);
            this.bntunai.Name = "bntunai";
            this.bntunai.Size = new System.Drawing.Size(300, 300);
            this.bntunai.TabIndex = 14;
            this.bntunai.UseVisualStyleBackColor = true;
            this.bntunai.Visible = false;
            this.bntunai.Click += new System.EventHandler(this.bntunai_Click);
            // 
            // btunai
            // 
            this.btunai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btunai.BackgroundImage")));
            this.btunai.Location = new System.Drawing.Point(620, 177);
            this.btunai.Name = "btunai";
            this.btunai.Size = new System.Drawing.Size(300, 300);
            this.btunai.TabIndex = 15;
            this.btunai.UseVisualStyleBackColor = true;
            this.btunai.Visible = false;
            this.btunai.Click += new System.EventHandler(this.btunai_Click);
            // 
            // lbpilihpembayaran
            // 
            this.lbpilihpembayaran.AutoSize = true;
            this.lbpilihpembayaran.BackColor = System.Drawing.Color.White;
            this.lbpilihpembayaran.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 30.8F);
            this.lbpilihpembayaran.Location = new System.Drawing.Point(257, 70);
            this.lbpilihpembayaran.Name = "lbpilihpembayaran";
            this.lbpilihpembayaran.Size = new System.Drawing.Size(629, 74);
            this.lbpilihpembayaran.TabIndex = 16;
            this.lbpilihpembayaran.Text = "Pilih Pembayaran.";
            this.lbpilihpembayaran.Visible = false;
            // 
            // pbtanya
            // 
            this.pbtanya.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pbtanya.Location = new System.Drawing.Point(-3, -2);
            this.pbtanya.Name = "pbtanya";
            this.pbtanya.Size = new System.Drawing.Size(1037, 752);
            this.pbtanya.TabIndex = 17;
            this.pbtanya.TabStop = false;
            this.pbtanya.Visible = false;
            // 
            // lbnambah
            // 
            this.lbnambah.AutoSize = true;
            this.lbnambah.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbnambah.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.8F);
            this.lbnambah.Location = new System.Drawing.Point(348, 572);
            this.lbnambah.Name = "lbnambah";
            this.lbnambah.Size = new System.Drawing.Size(450, 49);
            this.lbnambah.TabIndex = 18;
            this.lbnambah.Text = "Nambah menu lain?";
            this.lbnambah.Visible = false;
            // 
            // bya
            // 
            this.bya.BackColor = System.Drawing.Color.White;
            this.bya.Font = new System.Drawing.Font("Times New Roman", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bya.Location = new System.Drawing.Point(270, 647);
            this.bya.Name = "bya";
            this.bya.Size = new System.Drawing.Size(156, 69);
            this.bya.TabIndex = 19;
            this.bya.Text = "YA";
            this.bya.UseVisualStyleBackColor = false;
            this.bya.Visible = false;
            this.bya.Click += new System.EventHandler(this.bya_Click);
            // 
            // btidak
            // 
            this.btidak.BackColor = System.Drawing.Color.White;
            this.btidak.Font = new System.Drawing.Font("Times New Roman", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btidak.Location = new System.Drawing.Point(620, 647);
            this.btidak.Name = "btidak";
            this.btidak.Size = new System.Drawing.Size(156, 69);
            this.btidak.TabIndex = 20;
            this.btidak.Text = "TIDAK";
            this.btidak.UseVisualStyleBackColor = false;
            this.btidak.Visible = false;
            this.btidak.Click += new System.EventHandler(this.btidak_Click);
            // 
            // lproses
            // 
            this.lproses.AutoSize = true;
            this.lproses.BackColor = System.Drawing.Color.White;
            this.lproses.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.8F);
            this.lproses.Location = new System.Drawing.Point(243, 217);
            this.lproses.Name = "lproses";
            this.lproses.Size = new System.Drawing.Size(690, 49);
            this.lproses.TabIndex = 21;
            this.lproses.Text = "Silahkan ke kasir terimakasih.";
            this.lproses.Visible = false;
            this.lproses.Click += new System.EventHandler(this.lproses_Click);
            // 
            // bkembali
            // 
            this.bkembali.Location = new System.Drawing.Point(285, 302);
            this.bkembali.Name = "bkembali";
            this.bkembali.Size = new System.Drawing.Size(454, 75);
            this.bkembali.TabIndex = 22;
            this.bkembali.Text = "Kembali";
            this.bkembali.UseVisualStyleBackColor = true;
            this.bkembali.Visible = false;
            this.bkembali.Click += new System.EventHandler(this.bkembali_Click);
            // 
            // lblist1
            // 
            this.lblist1.AutoSize = true;
            this.lblist1.BackColor = System.Drawing.Color.White;
            this.lblist1.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblist1.Location = new System.Drawing.Point(11, 21);
            this.lblist1.Name = "lblist1";
            this.lblist1.Size = new System.Drawing.Size(253, 40);
            this.lblist1.TabIndex = 23;
            this.lblist1.Text = "French fries  x1";
            this.lblist1.Visible = false;
            // 
            // lblist2
            // 
            this.lblist2.AutoSize = true;
            this.lblist2.BackColor = System.Drawing.Color.White;
            this.lblist2.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblist2.Location = new System.Drawing.Point(11, 73);
            this.lblist2.Name = "lblist2";
            this.lblist2.Size = new System.Drawing.Size(255, 40);
            this.lblist2.TabIndex = 24;
            this.lblist2.Text = "Hamburger   x2";
            this.lblist2.Visible = false;
            // 
            // lbtot
            // 
            this.lbtot.AutoSize = true;
            this.lbtot.BackColor = System.Drawing.Color.White;
            this.lbtot.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtot.Location = new System.Drawing.Point(13, 526);
            this.lbtot.Name = "lbtot";
            this.lbtot.Size = new System.Drawing.Size(204, 40);
            this.lbtot.TabIndex = 25;
            this.lbtot.Text = "Total : Rp. 0";
            this.lbtot.Visible = false;
            // 
            // pbcart
            // 
            this.pbcart.BackColor = System.Drawing.Color.White;
            this.pbcart.Location = new System.Drawing.Point(-3, -5);
            this.pbcart.Name = "pbcart";
            this.pbcart.Size = new System.Drawing.Size(1037, 571);
            this.pbcart.TabIndex = 26;
            this.pbcart.TabStop = false;
            this.pbcart.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(758, 631);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(263, 85);
            this.btnback.TabIndex = 27;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Visible = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // pbverify
            // 
            this.pbverify.BackColor = System.Drawing.Color.White;
            this.pbverify.Location = new System.Drawing.Point(-3, -5);
            this.pbverify.Name = "pbverify";
            this.pbverify.Size = new System.Drawing.Size(1037, 755);
            this.pbverify.TabIndex = 28;
            this.pbverify.TabStop = false;
            this.pbverify.Visible = false;
            // 
            // pbkartu
            // 
            this.pbkartu.BackColor = System.Drawing.Color.White;
            this.pbkartu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbkartu.BackgroundImage")));
            this.pbkartu.Location = new System.Drawing.Point(305, 192);
            this.pbkartu.Name = "pbkartu";
            this.pbkartu.Size = new System.Drawing.Size(423, 340);
            this.pbkartu.TabIndex = 30;
            this.pbkartu.TabStop = false;
            this.pbkartu.Visible = false;
            // 
            // tbpin
            // 
            this.tbpin.BackColor = System.Drawing.Color.White;
            this.tbpin.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 30.8F);
            this.tbpin.Location = new System.Drawing.Point(432, 352);
            this.tbpin.Name = "tbpin";
            this.tbpin.Size = new System.Drawing.Size(183, 71);
            this.tbpin.TabIndex = 31;
            this.tbpin.Visible = false;
            this.tbpin.TextChanged += new System.EventHandler(this.tbpin_TextChanged);
            // 
            // lbpin
            // 
            this.lbpin.AutoSize = true;
            this.lbpin.BackColor = System.Drawing.Color.Silver;
            this.lbpin.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpin.Location = new System.Drawing.Point(395, 309);
            this.lbpin.Name = "lbpin";
            this.lbpin.Size = new System.Drawing.Size(324, 40);
            this.lbpin.TabIndex = 32;
            this.lbpin.Text = "Masukkan Pin Anda";
            this.lbpin.Visible = false;
            // 
            // pbpin
            // 
            this.pbpin.BackColor = System.Drawing.Color.Silver;
            this.pbpin.Location = new System.Drawing.Point(337, 294);
            this.pbpin.Name = "pbpin";
            this.pbpin.Size = new System.Drawing.Size(364, 144);
            this.pbpin.TabIndex = 33;
            this.pbpin.TabStop = false;
            this.pbpin.Visible = false;
            // 
            // lbprosses2
            // 
            this.lbprosses2.AutoSize = true;
            this.lbprosses2.BackColor = System.Drawing.Color.White;
            this.lbprosses2.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbprosses2.Location = new System.Drawing.Point(245, 251);
            this.lbprosses2.Name = "lbprosses2";
            this.lbprosses2.Size = new System.Drawing.Size(667, 40);
            this.lbprosses2.TabIndex = 34;
            this.lbprosses2.Text = "Pesanan anda sedang diproses terimakasih.";
            this.lbprosses2.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(-2, -5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1037, 755);
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1033, 744);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbprosses2);
            this.Controls.Add(this.tbpin);
            this.Controls.Add(this.lbpin);
            this.Controls.Add(this.pbpin);
            this.Controls.Add(this.pbkartu);
            this.Controls.Add(this.pbverify);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.lbtot);
            this.Controls.Add(this.lblist2);
            this.Controls.Add(this.lblist1);
            this.Controls.Add(this.pbcart);
            this.Controls.Add(this.bkembali);
            this.Controls.Add(this.lproses);
            this.Controls.Add(this.btidak);
            this.Controls.Add(this.bya);
            this.Controls.Add(this.lbnambah);
            this.Controls.Add(this.pbtanya);
            this.Controls.Add(this.lbpilihpembayaran);
            this.Controls.Add(this.btunai);
            this.Controls.Add(this.bntunai);
            this.Controls.Add(this.bbuy);
            this.Controls.Add(this.lbtotal);
            this.Controls.Add(this.lbdescription);
            this.Controls.Add(this.nuobjek);
            this.Controls.Add(this.pbgambar);
            this.Controls.Add(this.pbbuy);
            this.Controls.Add(this.bpaket);
            this.Controls.Add(this.bdessert);
            this.Controls.Add(this.bminuman);
            this.Controls.Add(this.bmakanan);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnpesan);
            this.Controls.Add(this.PbMenu);
            this.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "USER MENU";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbgambar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuobjek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtanya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbverify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbkartu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Button btnpesan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bmakanan;
        private System.Windows.Forms.Button bminuman;
        private System.Windows.Forms.Button bdessert;
        private System.Windows.Forms.Button bpaket;
        private System.Windows.Forms.PictureBox pbbuy;
        private System.Windows.Forms.PictureBox pbgambar;
        private System.Windows.Forms.NumericUpDown nuobjek;
        private System.Windows.Forms.Label lbdescription;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Button bbuy;
        private System.Windows.Forms.Button bntunai;
        private System.Windows.Forms.Button btunai;
        private System.Windows.Forms.Label lbpilihpembayaran;
        private System.Windows.Forms.PictureBox pbtanya;
        private System.Windows.Forms.Label lbnambah;
        private System.Windows.Forms.Button bya;
        private System.Windows.Forms.Button btidak;
        private System.Windows.Forms.Label lproses;
        private System.Windows.Forms.Button bkembali;
        private System.Windows.Forms.Label lblist1;
        private System.Windows.Forms.Label lblist2;
        private System.Windows.Forms.Label lbtot;
        private System.Windows.Forms.PictureBox pbcart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.PictureBox pbverify;
        private System.Windows.Forms.PictureBox pbkartu;
        private System.Windows.Forms.TextBox tbpin;
        private System.Windows.Forms.Label lbpin;
        private System.Windows.Forms.PictureBox pbpin;
        private System.Windows.Forms.Label lbprosses2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

