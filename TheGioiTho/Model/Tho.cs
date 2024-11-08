using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGioiTho.Model
{
    public class Tho
    {
        public int IDTho { get; set; }

        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string HoTen { get; set; }

        public string SoDienThoai { get; set; }

        public string GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public int SoNamKinhNghiem { get; set; }

        // Constructor không tham số
        public Tho() { }

        // Constructor có tham số
        public Tho(int idTho, string taiKhoan, string matKhau, string hoTen, string soDienThoai, string gioiTinh, string diaChi, int soNamKinhNghiem)
        {
            IDTho = idTho;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SoNamKinhNghiem = soNamKinhNghiem;
        }

        // Phương thức ToString để hiển thị thông tin thợ (tùy chọn)
        public override string ToString()
        {
            return $"ID: {IDTho}, Tài Khoản: {TaiKhoan}, Họ Tên: {HoTen}, Số ĐT: {SoDienThoai}, Giới Tính: {GioiTinh}, Địa Chỉ: {DiaChi}, Số Năm Kinh Nghiệm: {SoNamKinhNghiem}";
        }
    }

}
