namespace TheGioiTho.Controller
{
    partial class UC_DangBaiTimTho
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmbCongViec = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.RichTextBox();
            this.dtpLichThoDen = new System.Windows.Forms.DateTimePicker();
            this.txtTieuDe = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChonGio = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.cmbCongViec);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtMoTa);
            this.panel1.Controls.Add(this.dtpLichThoDen);
            this.panel1.Controls.Add(this.txtTieuDe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picHinhAnh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbChonGio);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(15, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 509);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(711, 374);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(202, 22);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Xem tất cả các bài đăng";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cmbCongViec
            // 
            this.cmbCongViec.FormattingEnabled = true;
            this.cmbCongViec.Location = new System.Drawing.Point(226, 154);
            this.cmbCongViec.Name = "cmbCongViec";
            this.cmbCongViec.Size = new System.Drawing.Size(354, 24);
            this.cmbCongViec.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(725, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 38);
            this.button2.TabIndex = 32;
            this.button2.Text = "Đăng bài ngay";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnDangBai_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 38);
            this.button1.TabIndex = 31;
            this.button1.Text = "Thêm hình ảnh mô tả";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnThemHinhAnh_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(226, 317);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(354, 79);
            this.txtMoTa.TabIndex = 30;
            this.txtMoTa.Text = "";
            // 
            // dtpLichThoDen
            // 
            this.dtpLichThoDen.Location = new System.Drawing.Point(226, 222);
            this.dtpLichThoDen.Name = "dtpLichThoDen";
            this.dtpLichThoDen.Size = new System.Drawing.Size(200, 22);
            this.dtpLichThoDen.TabIndex = 29;
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(226, 40);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(354, 79);
            this.txtTieuDe.TabIndex = 27;
            this.txtTieuDe.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tiêu Đề:";
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(683, 67);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(246, 224);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 22;
            this.picHinhAnh.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Công Việc:";
            // 
            // cmbChonGio
            // 
            this.cmbChonGio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbChonGio.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChonGio.FormattingEnabled = true;
            this.cmbChonGio.Items.AddRange(new object[] {
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00"});
            this.cmbChonGio.Location = new System.Drawing.Point(473, 214);
            this.cmbChonGio.Name = "cmbChonGio";
            this.cmbChonGio.Size = new System.Drawing.Size(107, 36);
            this.cmbChonGio.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(469, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 19);
            this.label14.TabIndex = 11;
            this.label14.Text = "Chọn Giờ:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(222, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 19);
            this.label15.TabIndex = 12;
            this.label15.Text = "Mô tả chi tiết:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lịch Thợ Đến:";
            // 
            // UC_DangBaiTimTho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UC_DangBaiTimTho";
            this.Size = new System.Drawing.Size(1058, 545);
            this.Load += new System.EventHandler(this.UC_DangBaiTimTho_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCongViec;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtMoTa;
        private System.Windows.Forms.DateTimePicker dtpLichThoDen;
        private System.Windows.Forms.RichTextBox txtTieuDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbChonGio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
