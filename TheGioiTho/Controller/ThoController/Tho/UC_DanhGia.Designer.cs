namespace TheGioiTho.Controller.ThoController.Tho
{
    partial class UC_DanhGia
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBaiDanhGia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiDanhGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaiDanhGia
            // 
            this.dgvBaiDanhGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaiDanhGia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBaiDanhGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaiDanhGia.Location = new System.Drawing.Point(3, 3);
            this.dgvBaiDanhGia.Name = "dgvBaiDanhGia";
            this.dgvBaiDanhGia.RowHeadersWidth = 51;
            this.dgvBaiDanhGia.RowTemplate.Height = 24;
            this.dgvBaiDanhGia.Size = new System.Drawing.Size(662, 412);
            this.dgvBaiDanhGia.TabIndex = 2;
            // 
            // UC_DanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvBaiDanhGia);
            this.Name = "UC_DanhGia";
            this.Size = new System.Drawing.Size(668, 418);
            this.Load += new System.EventHandler(this.UC_DanhGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiDanhGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaiDanhGia;
    }
}
