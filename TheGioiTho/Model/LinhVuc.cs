using System;

namespace TheGioiTho.Model
{
    public class LinhVuc
    {
        public int IDLinhVuc { get; set; }
        public int IDDanhMuc { get; set; }
        public string TenLinhVuc { get; set; }

        // Constructor không tham số
        public LinhVuc() { }

        // Constructor có tham số
        public LinhVuc(int idLinhVuc, int idDanhMuc, string tenLinhVuc)
        {
            IDLinhVuc = idLinhVuc;
            IDDanhMuc = idDanhMuc;
            TenLinhVuc = tenLinhVuc;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Lĩnh Vực: {IDLinhVuc}, ID Danh Mục: {IDDanhMuc}, Tên Lĩnh Vực: {TenLinhVuc}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDLinhVuc > 0 &&
                   IDDanhMuc > 0 &&
                   !string.IsNullOrEmpty(TenLinhVuc) &&
                   TenLinhVuc.Length <= 100;
        }
    }
}