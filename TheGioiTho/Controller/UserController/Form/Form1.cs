using System;
using System.Windows.Forms;
using TheGioiTho.Controller;  // Thêm namespace chứa UC_DangBaiNguoiDung

namespace TheGioiTho
{
    public partial class Form1 : Form
    {
        private UC_DangBaiTimTho ucDangBaiTimTho;
        private UC_NoiDungBaiDang ucNoiDungBaiDang;
        //private UC_DanhSachBaiDang ucDanhSachBaiDang;
        private UC_QuanLyLich ucQuanLyLich;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HienThiUCDangBaiTimTho(1);
            //HienThiUCNoiDungBaiDang(1);
            //HienThiUCDanhSachBaiDang();
            //HienThiUC_QuanLyLich();
        }

        // Phương thức để hiển thị UC_DangBaiTimTho
        private void HienThiUCDangBaiTimTho(int idNguoiDung)
        {
            if (ucDangBaiTimTho == null || ucDangBaiTimTho.IsDisposed)
            {
                ucDangBaiTimTho = new UC_DangBaiTimTho(idNguoiDung);
                ucDangBaiTimTho.Dock = DockStyle.Fill;
                // Giả sử bạn có một Panel hoặc container để chứa UserControl
                panelContainer.Controls.Add(ucDangBaiTimTho);
            }
            ucDangBaiTimTho.BringToFront();
        }

        private void HienThiUC_QuanLyLich()
        {
            if (ucQuanLyLich == null || ucQuanLyLich.IsDisposed)
            {
                //ucQuanLyLich = new UC_QuanLyLich();
                ucQuanLyLich.Dock = DockStyle.Fill;
                // Giả sử bạn có một Panel hoặc container để chứa UserControl
                panelContainer.Controls.Add(ucQuanLyLich);
            }
            ucQuanLyLich.BringToFront();
        }

       

        private void HienThiUCNoiDungBaiDang(int idBaiDang)
        {
            if (ucNoiDungBaiDang == null || ucNoiDungBaiDang.IsDisposed)
            {
                ucNoiDungBaiDang = new UC_NoiDungBaiDang(idBaiDang);
                ucNoiDungBaiDang.Dock = DockStyle.Fill;
                //ucNoiDungBaiDang.BaiDangDeleted += UcNoiDungBaiDang_BaiDangDeleted;
                panelContainer.Controls.Add(ucNoiDungBaiDang);
            }
            ucNoiDungBaiDang.BringToFront();
        }
        // Ví dụ: Sự kiện click của một button để hiển thị UC_DangBaiTimTho
        private void btnHienThiDangBai_Click(object sender, EventArgs e)
        {
            // Giả sử idNguoiDung là 1, bạn cần thay đổi giá trị này tùy theo logic của ứng dụng
            //HienThiUCDangBaiTimTho(1);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}