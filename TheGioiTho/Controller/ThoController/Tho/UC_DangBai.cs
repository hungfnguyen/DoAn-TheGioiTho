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
        private string imageName; // Đổi hinhAnh thành imageName để lưu tên file
        private readonly ImageController imageController; // Thêm ImageController
        private int idTho = UserSession.UserID;

        public UC_DangBai()
        {
            InitializeComponent();
            conn = DBConnection.GetConnection();
            imageController = new ImageController(); // Khởi tạo ImageController
            LoadThongTinTho();
            LoadLinhVuc();
        }


        private void btnDangBai_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            string thoiGianThucHien = txtThoiGianThucHien.Text.Trim();
            decimal giaTien;

            if (!decimal.TryParse(txtGiaTien.Text.Trim(), out giaTien))
            {
                MessageBox.Show("Vui lòng nhập giá tiền hợp lệ.");
                return;
            }

            int idLinhVuc = (int)cbChonCongViec.SelectedValue;

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ThemBaiDangTho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDLinhVuc", idLinhVuc);
                    cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@MoTa", moTa);
                    cmd.Parameters.AddWithValue("@HinhAnh", imageName); // Lưu tên file thay vì đường dẫn
                    cmd.Parameters.AddWithValue("@IDTho", idTho);
                    cmd.Parameters.AddWithValue("@GiaTien", giaTien);
                    cmd.Parameters.AddWithValue("@ThoiGianThucHien", thoiGianThucHien);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng bài thành công!");

                    // Clear form sau khi đăng bài thành công
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng bài: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Thêm method để clear form
        private void ClearForm()
        {
            txtTieuDe.Clear();
            txtMoTa.Clear();
            txtThoiGianThucHien.Clear();
            txtGiaTien.Clear();
            cbChonCongViec.SelectedIndex = -1;

            if (pictureBoxHinh.Image != null)
            {
                pictureBoxHinh.Image.Dispose();
                pictureBoxHinh.Image = null;
            }
            imageName = null;
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

        // Giải phóng resource khi đóng form
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (pictureBoxHinh.Image != null)
            {
                pictureBoxHinh.Image.Dispose();
            }
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
                openFileDialog.Title = "Chọn tệp ảnh";
                openFileDialog.Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.bmp|Tất cả các tệp|*.*";
                openFileDialog.InitialDirectory = "C:\\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Kiểm tra file có phải là ảnh hợp lệ không
                        if (!imageController.IsValidImageFile(openFileDialog.FileName))
                        {
                            MessageBox.Show("File không phải là ảnh hợp lệ!");
                            return;
                        }

                        using (var image = Image.FromFile(openFileDialog.FileName))
                        {
                            // Tạo tên file mới
                            imageName = imageController.GenerateFileName(openFileDialog.FileName);

                            // Lưu ảnh bằng ImageController
                            imageController.SaveImage(image, imageName);

                            // Hiển thị ảnh lên PictureBox
                            if (pictureBoxHinh.Image != null)
                            {
                                pictureBoxHinh.Image.Dispose();
                            }
                            pictureBoxHinh.Image = imageController.LoadImage(imageName);
                            pictureBoxHinh.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xử lý ảnh: " + ex.Message);
                        imageName = null;
                    }
                }
            }
        }
    }
}
