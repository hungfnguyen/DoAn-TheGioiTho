using System;
using System.Data.SqlClient;

namespace TheGioiTho.Config
{
    public static class DBConnection
    {
      
        private static readonly string connectionString = @"Data Source=LAPTOP-7H9D7KEU\CSDL_SQLSEVER;Initial Catalog=databaseMoi;Integrated Security=True;Encrypt=False";

        // Phương thức tạo kết nối tới cơ sở dữ liệu
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
