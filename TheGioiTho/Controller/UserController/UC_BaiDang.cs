using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TheGioiTho.Config;
using TheGioiTho.Dao;
using TheGioiTho.Model;


namespace TheGioiTho.Controller.UserController
{
    public partial class UC_BaiDang : UserControl
    {

        private TheGioiTho.Model.Tho tho;
        
        private int idNguoiDung = UserSession.UserID;
        private TaiKhoanNguoiDungDao taiKhoanDao = new TaiKhoanNguoiDungDao();

        private readonly ThoDAO thoDAO;

        private NguoiDung user;
        public UC_BaiDang(int id) 
        {
            InitializeComponent();
            LoadBaiDang();  // Tải danh sách bài đăng thợ khi khởi tạo
            dgvBaiDangTho.CellContentClick += new DataGridViewCellEventHandler(dgvBaiDangTho_CellContentClick);
            thoDAO = new ThoDAO();
            user = taiKhoanDao.LayThongTinNguoiDung(idNguoiDung); // Khởi tạo user tại đây
            idNguoiDung = id;
        }



        // Phương thức tải danh sách bài đăng thợ vào DataGridView
        private void LoadBaiDang()
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                // Thay đổi câu lệnh SQL để truy vấn từ View
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.XemTatCaBaiDangTho", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvBaiDangTho.DataSource = dataTable; // Gắn dữ liệu vào DataGridView

                // Đảm bảo DataGridView tự động điều chỉnh cột cho phù hợp với nội dung
                dgvBaiDangTho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                DateTime ngay = dtpNgayThoDen.Value.Date;
                DateTime gio = dtpGioThoDen.Value.Date;

                /*int idTho = Convert.ToInt32(selectedRow.Cells["IDTho"].Value);
                int idBaiDang = Convert.ToInt32(selectedRow.Cells["IDBaiDang"].Value);
                DatLich(idNguoiDung, idBaiDang, idTho, ngay, gio);*/
                        // Lấy thông tin từ các control trên form
                        DateTime ngayThoDen = dtpNgayThoDen.Value.Date; // Ngày thợ đến
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
                        }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài đăng thợ!");
            }
        }
        private void DatLich(int idNguoiDung, int idBaiDang, int idTho, DateTime ngayThoDen, DateTime gioThoDen)
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

     

        private void dgvBaiDangTho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvBaiDangTho_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng có chọn dòng hợp lệ không
            {
                DataGridViewRow row = dgvBaiDangTho.Rows[e.RowIndex];

                // Đổ dữ liệu vào các TextBox
                txtT.Text = row.Cells["TieuDe"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtGiaTien.Text = row.Cells["GiaTien"].Value.ToString();
                txtThoiGianThucHien.Text = row.Cells["ThoiGianThucHien"].Value.ToString();
                txtHoTenTho.Text = row.Cells["HoTen"].Value.ToString(); // HoTen của thợ
                txtHinhAnh.Text = row.Cells["HinhAnh"].Value.ToString();
                txtTenLinhVuc.Text = row.Cells["TenLinhVuc"].Value.ToString();

                // Đổ dữ liệu vào các DateTimePicker
                // dtpNgayThoDen.Value = Convert.ToDateTime(row.Cells["NgayThoDen"].Value);
                // dtpGioThoDen.Value = Convert.ToDateTime(row.Cells["GioThoDen"].Value);
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
    }
    }

