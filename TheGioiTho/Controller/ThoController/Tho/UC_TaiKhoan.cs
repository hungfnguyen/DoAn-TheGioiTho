using System;
using GUI.All_Calendar_Control;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.Dao;
using TheGioiTho.Model;
using System.Globalization;
using TheGioiTho.Config;
using System.Web.UI.WebControls;

namespace TheGioiTho.Controller.Tho
{
    public partial class UC_TaiKhoan : UserControl
    {
        private TaiKhoanDao taiKhoanDao;
        private TheGioiTho.Model.Tho tho;
        private int IDTho = UserSession.UserID;
        public UC_TaiKhoan()
        {
            InitializeComponent();
            taiKhoanDao = new TaiKhoanDao();
            LoadThongTinTho(IDTho);
            // Đăng ký sự kiện Load cho UC_TaiKhoan
            this.Load += UC_TaiKhoan_Load;
        }

        // Sự kiện Load của UC_TaiKhoan
        private void UC_TaiKhoan_Load(object sender, EventArgs e)
        {
            Calendar_Load(sender, e); // Gọi phương thức Calendar_Load khi control được load
        }
        public void LoadThongTinTho(int idTho)
        {
            tho = taiKhoanDao.LayThongTinTho(idTho); // Lấy thông tin thợ từ cơ sở dữ liệu
            if (tho != null)
            {
                // Hiển thị thông tin thợ trên form
                txtTenTho.Text = tho.HoTen;
                txtDiaChi.Text = tho.DiaChi;
                //txtemail.Text = tho. // Giả sử bạn đã có trường Email trong lớp Tho
                txtgioitinh.Text = tho.GioiTinh;
                txtsdt.Text = tho.SoDienThoai;
                txtSonamkn.Text = tho.SoNamKinhNghiem.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin thợ.");
            }
        }


