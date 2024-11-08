namespace TheGioiTho.Controller.Tho
{
    partial class Form_QuanLyBaiDang
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
            this.dgvQuanLyBaiDang = new System.Windows.Forms.DataGridView();
            this.btnXoaBaiDang = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.txtHinhAnhDuongDan = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.pbHinhAnh = new System.Windows.Forms.PictureBox();
            this.cbChonCongViec = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThoiGianThucHien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnChinhSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyBaiDang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuanLyBaiDang
            // 
            this.dgvQuanLyBaiDang.AllowUserToAddRows = false;
            this.dgvQuanLyBaiDang.AllowUserToResizeRows = false;
            this.dgvQuanLyBaiDang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanLyBaiDang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLyBaiDang.Location = new System.Drawing.Point(24, 36);
            this.dgvQuanLyBaiDang.Name = "dgvQuanLyBaiDang";
            this.dgvQuanLyBaiDang.RowHeadersWidth = 51;
            this.dgvQuanLyBaiDang.RowTemplate.Height = 80;
            this.dgvQuanLyBaiDang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuanLyBaiDang.Size = new System.Drawing.Size(1104, 356);
            this.dgvQuanLyBaiDang.TabIndex = 0;
            this.dgvQuanLyBaiDang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyBaiDang_CellClick);
            this.dgvQuanLyBaiDang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyBaiDang_CellContentClick);
            // 
            // btnXoaBaiDang
            // 
            this.btnXoaBaiDang.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnXoaBaiDang.Location = new System.Drawing.Point(978, 414);
            this.btnXoaBaiDang.Name = "btnXoaBaiDang";
            this.btnXoaBaiDang.Size = new System.Drawing.Size(150, 40);
            this.btnXoaBaiDang.TabIndex = 1;
            this.btnXoaBaiDang.Text = "Xóa Bài Đăng";
            this.btnXoaBaiDang.UseVisualStyleBackColor = false;
            this.btnXoaBaiDang.Click += new System.EventHandler(this.btnXoaBaiDang_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtTieuDe);
            this.panel1.Controls.Add(this.txtHinhAnhDuongDan);
            this.panel1.Controls.Add(this.btnChonAnh);
            this.panel1.Controls.Add(this.pbHinhAnh);
            this.panel1.Controls.Add(this.cbChonCongViec);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtGiaTien);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtThoiGianThucHien);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMoTa);
            this.panel1.Controls.Add(this.btnChinhSua);
            this.panel1.Location = new System.Drawing.Point(24, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 236);
            this.panel1.TabIndex = 2;
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(37, 30);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(307, 22);
            this.txtTieuDe.TabIndex = 24;
            // 
            // txtHinhAnhDuongDan
            // 
            this.txtHinhAnhDuongDan.Location = new System.Drawing.Point(762, 161);
            this.txtHinhAnhDuongDan.Name = "txtHinhAnhDuongDan";
            this.txtHinhAnhDuongDan.Size = new System.Drawing.Size(147, 22);
            this.txtHinhAnhDuongDan.TabIndex = 23;
            this.txtHinhAnhDuongDan.Visible = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(639, 125);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(116, 41);
            this.btnChonAnh.TabIndex = 22;
            this.btnChonAnh.Text = "Chọn Ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // pbHinhAnh
            // 
            this.pbHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHinhAnh.Location = new System.Drawing.Point(777, 54);
            this.pbHinhAnh.Name = "pbHinhAnh";
            this.pbHinhAnh.Size = new System.Drawing.Size(107, 100);
            this.pbHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHinhAnh.TabIndex = 21;
            this.pbHinhAnh.TabStop = false;
            // 
            // cbChonCongViec
            // 
            this.cbChonCongViec.FormattingEnabled = true;
            this.cbChonCongViec.Location = new System.Drawing.Point(37, 144);
            this.cbChonCongViec.Name = "cbChonCongViec";
            this.cbChonCongViec.Size = new System.Drawing.Size(307, 24);
            this.cbChonCongViec.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tiêu Đề";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mô tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Chọn Công Việc";
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(373, 144);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(228, 22);
            this.txtGiaTien.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Thời Gian Thực Hiện";
            // 
            // txtThoiGianThucHien
            // 
            this.txtThoiGianThucHien.Location = new System.Drawing.Point(373, 82);
            this.txtThoiGianThucHien.Name = "txtThoiGianThucHien";
            this.txtThoiGianThucHien.Size = new System.Drawing.Size(228, 22);
            this.txtThoiGianThucHien.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Giá Tiền";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(37, 82);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(307, 22);
            this.txtMoTa.TabIndex = 19;
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChinhSua.Location = new System.Drawing.Point(413, 189);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(150, 40);
            this.btnChinhSua.TabIndex = 3;
            this.btnChinhSua.Text = "Chỉnh Sửa";
            this.btnChinhSua.UseVisualStyleBackColor = false;
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // Form_QuanLyBaiDang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 679);
            this.Controls.Add(this.btnXoaBaiDang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvQuanLyBaiDang);
            this.Name = "Form_QuanLyBaiDang";
            this.Text = "Form_QuanLyBaiDang";
            this.Load += new System.EventHandler(this.Form_QuanLyBaiDang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyBaiDang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuanLyBaiDang;
        private System.Windows.Forms.Button btnXoaBaiDang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.ComboBox cbChonCongViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThoiGianThucHien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.PictureBox pbHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.TextBox txtHinhAnhDuongDan;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label label5;
    }
}