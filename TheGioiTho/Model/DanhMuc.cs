using System;

namespace TheGioiTho.Model
{
    public class DanhMuc
    {
        public int IDDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        // Constructor không tham số
        public DanhMuc() { }

        // Constructor có tham số
        public DanhMuc(int idDanhMuc, string tenDanhMuc)
        {
            IDDanhMuc = idDanhMuc;
            TenDanhMuc = tenDanhMuc;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Danh Mục: {IDDanhMuc}, Tên Danh Mục: {TenDanhMuc}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDDanhMuc > 0 &&
                   !string.IsNullOrEmpty(TenDanhMuc) &&
                   TenDanhMuc.Length <= 100;
        }
    }
}