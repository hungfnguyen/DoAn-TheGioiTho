using System;

namespace TheGioiTho.Model
{
    public class BaiDangNguoiDung
    {
        public int IDBaiDang { get; set; }
        public int IDNguoiDung { get; set; }
        public DateTime NgayThoDen { get; set; }
        public TimeSpan GioThoDen { get; set; }

        // Constructor không tham số
        public BaiDangNguoiDung() { }

        // Constructor có tham số
        public BaiDangNguoiDung(int idBaiDang, int idNguoiDung, DateTime ngayThoDen, TimeSpan gioThoDen)
        {
            IDBaiDang = idBaiDang;
            IDNguoiDung = idNguoiDung;
            NgayThoDen = ngayThoDen;
            GioThoDen = gioThoDen;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Bài Đăng: {IDBaiDang}, ID Người Dùng: {IDNguoiDung}, Ngày Thợ Đến: {NgayThoDen.ToShortDateString()}, Giờ Thợ Đến: {GioThoDen}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDBaiDang > 0 && IDNguoiDung > 0 && NgayThoDen != default(DateTime);
        }
    }
}