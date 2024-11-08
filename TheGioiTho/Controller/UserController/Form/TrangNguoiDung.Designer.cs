namespace TheGioiTho
{
    partial class TrangNguoiDung
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
            this.tabPageTrangChu = new System.Windows.Forms.TabPage();
            this.tabCtrlTrangChu = new System.Windows.Forms.TabControl();
            this.tabPageHoatDong = new System.Windows.Forms.TabPage();
            this.tabPageBaiDangTho = new System.Windows.Forms.TabPage();
            this.tabPageDanhSachThoYeuThich = new System.Windows.Forms.TabPage();
            this.tabPageTopTho = new System.Windows.Forms.TabPage();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.tabCtrlTrangChu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageTrangChu
            // 
            this.tabPageTrangChu.AutoScroll = true;
            this.tabPageTrangChu.Location = new System.Drawing.Point(4, 25);
            this.tabPageTrangChu.Name = "tabPageTrangChu";
            this.tabPageTrangChu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrangChu.Size = new System.Drawing.Size(1076, 570);
            this.tabPageTrangChu.TabIndex = 0;
            this.tabPageTrangChu.Text = "Trang Chủ";
            this.tabPageTrangChu.UseVisualStyleBackColor = true;
            this.tabPageTrangChu.Click += new System.EventHandler(this.tabPageTrangChu_Click);
            // 
            // tabCtrlTrangChu
            // 
            this.tabCtrlTrangChu.Controls.Add(this.tabPageTrangChu);
            this.tabCtrlTrangChu.Controls.Add(this.tabPageHoatDong);
            this.tabCtrlTrangChu.Controls.Add(this.tabPageBaiDangTho);
            this.tabCtrlTrangChu.Controls.Add(this.tabPageDanhSachThoYeuThich);
            this.tabCtrlTrangChu.Controls.Add(this.tabPageTopTho);
            this.tabCtrlTrangChu.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlTrangChu.Name = "tabCtrlTrangChu";
            this.tabCtrlTrangChu.SelectedIndex = 0;
            this.tabCtrlTrangChu.Size = new System.Drawing.Size(1084, 599);
            this.tabCtrlTrangChu.TabIndex = 0;
            this.tabCtrlTrangChu.SelectedIndexChanged += new System.EventHandler(this.tabCtrlTrangChu_SelectedIndexChanged);
            // 
            // tabPageHoatDong
            // 
            this.tabPageHoatDong.Location = new System.Drawing.Point(4, 25);
            this.tabPageHoatDong.Name = "tabPageHoatDong";
            this.tabPageHoatDong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHoatDong.Size = new System.Drawing.Size(1076, 570);
            this.tabPageHoatDong.TabIndex = 4;
            this.tabPageHoatDong.Text = "Hoạt động";
            this.tabPageHoatDong.UseVisualStyleBackColor = true;
            // 
            // tabPageBaiDangTho
            // 
            this.tabPageBaiDangTho.Location = new System.Drawing.Point(4, 25);
            this.tabPageBaiDangTho.Name = "tabPageBaiDangTho";
            this.tabPageBaiDangTho.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBaiDangTho.Size = new System.Drawing.Size(1076, 570);
            this.tabPageBaiDangTho.TabIndex = 5;
            this.tabPageBaiDangTho.Text = "Bài đăng thợ";
            this.tabPageBaiDangTho.UseVisualStyleBackColor = true;
            this.tabPageBaiDangTho.Click += new System.EventHandler(this.tabPageBaiDangTho_Click);
            // 
            // tabPageDanhSachThoYeuThich
            // 
            this.tabPageDanhSachThoYeuThich.Location = new System.Drawing.Point(4, 25);
            this.tabPageDanhSachThoYeuThich.Name = "tabPageDanhSachThoYeuThich";
            this.tabPageDanhSachThoYeuThich.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDanhSachThoYeuThich.Size = new System.Drawing.Size(1076, 570);
            this.tabPageDanhSachThoYeuThich.TabIndex = 6;
            this.tabPageDanhSachThoYeuThich.Text = "Danh Sách Thợ Yêu Thích";
            this.tabPageDanhSachThoYeuThich.UseVisualStyleBackColor = true;
            // 
            // tabPageTopTho
            // 
            this.tabPageTopTho.Location = new System.Drawing.Point(4, 25);
            this.tabPageTopTho.Name = "tabPageTopTho";
            this.tabPageTopTho.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTopTho.Size = new System.Drawing.Size(1076, 570);
            this.tabPageTopTho.TabIndex = 7;
            this.tabPageTopTho.Text = "Top Thợ";
            this.tabPageTopTho.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangXuat.Location = new System.Drawing.Point(1239, 0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(105, 30);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // TrangNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 631);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.tabCtrlTrangChu);
            this.Name = "TrangNguoiDung";
            this.Text = "TrangNguoiDung";
            this.Load += new System.EventHandler(this.TrangNguoiDung_Load);
            this.tabCtrlTrangChu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageTrangChu;
        private System.Windows.Forms.TabControl tabCtrlTrangChu;
        private System.Windows.Forms.TabPage tabPageHoatDong;
        private System.Windows.Forms.TabPage tabPageBaiDangTho;
        private System.Windows.Forms.TabPage tabPageDanhSachThoYeuThich;
        private System.Windows.Forms.TabPage tabPageTopTho;
        private System.Windows.Forms.Button btnDangXuat;
    }
}