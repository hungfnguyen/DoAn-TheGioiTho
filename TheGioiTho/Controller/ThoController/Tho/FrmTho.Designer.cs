namespace TheGioiTho.Controller.Tho
{
    partial class FrmTho
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
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnDangBai = new System.Windows.Forms.Button();
            this.btnLichHen = new System.Windows.Forms.Button();
            this.btnDanhGia = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrangChu.Location = new System.Drawing.Point(12, 21);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(105, 30);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnDangBai
            // 
            this.btnDangBai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangBai.Location = new System.Drawing.Point(114, 21);
            this.btnDangBai.Name = "btnDangBai";
            this.btnDangBai.Size = new System.Drawing.Size(105, 30);
            this.btnDangBai.TabIndex = 0;
            this.btnDangBai.Text = "Đăng Bài";
            this.btnDangBai.UseVisualStyleBackColor = true;
            this.btnDangBai.Click += new System.EventHandler(this.btnDangBai_Click);
            // 
            // btnLichHen
            // 
            this.btnLichHen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLichHen.Location = new System.Drawing.Point(215, 21);
            this.btnLichHen.Name = "btnLichHen";
            this.btnLichHen.Size = new System.Drawing.Size(105, 30);
            this.btnLichHen.TabIndex = 0;
            this.btnLichHen.Text = "Lịch Hẹn";
            this.btnLichHen.UseVisualStyleBackColor = true;
            this.btnLichHen.Click += new System.EventHandler(this.btnLichHen_Click);
            // 
            // btnDanhGia
            // 
            this.btnDanhGia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDanhGia.Location = new System.Drawing.Point(315, 21);
            this.btnDanhGia.Name = "btnDanhGia";
            this.btnDanhGia.Size = new System.Drawing.Size(105, 30);
            this.btnDanhGia.TabIndex = 0;
            this.btnDanhGia.Text = "Đánh Giá";
            this.btnDanhGia.UseVisualStyleBackColor = true;
            this.btnDanhGia.Click += new System.EventHandler(this.btnDanhGia_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThongKe.Location = new System.Drawing.Point(417, 21);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(105, 30);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTaiKhoan.Location = new System.Drawing.Point(519, 21);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(105, 30);
            this.btnTaiKhoan.TabIndex = 0;
            this.btnTaiKhoan.Text = "Tài Khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1215, 607);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangXuat.Location = new System.Drawing.Point(1122, 21);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(105, 30);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // FrmTho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 667);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnDanhGia);
            this.Controls.Add(this.btnLichHen);
            this.Controls.Add(this.btnDangBai);
            this.Controls.Add(this.btnTrangChu);
            this.Name = "FrmTho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnDangBai;
        private System.Windows.Forms.Button btnLichHen;
        private System.Windows.Forms.Button btnDanhGia;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDangXuat;
    }
}