
namespace Project_Staff
{
    partial class Cashier
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
            this.lWelcome = new System.Windows.Forms.Label();
            this.dgvCashPay = new System.Windows.Forms.DataGridView();
            this.dgvReady = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReady)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lWelcome
            // 
            this.lWelcome.AutoSize = true;
            this.lWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWelcome.Location = new System.Drawing.Point(6, 16);
            this.lWelcome.Name = "lWelcome";
            this.lWelcome.Size = new System.Drawing.Size(219, 29);
            this.lWelcome.TabIndex = 10;
            this.lWelcome.Text = "Welcome CLAIRE";
            // 
            // dgvCashPay
            // 
            this.dgvCashPay.AllowUserToAddRows = false;
            this.dgvCashPay.AllowUserToDeleteRows = false;
            this.dgvCashPay.AllowUserToResizeColumns = false;
            this.dgvCashPay.AllowUserToResizeRows = false;
            this.dgvCashPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashPay.Location = new System.Drawing.Point(6, 21);
            this.dgvCashPay.Name = "dgvCashPay";
            this.dgvCashPay.ReadOnly = true;
            this.dgvCashPay.RowHeadersVisible = false;
            this.dgvCashPay.RowHeadersWidth = 51;
            this.dgvCashPay.RowTemplate.Height = 24;
            this.dgvCashPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashPay.Size = new System.Drawing.Size(743, 267);
            this.dgvCashPay.TabIndex = 1;
            this.dgvCashPay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCashPay_MouseDoubleClick);
            // 
            // dgvReady
            // 
            this.dgvReady.AllowUserToAddRows = false;
            this.dgvReady.AllowUserToDeleteRows = false;
            this.dgvReady.AllowUserToResizeColumns = false;
            this.dgvReady.AllowUserToResizeRows = false;
            this.dgvReady.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReady.Location = new System.Drawing.Point(6, 21);
            this.dgvReady.Name = "dgvReady";
            this.dgvReady.ReadOnly = true;
            this.dgvReady.RowHeadersVisible = false;
            this.dgvReady.RowHeadersWidth = 51;
            this.dgvReady.RowTemplate.Height = 24;
            this.dgvReady.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReady.Size = new System.Drawing.Size(743, 278);
            this.dgvReady.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvReady);
            this.groupBox2.Location = new System.Drawing.Point(11, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 309);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Ready";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCashPay);
            this.groupBox1.Location = new System.Drawing.Point(11, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 304);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cash Payment";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Red;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogOut.Location = new System.Drawing.Point(661, 4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(110, 57);
            this.btnLogOut.TabIndex = 71;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 693);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lWelcome);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Cashier";
            this.Text = "Cashier";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReady)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lWelcome;
        private System.Windows.Forms.DataGridView dgvCashPay;
        private System.Windows.Forms.DataGridView dgvReady;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogOut;
    }
}