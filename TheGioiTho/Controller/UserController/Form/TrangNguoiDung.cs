using System;
using System.Drawing;
using System.Windows.Forms;
using TheGioiTho.Controller;
using TheGioiTho.Controller.UserController;
using TheGioiTho.Model;

namespace TheGioiTho
{
    public partial class TrangNguoiDung : Form
    {
        private readonly int idNguoiDung;  // Thêm biến để lưu ID người dùng

        public TrangNguoiDung(int idNguoiDung) // Thêm tham số để nhận ID người dùng
        {
            InitializeComponent();
            this.idNguoiDung = idNguoiDung;
        }

        private void TrangNguoiDung_Load(object sender, EventArgs e)
        {
            // Thiết lập kích thước của TabControl
            tabCtrlTrangChu.Dock = DockStyle.Fill;
            tabCtrlTrangChu.Padding = new Point(0, 0);
            tabCtrlTrangChu.Margin = new Padding(0);

            // Thiết lập kích thước cho từng TabPage
            foreach (TabPage tab in tabCtrlTrangChu.TabPages)
            {
                tab.Padding = new Padding(0);
                tab.Margin = new Padding(0);
                tab.AutoScroll = true; // Cho phép cuộn nếu nội dung lớn hơn
            }

            // Load UserControl mặc định cho tab Trang Chủ
            LoadTrangChu();
        }

        private void tabCtrlTrangChu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xác định tab được chọn và load UserControl tương ứng
            switch (tabCtrlTrangChu.SelectedTab.Name)
            {
                case "tabPageTrangChu":
                    LoadTrangChu();
                    break;

                case "tabPageHoatDong":
                    LoadHoatDong();
                    break;

                case "tabPageBaiDangTho":
                    LoadBaiDangTho();
                    break;
                case "tabPageDanhSachThoYeuThich":
                    LoadDanhSachThoYeuThich();
                    break;
                case "tabPageTopTho":
                    LoadTopTho();
                    break;
            }
        }

        private void LoadTrangChu()
        {
            tabPageTrangChu.Controls.Clear();
            UC_DangBaiTimTho ucDangBai = new UC_DangBaiTimTho(idNguoiDung)
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            // Tạo panel container để quản lý kích thước tốt hơn
            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                Margin = new Padding(0)
            };

            containerPanel.Controls.Add(ucDangBai);
            tabPageTrangChu.Controls.Add(containerPanel);
        }

        private void LoadHoatDong()
        {
            tabPageHoatDong.Controls.Clear();
            // Truyền idNguoiDung vào constructor của UC_QuanLyLich
            UC_QuanLyLich ucQuanLyLich = new UC_QuanLyLich(idNguoiDung)
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                Margin = new Padding(0)
            };

            containerPanel.Controls.Add(ucQuanLyLich);
            tabPageHoatDong.Controls.Add(containerPanel);
        }

        private void LoadBaiDangTho()
        {
            tabPageBaiDangTho.Controls.Clear();

            // Tạo đối tượng UserControl mới cho Bài Đăng Thợ
            UC_BaiDang ucBaiDang = new UC_BaiDang(idNguoiDung)
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            // Tạo panel container để quản lý kích thước tốt hơn
            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                Margin = new Padding(0)
            };

            // Thêm UserControl vào panel container
            containerPanel.Controls.Add(ucBaiDang);
            tabPageBaiDangTho.Controls.Add(containerPanel);
        }
        private void LoadDanhSachThoYeuThich()
        {
            tabPageDanhSachThoYeuThich.Controls.Clear();

            DanhSachThoYeuThich formDanhSachThoYeuTHich = new DanhSachThoYeuThich
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                Margin = new Padding(0)
            };

            containerPanel.Controls.Add(formDanhSachThoYeuTHich);
            tabPageDanhSachThoYeuThich.Controls.Add(containerPanel);
            formDanhSachThoYeuTHich.Show();

            // Điều chỉnh kích thước form để vừa với panel
            formDanhSachThoYeuTHich.Size = containerPanel.ClientSize;
        }
        private void LoadTopTho()
        {
            tabPageBaiDangTho.Controls.Clear();

            XemTopTho formXemTopTho = new XemTopTho
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                Margin = new Padding(0)
            };

            containerPanel.Controls.Add(formXemTopTho);
            tabPageTopTho.Controls.Add(containerPanel);
            formXemTopTho.Show();

            // Điều chỉnh kích thước form để vừa với panel
            formXemTopTho.Size = containerPanel.ClientSize;
        }
        // Thêm phương thức để xử lý khi form thay đổi kích thước
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Cập nhật lại kích thước của các controls
            foreach (TabPage tab in tabCtrlTrangChu.TabPages)
            {
                foreach (Control control in tab.Controls)
                {
                    if (control is Panel panel)
                    {
                        foreach (Control panelControl in panel.Controls)
                        {
                            if (panelControl is Form)
                            {
                                panelControl.Size = panel.ClientSize;
                            }
                        }
                    }
                }
            }
        }

        private void tabPageTrangChu_Click(object sender, EventArgs e)
        {

        }

        private void tabPageBaiDangTho_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thông tin đăng nhập hiện tại
                UserSession.UserID = 0;
                UserSession.VaiTro = null;

                // Hiển thị lại form đăng nhập
                FrmDangNhap loginForm = new FrmDangNhap();
                loginForm.Show();

                // Đóng form hiện tại
                this.Close();
            }
            // Nếu chọn No, không làm gì cả
        }
    }
}