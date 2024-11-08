using System;
using System.Windows.Forms;
using TheGioiTho.Model;
using TheGioiTho.DAO;
using System.Drawing;

namespace TheGioiTho.Controller
{
    public partial class UC_NoiDungBaiDang : UserControl
    {
        private BaiDangNguoiDungDAO baiDangNguoiDungDAO;
        private BaiDang baiDang;
        private BaiDangNguoiDung baiDangNguoiDung;
        private NguoiDung nguoiDung;
        private int idBaiDang;

        public UC_NoiDungBaiDang(int idBaiDang)
        {
            InitializeComponent();
            this.idBaiDang = idBaiDang;
            baiDangNguoiDungDAO = new BaiDangNguoiDungDAO();
            LoadBaiDang();
        }

        private void LoadBaiDang()
        {
            var result = baiDangNguoiDungDAO.GetBaiDangChiTietById(idBaiDang);
            baiDang = result.Item1;
            baiDangNguoiDung = result.Item2;
            nguoiDung = result.Item3;

            if (baiDang != null && baiDangNguoiDung != null && nguoiDung != null)
            {
                lblTitle.Text = baiDang.TieuDe;
                txtDiaChiKhachHang.Text = nguoiDung.DiaChi;
                txtGhiChu.Text = baiDang.MoTa;
                lblDienLanh.Text = baiDangNguoiDungDAO.GetTenLinhVuc(baiDang.IDLinhVuc);

                

                // Nếu có PictureBox, bạn có thể load hình ảnh ở đây
                //picHinhAnh.Image = Image.FromFile(baiDang.HinhAnh);
            }
            else
            {
                MessageBox.Show("Không tìm thấy bài đăng.");
            }
        }

        private void btnXoaBaiDang_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài đăng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (baiDangNguoiDungDAO.XoaBaiDang(idBaiDang))
                {
                    MessageBox.Show("Bài đăng đã được xóa thành công.");
                    // Thông báo cho form cha rằng bài đăng đã bị xóa
                    OnBaiDangDeleted();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa bài đăng.");
                }
            }
        }

        // Event để thông báo bài đăng đã bị xóa
        public event EventHandler BaiDangDeleted;

        protected virtual void OnBaiDangDeleted()
        {
            BaiDangDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void UC_NoiDungBaiDang_Load(object sender, EventArgs e)
        {

        }
    }
}