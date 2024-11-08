using System;

namespace TheGioiTho.Model
{
    public class BaiDangTho
    {
        public int IDBaiDang { get; set; }
        public int IDTho { get; set; }
        public decimal GiaTien { get; set; }
        public int ThoiGianThucHien { get; set; }

        // Constructor không tham số
        public BaiDangTho() { }

        // Constructor có tham số
        public BaiDangTho(int idBaiDang, int idTho, decimal giaTien, int thoiGianThucHien)
        {
            IDBaiDang = idBaiDang;
            IDTho = idTho;
            GiaTien = giaTien;
            ThoiGianThucHien = thoiGianThucHien;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Bài Đăng: {IDBaiDang}, ID Thợ: {IDTho}, Giá Tiền: {GiaTien}, Thời Gian Thực Hiện: {ThoiGianThucHien}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return GiaTien >= 0 && ThoiGianThucHien > 0;
        }
    }
}