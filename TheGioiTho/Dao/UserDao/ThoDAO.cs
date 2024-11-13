using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TheGioiTho.Config;

namespace TheGioiTho.Dao
{
    public class ThoDAO
    {
        public DataTable GetTop3ThoYeuThichNhat()
        {
            return ExecuteQuery("SELECT * FROM GetTop3ThoYeuThichNhat;");
        }

        public DataTable GetTop3ThoSoSaoCaoNhat()
        {
            return ExecuteQuery("SELECT * FROM GetTop3ThoSoSaoCaoNhat;");
        }

        public DataTable GetTop3ThoBiHuyNhieuNhat()
        {
            return ExecuteQuery("SELECT * FROM GetTop3ThoBiHuyNhieuNhat;");
        }

        public DataTable TimKiemThoTheoLinhVuc(string timkiem)
        {
            string query = $"SELECT * FROM TimThoTheoLinhVuc(N'{timkiem}')";
            return ExecuteQuery(query);
        }

        public DataTable XemTatCaBaiDangTho()
        {
            string query = "SELECT * FROM XemTatCaBaiDangTho";
            return ExecuteQuery(query);
        }

        public DataTable XemBaiDangThoTheoID(int id)
        {
            string query = $"SELECT * FROM XemBaiDangThoTheoID({id});";
            return ExecuteQuery(query);
        }

        public void DatLich(int idNguoiDung, int idBaiDang, int idTho, DateTime ngayThoDen, TimeSpan gioThoDen)
        {
            string query = $"EXEC DatLichThoKhiRanh @IDNguoiDung = {idNguoiDung}, @IDBaiDang = {idBaiDang}, @IDTho = {idTho}, " +
                           $"@NgayThoDen = '{ngayThoDen}', @GioThoDen = '{gioThoDen}';";
            ExecuteNonQuery1(query);
        }

        public DataTable XemDanhSachThoYeuThich(int id)
        {
            string query = $"SELECT * FROM XemDanhSachThoYeuThich({id})";
            return ExecuteQuery(query);
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thực thi truy vấn: " + ex.Message);
                }
            }
        }

        private void ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thực hiện lệnh: " + ex.Message);
                }
            }
        }
        private void ExecuteNonQuery1(string query)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    
                    connection.Open();
                    // Để lưu các thông báo PRINT
                    string printMessages = string.Empty;

                    // Đăng ký sự kiện InfoMessage để nhận thông báo từ SQL Server
                    connection.InfoMessage += (sender, e) =>
                    {
                        // Nối tất cả các thông báo lại thành một chuỗi
                        printMessages += e.Message + Environment.NewLine;
                    };
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Kiểm tra và hiển thị thông báo PRINT nếu có
                    if (!string.IsNullOrEmpty(printMessages))
                    {
                        MessageBox.Show(printMessages, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện lệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
