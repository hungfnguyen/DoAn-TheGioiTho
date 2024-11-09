using System;
using System.Data.SqlClient;

namespace TheGioiTho.Config
{
    public static class DBConnection
    {
      
        private static readonly string connectionString = @"Server=LAPTOP-M10LPRA9\CONGDON;Initial Catalog=databaseMoi;Integrated Security=True;TrustServerCertificate=True";

        // Phương thức tạo kết nối tới cơ sở dữ liệu
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
