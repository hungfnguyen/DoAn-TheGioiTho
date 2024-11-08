using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGioiTho.Config;
using TheGioiTho.Model;

namespace TheGioiTho.Dao
{
    public class LichHenNguoiDungDao
    {
        public List<LichHen> GetLichHen(int idNguoiDung, string trangThai)
        {
            List<LichHen> danhSachLichHen = new List<LichHen>();
            string query = @"
        SELECT *
        FROM View_DanhSachLichHen
        WHERE IDNguoiDung = @IDNguoiDung
        AND (@TrangThai IS NULL OR TrangThaiCongViecNguoiDung = @TrangThai)
        ORDER BY IDLichHen DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                        cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(trangThai) ? DBNull.Value : (object)trangThai);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Thêm vòng lặp while để đọc từng dòng dữ liệu
                            while (reader.Read())
                            {
                                LichHen lichHen = new LichHen
                                {
                                    IDLichHen = reader.GetInt32(reader.GetOrdinal("IDLichHen")),
                                    LinhVuc = !reader.IsDBNull(reader.GetOrdinal("LinhVuc")) ? reader.GetString(reader.GetOrdinal("LinhVuc")) : string.Empty,
                                    Ten = !reader.IsDBNull(reader.GetOrdinal("Ten")) ? reader.GetString(reader.GetOrdinal("Ten")) : string.Empty,
                                    SDT = !reader.IsDBNull(reader.GetOrdinal("SDT")) ? reader.GetString(reader.GetOrdinal("SDT")) : string.Empty,
                                    // Thêm kiểm tra NULL cho LichHenDen
                                    LichHenDen = !reader.IsDBNull(reader.GetOrdinal("LichHenDen")) ? reader.GetDateTime(reader.GetOrdinal("LichHenDen")) : DateTime.MinValue, // hoặc giá trị mặc định khác
                                    Gio = !reader.IsDBNull(reader.GetOrdinal("Gio")) ? reader.GetTimeSpan(reader.GetOrdinal("Gio")).ToString(@"hh\:mm") : "",
                                    GhiChu = !reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? reader.GetString(reader.GetOrdinal("GhiChu")) : string.Empty,
                                    TrangThaiCongViecTho = !reader.IsDBNull(reader.GetOrdinal("TrangThaiCongViecTho")) ? reader.GetString(reader.GetOrdinal("TrangThaiCongViecTho")) : string.Empty,
                                    TrangThaiCongViecNguoiDung = !reader.IsDBNull(reader.GetOrdinal("TrangThaiCongViecNguoiDung")) ? reader.GetString(reader.GetOrdinal("TrangThaiCongViecNguoiDung")) : string.Empty,
                                    GiaTien = !reader.IsDBNull(reader.GetOrdinal("GiaTien")) ? reader.GetDecimal(reader.GetOrdinal("GiaTien")) : 0m,
                                    IDTho = !reader.IsDBNull(reader.GetOrdinal("IDTho")) ? reader.GetInt32(reader.GetOrdinal("IDTho")) : 0
                                };

                                // Thêm đối tượng lichHen vào danh sách
                                danhSachLichHen.Add(lichHen);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi khi lấy danh sách lịch hẹn: {ex.Message}\nStack Trace: {ex.StackTrace}");
                    }
                }
            }
            return danhSachLichHen;
        }

        public bool LuuLyDoHuy(LyDoHuy lyDoHuy)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LuuLyDoHuy", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        cmd.Parameters.AddWithValue("@IDCongViec", lyDoHuy.IDCongViec);
                        cmd.Parameters.AddWithValue("@IDNguoiDung", lyDoHuy.IDNguoiDung);
                        cmd.Parameters.AddWithValue("@IDTho", lyDoHuy.IDTho);
                        cmd.Parameters.AddWithValue("@LyDo", lyDoHuy.LyDo);
                        cmd.Parameters.AddWithValue("@NgayHuy", lyDoHuy.NgayHuy);
                        cmd.Parameters.AddWithValue("@NguoiHuy", lyDoHuy.NguoiHuy);

                        // Add output parameter
                        SqlParameter successParam = new SqlParameter
                        {
                            ParameterName = "@Success",
                            SqlDbType = SqlDbType.Bit,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(successParam);

                        cmd.ExecuteNonQuery();
                        return (bool)successParam.Value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in LuuLyDoHuy: {ex.Message}");
                    throw;
                }
            }
        }

        public bool KiemTraLichHenDaHuy(int idCongViec)
        {
            string query = "SELECT COUNT(*) FROM LyDoHuy WHERE IDCongViec = @IDCongViec";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@IDCongViec", idCongViec);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in KiemTraLichHenDaHuy: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public LyDoHuy GetLyDoHuy(int idCongViec)
        {
            LyDoHuy lyDoHuy = null;
            string query = @"SELECT IDCongViec, IDNguoiDung, IDTho, LyDo, NgayHuy, NguoiHuy 
            FROM LyDoHuy 
            WHERE IDCongViec = @IDCongViec";
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDCongViec", idCongViec);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lyDoHuy = new LyDoHuy
                                {
                                    IDCongViec = reader.GetInt32(0),
                                    IDNguoiDung = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1),  // Kiểm tra NULL
                                    IDTho = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2),        // Kiểm tra NULL
                                    LyDo = reader.GetString(3),
                                    NgayHuy = reader.GetDateTime(4),
                                    NguoiHuy = reader.GetString(5)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lý do hủy: " + ex.Message);
            }
            return lyDoHuy;
        }

        public bool ThemYeuThich(int idNguoiDung, int? idLichHen = null, int? idTho = null)
        {
            const string storedProcedure = "ThemYeuThich";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                cmd.Parameters.AddWithValue("@IDTho", (object)idTho ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IDLichHen", (object)idLichHen ?? DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;  // Nếu không có exception, coi như thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi thêm yêu thích: {ex.Message}");
                    return false; // Trả về false khi có lỗi
                }
            }
        }



        public bool DaYeuThich(int idNguoiDung, int idLichHen)
        {
            string query = @"
        SELECT COUNT(*) FROM YeuThich 
        WHERE IDNguoiDung = @IDNguoiDung AND IDLichHen = @IDLichHen";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                cmd.Parameters.AddWithValue("@IDLichHen", idLichHen);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Nếu tồn tại bản ghi, trả về true
            }
        }

        public bool XoaYeuThich(int idNguoiDung, int idLichHen)
        {
            string query = "DELETE FROM YeuThich WHERE IDNguoiDung = @IDNguoiDung AND IDLichHen = @IDLichHen";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                        cmd.Parameters.AddWithValue("@IDLichHen", idLichHen);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in XoaYeuThich: {ex.Message}");
                        throw;
                    }
                }
            }
        }

    }
}
