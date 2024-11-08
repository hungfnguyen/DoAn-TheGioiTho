using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGioiTho.Config;
using TheGioiTho.Model;

namespace TheGioiTho.Dao
{
    public class LichHenDao
    {
        public List<LichHen> GetLichHen(int idNguoiDung, string trangThai)
        {
            List<LichHen> danhSachLichHen = new List<LichHen>();
            string query = @"
        SELECT 
            cv.IDCongViec as IDLichHen,
            lv.TenLinhVuc as LinhVuc,
            nd.HoTen as Ten,
            nd.SoDienThoai as SDT,
            bdn.NgayThoDen as LichHenDen,
            bdn.GioThoDen as Gio,
            bd.MoTa as GhiChu,
            bdt.GiaTien,
            cv.TrangThaiCongViecTho,
            cv.TrangThaiCongViecNguoiDung,
            bdt.IDTho
        FROM CongViec cv
        INNER JOIN BaiDang bd ON cv.IDBaiDang = bd.IDBaiDang
        INNER JOIN BaiDangNguoiDung bdn ON bd.IDBaiDang = bdn.IDBaiDang
        INNER JOIN BaiDangTho bdt ON bd.IDBaiDang = bdt.IDBaiDang
        INNER JOIN LinhVuc lv ON bd.IDLinhVuc = lv.IDLinhVuc
        INNER JOIN NguoiDung nd ON bdn.IDNguoiDung = nd.IDNguoiDung
        WHERE bdn.IDNguoiDung = @IDNguoiDung
        AND (@TrangThai IS NULL OR cv.TrangThaiCongViecNguoiDung = @TrangThai)
        ORDER BY cv.IDCongViec DESC";

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
                            while (reader.Read())
                            {
                                LichHen lichHen = new LichHen
                                {
                                    IDLichHen = reader.GetInt32(reader.GetOrdinal("IDLichHen")),
                                    LinhVuc = reader.GetString(reader.GetOrdinal("LinhVuc")),
                                    Ten = reader.GetString(reader.GetOrdinal("Ten")),
                                    SDT = reader.GetString(reader.GetOrdinal("SDT")),
                                    LichHenDen = reader.GetDateTime(reader.GetOrdinal("LichHenDen")),
                                    Gio = reader.GetTimeSpan(reader.GetOrdinal("Gio")).ToString(@"hh\:mm"),
                                    GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                    GiaTien = reader.GetDecimal(reader.GetOrdinal("GiaTien")),
                                    TrangThaiCongViecTho = reader.GetString(reader.GetOrdinal("TrangThaiCongViecTho")),
                                    TrangThaiCongViecNguoiDung = reader.GetString(reader.GetOrdinal("TrangThaiCongViecNguoiDung")),
                                    IDTho = reader.GetInt32(reader.GetOrdinal("IDTho"))
                                };
                                danhSachLichHen.Add(lichHen);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi
                        throw new Exception($"Lỗi khi lấy danh sách lịch hẹn: {ex.Message}");
                    }
                }
            }
            return danhSachLichHen;
        }

        public bool LuuLyDoHuy(LyDoHuy lyDoHuy)
        {
            string query = @"
    INSERT INTO LyDoHuy (IDCongViec, IDNguoiDung, IDTho, LyDo, NgayHuy, NguoiHuy)
    VALUES (@IDCongViec, @IDNguoiDung, @IDTho, @LyDo, @NgayHuy, @NguoiHuy);

    UPDATE CongViec 
    SET TrangThaiCongViecTho = N'Đã hủy',
        TrangThaiCongViecNguoiDung = N'Đã hủy'
    WHERE IDCongViec = @IDCongViec;";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                cmd.Transaction = transaction;

                                // Thêm parameters
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@IDCongViec", lyDoHuy.IDCongViec);
                                cmd.Parameters.AddWithValue("@IDNguoiDung", lyDoHuy.IDNguoiDung);
                                cmd.Parameters.AddWithValue("@IDTho", lyDoHuy.IDTho);
                                cmd.Parameters.AddWithValue("@LyDo", lyDoHuy.LyDo);
                                cmd.Parameters.AddWithValue("@NgayHuy", lyDoHuy.NgayHuy);
                                cmd.Parameters.AddWithValue("@NguoiHuy", lyDoHuy.NguoiHuy);

                                int result = cmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error
                        Console.WriteLine($"Error in LuuLyDoHuy: {ex.Message}");
                        throw;
                    }
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
                                    IDNguoiDung = reader.GetInt32(1),
                                    IDTho = reader.GetInt32(2),
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
            string query = @"
        INSERT INTO YeuThich (IDNguoiDung, IDTho, IDLichHen) 
        VALUES (@IDNguoiDung, @IDTho, @IDLichHen)";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                cmd.Parameters.AddWithValue("@IDTho", (object)idTho ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IDLichHen", (object)idLichHen ?? DBNull.Value);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
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
