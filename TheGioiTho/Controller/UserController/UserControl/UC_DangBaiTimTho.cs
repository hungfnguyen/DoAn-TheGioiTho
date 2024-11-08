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
using TheGioiTho.DAO;
using TheGioiTho.Model;
using TheGioiTho.Config;

namespace TheGioiTho.Controller
{
    public partial class UC_DangBaiTimTho : UserControl
    {
        
        private BaiDangNguoiDungDAO baiDangNguoiDungDAO;
        private int idNguoiDung;
        private string imagePath;
        private static readonly string IMAGE_FOLDER = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        public UC_DangBaiTimTho(int idNguoiDung)
        {
            InitializeComponent();
            baiDangNguoiDungDAO = new BaiDangNguoiDungDAO();
            this.idNguoiDung = idNguoiDung;

            if (!Directory.Exists(IMAGE_FOLDER))
            {
                Directory.CreateDirectory(IMAGE_FOLDER);
            }
        }

        private void UC_DangBaiTimTho_Load(object sender, EventArgs e)
        {
            LoadLinhVuc();
            LoadKhungGio();
            dtpLichThoDen.MinDate = DateTime.Today;
        }

        private void LoadLinhVuc()
        {
            cmbCongViec.DataSource = baiDangNguoiDungDAO.GetDanhSachLinhVuc();
            cmbCongViec.DisplayMember = "TenLinhVuc";
            cmbCongViec.ValueMember = "IDLinhVuc";
        }

        private void LoadKhungGio()
        {
            for (int i = 7; i <= 17; i++)
            {
                cmbChonGio.Items.Add($"{i:D2}:00");
            }
            if (cmbChonGio.Items.Count > 0)
            {
                cmbChonGio.SelectedIndex = 0;
            }
        }

        private void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFile);
                    string destFile = Path.Combine(IMAGE_FOLDER, fileName);

                    if (File.Exists(destFile))
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                        string fileExtension = Path.GetExtension(fileName);
                        fileName = $"{fileNameWithoutExtension}_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
                        destFile = Path.Combine(IMAGE_FOLDER, fileName);
                    }

                    File.Copy(sourceFile, destFile, true);
                    imagePath = destFile;
                    picHinhAnh.Image = new Bitmap(destFile);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnDangBai_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Thêm bài đăng
                            BaiDang baiDang = new BaiDang
                            {
                                IDLinhVuc = (int)cmbCongViec.SelectedValue,
                                TieuDe = txtTieuDe.Text,
                                MoTa = txtMoTa.Text,
                                HinhAnh = imagePath
                            };
                            int newBaiDangId = baiDangNguoiDungDAO.ThemBaiDang(baiDang, conn, transaction);
                            if (newBaiDangId > 0)
                            {
                                // 2. Thêm bài đăng người dùng
                                BaiDangNguoiDung baiDangNguoiDung = new BaiDangNguoiDung
                                {
                                    IDBaiDang = newBaiDangId,
                                    IDNguoiDung = this.idNguoiDung,
                                    NgayThoDen = dtpLichThoDen.Value.Date,
                                    GioThoDen = TimeSpan.Parse(cmbChonGio.SelectedItem.ToString())
                                };
                                if (baiDangNguoiDungDAO.ThemBaiDangNguoiDung(baiDangNguoiDung, conn, transaction))
                                {
                                    // 3. Thêm vào bảng CongViec với trạng thái phù hợp cho cả thợ và người dùng
                                    string insertCongViecQuery = @"
                            INSERT INTO CongViec (IDBaiDang, ThoiGianBatDau, ThoiGianHoanThanh, 
                                                TrangThaiCongViecTho, TrangThaiCongViecNguoiDung)
                            VALUES (@IDBaiDang, @ThoiGianBatDau, @ThoiGianHoanThanh, 
                                   N'Đang chờ xác nhận', N'Đang chờ xác nhận')";

                                    using (SqlCommand cmd = new SqlCommand(insertCongViecQuery, conn, transaction))
                                    {
                                        DateTime ngayThoDen = dtpLichThoDen.Value.Date;
                                        TimeSpan gioThoDen = TimeSpan.Parse(cmbChonGio.SelectedItem.ToString());
                                        DateTime thoiGianBatDau = ngayThoDen.Add(gioThoDen);
                                        cmd.Parameters.AddWithValue("@IDBaiDang", newBaiDangId);
                                        cmd.Parameters.AddWithValue("@ThoiGianBatDau", thoiGianBatDau);
                                        cmd.Parameters.AddWithValue("@ThoiGianHoanThanh", thoiGianBatDau.AddHours(2));
                                        cmd.ExecuteNonQuery();
                                    }
                                    transaction.Commit();
                                    MessageBox.Show("Đăng bài thành công!");
                                    ClearForm();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Có lỗi xảy ra khi đăng bài: {ex.Message}");
                        }
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề.");
                return false;
            }
            if (cmbCongViec.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lĩnh vực công việc.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả chi tiết.");
                return false;
            }
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Vui lòng thêm hình ảnh mô tả.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtTieuDe.Clear();
            cmbCongViec.SelectedIndex = -1;
            dtpLichThoDen.Value = DateTime.Today;
            cmbChonGio.SelectedIndex = -1;
            txtMoTa.Clear();
            picHinhAnh.Image = null;
            imagePath = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Tạo instance của form DanhSachBaiDang với idNguoiDung
                DanhSachBaiDang formDanhSachBaiDang = new DanhSachBaiDang(this.idNguoiDung);
                formDanhSachBaiDang.StartPosition = FormStartPosition.CenterScreen;
                formDanhSachBaiDang.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi mở danh sách bài đăng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}