        private void btnChinhSuaHoSo_Click(object sender, EventArgs e)
        {
            lblChinhSuaHoSo.Visible = true;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            txtTenTho.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            //txtemail.ReadOnly = false;
            txtgioitinh.ReadOnly = false;
            txtsdt.ReadOnly = false;
            txtSonamkn.ReadOnly = false;
            btnChinhSuaHoSo.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (tho != null)
            {
                // Cập nhật thông tin thợ từ các trường nhập liệu
                tho.HoTen = txtTenTho.Text;
                tho.DiaChi = txtDiaChi.Text;
                //tho.Email = txtemail.Text; // Giả sử bạn đã thêm thuộc tính Email trong lớp Tho
                tho.GioiTinh = txtgioitinh.Text;
                tho.SoDienThoai = txtsdt.Text;
                tho.SoNamKinhNghiem = int.Parse(txtSonamkn.Text);

                // Gọi phương thức lưu trong TaiKhoanDao
                if (taiKhoanDao.CapNhatTho(tho)) // Giả sử bạn đã tạo phương thức này
                {
                    MessageBox.Show("Cập nhật thông tin thành công.");
                    // Đặt lại các trường về chế độ chỉ đọc
                    txtTenTho.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                    //txtemail.ReadOnly = true;
                    txtgioitinh.ReadOnly = true;
                    txtsdt.ReadOnly = true;
                    txtSonamkn.ReadOnly = true;

                    // Ẩn nút lưu và hủy, hiện lại nút chỉnh sửa
                    btnLuu.Visible = false;
                    btnHuy.Visible = false;
                    btnChinhSuaHoSo.Visible = true;
                    lblChinhSuaHoSo.Visible = false;
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin không thành công.");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            taiKhoanDao = new TaiKhoanDao();
            LoadThongTinTho(1);
            // Đặt lại các trường về chế độ chỉ đọc
            txtTenTho.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            //txtemail.ReadOnly = true;
            txtgioitinh.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtSonamkn.ReadOnly = true;

            // Ẩn nút lưu và hủy, hiện lại nút chỉnh sửa
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnChinhSuaHoSo.Visible = true;
            lblChinhSuaHoSo.Visible = false;

        }

        private void btnDoimk_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các textbox
            string matKhauCu = txtMKcu.Text;
            string matKhauMoi = txtMKmoi.Text;
            string xacNhanMK = txtXacNhanMK.Text;

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu
            if (matKhauMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            if (taiKhoanDao.DoiMatKhau(tho.IDTho, matKhauCu, matKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công.");
                // Có thể làm sạch các trường
                txtMKcu.Clear();
                txtMKmoi.Clear();
                txtXacNhanMK.Clear();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác. Vui lòng thử lại.");
            }


        }

        
        public static int _year, _month;

        //danh sach cac ngay nghi sẽ xoa khi tho bỏ chọn
        private List<DateTime> offDays = new List<DateTime>();



        private void Calendar_Load(object sender, EventArgs e)
        {
            showDays(DateTime.Now.Month, DateTime.Now.Year);

            // Gọi phương thức từ TaiKhoanDao để đánh dấu ngày nghỉ
            LoadOffDays(IDTho,  _month, _year);
            // Gán sự kiện cho UC_Day
            foreach (UC_Day ucDay in flowLayoutPanel1.Controls.OfType<UC_Day>())
            {
                ucDay.OffDayStateChanged += UC_Day_OffDayStateChanged;
            }
        }

       


        private void MarkDayAsOff(int day, int month, int year)
        {
            foreach (UC_Day ucDay in flowLayoutPanel1.Controls.OfType<UC_Day>())
            {
                if (ucDay.DayText == day.ToString() && _month == month && _year == year)
                {
                    ucDay.MarkAsOffDay();
                    break; // Đánh dấu xong thì thoát vòng lặp
                }
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDays(_month, _year);
            
            LoadOffDays(IDTho, _month, _year);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _month -= 1;
            if (_month < 1)
            {
                _month = 1;
                _year -= 1;
            }
            showDays(_month, _year);
           
            LoadOffDays(IDTho, _month, _year);
        }
       

        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lblMonth.Text = monthName.ToUpper() + " " + year;
            DateTime startodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = (int)startodTheMonth.DayOfWeek; // Sửa thành ngày đầu tiên của tháng



            // Bắt đầu vòng lặp từ 0 để hiển thị ngày đầu tiên của tháng
            for (int i = 0; i < week; i++)
            {
                UC_Day uc = new UC_Day("");
                flowLayoutPanel1.Controls.Add(uc);
            }

            for (int i = 1; i <= day; i++) // Sửa điều kiện vòng lặp để bao gồm cả ngày cuối cùng của tháng
            {
                UC_Day uc = new UC_Day(i.ToString());
                uc.Year = _year;
                uc.Month = _month;
                flowLayoutPanel1.Controls.Add(uc);
            }

        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            // Cập nhật lịch nghỉ vào cơ sở dữ liệu
            taiKhoanDao.UpdateOffDaysToDatabase(IDTho, flowLayoutPanel1, _year, _month);
        }

        private void UC_Day_OffDayStateChanged(object sender, EventArgs e)
        {
            UC_Day ucDay = sender as UC_Day;
            if (ucDay != null)
            {
                if (ucDay.IsOffDay)
                {
                    // Nếu ngày nghỉ đã được chọn, thêm vào danh sách offDays
                    DateTime offDay = new DateTime(_year, _month, int.Parse(ucDay.DayText));
                    if (!offDays.Contains(offDay))
                    {
                        offDays.Add(offDay);
                    }
                }
                else
                {
                    // Nếu ngày nghỉ đã được bỏ chọn, xóa khỏi danh sách offDays
                    DateTime offDay = new DateTime(_year, _month, int.Parse(ucDay.DayText));
                    offDays.Remove(offDay);
                }
            }
        }

        private void txtTenTho_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void LoadOffDays(int idTho, int month, int year)
        {
            List<DateTime> offDays = taiKhoanDao.GetOffDaysByMonth(idTho, month, year);
            // Giả sử panel là FlowLayoutPanel chứa các UC_Day
            foreach (DateTime offDay in offDays)
            {
                foreach (UC_Day ucDay in flowLayoutPanel1.Controls.OfType<UC_Day>())
                {
                    if (ucDay.DayText == offDay.Day.ToString())
                    {
                        ucDay.MarkAsOffDay(); // Gọi phương thức đánh dấu ngày nghỉ
                        break;
                    }
                }
            }
        }

    }

}

