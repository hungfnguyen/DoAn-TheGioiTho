namespace GUI.All_Calendar_Control
{
    partial class UC_Gio
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
            this.lblGio = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // lblGio
            // 
            this.lblGio.BackColor = System.Drawing.Color.Transparent;
            this.lblGio.Location = new System.Drawing.Point(3, 3);
            this.lblGio.Name = "lblGio";
            this.lblGio.Size = new System.Drawing.Size(17, 18);
            this.lblGio.TabIndex = 0;
            this.lblGio.Text = "00";
            this.lblGio.Click += new System.EventHandler(this.lblGio_Click);
            // 
            // UC_Gio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGio);
            this.Name = "UC_Gio";
            this.Size = new System.Drawing.Size(87, 39);
            this.Click += new System.EventHandler(this.UC_Gio_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblGio;
    }
}
