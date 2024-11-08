using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.DAO;
using TheGioiTho.Model;

namespace TheGioiTho.Controller.ThoController.Tho
{
    public partial class UC_DanhGia : UserControl
    {
        private DanhGiaDAO danhGiaDAO;
        public UC_DanhGia()
        {
            InitializeComponent();
            /*ptbHinhAnh.Image = Image.FromFile(@"C:\Users\maiho\OneDrive\Hình ảnh\hehe.jpg");
            ptbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;*/
            this.Load += new EventHandler(UC_DanhGia_Load);
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

                // Lấy các giá trị từ dòng được chọn
                string hoTen = selectedRow.Cells["HoTen"].Value?.ToString() ?? "";
                string soSao = selectedRow.Cells["SoSao"].Value?.ToString() + " Sao" ?? "";
                string nhanXet = selectedRow.Cells["NhanXet"].Value?.ToString() ?? "";
                string hinhAnh = selectedRow.Cells["HinhAnh"].Value?.ToString() ?? "";

                // Mở form ChiTietDanhGiaForm và truyền dữ liệu vào
                FrmChiTietDanhGia chiTietForm = new FrmChiTietDanhGia(hoTen, soSao, nhanXet, hinhAnh);
                chiTietForm.ShowDialog(); // Mở form chi tiết dưới dạng cửa sổ modal
            }
        }

        private void LoadDanhGia(int IDTho)
        {
            dgvBaiDanhGia.AllowUserToAddRows = false;

            // Lấy danh sách đánh giá từ cơ sở dữ liệu dưới dạng DataTable
            DataTable danhSachDanhGia = danhGiaDAO.GetDanhGiaByIDTho(IDTho);
            // Thêm cột STT (Số thứ tự) vào DataTable
            danhSachDanhGia.Columns.Add("STT", typeof(int));
            for (int i = 0; i < danhSachDanhGia.Rows.Count; i++)
            {
                danhSachDanhGia.Rows[i]["STT"] = i + 1; // Đặt số thứ tự từ 1
            }

            // Đặt DataTable làm nguồn dữ liệu cho DataGridView
            dgvBaiDanhGia.DataSource = danhSachDanhGia;
            dgvBaiDanhGia.Columns["IDNguoiDung"].Visible = false;
            dgvBaiDanhGia.Columns["IDCongViec"].Visible = false;
            dgvBaiDanhGia.Columns["HinhAnh"].Visible = false;
            // Đảm bảo các cột xuất hiện theo thứ tự mong muốn
            dgvBaiDanhGia.Columns["STT"].DisplayIndex = 0;            // Số thứ tự
            dgvBaiDanhGia.Columns["HoTen"].DisplayIndex = 1;           // Khách Hàng
            dgvBaiDanhGia.Columns["SoSao"].DisplayIndex = 2;           // Số Sao
            dgvBaiDanhGia.Columns["NhanXet"].DisplayIndex = 3;         // Nhận Xét
            //dgvBaiDanhGia.Columns["HinhAnh"].DisplayIndex = 4;         // Hình Ảnh


        }
        private void UC_DanhGia_Load(object sender, EventArgs e)
        {
            int IDTho = UserSession.UserID;  // Thay ID tho thực tế
            LoadDanhGia(IDTho);
        }
    }
}
