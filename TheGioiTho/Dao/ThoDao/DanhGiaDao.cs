using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using TheGioiTho.Model;
using TheGioiTho.Config;
using System.Data;

namespace TheGioiTho.DAO
{
    public class DanhGiaDAO
    {
        // Thêm đánh giá mới
        public bool ThemDanhGia(DanhGia danhGia)
        {
            string query = @"
                INSERT INTO DanhGia (IDNguoiDung, IDCongViec, SoSao, NhanXet, HinhAnh)
                VALUES (@IDNguoiDung, @IDCongViec, @SoSao, @NhanXet, @HinhAnh)";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@IDNguoiDung", danhGia.IDNguoiDung);
                        cmd.Parameters.AddWithValue("@IDCongViec", danhGia.IDLichHen);
                        cmd.Parameters.AddWithValue("@SoSao", danhGia.SoSao);
                        cmd.Parameters.AddWithValue("@NhanXet",
                            (object)danhGia.NhanXet ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@HinhAnh",
                            (object)danhGia.HinhAnh ?? DBNull.Value);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in ThemDanhGia: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        // Lấy đánh giá theo IDCongViec
        public DanhGia GetDanhGiaByIDCongViec(int idCongViec)
        {
            string query = @"
                SELECT dg.*, nd.HoTen as TenNguoiDung
                FROM DanhGia dg
                JOIN NguoiDung nd ON dg.IDNguoiDung = nd.IDNguoiDung
                WHERE dg.IDCongViec = @IDCongViec";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDCongViec", idCongViec);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DanhGia
                                {
                                    IDNguoiDung = reader.GetInt32(reader.GetOrdinal("IDNguoiDung")),
                                    IDLichHen = idCongViec,
                                    SoSao = reader.GetInt32(reader.GetOrdinal("SoSao")),
                                    NhanXet = reader.IsDBNull(reader.GetOrdinal("NhanXet")) ?
                                        null : reader.GetString(reader.GetOrdinal("NhanXet")),
                                    HinhAnh = reader.IsDBNull(reader.GetOrdinal("HinhAnh")) ?
                                        null : reader.GetString(reader.GetOrdinal("HinhAnh"))
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in GetDanhGiaByIDCongViec: {ex.Message}");
                        throw;
                    }
                }
            }
            return null;
        }

        // Lấy danh sách đánh giá của một thợ và trả về kiểu DataTable
        public DataTable GetDanhGiaByIDTho(int idTho)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDanhGiaByIDTho", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTho", idTho);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Tự động tạo cột trong DataTable dựa trên dữ liệu từ SqlDataReader
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }


    }
}