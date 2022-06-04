
namespace Project_Staff
{
    partial class Kitchen_Detail
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lTNum = new System.Windows.Forms.Label();
            this.dgvKitchenDetail = new System.Windows.Forms.DataGridView();
            this.btnCook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(678, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 57);
            this.btnBack.TabIndex = 73;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lTNum
            // 
            this.lTNum.AutoSize = true;
            this.lTNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTNum.Location = new System.Drawing.Point(11, 22);
            this.lTNum.Name = "lTNum";
            this.lTNum.Size = new System.Drawing.Size(313, 25);
            this.lTNum.TabIndex = 72;
            this.lTNum.Text = "Transaction Number : blablabla";
            // 
            // dgvKitchenDetail
            // 
            this.dgvKitchenDetail.AllowUserToAddRows = false;
            this.dgvKitchenDetail.AllowUserToDeleteRows = false;
            this.dgvKitchenDetail.AllowUserToResizeColumns = false;
            this.dgvKitchenDetail.AllowUserToResizeRows = false;
            this.dgvKitchenDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitchenDetail.Location = new System.Drawing.Point(13, 70);
            this.dgvKitchenDetail.Name = "dgvKitchenDetail";
            this.dgvKitchenDetail.ReadOnly = true;
            this.dgvKitchenDetail.RowHeadersVisible = false;
            this.dgvKitchenDetail.RowHeadersWidth = 51;
            this.dgvKitchenDetail.RowTemplate.Height = 24;
            this.dgvKitchenDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKitchenDetail.Size = new System.Drawing.Size(775, 286);
            this.dgvKitchenDetail.TabIndex = 71;
            // 
            // btnCook
            // 
            this.btnCook.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCook.FlatAppearance.BorderSize = 0;
            this.btnCook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCook.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCook.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCook.Location = new System.Drawing.Point(678, 362);
            this.btnCook.Name = "btnCook";
            this.btnCook.Size = new System.Drawing.Size(110, 57);
            this.btnCook.TabIndex = 74;
            this.btnCook.Text = "Cook";
            this.btnCook.UseVisualStyleBackColor = false;
            this.btnCook.Click += new System.EventHandler(this.btnCook_Click);
            // 
            // Kitchen_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.btnCook);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lTNum);
            this.Controls.Add(this.dgvKitchenDetail);
            this.Name = "Kitchen_Detail";
            this.Text = "Kitchen_Detail";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lTNum;
        private System.Windows.Forms.DataGridView dgvKitchenDetail;
        private System.Windows.Forms.Button btnCook;
    }
}