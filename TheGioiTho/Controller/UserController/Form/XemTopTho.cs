using System;
using System.Windows.Forms;
using TheGioiTho.Dao;

namespace TheGioiTho
{
    public partial class XemTopTho : Form
    {
        private readonly ThoDAO thoDAO;

        public XemTopTho()
        {
            InitializeComponent();
            thoDAO = new ThoDAO();
        }

        private void XemTopTho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridView3.DataSource = thoDAO.GetTop3ThoYeuThichNhat();
                dataGridView1.DataSource = thoDAO.GetTop3ThoSoSaoCaoNhat();
                dataGridView2.DataSource = thoDAO.GetTop3ThoBiHuyNhieuNhat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
