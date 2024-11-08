using System;
using System.Windows.Forms;
using TheGioiTho.Dao;
using TheGioiTho.DAO;
using TheGioiTho.Model;

namespace TheGioiTho.Controller
{
    public partial class LiDoHuy : Form
    {
        private readonly LichHenNguoiDungDao lichHenDAO;
        private readonly int idCongViec;
        private readonly int idNguoiDung;
        private readonly int idTho;
        private readonly string nguoiHuy;

        // Constructor nhận các tham số cần thiết
        public LiDoHuy(int idCongViec, int idNguoiDung, int idTho, string nguoiHuy)
        {
            InitializeComponent();
            lichHenDAO = new LichHenNguoiDungDao();
            this.idCongViec = idCongViec;
            this.idNguoiDung = idNguoiDung;
            this.idTho = idTho;
            this.nguoiHuy = nguoiHuy;
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLiDoHuy.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do hủy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var lyDoHuy = new LyDoHuy
                {
                    IDCongViec = this.idCongViec,
                    IDNguoiDung = this.idNguoiDung,
                    IDTho = this.idTho,
                    LyDo = txtLiDoHuy.Text.Trim(),
                    NgayHuy = DateTime.Now,
                    NguoiHuy = this.nguoiHuy
                };

                // Kiểm tra xem lịch hẹn đã bị hủy chưa
                if (lichHenDAO.KiemTraLichHenDaHuy(idCongViec))
                {
                    MessageBox.Show("Lịch hẹn này đã bị hủy trước đó!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lichHenDAO.LuuLyDoHuy(lyDoHuy))
                {
                    MessageBox.Show("Đã hủy lịch hẹn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể hủy lịch hẹn. Vui lòng thử lại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
