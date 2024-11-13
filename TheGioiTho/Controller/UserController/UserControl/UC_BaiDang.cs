using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TheGioiTho.Config;
using TheGioiTho.Dao;
using TheGioiTho.Model;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Reflection;


namespace TheGioiTho.Controller.UserController
{
    public partial class UC_BaiDang : UserControl
    {

        private TheGioiTho.Model.Tho tho;
        private int idNguoiDung = UserSession.UserID;
        private TaiKhoanNguoiDungDao taiKhoanDao = new TaiKhoanNguoiDungDao();
        private readonly ThoDAO thoDAO;
        private NguoiDung user;
        private readonly ImageController imageController; // Thêm ImageController

        public UC_BaiDang(int id)
        {
            InitializeComponent();
            imageController = new ImageController();
            thoDAO = new ThoDAO();
            user = taiKhoanDao.LayThongTinNguoiDung(idNguoiDung);
            idNguoiDung = id;
            // Thêm sự kiện Load
            this.Load += UC_BaiDang_Load;
            LoadBaiDang();
        }

        private void UC_BaiDang_Load(object sender, EventArgs e)
        {
            LoadBaiDang();
            dgvBaiDangTho.CellContentClick += new DataGridViewCellEventHandler(dgvBaiDangTho_CellContentClick);
        }

        private void DgvBaiDangTho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvBaiDangTho.Columns[e.ColumnIndex].Name == "HinhAnhDisplay")
            {
                if (e.Value != null && e.Value is Image)
                {
                    DataGridViewImageCell cell = (DataGridViewImageCell)dgvBaiDangTho.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
        }



        // Phương thức tải danh sách bài đăng thợ vào DataGridView
        private void LoadBaiDang()
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                // 1. Load dữ liệu
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.XemTatCaBaiDangTho", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // 2. Xóa và tạo lại cột hình ảnh
                dgvBaiDangTho.Columns.Clear(); // Xóa tất cả các cột

                // 3. Set DataSource
                dgvBaiDangTho.DataSource = dataTable;

                // 4. Thêm cột hình ảnh
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "HinhAnhDisplay";
                imageColumn.HeaderText = "Hình Ảnh";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageColumn.Width = 150;
                dgvBaiDangTho.Columns.Add(imageColumn);

                // 5. Cấu hình hiển thị
                dgvBaiDangTho.RowTemplate.Height = 150;
                dgvBaiDangTho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 6. Ẩn cột không cần thiết
                if (dgvBaiDangTho.Columns.Contains("HinhAnh"))
                    dgvBaiDangTho.Columns["HinhAnh"].Visible = false;
                if (dgvBaiDangTho.Columns.Contains("IDBaiDang"))
                    dgvBaiDangTho.Columns["IDBaiDang"].Visible = false;

                // 7. Load ảnh cho từng dòng
                foreach (DataGridViewRow row in dgvBaiDangTho.Rows)
                {
                    string fileName = row.Cells["HinhAnh"].Value?.ToString();
                    Console.WriteLine($"Đang xử lý file: {fileName}");

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        try
                        {
                            using (Image originalImage = imageController.LoadImage(fileName))
                            {
                                if (originalImage != null)
                                {
                                    // Tạo bản sao của ảnh với kích thước phù hợp
                                    int targetWidth = 150;
                                    int targetHeight = 150;
                                    using (Bitmap resizedImage = new Bitmap(targetWidth, targetHeight))
                                    {
                                        using (Graphics g = Graphics.FromImage(resizedImage))
                                        {
                                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                            g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
                                        }
                                        row.Cells["HinhAnhDisplay"].Value = new Bitmap(resizedImage);
                                    }
                                    Console.WriteLine($"Đã load thành công ảnh: {fileName}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi khi load ảnh cho hàng {row.Index}: {ex.Message}");
                        }
                    }
                }

                // 8. Refresh và cập nhật giao diện
                dgvBaiDangTho.Refresh();
                Application.DoEvents();
            }
        }


