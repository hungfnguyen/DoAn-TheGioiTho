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

using TheGioiTho.Model;


namespace TheGioiTho.Controller.Tho
{
    public partial class UC_DangBai : UserControl
    {
        private SqlConnection conn = Config.DBConnection.GetConnection();
        string hinhAnh; // Giả sử bạn có txtHinhAnh

        private int idTho = UserSession.UserID;

        private void btnDangBai_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string tieuDe = txtTieuDe.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            string thoiGianThucHien = txtThoiGianThucHien.Text.Trim();
            decimal giaTien;

            // Kiểm tra và chuyển đổi giá tiền
            if (!decimal.TryParse(txtGiaTien.Text.Trim(), out giaTien))
            {
                MessageBox.Show("Vui lòng nhập giá tiền hợp lệ.");
                return;
            }

            int idLinhVuc = (int)cbChonCongViec.SelectedValue; // Lấy ID lĩnh vực đã chọn
            

            try
            {
                // Kết nối đến cơ sở dữ liệu
                conn.Open();

                // Sử dụng Stored Procedure sp_ThemBaiDangTho
                using (SqlCommand cmd = new SqlCommand("sp_ThemBaiDangTho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số cho thủ tục
                    cmd.Parameters.AddWithValue("@IDLinhVuc", idLinhVuc);
                    cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@MoTa", moTa);
                    cmd.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                    cmd.Parameters.AddWithValue("@IDTho", idTho);
                    cmd.Parameters.AddWithValue("@GiaTien", giaTien);
                    cmd.Parameters.AddWithValue("@ThoiGianThucHien", thoiGianThucHien);

                    // Thực thi Stored Procedure
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng bài thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng bài: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Đóng kết nối
            }
        }

        private void UC_DangBai_Load(object sender, EventArgs e)
        {

        }


 


        public UC_DangBai()
        {
            InitializeComponent();
            conn = DBConnection.GetConnection(); // Lấy kết nối từ cấu hình
            LoadThongTinTho(); // Gọi hàm khi UC được khởi tạo
            // Gọi hàm để tải lĩnh vực tương ứng khi công việc được chọn
            LoadLinhVuc();
        }

        private void LoadThongTinTho()
        {
            try
            {
                conn.Open();

                // Sử dụng stored procedure để lấy thông tin thợ
                SqlCommand cmd = new SqlCommand("sp_LayThongTinTho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTho", idTho); // Thay IDTho bằng ID thực tế

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu có kết quả
                {
                    txtTenTho.Text = reader["HoTen"].ToString();
                    txtSoDienThoai.Text = reader["SoDienThoai"].ToString();
                    txtDiaChi.Text = reader["DiaChi"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin thợ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cbChonCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadLinhVuc()
        {
            try
            {
                conn.Open();
                // Sử dụng view để lấy tất cả các lĩnh vực
                string query = "SELECT IDLinhVuc, TenLinhVuc FROM View_LinhVuc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbChonCongViec.DataSource = dt; // Gán DataSource cho ComboBox
                cbChonCongViec.DisplayMember = "TenLinhVuc"; // Hiển thị tên lĩnh vực
                cbChonCongViec.ValueMember = "IDLinhVuc"; // Lưu ID lĩnh vực
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lĩnh vực: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnQuanLyBaiDang_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của Form_QuanLyBaiDang
            Form_QuanLyBaiDang formQuanLyBaiDang = new Form_QuanLyBaiDang();

            // Hiển thị form
            formQuanLyBaiDang.Show(); // Sử dụng Show() nếu bạn muốn mở form không đồng bộ
        }

        private void btnChonTep_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập các thuộc tính cho OpenFileDialog
                openFileDialog.Title = "Chọn tệp ảnh";
                openFileDialog.Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.bmp|Tất cả các tệp|*.*"; // Chỉ cho phép chọn các loại tệp ảnh
                openFileDialog.InitialDirectory = "C:\\"; // Thư mục mặc định khi mở hộp thoại

                // Hiển thị hộp thoại và kiểm tra nếu người dùng chọn tệp
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn tệp đã chọn
                    string filePath = openFileDialog.FileName;

                    // Gán đường dẫn vào biến hinhAnh
                    hinhAnh = filePath;

                    // Nếu muốn, có thể tải và hiển thị hình ảnh
                    try
                    {
                        pictureBoxHinh.Image = Image.FromFile(filePath); // Giả sử bạn có một PictureBox tên pictureBoxHinh
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                    }
                }
            }
        }
    }
}
