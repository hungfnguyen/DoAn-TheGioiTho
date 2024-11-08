namespace TheGioiTho.Controller.Tho
{
    partial class UC_TrangChu
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
            this.components = new System.ComponentModel.Container();
            this.dgvBaiDangNguoiDung = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDatLich = new System.Windows.Forms.Button();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.txtThoiGianThucHien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtThoiGianLamViec = new System.Windows.Forms.TextBox();
            this.txtDiaDiemLamViec = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiaDiemLamViec = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.doAnTheGioiThoDataSet = new TheGioiTho.DoAnTheGioiThoDataSet();
            this.baiDangNguoiDungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baiDangNguoiDungTableAdapter = new TheGioiTho.DoAnTheGioiThoDataSetTableAdapters.BaiDangNguoiDungTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiDangNguoiDung)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doAnTheGioiThoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baiDangNguoiDungBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaiDangNguoiDung
            // 
            this.dgvBaiDangNguoiDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaiDangNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaiDangNguoiDung.Location = new System.Drawing.Point(3, 3);
            this.dgvBaiDangNguoiDung.Name = "dgvBaiDangNguoiDung";
            this.dgvBaiDangNguoiDung.RowHeadersWidth = 51;
            this.dgvBaiDangNguoiDung.RowTemplate.Height = 24;
            this.dgvBaiDangNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaiDangNguoiDung.Size = new System.Drawing.Size(807, 456);
            this.dgvBaiDangNguoiDung.TabIndex = 0;
            this.dgvBaiDangNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaiDangNguoiDung_CellClick);
            this.dgvBaiDangNguoiDung.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaiDangNguoiDung_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.txtThoiGianLamViec);
            this.panel1.Controls.Add(this.txtDiaDiemLamViec);
            this.panel1.Controls.Add(this.txtSoDienThoai);
            this.panel1.Controls.Add(this.txtTenKhachHang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDiaDiemLamViec);
            this.panel1.Controls.Add(this.lblSoDienThoai);
            this.panel1.Controls.Add(this.lblTenKhachHang);
            this.panel1.Location = new System.Drawing.Point(816, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 456);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnDatLich);
            this.panel2.Controls.Add(this.txtGiaTien);
            this.panel2.Controls.Add(this.txtThoiGianThucHien);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 140);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnDatLich
            // 
            this.btnDatLich.Location = new System.Drawing.Point(105, 97);
            this.btnDatLich.Name = "btnDatLich";
            this.btnDatLich.Size = new System.Drawing.Size(147, 40);
            this.btnDatLich.TabIndex = 0;
            this.btnDatLich.Text = "Đặt Lịch";
            this.btnDatLich.UseVisualStyleBackColor = true;
            this.btnDatLich.Click += new System.EventHandler(this.btnDatLich_Click);
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(169, 55);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(144, 22);
            this.txtGiaTien.TabIndex = 3;
            this.txtGiaTien.TextChanged += new System.EventHandler(this.txtGiaTien_TextChanged);
            // 
            // txtThoiGianThucHien
            // 
            this.txtThoiGianThucHien.Location = new System.Drawing.Point(169, 16);
            this.txtThoiGianThucHien.Name = "txtThoiGianThucHien";
            this.txtThoiGianThucHien.Size = new System.Drawing.Size(144, 22);
            this.txtThoiGianThucHien.TabIndex = 3;
            this.txtThoiGianThucHien.TextChanged += new System.EventHandler(this.txtThoiGianThucHien_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giá Tiền (vnd):";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thời Gian Thực Hiện (giờ):";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(27, 272);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(307, 22);
            this.txtGhiChu.TabIndex = 3;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // txtThoiGianLamViec
            // 
            this.txtThoiGianLamViec.Location = new System.Drawing.Point(27, 220);
            this.txtThoiGianLamViec.Name = "txtThoiGianLamViec";
            this.txtThoiGianLamViec.Size = new System.Drawing.Size(307, 22);
            this.txtThoiGianLamViec.TabIndex = 3;
            this.txtThoiGianLamViec.TextChanged += new System.EventHandler(this.txtThoiGianLamViec_TextChanged);
            // 
            // txtDiaDiemLamViec
            // 
            this.txtDiaDiemLamViec.Location = new System.Drawing.Point(27, 155);
            this.txtDiaDiemLamViec.Name = "txtDiaDiemLamViec";
            this.txtDiaDiemLamViec.Size = new System.Drawing.Size(307, 22);
            this.txtDiaDiemLamViec.TabIndex = 3;
            this.txtDiaDiemLamViec.TextChanged += new System.EventHandler(this.txtDiaDiemLamViec_TextChanged);
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(27, 92);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(307, 22);
            this.txtSoDienThoai.TabIndex = 3;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(27, 34);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(307, 22);
            this.txtTenKhachHang.TabIndex = 3;
            this.txtTenKhachHang.TextChanged += new System.EventHandler(this.txtTenKhachHang_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ghi Chú:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thời Gian Làm Việc";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDiaDiemLamViec
            // 
            this.lblDiaDiemLamViec.AutoSize = true;
            this.lblDiaDiemLamViec.Location = new System.Drawing.Point(24, 136);
            this.lblDiaDiemLamViec.Name = "lblDiaDiemLamViec";
            this.lblDiaDiemLamViec.Size = new System.Drawing.Size(120, 16);
            this.lblDiaDiemLamViec.TabIndex = 2;
            this.lblDiaDiemLamViec.Text = "Địa Điểm Làm Việc";
            this.lblDiaDiemLamViec.Click += new System.EventHandler(this.lblDiaDiemLamViec_Click);
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(24, 73);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(92, 16);
            this.lblSoDienThoai.TabIndex = 2;
            this.lblSoDienThoai.Text = "Số Điện Thoại";
            this.lblSoDienThoai.Click += new System.EventHandler(this.lblSoDienThoai_Click);
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Location = new System.Drawing.Point(24, 15);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(107, 16);
            this.lblTenKhachHang.TabIndex = 1;
            this.lblTenKhachHang.Text = "Tên Khách Hàng";
            this.lblTenKhachHang.Click += new System.EventHandler(this.lblTenKhachHang_Click);
            // 
            // doAnTheGioiThoDataSet
            // 
            this.doAnTheGioiThoDataSet.DataSetName = "DoAnTheGioiThoDataSet";
            this.doAnTheGioiThoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baiDangNguoiDungBindingSource
            // 
            this.baiDangNguoiDungBindingSource.DataMember = "BaiDangNguoiDung";
            this.baiDangNguoiDungBindingSource.DataSource = this.doAnTheGioiThoDataSet;
            this.baiDangNguoiDungBindingSource.CurrentChanged += new System.EventHandler(this.baiDangNguoiDungBindingSource_CurrentChanged);
            // 
            // baiDangNguoiDungTableAdapter
            // 
            this.baiDangNguoiDungTableAdapter.ClearBeforeFill = true;
            // 
            // UC_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBaiDangNguoiDung);
            this.Name = "UC_TrangChu";
            this.Size = new System.Drawing.Size(1189, 462);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiDangNguoiDung)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doAnTheGioiThoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baiDangNguoiDungBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaiDangNguoiDung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDiaDiemLamViec;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Button btnDatLich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.TextBox txtThoiGianThucHien;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtThoiGianLamViec;
        private System.Windows.Forms.TextBox txtDiaDiemLamViec;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.BindingSource baiDangNguoiDungBindingSource;
        private DoAnTheGioiThoDataSet doAnTheGioiThoDataSet;
        private DoAnTheGioiThoDataSetTableAdapters.BaiDangNguoiDungTableAdapter baiDangNguoiDungTableAdapter;
    }
}
