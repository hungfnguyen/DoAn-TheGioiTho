namespace TheGioiTho.Controller
{
    partial class DanhGia
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
            this.lblSao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNhanXet = new System.Windows.Forms.RichTextBox();
            this.cbSoSao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.flpHinhAnh = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSao
            // 
            this.lblSao.AutoSize = true;
            this.lblSao.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSao.Location = new System.Drawing.Point(170, 50);
            this.lblSao.Name = "lblSao";
            this.lblSao.Size = new System.Drawing.Size(177, 51);
            this.lblSao.TabIndex = 0;
            this.lblSao.Text = "☆☆☆☆☆";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đánh giá thợ";
            // 
            // txtNhanXet
            // 
            this.txtNhanXet.Location = new System.Drawing.Point(54, 203);
            this.txtNhanXet.Name = "txtNhanXet";
            this.txtNhanXet.Size = new System.Drawing.Size(421, 155);
            this.txtNhanXet.TabIndex = 8;
            this.txtNhanXet.Text = "";
            // 
            // cbSoSao
            // 
            this.cbSoSao.FormattingEnabled = true;
            this.cbSoSao.Items.AddRange(new object[] {
            "1 ★",
            "2 ★",
            "3 ★",
            "4 ★",
            "5 ★"});
            this.cbSoSao.Location = new System.Drawing.Point(190, 131);
            this.cbSoSao.Name = "cbSoSao";
            this.cbSoSao.Size = new System.Drawing.Size(209, 24);
            this.cbSoSao.TabIndex = 9;
            this.cbSoSao.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDanhGia_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nhận xét";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Đánh giá số sao";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Thêm hình ảnh";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // flpHinhAnh
            // 
            this.flpHinhAnh.AutoScroll = true;
            this.flpHinhAnh.Location = new System.Drawing.Point(43, 421);
            this.flpHinhAnh.Name = "flpHinhAnh";
            this.flpHinhAnh.Size = new System.Drawing.Size(452, 152);
            this.flpHinhAnh.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 605);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Gửi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // DanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 683);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flpHinhAnh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSoSao);
            this.Controls.Add(this.txtNhanXet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSao);
            this.Name = "DanhGia";
            this.Text = "DanhGia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtNhanXet;
        private System.Windows.Forms.ComboBox cbSoSao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flpHinhAnh;
        private System.Windows.Forms.Button button2;
    }
}