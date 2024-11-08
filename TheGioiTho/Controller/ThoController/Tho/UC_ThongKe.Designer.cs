namespace TheGioiTho.Controller.Tho
{
    partial class UC_ThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ThongKe));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnThongKe = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSaotb = new System.Windows.Forms.Label();
            this.lblSoDanhGia = new System.Windows.Forms.Label();
            this.rtSosaotb = new Guna.UI2.WinForms.Guna2RatingStar();
            this.pnlThongKe = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbThoiGian = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uC_DanhGia1 = new TheGioiTho.Controller.ThoController.Tho.UC_DanhGia();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1189, 577);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.cbThoiGian);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dgvDoanhThu);
            this.tabPage1.Controls.Add(this.pnThongKe);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1181, 548);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống Kê Doanh Thu";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(676, 7);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(499, 532);
            this.dgvDoanhThu.TabIndex = 1;
            // 
            // pnThongKe
            // 
            this.pnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnThongKe.Location = new System.Drawing.Point(6, 86);
            this.pnThongKe.Name = "pnThongKe";
            this.pnThongKe.Size = new System.Drawing.Size(672, 453);
            this.pnThongKe.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.pnlThongKe);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1181, 548);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống Kê Đánh Giá";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.uC_DanhGia1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(508, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 540);
            this.panel2.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(668, 74);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh Sách Đánh Giá";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblSaotb);
            this.panel1.Controls.Add(this.lblSoDanhGia);
            this.panel1.Controls.Add(this.rtSosaotb);
            this.panel1.Location = new System.Drawing.Point(6, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 163);
            this.panel1.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 90;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblSaotb
            // 
            this.lblSaotb.AutoSize = true;
            this.lblSaotb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaotb.Location = new System.Drawing.Point(171, 31);
            this.lblSaotb.Name = "lblSaotb";
            this.lblSaotb.Size = new System.Drawing.Size(109, 29);
            this.lblSaotb.TabIndex = 1;
            this.lblSaotb.Text = "Sosaotb";
            // 
            // lblSoDanhGia
            // 
            this.lblSoDanhGia.AutoSize = true;
            this.lblSoDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDanhGia.Location = new System.Drawing.Point(172, 110);
            this.lblSoDanhGia.Name = "lblSoDanhGia";
            this.lblSoDanhGia.Size = new System.Drawing.Size(122, 20);
            this.lblSoDanhGia.TabIndex = 89;
            this.lblSoDanhGia.Text = "so bai danh gia";
            // 
            // rtSosaotb
            // 
            this.rtSosaotb.BorderColor = System.Drawing.Color.DimGray;
            this.rtSosaotb.FillColor = System.Drawing.Color.White;
            this.rtSosaotb.Location = new System.Drawing.Point(176, 63);
            this.rtSosaotb.Name = "rtSosaotb";
            this.rtSosaotb.RatingColor = System.Drawing.Color.Yellow;
            this.rtSosaotb.ReadOnly = true;
            this.rtSosaotb.Size = new System.Drawing.Size(182, 44);
            this.rtSosaotb.TabIndex = 88;
            this.rtSosaotb.Value = 1F;
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlThongKe.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlThongKe.Location = new System.Drawing.Point(6, 196);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(496, 334);
            this.pnlThongKe.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xem Doanh Thu:";
            // 
            // cbThoiGian
            // 
            this.cbThoiGian.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThoiGian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbThoiGian.FormattingEnabled = true;
            this.cbThoiGian.Items.AddRange(new object[] {
            "1 tháng gần nhất",
            "3 tháng gần nhất",
            "6 tháng gần nhất",
            "1 năm gần nhất"});
            this.cbThoiGian.Location = new System.Drawing.Point(215, 21);
            this.cbThoiGian.Name = "cbThoiGian";
            this.cbThoiGian.Size = new System.Drawing.Size(267, 31);
            this.cbThoiGian.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ấn vào để xem chi tiết!";
            // 
            // uC_DanhGia1
            // 
            this.uC_DanhGia1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uC_DanhGia1.Location = new System.Drawing.Point(0, 115);
            this.uC_DanhGia1.Name = "uC_DanhGia1";
            this.uC_DanhGia1.Size = new System.Drawing.Size(668, 425);
            this.uC_DanhGia1.TabIndex = 0;
            // 
            // UC_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(1189, 577);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSaotb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSoDanhGia;
        private Guna.UI2.WinForms.Guna2RatingStar rtSosaotb;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlThongKe;
        private System.Windows.Forms.Panel pnThongKe;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private ThoController.Tho.UC_DanhGia uC_DanhGia1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbThoiGian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
