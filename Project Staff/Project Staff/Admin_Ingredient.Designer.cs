
namespace Project_Staff
{
    partial class Admin_Ingredient
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nupStock = new System.Windows.Forms.NumericUpDown();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(552, 455);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 40);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(404, 455);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 40);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(256, 455);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(142, 40);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(108, 455);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(142, 40);
            this.btnInsert.TabIndex = 32;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(290, 42);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(101, 27);
            this.btnFilter.TabIndex = 31;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Ready",
            "Out of Stock"});
            this.cbFilter.Location = new System.Drawing.Point(140, 44);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(144, 24);
            this.cbFilter.TabIndex = 21;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AllowUserToResizeColumns = false;
            this.dgvStaff.AllowUserToResizeRows = false;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(12, 76);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(776, 244);
            this.dgvStaff.TabIndex = 20;
            this.dgvStaff.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStaff_CellMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ingredient List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Welcome Admin";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(488, 340);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(268, 22);
            this.tbPrice.TabIndex = 41;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(108, 378);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(268, 22);
            this.tbName.TabIndex = 43;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(108, 340);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(268, 22);
            this.tbId.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(418, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "Stock :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Price :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Ingredient ID :";
            // 
            // nupStock
            // 
            this.nupStock.Location = new System.Drawing.Point(488, 381);
            this.nupStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupStock.Name = "nupStock";
            this.nupStock.Size = new System.Drawing.Size(268, 22);
            this.nupStock.TabIndex = 45;
            this.nupStock.ValueChanged += new System.EventHandler(this.nupStock_ValueChanged);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(397, 42);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(101, 27);
            this.btnClearFilter.TabIndex = 46;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Location = new System.Drawing.Point(678, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 57);
            this.btnLogout.TabIndex = 48;
            this.btnLogout.Text = "Back";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Admin_Ingredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.nupStock);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Admin_Ingredient";
            this.Text = "Admin_Ingredient";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupStock;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnLogout;
    }
}