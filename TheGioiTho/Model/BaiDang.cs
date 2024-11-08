using System;

namespace TheGioiTho.Model
{
    public class BaiDang
    {
        public int IDBaiDang { get; set; }
        public int IDLinhVuc { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        // Constructor không tham số
        public BaiDang() { }

        // Constructor có tham số
        public BaiDang(int idBaiDang, int idLinhVuc, string tieuDe, string moTa, string hinhAnh)
        {
            IDBaiDang = idBaiDang;
            IDLinhVuc = idLinhVuc;
            TieuDe = tieuDe;
            MoTa = moTa;
            HinhAnh = hinhAnh;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Bài Đăng: {IDBaiDang}, ID Lĩnh Vực: {IDLinhVuc}, Tiêu Đề: {TieuDe}, Mô Tả: {(MoTa.Length > 50 ? MoTa.Substring(0, 50) + "..." : MoTa)}, Hình Ảnh: {HinhAnh}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDBaiDang > 0 &&
                   IDLinhVuc > 0 &&
                   !string.IsNullOrEmpty(TieuDe) &&
                   TieuDe.Length <= 100 &&
                   !string.IsNullOrEmpty(MoTa) &&
                   !string.IsNullOrEmpty(HinhAnh) &&
                   HinhAnh.Length <= 255;
        }
    }
}