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
            this.pnlThongKe = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSoDanhGia = new System.Windows.Forms.Label();
            this.rtSosaotb = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblSaotb = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1189, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.dgvDoanhThu);
            this.tabPage1.Controls.Add(this.pnThongKe);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1181, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống Kê Doanh Thu";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(733, 7);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(442, 417);
            this.dgvDoanhThu.TabIndex = 1;
            // 
            // pnThongKe
            // 
            this.pnThongKe.Location = new System.Drawing.Point(6, 3);
            this.pnThongKe.Name = "pnThongKe";
            this.pnThongKe.Size = new System.Drawing.Size(721, 421);
            this.pnThongKe.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.pnlThongKe);
            this.tabPage2.Controls.Add(this.lblSoDanhGia);
            this.tabPage2.Controls.Add(this.rtSosaotb);
            this.tabPage2.Controls.Add(this.lblSaotb);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1181, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống Kê Đánh Giá";
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlThongKe.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlThongKe.Location = new System.Drawing.Point(593, 6);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(572, 393);
            this.pnlThongKe.TabIndex = 90;
            // 
            // lblSoDanhGia
            // 
            this.lblSoDanhGia.AutoSize = true;
            this.lblSoDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDanhGia.Location = new System.Drawing.Point(252, 243);
            this.lblSoDanhGia.Name = "lblSoDanhGia";
            this.lblSoDanhGia.Size = new System.Drawing.Size(122, 20);
            this.lblSoDanhGia.TabIndex = 89;
            this.lblSoDanhGia.Text = "so bai danh gia";
            // 
            // rtSosaotb
            // 
            this.rtSosaotb.BorderColor = System.Drawing.Color.White;
            this.rtSosaotb.FillColor = System.Drawing.Color.White;
            this.rtSosaotb.Location = new System.Drawing.Point(247, 154);
            this.rtSosaotb.Name = "rtSosaotb";
            this.rtSosaotb.RatingColor = System.Drawing.Color.Yellow;
            this.rtSosaotb.ReadOnly = true;
            this.rtSosaotb.Size = new System.Drawing.Size(182, 44);
            this.rtSosaotb.TabIndex = 88;
            this.rtSosaotb.Value = 1F;
            // 
            // lblSaotb
            // 
            this.lblSaotb.AutoSize = true;
            this.lblSaotb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaotb.Location = new System.Drawing.Point(242, 97);
            this.lblSaotb.Name = "lblSaotb";
            this.lblSaotb.Size = new System.Drawing.Size(109, 29);
            this.lblSaotb.TabIndex = 1;
            this.lblSaotb.Text = "Sosaotb";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UC_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(1189, 462);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
    }
}
