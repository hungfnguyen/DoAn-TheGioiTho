using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.All_Calendar_Control
{
    public partial class UC_Day : UserControl
    {
        public bool IsOffDay { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        private bool isCheckedChanged = true;

        public event EventHandler OffDayStateChanged;

        public string DayText // Thêm thuộc tính này để truy cập vào Text của label1 từ bên ngoài
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isCheckedChanged)
            {
                return;
            }

            DateTime selectedDate = new DateTime(Year, Month, int.Parse(label1.Text));
            DateTime currentDate = DateTime.Today;

            if (selectedDate < currentDate)
            {
                isCheckedChanged = false; // Đặt giá trị của biến cờ thành false để tránh gọi lại sự kiện CheckedChanged
                MessageBox.Show("Không thể chọn hoặc bỏ chọn ngày trong quá khứ.");
                checkBox1.Checked = false; // Không cho phép chọn hoặc bỏ chọn ngày trong quá khứ
                isCheckedChanged = true; // Đặt lại giá trị của biến cờ thành true để cho phép sự kiện CheckedChanged tiếp tục được kích hoạt
                return;
            }

            IsOffDay = checkBox1.Checked;
            if (IsOffDay)
            {
                this.BackColor = Color.FromArgb(255, 150, 79);
                this.panel1.BackColor = Color.FromArgb(255, 150, 79);
            }
            else
            {
                this.BackColor = Color.White;
                this.panel1.BackColor = Color.White;
            }

            // Gửi sự kiện cho Form Calendar khi trạng thái ngày nghỉ thay đổi
            OffDayStateChanged?.Invoke(this, EventArgs.Empty);
        }

        // Trong UserControl UC_Day
        public void MarkAsOffDay()
        {
            IsOffDay = true;
            //label1.BackColor = Color.FromArgb(255, 150, 79);
            checkBox1.Checked = true;
        }

        public UC_Day(string day)
        {
            InitializeComponent();
            label1.Text = day;
            IsOffDay = false;
        }

        private void UC_Day_Load(object sender, EventArgs e)
        {
            // Thử chuyển đổi giá trị của label1 thành kiểu ngày
            if (int.TryParse(label1.Text, out int dayNumber) && dayNumber >= 1 && dayNumber <= 31)
            {
                // Nếu chuyển đổi thành công và giá trị là một ngày hợp lệ, hiển thị checkBox1
                checkBox1.Visible = true;
            }
            else
            {
                // Nếu không thành công hoặc giá trị không phải là một ngày hợp lệ, ẩn checkBox1
                checkBox1.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ResetDay()
        {
            IsOffDay = false;
            label1.BackColor = Color.White;
            checkBox1.Checked = false;
        }
    }
}
