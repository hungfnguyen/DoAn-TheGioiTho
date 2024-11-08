namespace TheGioiTho.Controller
{
    partial class LiDoHuy
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
            this.lblLiDoHuy = new System.Windows.Forms.Label();
            this.txtLiDoHuy = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLiDoHuy
            // 
            this.lblLiDoHuy.AutoSize = true;
            this.lblLiDoHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiDoHuy.Location = new System.Drawing.Point(277, 54);
            this.lblLiDoHuy.Name = "lblLiDoHuy";
            this.lblLiDoHuy.Size = new System.Drawing.Size(204, 32);
            this.lblLiDoHuy.TabIndex = 0;
            this.lblLiDoHuy.Text = "Lý do bạn hủy";
            // 
            // txtLiDoHuy
            // 
            this.txtLiDoHuy.Location = new System.Drawing.Point(51, 114);
            this.txtLiDoHuy.Name = "txtLiDoHuy";
            this.txtLiDoHuy.Size = new System.Drawing.Size(725, 242);
            this.txtLiDoHuy.TabIndex = 1;
            this.txtLiDoHuy.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(304, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Gửi ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // LiDoHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 454);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLiDoHuy);
            this.Controls.Add(this.lblLiDoHuy);
            this.Name = "LiDoHuy";
            this.Text = "LiDoHuy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLiDoHuy;
        private System.Windows.Forms.RichTextBox txtLiDoHuy;
        private System.Windows.Forms.Button button1;
    }
}