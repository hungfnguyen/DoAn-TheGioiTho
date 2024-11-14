using System;
using System.Data.SqlClient;

namespace TheGioiTho.Config
{
    public static class DBConnection
    {
      
        private static readonly string connectionString = @"Data Source=LAPTOP-DTKDJMOS\SQLEXPRESS;Initial Catalog=DoAn-TheGioiTho;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Phương thức tạo kết nối tới cơ sở dữ liệu
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
