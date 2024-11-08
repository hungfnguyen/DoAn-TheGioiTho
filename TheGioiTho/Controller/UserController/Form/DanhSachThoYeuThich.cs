using System;
using System.Windows.Forms;
using TheGioiTho.Dao;
using TheGioiTho.Model;

namespace TheGioiTho
{
    public partial class DanhSachThoYeuThich : Form
    {
        private readonly ThoDAO thoDAO;

        public DanhSachThoYeuThich()
        {
            InitializeComponent();
            thoDAO = new ThoDAO();
        }

        private void DanhSachThoYeuThich_Load(object sender, EventArgs e)
        {
            int id = 1;
            //id = UserSession.UserID;
            XemDanhSachThoYeuThich(id);
        }

        private void XemDanhSachThoYeuThich(int id)
        {
            try
            {
                dataGridView1.DataSource = thoDAO.XemDanhSachThoYeuThich(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Chức năng của button1, nếu cần
        }
    }
}
