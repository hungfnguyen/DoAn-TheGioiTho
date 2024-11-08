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
using TheGioiTho.Controller.Tho;
using TheGioiTho.Controller;
using TheGioiTho.Model;

namespace TheGioiTho.Controller
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string vaiTro = cmbVaiTro.SelectedItem?.ToString();
            string tenTK = txtTenTK.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(vaiTro) || string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "";

                    if (vaiTro == "Thợ")
                    {
                        query = @"SELECT IDTho AS UserID, TaiKhoan, MatKhau FROM Tho WHERE TaiKhoan = @TenTK AND MatKhau = @MatKhau";
                    }
                    else if (vaiTro == "Người Dùng")
                    {
                        query = @"SELECT IDNguoiDung AS UserID, TaiKhoan, MatKhau FROM NguoiDung WHERE TaiKhoan = @TenTK AND MatKhau = @MatKhau";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenTK", tenTK);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đăng nhập thành công
                                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Lưu ID và Vai Trò vào UserSession
                                int userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                UserSession.UserID = userID;
                                UserSession.VaiTro = vaiTro;

                                // Kiểm tra nếu lưu mật khẩu
                                if (cbLuumk.Checked)
                                {
                                    Properties.Settings.Default.TenTK = tenTK;
                                    Properties.Settings.Default.MatKhau = matKhau;
                                    Properties.Settings.Default.VaiTro = vaiTro;
                                    Properties.Settings.Default.Save();
                                }
                                else
                                {
                                    Properties.Settings.Default.Reset();
                                }

                                // Đóng form đăng nhập và mở form tương ứng với vai trò
                                reader.Close();
                                this.Hide();

                                if (vaiTro == "Thợ")
                                {
                                    FrmTho frmTho = new FrmTho();
                                    frmTho.Show();
                                }
                                else if (vaiTro == "Người Dùng")
                                {
                                    // Truyền userID vào constructor của TrangNguoiDung
                                    TrangNguoiDung frmNguoiDung = new TrangNguoiDung(userID);
                                    frmNguoiDung.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            // Tải thông tin đăng nhập nếu trước đó đã lưu
            if (!string.IsNullOrEmpty(Properties.Settings.Default.TenTK))
            {
                txtTenTK.Text = Properties.Settings.Default.TenTK;
                txtMatKhau.Text = Properties.Settings.Default.MatKhau;
                cmbVaiTro.SelectedItem = Properties.Settings.Default.VaiTro;
                cbLuumk.Checked = true;
            }
        }
    }
}
