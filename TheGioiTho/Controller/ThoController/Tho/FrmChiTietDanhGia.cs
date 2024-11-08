using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGioiTho.Controller.ThoController.Tho
{
    public partial class FrmChiTietDanhGia : Form
    {
        public FrmChiTietDanhGia(string hoTen, string soSao, string nhanXet, string hinhAnh)
        {
            InitializeComponent();
            // Gán các giá trị vào các điều khiển trong form chi tiết
            txtTenKhachHang.Text = hoTen;
            lblsao.Text = soSao;
            txtNhanXet.Text = nhanXet;

            // Lấy số sao từ biến "soSao" và chuyển về kiểu số nguyên, bỏ phần " Sao" ra để lấy giá trị chính xác
            string soSaoValue = soSao.Replace(" Sao", "");
            if (int.TryParse(soSaoValue, out int soSaoInt))
            {
                // Hiển thị sao bằng các ký tự đặc biệt ★ và ☆
                lblssao.Text = new string('★', soSaoInt) + new string('☆', 5 - soSaoInt);
            }
            else
            {
                lblssao.Text = ""; // Đặt giá trị mặc định nếu không thể chuyển đổi
            }

            // Kiểm tra và hiển thị hình ảnh
            if (!string.IsNullOrEmpty(hinhAnh) && File.Exists(hinhAnh))
            {
                ptbHinhAnh.Image = Image.FromFile(hinhAnh);
                ptbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                ptbHinhAnh.Image = null; // Hoặc hiển thị hình mặc định nếu không có ảnh
            }
        }
    }
}
