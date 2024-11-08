using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGioiTho.Model
{
    public class NgayNghiTho
    {
        public int IDTho { get; set; }
        public int IDNgayNghi { get; set; }

        // Constructor không tham số
        public NgayNghiTho() { }

        // Constructor có tham số
        public NgayNghiTho(int idTho, int idNgayNghi)
        {
            IDTho = idTho;
            IDNgayNghi = idNgayNghi;
        }

        // Phương thức ToString để hiển thị thông tin (tùy chọn)
        public override string ToString()
        {
            return $"ID Thợ: {IDTho}, ID Ngày Nghỉ: {IDNgayNghi}";
        }
    }
}