using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGioiTho.Model;
using TheGioiTho.Config;
using GUI.All_Calendar_Control;
using System.Windows.Forms;
using System.Data;

namespace TheGioiTho.Dao
{
    public class TaiKhoanDao
    {
        public bool DoiMatKhau(int idTho, string matKhauCu, string matKhauMoi)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DoiMatKhau", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTho", idTho);
                    cmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);
                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Lấy giá trị trả về từ stored procedure

                    // Kiểm tra xem result có phải là null hay không
                    if (result != null)
                    {
                        return (int)result == 1; // Trả về true nếu đổi mật khẩu thành công
                    }
                    else
                    {
                        return false; // Không có giá trị trả về
                    }
                }
            }
        }




        public bool CapNhatTho(Tho tho)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CapNhatTho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTho", tho.IDTho);
                    cmd.Parameters.AddWithValue("@TaiKhoan", tho.TaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", tho.MatKhau);
                    cmd.Parameters.AddWithValue("@HoTen", tho.HoTen);
                    cmd.Parameters.AddWithValue("@SoDienThoai", tho.SoDienThoai);
                    cmd.Parameters.AddWithValue("@GioiTinh", tho.GioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", tho.DiaChi);
                    cmd.Parameters.AddWithValue("@SoNamKinhNghiem", tho.SoNamKinhNghiem);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0; // Trả về true nếu có dòng được cập nhật
                }
            }
        }


        // Phương thức lấy thông tin thợ qua IDTho
        public Tho LayThongTinTho(int idTho)
        {
            Tho tho = null;
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_LayThongTinTho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTho", idTho);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tho = new Tho
                            {
                                IDTho = reader.GetInt32(0),
                                TaiKhoan = reader.GetString(1),
                                MatKhau = reader.GetString(2),
                                HoTen = reader.GetString(3),
                                SoDienThoai = reader.GetString(4),
                                GioiTinh = reader.GetString(5),
                                DiaChi = reader.GetString(6),
                                SoNamKinhNghiem = reader.GetInt32(7)
                            };
                        }
                    }
                }
            }

            return tho;
        }


        

        public void UpdateOffDaysToDatabase(int idTho, FlowLayoutPanel panel, int year, int month)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Xóa các ngày nghỉ hiện tại trong tháng
                    string deleteAllQuery = "DELETE FROM NgayNghi WHERE IDTho = @IDTho AND YEAR(Ngay) = @Year AND MONTH(Ngay) = @Month";
                    SqlCommand deleteAllCommand = new SqlCommand(deleteAllQuery, connection);
                    deleteAllCommand.Parameters.AddWithValue("@IDTho", idTho);
                    deleteAllCommand.Parameters.AddWithValue("@Year", year);
                    deleteAllCommand.Parameters.AddWithValue("@Month", month);
                    deleteAllCommand.ExecuteNonQuery();

                    // Thêm các ngày nghỉ
                    foreach (UC_Day dayControl in panel.Controls.OfType<UC_Day>().Where(uc => uc.IsOffDay))
                    {
                        DateTime offDay = new DateTime(year, month, int.Parse(dayControl.DayText));
                        string insertQuery = "INSERT INTO NgayNghi (IDTho, Ngay) VALUES (@IDTho, @Ngay)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@IDTho", idTho);
                        insertCommand.Parameters.AddWithValue("@Ngay", offDay);
                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật lịch nghỉ thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật lịch nghỉ: " + ex.Message);
                }
            }
        }
        public List<DateTime> GetOffDaysByMonth(int idTho, int month, int year)
        {
            List<DateTime> offDays = new List<DateTime>();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Ngay FROM vw_OffDaysByMonth WHERE IDTho = @IDTho AND Month = @Month AND Year = @Year";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IDTho", idTho);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        offDays.Add(reader.GetDateTime(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách ngày nghỉ: " + ex.Message);
                }
            }

            return offDays;
        }

    }

}
