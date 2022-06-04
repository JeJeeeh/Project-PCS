
namespace Project_Staff
{
    partial class Kitchen
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
            this.dgvKitchen = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKitchen
            // 
            this.dgvKitchen.AllowUserToAddRows = false;
            this.dgvKitchen.AllowUserToDeleteRows = false;
            this.dgvKitchen.AllowUserToResizeColumns = false;
            this.dgvKitchen.AllowUserToResizeRows = false;
            this.dgvKitchen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitchen.Location = new System.Drawing.Point(15, 69);
            this.dgvKitchen.Name = "dgvKitchen";
            this.dgvKitchen.ReadOnly = true;
            this.dgvKitchen.RowHeadersVisible = false;
            this.dgvKitchen.RowHeadersWidth = 51;
            this.dgvKitchen.RowTemplate.Height = 24;
            this.dgvKitchen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKitchen.Size = new System.Drawing.Size(776, 383);
            this.dgvKitchen.TabIndex = 8;
            this.dgvKitchen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKitchen_MouseDoubleClick);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Location = new System.Drawing.Point(678, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 57);
            this.btnLogout.TabIndex = 71;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lWelcome
            // 
            this.lWelcome.AutoSize = true;
            this.lWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWelcome.Location = new System.Drawing.Point(12, 21);
            this.lWelcome.Name = "lWelcome";
            this.lWelcome.Size = new System.Drawing.Size(181, 25);
            this.lWelcome.TabIndex = 72;
            this.lWelcome.Text = "Welcome Kitchen";
            // 
            // Kitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.lWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dgvKitchen);
            this.Name = "Kitchen";
            this.Text = "Kitchen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvKitchen;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lWelcome;
    }
}