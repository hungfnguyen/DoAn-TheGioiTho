using System;
using System.Drawing;  // Cho Image, Bitmap
using System.IO;  // Cho Path, File
using System.Windows.Forms;  // Thêm cái này để dùng Application
using System.Drawing.Imaging; // Cho ImageFormat
using System.Drawing.Drawing2D;

namespace TheGioiTho.Controller
{
    public class ImageController
    {
        private static readonly string IMAGE_FOLDER = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
        "Images"
    );

        public ImageController()
        {
            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(IMAGE_FOLDER))
            {
                Directory.CreateDirectory(IMAGE_FOLDER);
                Console.WriteLine($"Đã tạo thư mục Images tại: {IMAGE_FOLDER}");
            }

            // Debug log
            Console.WriteLine($"Đường dẫn thư mục Images: {IMAGE_FOLDER}");
            Console.WriteLine($"Thư mục tồn tại: {Directory.Exists(IMAGE_FOLDER)}");
        }
        private const int MAX_WIDTH = 1024;
        private const int MAX_HEIGHT = 1024;

        // Phương thức lưu ảnh
        public string SaveImage(Image image, string fileName)
        {
            try
            {
                if (image == null || string.IsNullOrEmpty(fileName))
                    throw new ArgumentException("Invalid image or filename");

                using (var resizedImage = ResizeIfNeeded(image))
                {
                    string savePath = Path.Combine(IMAGE_FOLDER, fileName);
                    resizedImage.Save(savePath, ImageFormat.Jpeg);
                    return fileName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save image", ex);
            }
        }

        // Phương thức load ảnh
        public Image LoadImage(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                    return null;

                string imagePath = Path.Combine(IMAGE_FOLDER, fileName);
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"File không tồn tại: {imagePath}");
                    return null;
                }

                // Tạo một bản sao của ảnh để tránh lỗi GDI+
                using (var originalImage = Image.FromFile(imagePath))
                {
                    return new Bitmap(originalImage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load ảnh {fileName}: {ex.Message}");
                return null;
            }
        }

        // Phương thức xóa ảnh
        public bool DeleteImage(string fileName)
        {
            try
            {
                string imagePath = Path.Combine(IMAGE_FOLDER, fileName);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete image", ex);
            }
        }

        // Phương thức resize ảnh
        private Image ResizeIfNeeded(Image image)
        {
            if (image.Width <= MAX_WIDTH && image.Height <= MAX_HEIGHT)
                return new Bitmap(image);

            var ratio = Math.Min(
                (double)MAX_WIDTH / image.Width,
                (double)MAX_HEIGHT / image.Height
            );

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var result = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return result;
        }

        // Phương thức kiểm tra file ảnh hợp lệ
        public bool IsValidImageFile(string filePath)
        {
            try
            {
                using (var img = Image.FromFile(filePath))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Phương thức tạo tên file mới
        public string GenerateFileName(string originalFileName)
        {
            return $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        }

        
    }
}
