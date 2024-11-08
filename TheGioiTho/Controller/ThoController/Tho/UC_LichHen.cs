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

namespace TheGioiTho.Controller.Tho
{
    public partial class UC_LichHen : UserControl
    {
        public UC_LichHen()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void btnChuaXuLi_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachCongViecChuaXuLi();
            dgvLichHen.DataSource = dt; // Gán DataTable vào DataGridView
            btn_ChapNhan.Visible = true;
            btn_TuChoi.Visible = true;
            btn_HoanThanh.Visible = false;
            btn_XemLyDoHuy.Visible = false;
        }

        private DataTable LayDanhSachCongViecChuaXuLi()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Config.DBConnection.GetConnection())

            {
                conn.Open();
                string query = "SELECT * FROM View_CongViec WHERE TrangThaiCongViecTho = N'Chưa Xử Lí'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LayDanhSachCongViecDaChapNhan()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM View_CongViec WHERE TrangThaiCongViecTho = N'Đã Chấp Nhận'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LayDanhSachCongViecTuChoi()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM View_CongViec WHERE TrangThaiCongViecTho = N'Từ Chối'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LayDanhSachCongViecDaHoanThanh()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM View_CongViec WHERE TrangThaiCongViecTho = N'Đã hoàn thành'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


        private DataTable LayDanhSachCongViecDaHuy()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM View_CongViec WHERE TrangThaiCongViecTho = N'Đã hủy'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


        private void SetupDataGridView()
        {
            dgvLichHen.AutoGenerateColumns = false; // Tắt tự động sinh cột
            dgvLichHen.Columns.Clear();

            // Tạo các cột cho DataGridView
            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Công Việc", // Thêm tiêu đề cho cột ID
                DataPropertyName = "IDCongViec" // Liên kết với cột IDCongViec
            });

            // Tạo các cột cho DataGridView
            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lĩnh Vực",
                DataPropertyName = "TenLinhVuc"
            });

            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Khách Hàng",
                DataPropertyName = "TenKhachHang"
            });

            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Giờ",
                DataPropertyName = "NgayGio"
            });

            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Địa Chỉ",
                DataPropertyName = "DiaChi"
            });

            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá Tiền",
                DataPropertyName = "GiaTien"
            });

            dgvLichHen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ghi Chú",
                DataPropertyName = "GhiChu"
            });
        }

        private void UC_LichHen_Load(object sender, EventArgs e)
        {

        }

        private int LayIDCongViecDuocChon()
        {
            if (dgvLichHen.SelectedRows.Count > 0)
            {
                // Giả sử IDCongViec nằm ở cột thứ 0 trong DataGridView
                return Convert.ToInt32(dgvLichHen.SelectedRows[0].Cells[0].Value); // Thay đổi chỉ số cột nếu cần
            }
            return -1; // Không có dòng nào được chọn
        }

        private void ChapNhanCongViec(int idCongViec)
        {
            CapNhatTrangThaiCongViec(idCongViec, "Đã Chấp Nhận", "Đã xác nhận");
        }

        private void TuChoiCongViec(int idCongViec)
        {
            CapNhatTrangThaiCongViec(idCongViec, "Từ Chối", "Đã hủy");
        }

        private void btn_ChapNhan_Click(object sender, EventArgs e)
        {
            int idCongViec = LayIDCongViecDuocChon();
            if (idCongViec != -1)
            {
                ChapNhanCongViec(idCongViec);
                MessageBox.Show("Bạn đã chấp nhận công việc thành công!");
                // Cập nhật lại DataGridView nếu cần
                dgvLichHen.DataSource = LayDanhSachCongViecChuaXuLi();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc để chấp nhận.");
            }
        }

        private void btn_TuChoi_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDaChapNhan_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachCongViecDaChapNhan(); // Lấy danh sách công việc đã chấp nhận
            dgvLichHen.DataSource = dt; // Gán DataTable vào DataGridView
            btn_ChapNhan.Visible = false;
            btn_TuChoi.Visible = false;
            btn_HoanThanh.Visible = true;
            btn_XemLyDoHuy.Visible = false;
        }

        



       

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachCongViecTuChoi(); // Lấy danh sách công việc đã từ chối
            dgvLichHen.DataSource = dt; // Gán DataTable vào DataGridView
            btn_ChapNhan.Visible = false;
            btn_TuChoi.Visible = false;
            btn_HoanThanh.Visible = false;
            btn_XemLyDoHuy.Visible = false;
        }

        private void btnDaHoanThanh_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachCongViecDaHoanThanh(); // Lấy danh sách công việc đã hoàn thành
            dgvLichHen.DataSource = dt; // Gán DataTable vào DataGridView
            btn_ChapNhan.Visible = false;
            btn_TuChoi.Visible = false;
            btn_HoanThanh.Visible = false;
            btn_XemLyDoHuy.Visible = false;
        }

        private void btnDaHuy_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachCongViecDaHuy(); // Lấy danh sách công việc đã hủy
            dgvLichHen.DataSource = dt; // Gán DataTable vào DataGridView
            btn_ChapNhan.Visible = false;
            btn_TuChoi.Visible = false;
            btn_HoanThanh.Visible = false;
            btn_XemLyDoHuy.Visible = true;
        }

        private void CapNhatTrangThaiCongViec(int idCongViec, string trangThaiTho, string trangThaiNguoiDung)
        {
            try
            {
                using (SqlConnection conn = Config.DBConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_CapNhatTrangThaiCongViec", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDCongViec", idCongViec);
                        cmd.Parameters.AddWithValue("@TrangThaiTho", trangThaiTho);
                        cmd.Parameters.AddWithValue("@TrangThaiNguoiDung", trangThaiNguoiDung);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            try
            {
                int idCongViec = LayIDCongViecDuocChon();
                if (idCongViec != -1)
                {
                    HoanThanhCongViec(idCongViec);
                    MessageBox.Show("Công việc đã được hoàn thành!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật lại DataGridView
                    dgvLichHen.DataSource = LayDanhSachCongViecDaChapNhan();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một công việc để hoàn thành.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HoanThanhCongViec(int idCongViec)
        {
            CapNhatTrangThaiCongViec(idCongViec, "Đã hoàn thành", "Hoàn tất");
        }
        private void btn_XemLyDoHuy_Click(object sender, EventArgs e)
        {
            try
            {
                int idCongViec = LayIDCongViecDuocChon(); // Get the selected job ID
                if (idCongViec != -1)
                {
                    string lyDoHuy = LayLyDoHuyCongViec(idCongViec); // Get cancellation reason for the selected job
                    if (!string.IsNullOrEmpty(lyDoHuy))
                    {
                        MessageBox.Show($"Lý do hủy công việc: {lyDoHuy}", "Lý do hủy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Công việc này không có lý do hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một công việc để xem lý do hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy lý do hủy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LayLyDoHuyCongViec(int idCongViec)
        {
            string lyDoHuy = string.Empty;
            using (SqlConnection conn = Config.DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT LyDo FROM View_ChiTietLyDoHuy WHERE IDCongViec = @IDCongViec";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDCongViec", idCongViec);
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        lyDoHuy = result.ToString();
                    }
                }
            }
            return lyDoHuy;
        }

        private void dgvLichHen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_TuChoi_Click_1(object sender, EventArgs e)
        {
            int idCongViec = LayIDCongViecDuocChon();
            if (idCongViec != -1)
            {
                TuChoiCongViec(idCongViec);
                MessageBox.Show("Bạn đã từ chối công việc thành công!");
                // Cập nhật lại DataGridView nếu cần
                dgvLichHen.DataSource = LayDanhSachCongViecChuaXuLi();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc để từ chối.");
            }
        }

        private void btn_ChapNhan_Click_1(object sender, EventArgs e)
        {
            int idCongViec = LayIDCongViecDuocChon();
            if (idCongViec != -1)
            {
                ChapNhanCongViec(idCongViec);
                MessageBox.Show("Bạn đã chấp nhận công việc thành công!");
                // Cập nhật lại DataGridView nếu cần
                dgvLichHen.DataSource = LayDanhSachCongViecChuaXuLi();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc để chấp nhận.");
            }
        }
    }
}
