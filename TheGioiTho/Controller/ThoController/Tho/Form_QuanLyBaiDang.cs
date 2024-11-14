using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
    public partial class Form_QuanLyBaiDang : Form
    {
        private bool isDataChanged = false;
        private readonly ImageController imageController;
        private string imageName; // Thêm biến lưu tên file ảnh

        public Form_QuanLyBaiDang()
        {
            InitializeComponent();
            imageController = new ImageController(); // Khởi tạo ImageController
            LoadLinhVuc();
        }

        private void dgvQuanLyBaiDang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

            private void Form_QuanLyBaiDang_Load(object sender, EventArgs e)
            {

            DataTable dataTable = LayDanhSachBaiDang();
            dgvQuanLyBaiDang.DataSource = dataTable;

            dgvQuanLyBaiDang.Columns["IDBaiDang"].Visible = false;
            dgvQuanLyBaiDang.Columns["HinhAnh"].Visible = false;

            if (!dgvQuanLyBaiDang.Columns.Contains("HinhAnhDisplay"))
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                {
                    Name = "HinhAnhDisplay",
                    HeaderText = "Hình Ảnh",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvQuanLyBaiDang.Columns.Add(imageColumn);
            }

            dgvQuanLyBaiDang.RowTemplate.Height = 150;

            // Sử dụng ImageController để load ảnh
            foreach (DataGridViewRow row in dgvQuanLyBaiDang.Rows)
            {
                string fileName = row.Cells["HinhAnh"].Value?.ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    try
                    {
                        Image img = imageController.LoadImage(fileName);
                        row.Cells["HinhAnhDisplay"].Value = img;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Không thể tải hình ảnh: {ex.Message}");
                        row.Cells["HinhAnhDisplay"].Value = null;
                    }
                }
                else
                {
                    row.Cells["HinhAnhDisplay"].Value = null;
                }
            }
        }

        private DataTable LayDanhSachBaiDang()
        {
            DataTable dt = new DataTable();

         

            using (SqlConnection conn = Config.DBConnection.GetConnection())

            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachBaiDang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thay IDTho bằng giá trị thực tế bạn cần lấy
                        cmd.Parameters.AddWithValue("@IDTho", UserSession.UserID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu bài đăng: " + ex.Message);
                }
            }
            return dt;
        }




        private int GetSelectedBaiDangId()
        {
            if (dgvQuanLyBaiDang.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvQuanLyBaiDang.SelectedRows[0].Cells["IDBaiDang"].Value);
            }
            return -1; // Trả về -1 nếu không có hàng nào được chọn
        }

        private void XoaBaiDang(int idBaiDang)
        {


            using (SqlConnection conn = Config.DBConnection.GetConnection())

            {
                try
                {
                    conn.Open();
                    string storedProcedure = "sp_XoaBaiDang"; // Tên stored procedure

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Đặt loại command là stored procedure
                        cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang); // Truyền tham số cho stored procedure

                        int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi stored procedure

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa bài đăng thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy bài đăng để xóa.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa bài đăng: " + ex.Message);
                }
            }
        }


        private void btnXoaBaiDang_Click(object sender, EventArgs e)
        {
            int idBaiDang = GetSelectedBaiDangId();
            if (idBaiDang != -1)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài đăng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    XoaBaiDang(idBaiDang);
                    dgvQuanLyBaiDang.DataSource = LayDanhSachBaiDang(); // Cập nhật lại DataGridView
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài đăng để xóa.");
            }

            RefreshDataGrid();
        }

        private void dgvQuanLyBaiDang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có chọn đúng hàng
            {
                DataGridViewRow row = dgvQuanLyBaiDang.Rows[e.RowIndex];

                // Gán dữ liệu vào các control
                txtTieuDe.Text = row.Cells["TieuDe"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtThoiGianThucHien.Text = row.Cells["ThoiGianThucHien"].Value.ToString();
                txtGiaTien.Text = row.Cells["GiaTien"].Value.ToString();

                // Giả sử cbChonCongViec hiển thị tên công việc từ LinhVuc
                cbChonCongViec.Text = row.Cells["TenLinhVuc"].Value.ToString();
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            int idBaiDang = GetSelectedBaiDangId();
            if (idBaiDang == -1)
            {
                MessageBox.Show("Vui lòng chọn một bài đăng để chỉnh sửa.");
                return;
            }

            int idLinhVuc = Convert.ToInt32(cbChonCongViec.SelectedValue);

            // Sử dụng tên file ảnh đã lưu
            string imageNameToSave = imageName;
            if (string.IsNullOrEmpty(imageNameToSave))
            {
                // Nếu không có ảnh mới, giữ nguyên ảnh cũ
                imageNameToSave = dgvQuanLyBaiDang.SelectedRows[0].Cells["HinhAnh"].Value?.ToString();
            }

            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_CapNhatBaiDang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                        cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text);
                        cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                        cmd.Parameters.AddWithValue("@HinhAnh", imageNameToSave);
                        cmd.Parameters.AddWithValue("@IDLinhVuc", idLinhVuc);
                        cmd.Parameters.AddWithValue("@GiaTien", decimal.Parse(txtGiaTien.Text));
                        cmd.Parameters.AddWithValue("@ThoiGianThucHien", txtThoiGianThucHien.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật bài đăng thành công!");
                        RefreshDataGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật bài đăng: " + ex.Message);
                }
            }
        }

        private void RefreshDataGrid()
        {
            dgvQuanLyBaiDang.DataSource = LayDanhSachBaiDang();

            dgvQuanLyBaiDang.Columns["IDBaiDang"].Visible = false;
            dgvQuanLyBaiDang.Columns["HinhAnh"].Visible = false;

            foreach (DataGridViewRow row in dgvQuanLyBaiDang.Rows)
            {
                string fileName = row.Cells["HinhAnh"].Value?.ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    try
                    {
                        Image img = imageController.LoadImage(fileName);
                        row.Cells["HinhAnhDisplay"].Value = img;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Không thể tải hình ảnh: {ex.Message}");
                        row.Cells["HinhAnhDisplay"].Value = null;
                    }
                }
                else
                {
                    row.Cells["HinhAnhDisplay"].Value = null;
                }
            }
        }


        private void LoadLinhVuc()
        {
            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IDLinhVuc, TenLinhVuc FROM View_LinhVuc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbChonCongViec.DataSource = dt;
                    cbChonCongViec.DisplayMember = "TenLinhVuc";  // Hiển thị tên lĩnh vực
                    cbChonCongViec.ValueMember = "IDLinhVuc";     // Lưu IDLinhVuc
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách lĩnh vực: " + ex.Message);
                }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (!imageController.IsValidImageFile(ofd.FileName))
                        {
                            MessageBox.Show("File không phải là ảnh hợp lệ!");
                            return;
                        }

                        using (var image = Image.FromFile(ofd.FileName))
                        {
                            // Tạo tên file mới
                            imageName = imageController.GenerateFileName(ofd.FileName);

                            // Lưu ảnh bằng ImageController
                            imageController.SaveImage(image, imageName);

                            // Hiển thị ảnh lên PictureBox
                            if (pbHinhAnh.Image != null)
                            {
                                pbHinhAnh.Image.Dispose();
                            }
                            pbHinhAnh.Image = imageController.LoadImage(imageName);
                            pbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;

                            txtHinhAnhDuongDan.Text = imageName; // Lưu tên file thay vì đường dẫn
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Giải phóng hình ảnh trong PictureBox
            if (pbHinhAnh.Image != null)
            {
                pbHinhAnh.Image.Dispose();
            }

            // Giải phóng hình ảnh trong DataGridView
            foreach (DataGridViewRow row in dgvQuanLyBaiDang.Rows)
            {
                if (row.Cells["HinhAnhDisplay"].Value is Image img)
                {
                    img.Dispose();
                }
            }
        }
    }
}