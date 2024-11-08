namespace TheGioiTho.Controller
{
    partial class UC_QuanLyLich
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flpLichHen = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 94);
            this.panel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(715, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 53);
            this.button4.TabIndex = 3;
            this.button4.Text = "Đã hủy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnDaHuy_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(419, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 53);
            this.button3.TabIndex = 2;
            this.button3.Text = "Hoàn tất";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "Đã xác nhận";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnDaXacNhan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Đang chờ thợ xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnDangChoXacNhan_Click);
            // 
            // flpLichHen
            // 
            this.flpLichHen.AutoScroll = true;
            this.flpLichHen.BackColor = System.Drawing.Color.White;
            this.flpLichHen.Location = new System.Drawing.Point(3, 103);
            this.flpLichHen.Name = "flpLichHen";
            this.flpLichHen.Size = new System.Drawing.Size(1046, 449);
            this.flpLichHen.TabIndex = 1;
            this.flpLichHen.Paint += new System.Windows.Forms.PaintEventHandler(this.flpLichHen_Paint);
            // 
            // UC_QuanLyLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpLichHen);
            this.Controls.Add(this.panel1);
            this.Name = "UC_QuanLyLich";
            this.Size = new System.Drawing.Size(1052, 555);
            this.Load += new System.EventHandler(this.UC_QuanLyLich_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flpLichHen;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
