using System;

namespace TheGioiTho.Model
{
    public class DatLich
    {
        public int IDNguoiDung { get; set; }
        public int IDBaiDang { get; set; }

        // Constructor không tham số
        public DatLich() { }

        // Constructor có tham số
        public DatLich(int idNguoiDung, int idBaiDang)
        {
            IDNguoiDung = idNguoiDung;
            IDBaiDang = idBaiDang;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Người Dùng: {IDNguoiDung}, ID Bài Đăng: {IDBaiDang}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDNguoiDung > 0 && IDBaiDang > 0;
        }
    }
}