using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGioiTho.Dao;
using System.Windows.Forms.DataVisualization.Charting;
using TheGioiTho.DAO;


namespace TheGioiTho.Controller.Tho
{
    public partial class UC_ThongKe : UserControl
    {
        private ThongKeDao danhGiaDAO;
        private int reviewCount = 0;
        public UC_ThongKe()
        {
            InitializeComponent();
            danhGiaDAO = new ThongKeDao(); // Khởi tạo đối tượng DanhGiaDAO
            this.Load += new EventHandler(UC_XemDanhGia_Load);
            
            
        }
        private void CreateChartDuong(Dictionary<string, decimal> data)
        {
            pnThongKe.Controls.Clear();

            // Create a line chart
            Chart chartLine = new Chart();
            chartLine.Size = new Size(pnThongKe.Width, pnThongKe.Height); // Increase chart size for better visibility
            chartLine.BackColor = Color.WhiteSmoke; // Set background color

            // Create chart area and configure its properties
            ChartArea chartAreaLine = new ChartArea();
            chartLine.ChartAreas.Add(chartAreaLine);
            chartAreaLine.BackColor = Color.White;
            chartAreaLine.AxisX.MajorGrid.LineColor = Color.LightGray; // Adjust grid line color
            chartAreaLine.AxisX.LineColor = Color.Black; // Adjust axis line color
            chartAreaLine.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartAreaLine.AxisY.LineColor = Color.Black;
            chartAreaLine.AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            chartAreaLine.AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            chartAreaLine.AxisY.Title = "Doanh Thu";
            chartAreaLine.AxisX.Interval = 1; // Ensure labels are displayed for each data point

            // Create series for the line chart and configure its properties
            Series seriesLine = new Series();
            seriesLine.ChartType = SeriesChartType.Line;
            seriesLine.Color = Color.FromArgb(52, 152, 219); // Set line color
            seriesLine.BorderWidth = 2; // Increase line thickness for better visibility

            // Loop through the data and add points to the series
            foreach (var item in data)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(item.Key, item.Value);
                point.Label = String.Format("{0:N0} $", item.Value);
                point.LabelForeColor = Color.Black;
                point.Font = new Font("Arial", 10, FontStyle.Regular);
                seriesLine.Points.Add(point);
            }

            chartLine.Series.Add(seriesLine);

            // Customize title color
            chartLine.Titles.Add("Biểu đồ thống kê doanh thu các tháng gần đây");
            chartLine.Titles[0].ForeColor = Color.FromArgb(44, 62, 80); // Set title color
            chartLine.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold); // Increase title font size

