using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TheGioiTho.DAO;
using TheGioiTho.Model;
using System.Drawing;  

namespace TheGioiTho
{
    public partial class DanhSachBaiDang : Form
    {
        private BaiDangNguoiDungDAO baiDangDAO;
        private readonly int idNguoiDung;  // Thêm biến idNguoiDung
        private static readonly string IMAGE_FOLDER = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        public DanhSachBaiDang(int idNguoiDung)  // Thêm tham số vào constructor
        {
            InitializeComponent();
            InitializeDataGridView();
            baiDangDAO = new BaiDangNguoiDungDAO();
            this.idNguoiDung = idNguoiDung;  // Lưu idNguoiDung

            if (!Directory.Exists(IMAGE_FOLDER))
            {
                Directory.CreateDirectory(IMAGE_FOLDER);
            }
        }

        private void InitializeDataGridView()
        {
            dgvDanhSachBaiDang = new DataGridView();
            dgvDanhSachBaiDang.Dock = DockStyle.Fill;

            // Thêm các cột cho DataGridView
            dgvDanhSachBaiDang.Columns.Add("IDBaiDang", "ID");
            dgvDanhSachBaiDang.Columns.Add("IDLinhVuc", "Lĩnh Vực");
            dgvDanhSachBaiDang.Columns.Add("TieuDe", "Tiêu Đề");
            dgvDanhSachBaiDang.Columns.Add("MoTa", "Mô Tả");

            // Thêm cột hình ảnh kiểu DataGridViewImageColumn
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Hình Ảnh";
            imgCol.Name = "HinhAnh";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvDanhSachBaiDang.Columns.Add(imgCol);

            // Cấu hình thuộc tính của DataGridView
            dgvDanhSachBaiDang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachBaiDang.AllowUserToAddRows = false;
            dgvDanhSachBaiDang.ReadOnly = true;
            

            // Điều chỉnh chiều cao của hàng để hiển thị hình ảnh tốt hơn
            dgvDanhSachBaiDang.RowTemplate.Height = 80;

            // Thêm sự kiện click cho DataGridView
            dgvDanhSachBaiDang.CellDoubleClick += DgvDanhSachBaiDang_CellDoubleClick;

            // Thêm DataGridView vào Form
            this.Controls.Add(dgvDanhSachBaiDang);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDanhSachBaiDang();
        }

        private void LoadDanhSachBaiDang()
        {
            try
            {
                dgvDanhSachBaiDang.Rows.Clear();
                List<BaiDang> danhSachBaiDang = baiDangDAO.GetAllBaiDang(idNguoiDung);

                foreach (BaiDang baiDang in danhSachBaiDang)
                {
                    Image hinhAnh = null;
                    if (!string.IsNullOrEmpty(baiDang.HinhAnh))
                    {
                        string imagePath = Path.Combine(IMAGE_FOLDER, baiDang.HinhAnh);
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    hinhAnh = Image.FromStream(stream);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Sử dụng hình ảnh mặc định hoặc để null nếu không load được
                                Console.WriteLine($"Lỗi khi load hình ảnh: {ex.Message}");
                            }
                        }
                    }

                    dgvDanhSachBaiDang.Rows.Add(
                        baiDang.IDBaiDang,
                        baiDang.IDLinhVuc,
                        baiDang.TieuDe,
                        baiDang.MoTa,
                        hinhAnh // Thêm hình ảnh vào cột
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải danh sách bài đăng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Giải phóng tài nguyên hình ảnh
            foreach (DataGridViewRow row in dgvDanhSachBaiDang.Rows)
            {
                if (row.Cells["HinhAnh"].Value is Image img)
                {
                    img.Dispose();
                }
            }
        }

        private void DgvDanhSachBaiDang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idBaiDang = Convert.ToInt32(dgvDanhSachBaiDang.Rows[e.RowIndex].Cells["IDBaiDang"].Value);
                // Xử lý khi double click vào một bài đăng
                // Ví dụ: Mở form chi tiết bài đăng
                // ChiTietBaiDang formChiTiet = new ChiTietBaiDang(idBaiDang);
                // formChiTiet.ShowDialog();
            }
        }

        // Thêm phương thức để refresh data
        public void RefreshData()
        {
            LoadDanhSachBaiDang();
        }

        private void DanhSachBaiDang_Load(object sender, EventArgs e)
        {

        }
    }
}