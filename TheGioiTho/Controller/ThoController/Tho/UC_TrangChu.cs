using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        private int idNguoiDung; // Biến để lưu ID người dùng
       


        public UC_TrangChu()
        {
            InitializeComponent();
            conn = DBConnection.GetConnection(); // Lấy kết nối từ cấu hình
            LoadBaiDangNguoiDung(); // Gọi hàm khi UC được khởi tạo
            dgvBaiDangNguoiDung.CellClick += dgvBaiDangNguoiDung_CellClick; // Đăng ký sự kiện CellClick
        }

   

        private void dgvBaiDangNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadBaiDangNguoiDung()
        {
            try
            {
                string query = "SELECT * FROM vw_BaiDangNguoiDung";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvBaiDangNguoiDung.DataSource = dt;


                // Cập nhật cột HinhAnh để hiển thị hình ảnh
                foreach (DataGridViewRow row in dgvBaiDangNguoiDung.Rows)
                {
                    string imagePath = row.Cells["HinhAnh"].Value?.ToString(); // Lấy giá trị từ cột HinhAnh
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        try
                        {
                            // Đảm bảo đường dẫn hình ảnh chính xác và chuyển đổi thành Image
                            row.Cells["HinhAnh"].Value = Image.FromFile(imagePath); // Chuyển đổi đường dẫn thành hình ảnh
                        }
                        catch (Exception)
                        {
                            row.Cells["HinhAnh"].Value = null; // Nếu không thể load hình, gán giá trị null
                        }
                    }
                }


                // Ẩn cột IDNguoiDung
                dgvBaiDangNguoiDung.Columns["IDNguoiDung"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvBaiDangNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra không phải tiêu đề cột
            {
                DataGridViewRow selectedRow = dgvBaiDangNguoiDung.Rows[e.RowIndex];

                // Gán dữ liệu vào các TextBox
                txtTenKhachHang.Text = selectedRow.Cells["HoTen"].Value?.ToString() ?? "";
                txtSoDienThoai.Text = selectedRow.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtDiaDiemLamViec.Text = selectedRow.Cells["DiaChiKhachHang"].Value?.ToString() ?? "";
                txtThoiGianLamViec.Text = $"{selectedRow.Cells["NgayThoDen"].Value?.ToString() ?? ""} {selectedRow.Cells["GioThoDen"].Value?.ToString() ?? ""}";
                txtGhiChu.Text = selectedRow.Cells["GhiChu"].Value?.ToString() ?? "";

                // Lấy ID người dùng từ hàng đã chọn
                idNguoiDung = Convert.ToInt32(selectedRow.Cells["IDNguoiDung"].Value); // ID người dùng đã được thêm vào nhưng ẩn
            }
        }

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

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtThoiGianThucHien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThoiGianLamViec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaDiemLamViec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDiaDiemLamViec_Click(object sender, EventArgs e)
        {

        }

        private void lblSoDienThoai_Click(object sender, EventArgs e)
        {

        }

        private void lblTenKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void baiDangNguoiDungBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
