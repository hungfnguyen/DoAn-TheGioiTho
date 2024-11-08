using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TheGioiTho.Config;
using TheGioiTho.Model;

namespace TheGioiTho.DAO
{
    public class BaiDangNguoiDungDAO
    {
        public bool ThemBaiDangNguoiDung(BaiDangNguoiDung baiDangNguoiDung, SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"INSERT INTO BaiDangNguoiDung (IDBaiDang, IDNguoiDung, NgayThoDen, GioThoDen) 
                        VALUES (@IDBaiDang, @IDNguoiDung, @NgayThoDen, @GioThoDen)";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@IDBaiDang", baiDangNguoiDung.IDBaiDang);
                cmd.Parameters.AddWithValue("@IDNguoiDung", baiDangNguoiDung.IDNguoiDung);
                cmd.Parameters.AddWithValue("@NgayThoDen", baiDangNguoiDung.NgayThoDen);
                cmd.Parameters.AddWithValue("@GioThoDen", baiDangNguoiDung.GioThoDen);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaBaiDangNguoiDung(int idBaiDang)
        {
            string query = "DELETE FROM BaiDangNguoiDung WHERE IDBaiDang = @IDBaiDang";
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public int ThemBaiDang(BaiDang baiDang, SqlConnection conn, SqlTransaction transaction)
        {
            int newId = 0;
            string query = "EXEC sp_ThemBaiDang @IDLinhVuc, @TieuDe, @MoTa, @HinhAnh, @IDBaiDang OUTPUT";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@IDLinhVuc", baiDang.IDLinhVuc);
                cmd.Parameters.AddWithValue("@TieuDe", baiDang.TieuDe);
                cmd.Parameters.AddWithValue("@MoTa", baiDang.MoTa);
                cmd.Parameters.AddWithValue("@HinhAnh", baiDang.HinhAnh);

                SqlParameter outputParam = new SqlParameter("@IDBaiDang", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();
                newId = (int)outputParam.Value;
            }

            return newId;
        }

        public bool XoaBaiDang(int idBaiDang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_XoaBaiDang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm input parameter
                        cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);

                        // Thêm output parameter để nhận kết quả
                        SqlParameter outputSuccess = new SqlParameter
                        {
                            ParameterName = "@Success",
                            SqlDbType = SqlDbType.Bit,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputSuccess);

                        cmd.ExecuteNonQuery();

                        // Trả về kết quả từ stored procedure
                        return (bool)outputSuccess.Value;
                    }
                }
                catch (SqlException ex)
                {
                    // Log lỗi và/hoặc xử lý exception tùy theo yêu cầu
                    Console.WriteLine($"Lỗi SQL khi xóa bài đăng: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa bài đăng: {ex.Message}");
                    return false;
                }
            }
        }

        public (BaiDang, BaiDangNguoiDung, NguoiDung) GetBaiDangChiTietById(int idBaiDang)
        {
            // Thay đổi tên view
            string query = "SELECT * FROM vw_BaiDangNguoiDungChiTiet WHERE IDBaiDang = @IDBaiDang";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            BaiDang baiDang = new BaiDang
                            {
                                IDBaiDang = reader.GetInt32(reader.GetOrdinal("IDBaiDang")),
                                IDLinhVuc = reader.GetInt32(reader.GetOrdinal("IDLinhVuc")),
                                TieuDe = reader.GetString(reader.GetOrdinal("TieuDe")),
                                MoTa = reader.GetString(reader.GetOrdinal("MoTa")),
                                HinhAnh = reader.GetString(reader.GetOrdinal("HinhAnh"))
                            };

                            BaiDangNguoiDung baiDangNguoiDung = new BaiDangNguoiDung
                            {
                                IDBaiDang = reader.GetInt32(reader.GetOrdinal("IDBaiDang")),
                                IDNguoiDung = reader.GetInt32(reader.GetOrdinal("IDNguoiDung")),
                                NgayThoDen = reader.GetDateTime(reader.GetOrdinal("NgayThoDen")),
                                GioThoDen = reader.GetTimeSpan(reader.GetOrdinal("GioThoDen"))
                            };

                            NguoiDung nguoiDung = new NguoiDung
                            {
                                IDNguoiDung = reader.GetInt32(reader.GetOrdinal("IDNguoiDung")),
                                TaiKhoan = reader.GetString(reader.GetOrdinal("TaiKhoan")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                SoDienThoai = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                DiaChi = reader.GetString(reader.GetOrdinal("DiaChi"))
                            };

                            return (baiDang, baiDangNguoiDung, nguoiDung);
                        }
                    }
                }
            }

            return (null, null, null);
        }

        public List<BaiDang> GetAllBaiDang(int idNguoiDung)  // Thêm tham số idNguoiDung
        {
            List<BaiDang> danhSachBaiDang = new List<BaiDang>();
            string query = @"SELECT * 
                    FROM vw_DanhSachBaiDangNguoiDung 
                    WHERE IDNguoiDung = @IDNguoiDung 
                    ORDER BY IDBaiDang DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDNguoiDung", idNguoiDung);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BaiDang baiDang = new BaiDang
                            {
                                IDBaiDang = reader.GetInt32(reader.GetOrdinal("IDBaiDang")),
                                IDLinhVuc = reader.GetInt32(reader.GetOrdinal("IDLinhVuc")),
                                TieuDe = reader.GetString(reader.GetOrdinal("TieuDe")),
                                MoTa = reader.GetString(reader.GetOrdinal("MoTa")),
                                HinhAnh = reader.GetString(reader.GetOrdinal("HinhAnh"))
                            };
                            danhSachBaiDang.Add(baiDang);
                        }
                    }
                }
            }
            return danhSachBaiDang;
        }

        public string GetTenLinhVuc(int idLinhVuc)
        {
            string query = "SELECT TenLinhVuc FROM LinhVuc WHERE IDLinhVuc = @IDLinhVuc";
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLinhVuc", idLinhVuc);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        public List<LinhVuc> GetDanhSachLinhVuc()
        {
            List<LinhVuc> danhSachLinhVuc = new List<LinhVuc>();
            string query = "SELECT IDLinhVuc, TenLinhVuc FROM LinhVuc";
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachLinhVuc.Add(new LinhVuc
                            {
                                IDLinhVuc = reader.GetInt32(0),
                                TenLinhVuc = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return danhSachLinhVuc;
        }
    }
}
