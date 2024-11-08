using System;
using System.Data;
using System.Windows.Forms;
using TheGioiTho.Dao;
using TheGioiTho.DAO;

namespace TheGioiTho
{
    public partial class XemDanhGia : Form
    {
        public int id { get; set; }
        private readonly DanhGiaNguoiDungDao  danhGiaDao;

        public XemDanhGia()
        {
            InitializeComponent();
            danhGiaDao = new DanhGiaNguoiDungDao();
        }

        private void XemDanhGiaTheoTho(int id)
        {
            try
            {
                DataTable dataTable = danhGiaDao.GetDanhGiaTheoTho(id);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void XemDanhGia_Load(object sender, EventArgs e)
        {
            XemDanhGiaTheoTho(id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi người dùng click vào ô trong DataGridView (nếu cần)
        }
    }
}
