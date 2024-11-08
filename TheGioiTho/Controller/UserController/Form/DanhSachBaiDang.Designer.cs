namespace TheGioiTho
{
    partial class DanhSachBaiDang
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
            this.dgvDanhSachBaiDang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachBaiDang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSachBaiDang
            // 
            this.dgvDanhSachBaiDang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachBaiDang.Location = new System.Drawing.Point(0, 484);
            this.dgvDanhSachBaiDang.Name = "dgvDanhSachBaiDang";
            this.dgvDanhSachBaiDang.RowHeadersWidth = 51;
            this.dgvDanhSachBaiDang.RowTemplate.Height = 24;
            this.dgvDanhSachBaiDang.Size = new System.Drawing.Size(1031, 10);
            this.dgvDanhSachBaiDang.TabIndex = 0;
            // 
            // DanhSachBaiDang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 495);
            this.Controls.Add(this.dgvDanhSachBaiDang);
            this.Name = "DanhSachBaiDang";
            this.Text = "DanhSachBaiDang";
            this.Load += new System.EventHandler(this.DanhSachBaiDang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachBaiDang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSachBaiDang;
    }
}