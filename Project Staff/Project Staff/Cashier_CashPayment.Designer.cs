﻿
namespace Project_Staff
{
    partial class Cashier_CashPayment
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
            this.lGrandTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lTNum = new System.Windows.Forms.Label();
            this.lTotal = new System.Windows.Forms.Label();
            this.dgvCashier = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).BeginInit();
            this.SuspendLayout();
            // 
            // lGrandTotal
            // 
            this.lGrandTotal.AutoSize = true;
            this.lGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGrandTotal.Location = new System.Drawing.Point(487, 429);
            this.lGrandTotal.Name = "lGrandTotal";
            this.lGrandTotal.Size = new System.Drawing.Size(267, 25);
            this.lGrandTotal.TabIndex = 14;
            this.lGrandTotal.Text = "Grand Total = Rp. 110.000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(579, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "PPN = 10%";
            // 
            // lTNum
            // 
            this.lTNum.AutoSize = true;
            this.lTNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTNum.Location = new System.Drawing.Point(12, 27);
            this.lTNum.Name = "lTNum";
            this.lTNum.Size = new System.Drawing.Size(313, 25);
            this.lTNum.TabIndex = 12;
            this.lTNum.Text = "Transaction Number : blablabla";
            // 
            // lTotal
            // 
            this.lTotal.AutoSize = true;
            this.lTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTotal.Location = new System.Drawing.Point(564, 372);
            this.lTotal.Name = "lTotal";
            this.lTotal.Size = new System.Drawing.Size(190, 24);
            this.lTotal.TabIndex = 11;
            this.lTotal.Text = "Total = Rp. 100.000";
            // 
            // dgvCashier
            // 
            this.dgvCashier.AllowUserToAddRows = false;
            this.dgvCashier.AllowUserToDeleteRows = false;
            this.dgvCashier.AllowUserToResizeColumns = false;
            this.dgvCashier.AllowUserToResizeRows = false;
            this.dgvCashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashier.Location = new System.Drawing.Point(14, 75);
            this.dgvCashier.Name = "dgvCashier";
            this.dgvCashier.ReadOnly = true;
            this.dgvCashier.RowHeadersVisible = false;
            this.dgvCashier.RowHeadersWidth = 51;
            this.dgvCashier.RowTemplate.Height = 24;
            this.dgvCashier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashier.Size = new System.Drawing.Size(775, 286);
            this.dgvCashier.TabIndex = 10;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(679, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 57);
            this.btnBack.TabIndex = 70;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPay.Location = new System.Drawing.Point(679, 457);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(110, 57);
            this.btnPay.TabIndex = 71;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // Cashier_CashPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 522);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lGrandTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lTNum);
            this.Controls.Add(this.lTotal);
            this.Controls.Add(this.dgvCashier);
            this.Name = "Cashier_CashPayment";
            this.Text = "Cashier_CashPayment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lGrandTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lTNum;
        private System.Windows.Forms.Label lTotal;
        private System.Windows.Forms.DataGridView dgvCashier;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPay;
    }
}