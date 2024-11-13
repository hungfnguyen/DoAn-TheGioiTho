using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.Config;
using TheGioiTho.Dao;
using TheGioiTho.Model;

namespace TheGioiTho
{
    public partial class TimKiemTho : Form
    {
        private readonly ThoDAO thoDAO;
        private DataGridViewRow selectedRow;
        private int idNguoiDung;
        public TimKiemTho(int idNguoiDung)
        {
            InitializeComponent();
            thoDAO = new ThoDAO();
            this.idNguoiDung = idNguoiDung;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = txtTimKiem.Text;
           // MessageBox.Show(text);
            if (string.IsNullOrEmpty(text))
                XemTatCaBaiDangTho();
            else
                TimKiemThoTheoLinhVuc(text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XemTatCaBaiDangTho();
        }
        private void TimKiemThoTheoLinhVuc(string timkiem)
        {
            try
            {
                dataGridViewTimKiem.DataSource = thoDAO.TimKiemThoTheoLinhVuc(timkiem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void XemTatCaBaiDangTho()
        {
            try
            {
                dataGridViewTimKiem.DataSource = thoDAO.XemTatCaBaiDangTho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XemTopTho xemTopTho = new XemTopTho();
            xemTopTho.Show();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DanhSachThoYeuThich danhSachThoYeuThich = new DanhSachThoYeuThich();
            danhSachThoYeuThich.Show();
        }

        

        private void dataGridViewTimKiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTimKiem.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                selectedRow = dataGridViewTimKiem.Rows[e.RowIndex];
                int id = Convert.ToInt32(selectedRow.Cells[1].Value);
                XemBaiDangThoTheoID(id);
            }
        }

        private void XemBaiDangThoTheoID(int id)
        {
            try
            {
                DataTable dataTable = thoDAO.XemBaiDangThoTheoID(id);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    textBox1.Text = row["TieuDe"].ToString();
                    textBox2.Text = row["MoTa"].ToString();
                    textBox3.Text = row["HinhAnh"].ToString();
                    textBox4.Text = row["TenLinhVuc"].ToString();
                    textBox5.Text = row["HoTen"].ToString();
                    textBox6.Text = row["GiaTien"].ToString();
                    textBox7.Text = row["ThoiGianThucHien"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            XemDanhGia xemDanhGia = new XemDanhGia();
            int id = Convert.ToInt32(selectedRow.Cells[2].Value);
            xemDanhGia.id = id;
            xemDanhGia.Show();
        }
        private void DatLich(int idNguoiDung, int idBaiDang, int idTho, DateTime ngayThoDen, TimeSpan gioThoDen)
        {
            try
            {
                thoDAO.DatLich(idNguoiDung, idBaiDang, idTho, ngayThoDen, gioThoDen);
                MessageBox.Show("Đặt Lịch Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime ngay = dateTimePicker1.Value.Date;
            TimeSpan gio = dateTimePicker2.Value.TimeOfDay;

            int idTho = Convert.ToInt32(selectedRow.Cells[1].Value);
            int idBaiDang = Convert.ToInt32(selectedRow.Cells[2].Value);
            DatLich(idNguoiDung, idBaiDang, idTho, ngay, gio);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
