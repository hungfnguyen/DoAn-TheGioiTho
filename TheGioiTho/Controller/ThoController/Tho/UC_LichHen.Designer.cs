namespace TheGioiTho.Controller.Tho
{
    partial class UC_LichHen
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
            this.btnDaHuy = new System.Windows.Forms.Button();
            this.btnDaHoanThanh = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnDaChapNhan = new System.Windows.Forms.Button();
            this.btnChuaXuLi = new System.Windows.Forms.Button();
            this.dgvLichHen = new System.Windows.Forms.DataGridView();
            this.btn_TuChoi = new System.Windows.Forms.Button();
            this.btn_ChapNhan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_XemLyDoHuy = new System.Windows.Forms.Button();
            this.btn_HoanThanh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDaHuy
            // 
            this.btnDaHuy.Location = new System.Drawing.Point(597, 16);
            this.btnDaHuy.Name = "btnDaHuy";
            this.btnDaHuy.Size = new System.Drawing.Size(142, 30);
            this.btnDaHuy.TabIndex = 2;
            this.btnDaHuy.Text = "Đã Hủy";
            this.btnDaHuy.UseVisualStyleBackColor = true;
            this.btnDaHuy.Click += new System.EventHandler(this.btnDaHuy_Click);
            // 
            // btnDaHoanThanh
            // 
            this.btnDaHoanThanh.Location = new System.Drawing.Point(449, 16);
            this.btnDaHoanThanh.Name = "btnDaHoanThanh";
            this.btnDaHoanThanh.Size = new System.Drawing.Size(142, 30);
            this.btnDaHoanThanh.TabIndex = 3;
            this.btnDaHoanThanh.Text = "Đã Hoàn Thành";
            this.btnDaHoanThanh.UseVisualStyleBackColor = true;
            this.btnDaHoanThanh.Click += new System.EventHandler(this.btnDaHoanThanh_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Location = new System.Drawing.Point(301, 16);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(142, 30);
            this.btnTuChoi.TabIndex = 4;
            this.btnTuChoi.Text = "Từ Chối";
            this.btnTuChoi.UseVisualStyleBackColor = true;
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // btnDaChapNhan
            // 
            this.btnDaChapNhan.Location = new System.Drawing.Point(153, 16);
            this.btnDaChapNhan.Name = "btnDaChapNhan";
            this.btnDaChapNhan.Size = new System.Drawing.Size(142, 30);
            this.btnDaChapNhan.TabIndex = 5;
            this.btnDaChapNhan.Text = "Đã Chấp Nhận";
            this.btnDaChapNhan.UseVisualStyleBackColor = true;
            this.btnDaChapNhan.Click += new System.EventHandler(this.btnDaChapNhan_Click);
            // 
            // btnChuaXuLi
            // 
            this.btnChuaXuLi.Location = new System.Drawing.Point(5, 16);
            this.btnChuaXuLi.Name = "btnChuaXuLi";
            this.btnChuaXuLi.Size = new System.Drawing.Size(142, 30);
            this.btnChuaXuLi.TabIndex = 6;
            this.btnChuaXuLi.Text = "Chưa Xử Lí";
            this.btnChuaXuLi.UseVisualStyleBackColor = true;
            this.btnChuaXuLi.Click += new System.EventHandler(this.btnChuaXuLi_Click);
            // 
            // dgvLichHen
            // 
            this.dgvLichHen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichHen.Location = new System.Drawing.Point(5, 62);
            this.dgvLichHen.Name = "dgvLichHen";
            this.dgvLichHen.RowHeadersWidth = 51;
            this.dgvLichHen.RowTemplate.Height = 24;
            this.dgvLichHen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichHen.Size = new System.Drawing.Size(832, 363);
            this.dgvLichHen.TabIndex = 7;
            this.dgvLichHen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichHen_CellContentClick);
            // 
            // btn_TuChoi
            // 
            this.btn_TuChoi.Location = new System.Drawing.Point(20, 60);
            this.btn_TuChoi.Name = "btn_TuChoi";
            this.btn_TuChoi.Size = new System.Drawing.Size(264, 30);
            this.btn_TuChoi.TabIndex = 8;
            this.btn_TuChoi.Text = "Từ Chối";
            this.btn_TuChoi.UseVisualStyleBackColor = true;
            this.btn_TuChoi.Click += new System.EventHandler(this.btn_TuChoi_Click_1);
            // 
            // btn_ChapNhan
            // 
            this.btn_ChapNhan.Location = new System.Drawing.Point(20, 24);
            this.btn_ChapNhan.Name = "btn_ChapNhan";
            this.btn_ChapNhan.Size = new System.Drawing.Size(264, 30);
            this.btn_ChapNhan.TabIndex = 9;
            this.btn_ChapNhan.Text = "Chấp Nhận";
            this.btn_ChapNhan.UseVisualStyleBackColor = true;
            this.btn_ChapNhan.Click += new System.EventHandler(this.btn_ChapNhan_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_XemLyDoHuy);
            this.panel1.Controls.Add(this.btn_HoanThanh);
            this.panel1.Controls.Add(this.btn_ChapNhan);
            this.panel1.Controls.Add(this.btn_TuChoi);
            this.panel1.Location = new System.Drawing.Point(857, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 112);
            this.panel1.TabIndex = 10;
            // 
            // btn_XemLyDoHuy
            // 
            this.btn_XemLyDoHuy.Location = new System.Drawing.Point(20, 24);
            this.btn_XemLyDoHuy.Name = "btn_XemLyDoHuy";
            this.btn_XemLyDoHuy.Size = new System.Drawing.Size(264, 30);
            this.btn_XemLyDoHuy.TabIndex = 12;
            this.btn_XemLyDoHuy.Text = "Xem Lý Do Hủy";
            this.btn_XemLyDoHuy.UseVisualStyleBackColor = true;
            this.btn_XemLyDoHuy.Visible = false;
            this.btn_XemLyDoHuy.Click += new System.EventHandler(this.btn_XemLyDoHuy_Click);
            // 
            // btn_HoanThanh
            // 
            this.btn_HoanThanh.Location = new System.Drawing.Point(20, 37);
            this.btn_HoanThanh.Name = "btn_HoanThanh";
            this.btn_HoanThanh.Size = new System.Drawing.Size(264, 30);
            this.btn_HoanThanh.TabIndex = 11;
            this.btn_HoanThanh.Text = "Hoàn Thành";
            this.btn_HoanThanh.UseVisualStyleBackColor = true;
            this.btn_HoanThanh.Visible = false;
            this.btn_HoanThanh.Click += new System.EventHandler(this.btn_HoanThanh_Click);
            // 
            // UC_LichHen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvLichHen);
            this.Controls.Add(this.btnDaHuy);
            this.Controls.Add(this.btnDaHoanThanh);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDaChapNhan);
            this.Controls.Add(this.btnChuaXuLi);
            this.Name = "UC_LichHen";
            this.Size = new System.Drawing.Size(1185, 458);
            this.Load += new System.EventHandler(this.UC_LichHen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDaHuy;
        private System.Windows.Forms.Button btnDaHoanThanh;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnDaChapNhan;
        private System.Windows.Forms.Button btnChuaXuLi;
        private System.Windows.Forms.DataGridView dgvLichHen;
        private System.Windows.Forms.Button btn_TuChoi;
        private System.Windows.Forms.Button btn_ChapNhan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_XemLyDoHuy;
        private System.Windows.Forms.Button btn_HoanThanh;
    }
}
