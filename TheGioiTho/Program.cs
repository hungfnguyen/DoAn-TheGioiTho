using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.Controller.Tho;
using TheGioiTho.Controller;


namespace TheGioiTho
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //chay ben nguoi dung
            Application.Run(new FrmDangNhap());

            //Application.Run(new TrangNguoiDung(2));

            //Application.Run(new FrmTho());
        }
    }
}