        // Sự kiện khi người dùng click vào một dòng trong DataGridView
        private void dgvBaiDangTho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        
        // Sự kiện khi người dùng nhấn nút Đặt Lịch
        private void btnDatLich_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn trong DataGridView
            if (dgvBaiDangTho.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBaiDangTho.SelectedRows[0]; // Lấy dòng được chọn đầu tiên
                System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                // Lấy giá trị từ DateTimePicker và định dạng thành chuỗi theo yêu cầu
                string formattedDate = dtpNgayThoDen.Value.ToString("yyyy-MM-dd");

                // Chuyển đổi chuỗi thành DateTime
                DateTime ngay = DateTime.Parse(formattedDate);
                TimeSpan gio = TimeSpan.Parse(dtpGioThoDen.Value.ToString("HH:mm:ss"));
                int idTho = Convert.ToInt32(selectedRow.Cells["IDTho"].Value);
                int idBaiDang = Convert.ToInt32(selectedRow.Cells["IDBaiDang"].Value);
                DatLich(idNguoiDung, idBaiDang, idTho, ngay, gio);
                        // Lấy thông tin từ các control trên form
                     /*   DateTime ngayThoDen = dtpNgayThoDen.Value.Date; // Ngày thợ đến
                        DateTime gioThoDen = dtpGioThoDen.Value; // Giờ thợ đến
                        DateTime thoiGianBatDau = ngayThoDen.Add(gioThoDen.TimeOfDay); // Hợp nhất ngày và giờ
                        decimal giaTien = Convert.ToDecimal(txtGiaTien.Text); // Giá tiền cho công việc

                        string hoTenKhachHang = user.HoTen;
                        string diaChiKhachHang = user.DiaChi;
                        string sdtNguoiDung = user.SoDienThoai;
                        string moTa = selectedRow.Cells["MoTa"].Value.ToString();
                        string hoTentho = selectedRow.Cells["HoTen"].Value.ToString();
                        DateTime thoiGianHoanThanh = thoiGianBatDau.AddHours(3); // Giả sử công việc dự kiến kéo dài 3 giờ, có thể điều chỉnh
                        int idTho = Convert.ToInt32(selectedRow.Cells["IDTho"].Value);




                        // Lấy các ID từ dòng được chọn trong DataGridView
                        int idBaiDang = Convert.ToInt32(selectedRow.Cells["IDBaiDang"].Value);

                        using (SqlConnection connection = DBConnection.GetConnection())
                        {
                            string query = "INSERT INTO CongViec (IDBaiDang, NgayThoDen, TrangThaiCongViecTho, TrangThaiCongViecNguoiDung, GiaTien, HoTenKhachHang, DiaChiKhachHang, HoTenTho, MoTa, IDTho, IDNguoiDung, ThoiGianBatDau) " +
                                           "VALUES (@IDBaiDang, @NgayThoDen, @TrangThaiCongViecTho, @TrangThaiCongViecNguoiDung, @GiaTien, @HoTenKhachHang, @DiaChiKhachHang, @HoTenTho, @MoTa, @IDTho, @IDNguoiDung, @ThoiGianBatDau)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                                command.Parameters.AddWithValue("@NgayThoDen", ngayThoDen);
                                command.Parameters.AddWithValue("@TrangThaiCongViecTho", "Chưa Xử Lí"); // Đặt trạng thái ban đầu
                                command.Parameters.AddWithValue("@TrangThaiCongViecNguoiDung", "Đang chờ xác nhận"); // Đặt trạng thái ban đầu
                                command.Parameters.AddWithValue("@GiaTien", giaTien);
                                command.Parameters.AddWithValue("@HoTenKhachHang", hoTenKhachHang);
                                command.Parameters.AddWithValue("@DiaChiKhachHang", diaChiKhachHang);
                                command.Parameters.AddWithValue("HoTenTho", hoTentho);
                                command.Parameters.AddWithValue("@MoTa", moTa);
                                command.Parameters.AddWithValue("@IDTho", idTho);
                                command.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                                command.Parameters.AddWithValue("@ThoiGianBatDau", thoiGianBatDau);

                                connection.Open();
                                int result = command.ExecuteNonQuery(); // Thực thi câu lệnh

                                if (result > 0)
                                {
                                    MessageBox.Show("Đặt lịch thành công!");
                                }
                                else
                                {
                                    MessageBox.Show("Đặt lịch không thành công.");
                                }
                            }
                        }*/
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài đăng thợ!");
            }
        }
        private void DatLich(int idNguoiDung, int idBaiDang, int idTho, DateTime ngayThoDen, TimeSpan gioThoDen)
        {
            try
            {
                thoDAO.DatLich(idNguoiDung, idBaiDang, idTho, ngayThoDen, gioThoDen);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        // Sự kiện khi người dùng nhấn nút Xem Đánh Giá
        private void btnXemDanhGia_Click(object sender, EventArgs e)
        {
            XemDanhGia xemDanhGia = new XemDanhGia();
            DataGridViewRow selectedRow = dgvBaiDangTho.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["IDTho"].Value);
            xemDanhGia.id = id;
            xemDanhGia.Show();
        }

     

        private void dgvBaiDangTho_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBaiDangTho.Rows[e.RowIndex];

                txtT.Text = row.Cells["TieuDe"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtGiaTien.Text = row.Cells["GiaTien"].Value.ToString();
                txtThoiGianThucHien.Text = row.Cells["ThoiGianThucHien"].Value.ToString();
                txtHoTenTho.Text = row.Cells["HoTen"].Value.ToString();
                txtHinhAnh.Text = row.Cells["HinhAnh"].Value.ToString(); // Hiển thị tên file ảnh
                txtTenLinhVuc.Text = row.Cells["TenLinhVuc"].Value.ToString();

                // Hiển thị ảnh trong một PictureBox nếu bạn có
                string fileName = row.Cells["HinhAnh"].Value?.ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    try
                    {
                        // Nếu bạn có PictureBox để hiển thị ảnh chi tiết
                        // pictureBox.Image?.Dispose();
                        // pictureBox.Image = imageController.LoadImage(fileName);
                        // pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
                    }
                }
            }
        }

        private void btnXemDanhGia_Click_1(object sender, EventArgs e)
        {
            if (dgvBaiDangTho.SelectedRows.Count > 0)
            {
                XemDanhGia xemDanhGia = new XemDanhGia();
            DataGridViewRow selectedRow = dgvBaiDangTho.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["IDTho"].Value);
            xemDanhGia.id = id;
            xemDanhGia.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài đăng thợ!");
            }
            /* string hoTenTho = txtHoTenTho.Text;

             if (string.IsNullOrWhiteSpace(hoTenTho))
             {
                 MessageBox.Show("Vui lòng nhập tên thợ để xem đánh giá.");
                 return;
             }

             // Mở form hoặc dialog để hiển thị danh sách đánh giá
             using (SqlConnection connection = DBConnection.GetConnection())
             {
                 string query = "SELECT * FROM DanhGia WHERE HoTenTho = @HoTenTho";
                 SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                 dataAdapter.SelectCommand.Parameters.AddWithValue("@HoTenTho", hoTenTho);
                 DataTable dataTable = new DataTable();
                 dataAdapter.Fill(dataTable);

                 // Hiển thị danh sách đánh giá trong một dialog hoặc form khác
                 Form danhGiaForm = new Form
                 {
                     Text = "Danh Sách Đánh Giá"
                 };
                 DataGridView dgvDanhGia = new DataGridView
                 {
                     DataSource = dataTable,
                     Dock = DockStyle.Fill
                 };
                 danhGiaForm.Controls.Add(dgvDanhGia);
                 danhGiaForm.Show();*/
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string text = txtTimKiem.Text;
            // MessageBox.Show(text);
            if (string.IsNullOrEmpty(text))
                XemTatCaBaiDangTho();
            else
                TimKiemThoTheoLinhVuc(text);
        }
        private void TimKiemThoTheoLinhVuc(string timkiem)
        {
            try
            {
                dgvBaiDangTho.DataSource = thoDAO.TimKiemThoTheoLinhVuc(timkiem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void XemTatCaBaiDangTho()
        {
            try
            {
                dgvBaiDangTho.DataSource = thoDAO.XemTatCaBaiDangTho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            // Giải phóng ảnh trong DataGridView
            foreach (DataGridViewRow row in dgvBaiDangTho.Rows)
            {
                if (row.Cells["HinhAnhDisplay"].Value is Image img)
                {
                    img.Dispose();
                }
            }
        }

        private void dtpNgayThoDen_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

