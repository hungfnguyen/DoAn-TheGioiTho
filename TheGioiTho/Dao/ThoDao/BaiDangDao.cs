    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    namespace TheGioiTho.Controller.Tho.Dao
    {
        public class BaiDangDao
        {
            public DataTable LayDanhSachBaiDang(int idTho)
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = Config.DBConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT BaiDangTho.IDBaiDang, BaiDang.TieuDe, BaiDang.MoTa, LinhVuc.TenLinhVuc, BaiDangTho.GiaTien, BaiDangTho.ThoiGianThucHien, BaiDang.HinhAnh " +
                                       "FROM BaiDangTho " +
                                       "INNER JOIN BaiDang ON BaiDangTho.IDBaiDang = BaiDang.IDBaiDang " +
                                       "INNER JOIN LinhVuc ON LinhVuc.IDLinhVuc = BaiDang.IDLinhVuc " +
                                       "WHERE BaiDangTho.IDTho = @IDTho";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@IDTho", idTho);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải dữ liệu bài đăng: " + ex.Message);
                    }
                }
                return dt;
            }

            public void XoaBaiDang(int idBaiDang)
            {
                using (SqlConnection conn = Config.DBConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM BaiDangTho WHERE IDBaiDang = @IDBaiDang";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa bài đăng: " + ex.Message);
                    }
                }
            }

            public void CapNhatBaiDang(int idBaiDang, string tieuDe, string moTa, string hinhAnh, int idLinhVuc, decimal giaTien, string thoiGianThucHien)
            {
                using (SqlConnection conn = Config.DBConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Cập nhật bảng BaiDang
                            string updateBaiDangQuery =
                                "UPDATE BaiDang SET TieuDe = @TieuDe, MoTa = @MoTa, HinhAnh = @HinhAnh, IDLinhVuc = @IDLinhVuc WHERE IDBaiDang = @IDBaiDang";
                            using (SqlCommand cmd1 = new SqlCommand(updateBaiDangQuery, conn, transaction))
                            {
                                cmd1.Parameters.AddWithValue("@TieuDe", tieuDe);
                                cmd1.Parameters.AddWithValue("@MoTa", moTa);
                                cmd1.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                                cmd1.Parameters.AddWithValue("@IDLinhVuc", idLinhVuc);
                                cmd1.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                                cmd1.ExecuteNonQuery();
                            }

                            // Cập nhật bảng BaiDangTho
                            string updateBaiDangThoQuery =
                                "UPDATE BaiDangTho SET GiaTien = @GiaTien, ThoiGianThucHien = @ThoiGianThucHien WHERE IDBaiDang = @IDBaiDang";
                            using (SqlCommand cmd2 = new SqlCommand(updateBaiDangThoQuery, conn, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@GiaTien", giaTien);
                                cmd2.Parameters.AddWithValue("@ThoiGianThucHien", thoiGianThucHien);
                                cmd2.Parameters.AddWithValue("@IDBaiDang", idBaiDang);
                                cmd2.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi cập nhật bài đăng: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
