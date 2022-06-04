
namespace Project_Staff
{
    partial class Cashier_OrderReady
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
            this.dgvCashierDetail = new System.Windows.Forms.DataGridView();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lTNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashierDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCashierDetail
            // 
            this.dgvCashierDetail.AllowUserToAddRows = false;
            this.dgvCashierDetail.AllowUserToDeleteRows = false;
            this.dgvCashierDetail.AllowUserToResizeColumns = false;
            this.dgvCashierDetail.AllowUserToResizeRows = false;
            this.dgvCashierDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashierDetail.Location = new System.Drawing.Point(13, 73);
            this.dgvCashierDetail.Name = "dgvCashierDetail";
            this.dgvCashierDetail.ReadOnly = true;
            this.dgvCashierDetail.RowHeadersVisible = false;
            this.dgvCashierDetail.RowHeadersWidth = 51;
            this.dgvCashierDetail.RowTemplate.Height = 24;
            this.dgvCashierDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashierDetail.Size = new System.Drawing.Size(775, 294);
            this.dgvCashierDetail.TabIndex = 5;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDone.Location = new System.Drawing.Point(678, 373);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(110, 57);
            this.btnDone.TabIndex = 72;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(678, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 57);
            this.btnBack.TabIndex = 71;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lTNum
            // 
            this.lTNum.AutoSize = true;
            this.lTNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTNum.Location = new System.Drawing.Point(12, 23);
            this.lTNum.Name = "lTNum";
            this.lTNum.Size = new System.Drawing.Size(313, 25);
            this.lTNum.TabIndex = 73;
            this.lTNum.Text = "Transaction Number : blablabla";
            // 
            // Cashier_OrderReady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 438);
            this.Controls.Add(this.lTNum);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvCashierDetail);
            this.Name = "Cashier_OrderReady";
            this.Text = "Cashier_OrderReady";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashierDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCashierDetail;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lTNum;
    }
}