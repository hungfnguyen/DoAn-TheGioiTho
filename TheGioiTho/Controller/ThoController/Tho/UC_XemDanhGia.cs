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
using TheGioiTho.DAO;
using TheGioiTho.Model;

namespace TheGioiTho.Controller.Tho
{
    public partial class UC_XemDanhGia : UserControl
    {
        private DanhGiaDAO danhGiaDAO;

        public UC_XemDanhGia()
        {
            InitializeComponent();
            /*ptbHinhAnh.Image = Image.FromFile(@"C:\Users\maiho\OneDrive\Hình ảnh\hehe.jpg");
            ptbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;*/
            this.Load += new EventHandler(UC_XemDanhGia_Load);
            danhGiaDAO = new DanhGiaDAO(); // Khởi tạo đối tượng DanhGiaDAO
            //InitializeDataGridView(); // Khởi tạo các cột cho DataGridView
            dgvBaiDanhGia.CellClick += new DataGridViewCellEventHandler(dgvBaiDanhGia_CellClick); // Thêm sự kiện CellClick

        }

        private void dgvBaiDanhGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chỉ số dòng hợp lệ
            {
                // Lấy dòng hiện tại mà người dùng click
                DataGridViewRow selectedRow = dgvBaiDanhGia.Rows[e.RowIndex];

                // Gán giá trị từ dòng được chọn vào các điều khiển tương ứng
                txtTenKhachHang.Text = selectedRow.Cells["HoTen"].Value?.ToString() ?? ""; // Lấy Họ Tên
                lblsao.Text = selectedRow.Cells["SoSao"].Value?.ToString() + " Sao"; // Lấy Số Sao
                txtNhanXet.Text = selectedRow.Cells["NhanXet"].Value?.ToString() ?? ""; // Lấy Nhận Xét

                // Lấy số sao từ cell "SoSao" và chuyển về kiểu số nguyên
                if (int.TryParse(selectedRow.Cells["SoSao"].Value?.ToString(), out int soSao))
                {
                    lblssao.Text = new string('★', soSao) + new string('☆', 5 - soSao);
                }
                ptbHinhAnh.Image = Image.FromFile(selectedRow.Cells["HinhAnh"].Value?.ToString() ?? "");
                ptbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;

                

            }
        }

        private void LoadDanhGia(int IDTho)
        {
            dgvBaiDanhGia.AllowUserToAddRows = false;

            // Lấy danh sách đánh giá từ cơ sở dữ liệu dưới dạng DataTable
            DataTable danhSachDanhGia = danhGiaDAO.GetDanhGiaByIDTho(IDTho);
            dgvBaiDanhGia.DataSource = danhSachDanhGia;
       
          
        }

        
           
            private void UC_XemDanhGia_Load(object sender, EventArgs e)
            {
                int IDTho = UserSession.UserID;  // Thay ID tho thực tế
                LoadDanhGia(IDTho);

        }
    }
}
