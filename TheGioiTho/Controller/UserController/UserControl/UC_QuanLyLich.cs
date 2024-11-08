using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.Dao;
using TheGioiTho.Model;

namespace TheGioiTho.Controller
{
    public partial class UC_QuanLyLich : UserControl
    {
        private LichHenNguoiDungDao lichHenDAO;
        private readonly int idNguoiDung;  // Thêm biến để lưu ID người dùng

        // Sửa constructor để nhận IDNguoiDung
        public UC_QuanLyLich(int idNguoiDung)
        {
            InitializeComponent();
            lichHenDAO = new LichHenNguoiDungDao();
            this.idNguoiDung = idNguoiDung;  // Lưu ID người dùng
        }

        private void UC_QuanLyLich_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị danh sách lịch hẹn đang chờ xác nhận khi tải UserControl
            HienThiDanhSachLichHen("Đã xác nhận");
        }

        private void btnDangChoXacNhan_Click(object sender, EventArgs e)
        {
            HienThiDanhSachLichHen("Đang chờ xác nhận");
            //HienThiDanhSachLichHen("Chưa xử lí");
        }

        private void btnDaXacNhan_Click(object sender, EventArgs e)
        {
            HienThiDanhSachLichHen("Đã xác nhận");
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            HienThiDanhSachLichHen("Hoàn tất");
        }

        private void btnDaHuy_Click(object sender, EventArgs e)
        {
            HienThiDanhSachLichHen("Đã hủy");
        }

        private void HienThiDanhSachLichHen(string trangThai)
        {
            List<LichHen> danhSachLichHen = lichHenDAO.GetLichHen(idNguoiDung, trangThai);
            flpLichHen.Controls.Clear();

            if (trangThai == "Đã hủy")
            {
                foreach (LichHen lichHen in danhSachLichHen)
                {
                    ChiTietLich chiTietLich = new ChiTietLich(lichHen, idNguoiDung);  // Truyền idNguoiDung
                    chiTietLich.ConfigureButtons(false, false, false, false, false, true);
                    chiTietLich.Dock = DockStyle.Top;
                    flpLichHen.Controls.Add(chiTietLich);
                }
            }
            else if (trangThai == "Hoàn tất")
            {
                foreach (LichHen lichHen in danhSachLichHen)
                {
                    ChiTietLich chiTietLich = new ChiTietLich(lichHen, idNguoiDung);  // Truyền idNguoiDung
                    bool daDanhGia = false;
                    bool daYeuThich = lichHenDAO.DaYeuThich(idNguoiDung, lichHen.IDLichHen);
                    chiTietLich.ConfigureButtons(false, false, !daDanhGia, !daYeuThich, daYeuThich, false);
                    chiTietLich.Dock = DockStyle.Top;
                    flpLichHen.Controls.Add(chiTietLich);
                }
            }
            else if (trangThai == "Đã xác nhận")
            {
                foreach (LichHen lichHen in danhSachLichHen)
                {
                    ChiTietLich chiTietLich = new ChiTietLich(lichHen, idNguoiDung);  // Truyền idNguoiDung
                    chiTietLich.ConfigureButtons(true, false, false, false, false, false);
                    chiTietLich.Dock = DockStyle.Top;
                    flpLichHen.Controls.Add(chiTietLich);
                }
            }
            else if (trangThai == "Đang chờ xác nhận")
            {
                foreach (LichHen lichHen in danhSachLichHen)
                {
                    ChiTietLich chiTietLich = new ChiTietLich(lichHen, idNguoiDung);  // Truyền idNguoiDung
                    chiTietLich.ConfigureButtons(true, false, false, false, false, false);
                    chiTietLich.Dock = DockStyle.Top;
                    flpLichHen.Controls.Add(chiTietLich);
                }
            }
            else
            {
                foreach (LichHen lichHen in danhSachLichHen)
                {
                    ChiTietLich chiTietLich = new ChiTietLich(lichHen, idNguoiDung);  // Truyền idNguoiDung
                    chiTietLich.ConfigureButtons(true, false, false, false, false, false);
                    chiTietLich.Dock = DockStyle.Top;
                    flpLichHen.Controls.Add(chiTietLich);
                }
            }
        }

        private void flpLichHen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}