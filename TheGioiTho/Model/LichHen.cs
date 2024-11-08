using System;

namespace TheGioiTho.Model
{
    public class LichHen
    {
        public int IDLichHen { get; set; }
        public string LinhVuc { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public DateTime LichHenDen { get; set; }
        public string Gio { get; set; }
        public string GhiChu { get; set; }
        public decimal GiaTien { get; set; }
        public string TrangThaiCongViecTho { get; set; }
        public string TrangThaiCongViecNguoiDung { get; set; }
        public int IDTho { get; set; }

        // Constructor mặc định
        public LichHen() { }

        // Constructor với tất cả các tham số
        public LichHen(int idLichHen, string linhVuc, string ten, string sdt, DateTime lichHenDen,
                       string gio, string ghiChu, decimal giaTien, string trangThaiCongViecTho,
                       string trangThaiCongViecNguoiDung, int idTho)
        {
            IDLichHen = idLichHen;
            LinhVuc = linhVuc;
            Ten = ten;
            SDT = sdt;
            LichHenDen = lichHenDen;
            Gio = gio;
            GhiChu = ghiChu;
            GiaTien = giaTien;
            TrangThaiCongViecTho = trangThaiCongViecTho;
            TrangThaiCongViecNguoiDung = trangThaiCongViecNguoiDung;
            IDTho = idTho;
        }

        // Override phương thức ToString() để dễ dàng hiển thị thông tin
        public override string ToString()
        {
            return $"Lịch hẹn ID: {IDLichHen}, Lĩnh vực: {LinhVuc}, Tên: {Ten}, SDT: {SDT}, " +
                   $"Lịch hẹn đến: {LichHenDen.ToShortDateString()} {Gio}, Giá tiền: {GiaTien}";
        }
    }
}
