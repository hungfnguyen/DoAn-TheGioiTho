using System;

namespace TheGioiTho.Model
{
    public class CongViec
    {
        public int IDCongViec { get; set; }
        public int IDBaiDang { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianHoanThanh { get; set; }
        public string TrangThaiCongViecTho { get; set; }

        // Constructor không tham số
        public CongViec() { }

        // Constructor có tham số
        public CongViec(int idCongViec, int idBaiDang, DateTime thoiGianBatDau, DateTime thoiGianHoanThanh, string trangThaiCongViecTho)
        {
            IDCongViec = idCongViec;
            IDBaiDang = idBaiDang;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianHoanThanh = thoiGianHoanThanh;
            TrangThaiCongViecTho = trangThaiCongViecTho;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Công Việc: {IDCongViec}, ID Bài Đăng: {IDBaiDang}, Thời Gian Bắt Đầu: {ThoiGianBatDau}, Thời Gian Hoàn Thành: {ThoiGianHoanThanh}, Trạng Thái: {TrangThaiCongViecTho}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDCongViec > 0 &&
                   IDBaiDang > 0 &&
                   ThoiGianBatDau <= ThoiGianHoanThanh &&
                   !string.IsNullOrEmpty(TrangThaiCongViecTho) &&
                   TrangThaiCongViecTho.Length <= 50;
        }
    }
}