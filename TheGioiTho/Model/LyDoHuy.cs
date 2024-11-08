using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGioiTho.Model
{
    public class LyDoHuy
    {
        public int IDCongViec { get; set; }
        public int? IDNguoiDung { get; set; }  // Thêm ? để cho phép null
        public int? IDTho { get; set; }        // Thêm ? để cho phép null
        public string LyDo { get; set; }
        public DateTime NgayHuy { get; set; }
        public string NguoiHuy { get; set; }

        // Constructor mặc định
        public LyDoHuy() { }

        // Constructor với tất cả các tham số
        public LyDoHuy(int idCongViec, int idNguoiDung, int idTho,
                      string lyDo, DateTime ngayHuy, string nguoiHuy)
        {
            IDCongViec = idCongViec;
            IDNguoiDung = idNguoiDung;
            IDTho = idTho;
            LyDo = lyDo;
            NgayHuy = ngayHuy;
            NguoiHuy = nguoiHuy;
        }

        // Phương thức ToString() để dễ dàng hiển thị thông tin
        public override string ToString()
        {
            return $"Công việc {IDCongViec} - {NguoiHuy} hủy ngày {NgayHuy.ToString("dd/MM/yyyy HH:mm")} - Lý do: {LyDo}";
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return IDCongViec > 0
                && IDNguoiDung > 0
                && IDTho > 0
                && !string.IsNullOrEmpty(LyDo)
                && !string.IsNullOrEmpty(NguoiHuy)
                && NgayHuy != default(DateTime);
        }
    }
}
