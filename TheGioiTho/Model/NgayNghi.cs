using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGioiTho.Model
{
    public class NgayNghi
    {
        public int IDNgayNghi { get; set; }
        public int IDTho { get; set; }
        public DateTime Ngay { get; set; }
        public TimeSpan Gio { get; set; }

        // Constructor không tham số
        public NgayNghi() { }

        // Constructor có tham số
        public NgayNghi(int idNgayNghi, int idTho, DateTime ngay, TimeSpan gio)
        {
            IDNgayNghi = idNgayNghi;
            IDTho = idTho;
            Ngay = ngay;
            Gio = gio;
        }

        // Phương thức ToString để hiển thị thông tin ngày nghỉ (tùy chọn)
        public override string ToString()
        {
            return $"ID Ngày Nghỉ: {IDNgayNghi}, ID Thợ: {IDTho}, Ngày: {Ngay.ToShortDateString()}, Giờ: {Gio}";
        }
    }
}