using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class ImageProcessor
    {
        public Mat Image { get; set; }

        
        private string _basePath = AppDomain.CurrentDomain.BaseDirectory;
        private string _inputImagesFolderPath = @"..\..\..\input_images\";

        public ImageProcessor(string imgName)
        {
            LoadImage(imgName);
        }

        public Mat CropImage()
        {
            ImageCropper cropper = new ImageCropper(Image);
            return cropper.CropGridInImage();
        }

        private void LoadImage(string fileName)
        {
            string FolderPath = Path.Combine(_basePath, _inputImagesFolderPath);
            string FilePath = Path.GetFullPath(Path.Combine(FolderPath, fileName));

            try
            {
                Image = Cv2.ImRead(FilePath);
                Console.WriteLine($"Image with dimensions {Image.Width}x{Image.Height} succesfully loaded.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not load image: " + e.Message);
            }
        }

        private void ShowImage(Mat imageToShow)
        {
            Cv2.ImShow("image", imageToShow);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        private void SaveImage(Mat imageToSave, string imageName)
        {
            string outputPath = Path.Combine(@"..\..\..\output_images\", imageName);
            string PathToSave = Path.GetFullPath(Path.Combine(_basePath, outputPath));

            Cv2.ImWrite(PathToSave, imageToSave);
        }
    }
}