            // Add the chart to the panel
            pnThongKe.Controls.Add(chartLine);
        }
        private void CreateChartSao(int IDTho)
        {
            // Xóa biểu đồ cũ (nếu có)
            pnlThongKe.Controls.Clear();

            // Tạo biểu đồ cột
            Chart chartColumn = new Chart
            {
                Dock = DockStyle.Fill, // Tự động phóng to/thu nhỏ theo kích thước panel
                BackColor = Color.Transparent // Màu nền của biểu đồ
            };

            // Thêm tiêu đề cho biểu đồ và tùy chỉnh cỡ chữ
            Title chartTitle = new Title
            {
                Text = "Thống kê số sao của thợ",  // Tiêu đề của biểu đồ
                Font = new Font("Arial", 14, FontStyle.Bold),  // Đặt cỡ chữ lớn hơn và in đậm
                ForeColor = Color.White // Màu của chữ tiêu đề
            };
            chartColumn.Titles.Add(chartTitle);

            // Tạo khu vực biểu đồ và cấu hình các thuộc tính
            ChartArea chartAreaColumn = new ChartArea
            {
                BackColor = Color.FromArgb(240, 240, 240) // Màu nền nhẹ nhàng cho khu vực biểu đồ
            };

            // Thêm tiêu đề cho trục X và trục Y
            chartAreaColumn.AxisX.Title = "Số sao";
            chartAreaColumn.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Regular);
            chartAreaColumn.AxisX.LabelStyle.ForeColor = Color.Black;
            chartAreaColumn.AxisX.LineColor = Color.Gray; // Màu của trục X

            chartAreaColumn.AxisY.Title = "Số lượng";
            chartAreaColumn.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Regular);
            chartAreaColumn.AxisY.LabelStyle.ForeColor = Color.Black;
            chartAreaColumn.AxisY.LineColor = Color.Gray; // Màu của trục Y

            // Tùy chỉnh lưới
            chartAreaColumn.AxisX.MajorGrid.LineColor = Color.LightGray; // Lưới trục X
            chartAreaColumn.AxisY.MajorGrid.LineColor = Color.LightGray; // Lưới trục Y

            chartColumn.ChartAreas.Add(chartAreaColumn);

            // Tạo loạt dữ liệu cho biểu đồ cột
            Series seriesColumn = new Series
            {
                Name = "Số sao",
                IsValueShownAsLabel = true, // Hiển thị giá trị trên các cột
                ChartType = SeriesChartType.Column,
                BorderWidth = 1,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Thêm dữ liệu và tùy chỉnh màu cho mỗi số sao
            for (int i = 1; i <= 5; i++)
            {
                int soLuong = danhGiaDAO.DemSoSao(IDTho, i);
                DataPoint point = new DataPoint(i, soLuong);

                // Tùy chỉnh màu cho từng cột tương ứng với số sao
                switch (i)
                {
                    case 5:
                        point.Color = Color.Gold; // Màu vàng đậm cho 5 sao
                        break;
                    case 4:
                        point.Color = Color.FromArgb(255, 223, 0); // Màu vàng nhạt hơn cho 4 sao
                        break;
                    case 3:
                        point.Color = Color.FromArgb(255, 204, 0); // Màu trung bình cho 3 sao
                        break;
                    case 2:
                        point.Color = Color.FromArgb(255, 183, 0); // Màu nhạt cho 2 sao
                        break;
                    case 1:
                        point.Color = Color.FromArgb(255, 160, 0); // Màu rất nhạt hoặc cam cho 1 sao
                        break;
                }

                seriesColumn.Points.Add(point);
            }

            chartColumn.Series.Add(seriesColumn);

            // Thêm biểu đồ cột vào panel
            pnlThongKe.Controls.Add(chartColumn); // Thêm vào panel
        }


        // Tùy chỉnh các thuộc tính của trục
        private void CustomizeAxis(ChartArea chartArea)
        {
            chartArea.AxisX.MajorGrid.Enabled = false; // Tắt lưới trên trục X
            chartArea.AxisY.MajorGrid.Enabled = false; // Tắt lưới trên trục Y
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Font chữ và kích thước của nhãn trục X
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Font chữ và kích thước của nhãn trục Y
        }

        // Tạo và cấu hình series dữ liệu cho biểu đồ
        private Series CreateSeries()
        {
            Series series = new Series
            {
                ChartType = SeriesChartType.Bar, // Sử dụng biểu đồ cột ngang
                Color = Color.Yellow // Màu của cột
            };

            return series;
        }

        // Tùy chỉnh hình dạng đầu cột
        private void CustomizeDataPoints(Series series)
        {
            foreach (DataPoint point in series.Points)
            {
                point.MarkerStyle = MarkerStyle.Circle; // Đặt hình dạng đầu cột thành hình tròn
                point.MarkerSize = 25; // Đặt kích thước của đầu cột
            }
        }
        private void LoadData(int IDTho)
        {
            ThongKeDao thongKeDao = new ThongKeDao();
            Dictionary<string, decimal> doanhThuTheoThang = danhGiaDAO.LayDoanhThuCacThangGanDay(3, IDTho);

            CreateChartDuong(doanhThuTheoThang);
            DataTable dt = thongKeDao.LayDanhSachCongViecDaHoanThanh(IDTho);
            dgvDoanhThu.DataSource = dt;
        }
        private void UC_XemDanhGia_Load(object sender, EventArgs e)
        {
            int IDTho = 2;  // Thay ID tho thực tế
            LoadData(IDTho);

            // Tính điểm trung bình và hiển thị lên lblSaotb
            decimal diemTrungBinh = danhGiaDAO.TinhDiemTrungBinh(IDTho);
            lblSaotb.Text = $"Số sao trung bình: {diemTrungBinh:F1}"; // Hiển thị với 2 chữ số thập phân

            // Hiển thị số lượng đánh giá
            lblSoDanhGia.Text = reviewCount.ToString() + " bài đánh giá";

            // Gán giá trị cho rtSoSaoTB với kiểu float
            rtSosaotb.Value = Convert.ToSingle(diemTrungBinh);
            // Lấy số lượng bài đánh giá
            reviewCount = danhGiaDAO.DemSoLuongDanhGia(IDTho);

            // Hiển thị số lượng đánh giá
            lblSoDanhGia.Text = reviewCount.ToString() + " bài đánh giá";

            // Tạo biểu đồ thống kê số sao
            CreateChartSao(IDTho);
           

        }

    }
}

