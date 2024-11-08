using System;
using System.Data.SqlClient;
using TheGioiTho.Model;
using TheGioiTho.Config;

namespace TheGioiTho.Dao
{
    public class TaiKhoanNguoiDungDao
    {
        public NguoiDung LayThongTinNguoiDung(int idNguoiDung)
        {
            NguoiDung nguoiDung = null;
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT IDNguoiDung, TaiKhoan, MatKhau, HoTen, SoDienThoai, DiaChi " +  // Thêm dấu cách sau 'DiaChi'
                               "FROM NguoiDung WHERE IDNguoiDung = @IDNguoiDung";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nguoiDung = new NguoiDung
                            {
                                IDNguoiDung = reader.GetInt32(0),
                                TaiKhoan = reader.GetString(1),
                                MatKhau = reader.GetString(2),
                                HoTen = reader.GetString(3),
                                SoDienThoai = reader.GetString(4),
                                DiaChi = reader.GetString(5),
                            };
                        }
                    }
                }
            }

            return nguoiDung;
        }
    }
}
