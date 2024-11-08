using System;
using System.Data.SqlClient;

namespace TheGioiTho.Config
{
    public static class DBConnection
    {
      
        private static readonly string connectionString = @"Data Source=LAPTOP-QTEB4KQ5\SQLEXPRESS;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True";

        // Phương thức tạo kết nối tới cơ sở dữ liệu
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
