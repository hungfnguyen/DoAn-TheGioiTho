namespace TheGioiTho.Controller.Tho
{
    partial class UC_XemDanhGia
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblsao = new System.Windows.Forms.Label();
            this.ptbHinhAnh = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhanXet = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.lblNhanXet = new System.Windows.Forms.Label();
            this.lblSoSao = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.lblssao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiDanhGia)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaiDanhGia
            // 
            this.dgvBaiDanhGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaiDanhGia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBaiDanhGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaiDanhGia.Location = new System.Drawing.Point(3, 0);
            this.dgvBaiDanhGia.Name = "dgvBaiDanhGia";
            this.dgvBaiDanhGia.RowHeadersWidth = 51;
            this.dgvBaiDanhGia.RowTemplate.Height = 24;
            this.dgvBaiDanhGia.Size = new System.Drawing.Size(807, 492);
            this.dgvBaiDanhGia.TabIndex = 1;
            this.dgvBaiDanhGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaiDanhGia_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblsao);
            this.panel1.Controls.Add(this.ptbHinhAnh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNhanXet);
            this.panel1.Controls.Add(this.txtTenKhachHang);
            this.panel1.Controls.Add(this.lblNhanXet);
            this.panel1.Controls.Add(this.lblSoSao);
            this.panel1.Controls.Add(this.lblTenKhachHang);
            this.panel1.Controls.Add(this.lblssao);
            this.panel1.Location = new System.Drawing.Point(816, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 486);
            this.panel1.TabIndex = 2;
            // 
            // lblsao
            // 
            this.lblsao.AllowDrop = true;
            this.lblsao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsao.Location = new System.Drawing.Point(120, 82);
            this.lblsao.Name = "lblsao";
            this.lblsao.Size = new System.Drawing.Size(58, 41);
            this.lblsao.TabIndex = 7;
            this.lblsao.Text = "so sao";
            this.lblsao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbHinhAnh
            // 
            this.ptbHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbHinhAnh.Location = new System.Drawing.Point(27, 288);
            this.ptbHinhAnh.Name = "ptbHinhAnh";
            this.ptbHinhAnh.Size = new System.Drawing.Size(307, 184);
            this.ptbHinhAnh.TabIndex = 6;
            this.ptbHinhAnh.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hình Ảnh";
            // 
            // txtNhanXet
            // 
            this.txtNhanXet.AllowDrop = true;
            this.txtNhanXet.Location = new System.Drawing.Point(27, 207);
            this.txtNhanXet.Name = "txtNhanXet";
            this.txtNhanXet.ReadOnly = true;
            this.txtNhanXet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNhanXet.Size = new System.Drawing.Size(307, 22);
            this.txtNhanXet.TabIndex = 3;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(27, 34);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.ReadOnly = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(307, 22);
            this.txtTenKhachHang.TabIndex = 3;
            // 
            // lblNhanXet
            // 
            this.lblNhanXet.AutoSize = true;
            this.lblNhanXet.Location = new System.Drawing.Point(24, 188);
            this.lblNhanXet.Name = "lblNhanXet";
            this.lblNhanXet.Size = new System.Drawing.Size(61, 16);
            this.lblNhanXet.TabIndex = 2;
            this.lblNhanXet.Text = "Nhận Xét";
            // 
            // lblSoSao
            // 
            this.lblSoSao.AutoSize = true;
            this.lblSoSao.Location = new System.Drawing.Point(24, 95);
            this.lblSoSao.Name = "lblSoSao";
            this.lblSoSao.Size = new System.Drawing.Size(90, 16);
            this.lblSoSao.TabIndex = 2;
            this.lblSoSao.Text = "Sao Đánh Giá";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Location = new System.Drawing.Point(24, 15);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(107, 16);
            this.lblTenKhachHang.TabIndex = 1;
            this.lblTenKhachHang.Text = "Tên Khách Hàng";
            // 
            // lblssao
            // 
            this.lblssao.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblssao.Location = new System.Drawing.Point(72, 111);
            this.lblssao.Name = "lblssao";
            this.lblssao.Size = new System.Drawing.Size(183, 41);
            this.lblssao.TabIndex = 8;
            this.lblssao.Text = "☆☆☆☆☆";
            // 
            // UC_XemDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBaiDanhGia);
            this.Name = "UC_XemDanhGia";
            this.Size = new System.Drawing.Size(1189, 507);
            this.Load += new System.EventHandler(this.UC_XemDanhGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiDanhGia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaiDanhGia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNhanXet;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label lblNhanXet;
        private System.Windows.Forms.Label lblSoSao;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Label lblsao;
        private System.Windows.Forms.PictureBox ptbHinhAnh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblssao;
    }
}
