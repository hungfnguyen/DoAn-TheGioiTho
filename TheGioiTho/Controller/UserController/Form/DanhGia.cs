using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using TheGioiTho.DAO;
using TheGioiTho.Model;

namespace TheGioiTho.Controller
{
    public partial class DanhGia : Form
    {
        private readonly DanhGiaDAO danhGiaDAO;
        private readonly int idNguoiDung;
        private readonly int idCongViec;
        private List<string> imagePaths;  // Danh sách đường dẫn ảnh
        private const int MAX_IMAGES = 5;  // Số lượng ảnh tối đa
        private static readonly string IMAGE_FOLDER = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        public DanhGia(int idNguoiDung, int idCongViec)
        {
            InitializeComponent();
            this.danhGiaDAO = new DanhGiaDAO();
            this.idNguoiDung = idNguoiDung;
            this.idCongViec = idCongViec;
            this.imagePaths = new List<string>();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            // Thêm các lựa chọn số sao vào ComboBox
            cbSoSao.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                cbSoSao.Items.Add($"{i} ★");
            }
            cbSoSao.SelectedIndex = 4; // Mặc định chọn 5 sao
        }

        private void ComboBoxDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSoSao.SelectedItem != null)
            {
                string selectedText = cbSoSao.SelectedItem.ToString();
                int soSao = int.Parse(selectedText.Split(' ')[0]);
                lblSao.Text = new string('★', soSao) + new string('☆', 5 - soSao);
            }
        }
        // ... Các phương thức khác giữ nguyên ...

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (imagePaths.Count >= MAX_IMAGES)
            {
                MessageBox.Show($"Chỉ được thêm tối đa {MAX_IMAGES} ảnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string sourceFile in openFileDialog.FileNames)
                    {
                        if (imagePaths.Count >= MAX_IMAGES) break;

                        try
                        {
                            // Lấy tên file gốc
                            string fileName = Path.GetFileName(sourceFile);
                            string destFile = Path.Combine(IMAGE_FOLDER, fileName);

                            // Đảm bảo thư mục tồn tại
                            if (!Directory.Exists(IMAGE_FOLDER))
                            {
                                Directory.CreateDirectory(IMAGE_FOLDER);
                            }

                            // Kiểm tra nếu file đích đã tồn tại, thì thay thế hoặc xử lý theo cách bạn muốn
                            if (File.Exists(destFile))
                            {
                                // Có thể thêm logic để thay đổi tên nếu file đã tồn tại, ví dụ:
                                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                                string extension = Path.GetExtension(fileName);
                                int count = 1;

                                // Tạo tên mới nếu file đã tồn tại
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(IMAGE_FOLDER, $"{fileNameWithoutExtension}_{count}{extension}");
                                    count++;
                                }
                            }

                            // Copy file ảnh
                            File.Copy(sourceFile, destFile, true);

                            // Lưu đường dẫn đầy đủ vào imagePaths
                            imagePaths.Add(destFile); // Lưu đường dẫn đầy đủ, không chỉ tên file

                            // Thêm ảnh vào FlowLayoutPanel
                            AddImageToPanel(destFile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi thêm ảnh: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void AddImageToPanel(string imagePath)
        {
            string fullPath = Path.Combine(IMAGE_FOLDER, imagePath); // Đường dẫn đầy đủ của ảnh

            Panel imageContainer = new Panel
            {
                Width = 150,
                Height = 150,
                Margin = new Padding(5),
                BackColor = Color.White
            };
            PictureBox pictureBox = new PictureBox
            {
                Width = 140,
                Height = 120,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(fullPath), // Sử dụng đường dẫn đầy đủ
                Tag = imagePath, // Lưu lại tên file trong Tag
                Location = new Point(5, 5)
            };
            Button btnDelete = new Button
            {
                Text = "X",
                Width = 25,
                Height = 25,
                BackColor = Color.Red,
                ForeColor = Color.White,
                Location = new Point(pictureBox.Width - 25, 0),
                Tag = imagePath, // Lưu lại tên file trong Tag
                Parent = pictureBox
            };
            btnDelete.Click += (sender, e) =>
            {
                Button btn = sender as Button;
                string fileName = btn.Tag.ToString();
                string fullPathToDelete = Path.Combine(IMAGE_FOLDER, fileName);
                imagePaths.Remove(fileName);
                flpHinhAnh.Controls.Remove(imageContainer);
                // Giải phóng tài nguyên
                pictureBox.Image.Dispose();
                if (File.Exists(fullPathToDelete))
                {
                    try { File.Delete(fullPathToDelete); }
                    catch { /* Xử lý nếu không xóa được file */ }
                }
            };
            imageContainer.Controls.Add(pictureBox);
            flpHinhAnh.Controls.Add(imageContainer);
        }


        private void btnGui_Click(object sender, EventArgs e)
        {
            if (cbSoSao.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn số sao đánh giá!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        


            try
            {
                string selectedText = cbSoSao.SelectedItem.ToString();
                int soSao = int.Parse(selectedText.Split(' ')[0]);

                // Chuyển danh sách ảnh thành chuỗi, phân cách bằng dấu ;
                string hinhAnh = string.Join(";", imagePaths);

                var danhGia = new TheGioiTho.Model.DanhGia
                {
                    IDNguoiDung = this.idNguoiDung,
                    IDLichHen = this.idCongViec,
                    SoSao = soSao,
                    NhanXet = txtNhanXet.Text.Trim(),
                    HinhAnh = hinhAnh
                };

                if (danhGiaDAO.ThemDanhGia(danhGia))
                {
                    MessageBox.Show("Đánh giá thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi gửi đánh giá!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Giải phóng tài nguyên của tất cả các PictureBox
            foreach (Control container in flpHinhAnh.Controls)
            {
                foreach (Control control in container.Controls)
                {
                    if (control is PictureBox pictureBox)
                    {
                        if (pictureBox.Image != null)
                        {
                            pictureBox.Image.Dispose();
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}