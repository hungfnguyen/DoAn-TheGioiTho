using System;

namespace TheGioiTho.Model
{
    public class NhanViec
    {
        public int IDTho { get; set; }
        public int IDBaiDang { get; set; }

        // Constructor không tham số
        public NhanViec() { }

        // Constructor có tham số
        public NhanViec(int idTho, int idBaiDang)
        {
            IDTho = idTho;
            IDBaiDang = idBaiDang;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Thợ: {IDTho}, ID Bài Đăng: {IDBaiDang}";
        }
    }
}