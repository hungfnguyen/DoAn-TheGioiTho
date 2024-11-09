using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.Config;
using TheGioiTho.Dao;
using TheGioiTho.Model;

namespace TheGioiTho.Controller.Tho
{
    public partial class UC_TrangChu : UserControl
    {
        private TheGioiTho.Model.Tho tho;
        private int idTho = UserSession.UserID;
        private SqlConnection conn = Config.DBConnection.GetConnection();
        private TaiKhoanDao taiKhoanDao = new TaiKhoanDao();
        private int idNguoiDung;
        private readonly ImageController imageController; // Thêm ImageController

        public UC_TrangChu()
        {
            InitializeComponent();
            imageController = new ImageController(); // Khởi tạo ImageController
            conn = DBConnection.GetConnection();
            LoadBaiDangNguoiDung();
            dgvBaiDangNguoiDung.CellClick += dgvBaiDangNguoiDung_CellClick;
            this.Load += UC_TrangChu_Load;
        }

        private void UC_TrangChu_Load(object sender, EventArgs e)
        {
            LoadBaiDangNguoiDung();
        }

        private void dgvBaiDangNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadBaiDangNguoiDung()
        {
            try
            {
                // 1. Load data từ database
                string query = "SELECT * FROM vw_BaiDangNguoiDung";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 2. Set DataSource ngay từ đầu
                dgvBaiDangNguoiDung.DataSource = dt;

                // 3. Ẩn các cột không cần thiết
                dgvBaiDangNguoiDung.Columns["IDNguoiDung"].Visible = false;
                dgvBaiDangNguoiDung.Columns["HinhAnh"].Visible = false;

                // 4. Thêm cột hình ảnh
                if (!dgvBaiDangNguoiDung.Columns.Contains("HinhAnhDisplay"))
                {
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                    {
                        Name = "HinhAnhDisplay",
                        HeaderText = "Hình Ảnh",
                        ImageLayout = DataGridViewImageCellLayout.Zoom
                    };
                    dgvBaiDangNguoiDung.Columns.Add(imageColumn);
                }

                // 5. Cấu hình hiển thị
                dgvBaiDangNguoiDung.RowTemplate.Height = 150;
                dgvBaiDangNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Debug đường dẫn
                string imageFolderPath = Path.Combine(
                    Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
                    "Images"
                );
                Console.WriteLine($"Đường dẫn thư mục Images: {imageFolderPath}");
                Console.WriteLine($"Thư mục tồn tại: {Directory.Exists(imageFolderPath)}");

                // 6. Load và gán ảnh
                foreach (DataGridViewRow row in dgvBaiDangNguoiDung.Rows)
                {
                    try
                    {
                        string fileName = row.Cells["HinhAnh"].Value?.ToString();
                        Console.WriteLine($"Tên file ảnh: {fileName}"); // Debug log

                        if (!string.IsNullOrEmpty(fileName))
                        {
                            Image img = imageController.LoadImage(fileName);
                            if (img != null)
                            {
                                row.Cells["HinhAnhDisplay"].Value = img;
                                Console.WriteLine($"Đã load thành công ảnh: {fileName}");
                            }
                            else
                            {
                                Console.WriteLine($"Không thể load ảnh: {fileName}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi load ảnh: {ex.Message}");
                    }
                }

                // 7. Refresh để đảm bảo hiển thị
                dgvBaiDangNguoiDung.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvBaiDangNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvBaiDangNguoiDung.Rows[e.RowIndex];

                txtTenKhachHang.Text = selectedRow.Cells["HoTen"].Value?.ToString() ?? "";
                txtSoDienThoai.Text = selectedRow.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtDiaDiemLamViec.Text = selectedRow.Cells["DiaChiKhachHang"].Value?.ToString() ?? "";
                txtThoiGianLamViec.Text = $"{selectedRow.Cells["NgayThoDen"].Value?.ToString() ?? ""} {selectedRow.Cells["GioThoDen"].Value?.ToString() ?? ""}";
                txtGhiChu.Text = selectedRow.Cells["GhiChu"].Value?.ToString() ?? "";
                idNguoiDung = Convert.ToInt32(selectedRow.Cells["IDNguoiDung"].Value);

                // Hiển thị ảnh trong PictureBox nếu có
                string fileName = selectedRow.Cells["HinhAnh"].Value?.ToString();
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

        /*protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            // Giải phóng ảnh trong DataGridView
            foreach (DataGridViewRow row in dgvBaiDangNguoiDung.Rows)
            {
                if (row.Cells["HinhAnhDisplay"].Value is Image img)
                {
                    img.Dispose();
                }
            }
        }*/

        private void btnDatLich_Click(object sender, EventArgs e)
        {
            tho = taiKhoanDao.LayThongTinTho(idTho);


            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(txtThoiGianThucHien.Text) || string.IsNullOrWhiteSpace(txtGiaTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thời gian thực hiện và giá tiền.");
                return;
            }

            // Kiểm tra xem có hàng nào được chọn không
            if (dgvBaiDangNguoiDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bài đăng trước khi đặt lịch.");
                return;
            }

            // Lấy thông tin từ các TextBox
            string giaTien = txtGiaTien.Text;

            // Chuyển đổi chuỗi thoiGianThucHien thành DateTime
            DateTime thoiGianThucHien;
            if (!DateTime.TryParse(txtThoiGianThucHien.Text, out thoiGianThucHien))
            {
                MessageBox.Show("Vui lòng nhập thời gian thực hiện đúng định dạng.");
                return;
            }

            string idBaiDang = dgvBaiDangNguoiDung.SelectedRows[0].Cells["IDBaiDang"].Value.ToString(); // Lấy ID bài đăng
            string hoTenKhachHang = dgvBaiDangNguoiDung.SelectedRows[0].Cells["HoTen"].Value.ToString();
            string diaChi = dgvBaiDangNguoiDung.SelectedRows[0].Cells["DiaChiKhachHang"].Value.ToString();

            string hoTenTho = tho.HoTen;
            string SDTTho = tho.SoDienThoai;

            DateTime ngayThoDen;
            if (!DateTime.TryParse(dgvBaiDangNguoiDung.SelectedRows[0].Cells["NgayThoDen"].Value.ToString(), out ngayThoDen))
            {
                MessageBox.Show("Ngày thợ đến không hợp lệ.");
                return;
            }


            string moTa = dgvBaiDangNguoiDung.SelectedRows[0].Cells["GhiChu"].Value.ToString();

            // Gọi hàm lưu thông tin đặt lịch
            DatLich(idBaiDang, thoiGianThucHien, giaTien, hoTenKhachHang, diaChi, hoTenTho, SDTTho, ngayThoDen, moTa, idTho, idNguoiDung);
        }

        private void DatLich(string idBaiDang, DateTime thoiGianThucHien, string giaTien, string hoTenKhachHang, string diaChi, string hoTenTho, string SDTTho, DateTime ngayThoDen, string moTa, int idTho, int idNguoiDung)
        {
            try
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                DataGridViewRow selectedRow = dgvBaiDangNguoiDung.SelectedRows[0];
                DateTime gioThoDen;

                if (!DateTime.TryParse(selectedRow.Cells["GioThoDen"].Value.ToString(), out gioThoDen))
                {
                    MessageBox.Show("Giờ thợ đến không hợp lệ.");
                    return;
                }

                decimal giaTienDecimal;
                if (!decimal.TryParse(giaTien, out giaTienDecimal))
                {
                    MessageBox.Show("Giá tiền không hợp lệ.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand("sp_DatLich", conn, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDTho", idTho);
                    cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                    cmd.Parameters.AddWithValue("@GioThoDen", gioThoDen);
                    cmd.Parameters.AddWithValue("@ThoiGianThucHien", thoiGianThucHien.TimeOfDay);
                    cmd.Parameters.AddWithValue("@GiaTien", giaTienDecimal);
                    cmd.Parameters.AddWithValue("@HoTenKhachHang", hoTenKhachHang);
                    cmd.Parameters.AddWithValue("@DiaChiKhachHang", diaChi);
                    cmd.Parameters.AddWithValue("@HoTenTho", hoTenTho);
                    cmd.Parameters.AddWithValue("@SDTTho", SDTTho);
                    cmd.Parameters.AddWithValue("@NgayThoDen", ngayThoDen);
                    cmd.Parameters.AddWithValue("@Mota", moTa);
                    cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Đặt lịch thành công!");
                LoadBaiDangNguoiDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lịch: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        /*private void DatLich(string idBaiDang, DateTime thoiGianThucHien, string giaTien, string hoTenKhachHang, string diaChi, string hoTenTho, string SDTTho, DateTime ngayThoDen, string moTa, int idTho, int idNguoiDung)
        {
            try
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                DataGridViewRow selectedRow = dgvBaiDangNguoiDung.SelectedRows[0];
                DateTime gioThoDen;

                if (!DateTime.TryParse(selectedRow.Cells["GioThoDen"].Value.ToString(), out gioThoDen))
                {
                    MessageBox.Show("Giờ thợ đến không hợp lệ.");
                    return;
                }

                decimal giaTienDecimal;
                if (!decimal.TryParse(giaTien, out giaTienDecimal))
                {
                    MessageBox.Show("Giá tiền không hợp lệ.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand("sp_DatLich", conn, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Chỉ truyền 5 tham số theo stored procedure mới
                    cmd.Parameters.AddWithValue("@IDTho", 1); // Giả định ID thợ là 1
                    cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                    cmd.Parameters.AddWithValue("@GioThoDen", gioThoDen);
                    cmd.Parameters.AddWithValue("@ThoiGianThucHien", thoiGianThucHien.TimeOfDay);
                    cmd.Parameters.AddWithValue("@GiaTien", giaTienDecimal);
                    cmd.Parameters.AddWithValue("@HoTenKhachHang", hoTenKhachHang);
                    cmd.Parameters.AddWithValue("@DiaChiKhachHang", diaChi);

                    cmd.Parameters.AddWithValue("@HoTenTho", hoTenTho);
                    cmd.Parameters.AddWithValue("@SDTTho", SDTTho);
                    cmd.Parameters.AddWithValue("@NgayThoDen", ngayThoDen);
                    cmd.Parameters.AddWithValue("@Mota", moTa);
                    cmd.Parameters.AddWithValue("@IDTho", idTho);
                    cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);



                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Đặt lịch thành công!");
                LoadBaiDangNguoiDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lịch: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }*/

        
    }
}
