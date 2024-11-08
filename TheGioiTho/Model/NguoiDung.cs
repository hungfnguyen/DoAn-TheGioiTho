using System;

namespace TheGioiTho.Model
{
    public class NguoiDung
    {
        public int IDNguoiDung { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal? SoSao { get; set; }

        // Constructor không tham số
        public NguoiDung() { }

        // Constructor có tham số
        public NguoiDung(int idNguoiDung, string taiKhoan, string matKhau, string hoTen, string soDienThoai, string diaChi, decimal? soSao)
        {
            IDNguoiDung = idNguoiDung;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            SoSao = soSao;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID: {IDNguoiDung}, Tài Khoản: {TaiKhoan}, Họ Tên: {HoTen}, SĐT: {SoDienThoai}, Địa Chỉ: {DiaChi}, Số Sao: {SoSao}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(TaiKhoan) &&
                   !string.IsNullOrEmpty(MatKhau) &&
                   !string.IsNullOrEmpty(HoTen) &&
                   !string.IsNullOrEmpty(SoDienThoai) &&
                   !string.IsNullOrEmpty(DiaChi) &&
                   (SoSao == null || (SoSao >= 0 && SoSao <= 5));
        }
    }
}