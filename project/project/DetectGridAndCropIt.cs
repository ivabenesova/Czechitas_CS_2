using OpenCvSharp;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Point = OpenCvSharp.Point;

namespace project
{
    internal class DetectGridAndCropIt
    {
        private Mat _image;

        public string FilePath { get; set; }
        public Mat Image { get; set; }

        private string _basePath = AppDomain.CurrentDomain.BaseDirectory;

        public List<Point2f> SquareCorners = new List<Point2f>();

        public DetectGridAndCropIt(string filePath)
        {
            FilePath = Path.GetFullPath(Path.Combine(_basePath, filePath));
            Console.WriteLine(FilePath);
            try
            {
                Image = Cv2.ImRead(FilePath);
                Console.WriteLine($"Image with dimensions {Image.Width}x{Image.Height} succesfully loaded.");
                ;
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not load image: " + e.Message);
            }

            
        }


        //add some info/razeni:
        //1. levy horni,
        //2. pravy horni,
        //3. pravy dolni
        //4. levy dolni
        public void UserAddsCornersOfGridAndCoordinatesAreSavedIntoList()
        {
            Cv2.NamedWindow("Image");
            Cv2.SetMouseCallback("Image", OnMouse); // adjust size on screen
            while (true)
            {
                Mat tempImage = Image.Clone();

                // Vykreslení bodů na obrázku
                foreach (var point2f in SquareCorners)
                {
                    Point pointInt = new Point((int)point2f.X, (int)point2f.Y);
                    Cv2.Circle(tempImage, pointInt, 5, new Scalar(0, 0, 255), 2);
                }

                Cv2.ImShow("Image", tempImage);
                int key = Cv2.WaitKey(20);
                if (key == 27 || SquareCorners.Count == 4)// Esc ends program
                {
                    break;
                }
            }

            Cv2.DestroyAllWindows();

            TransformAndCrop();

        }

        private void OnMouse(MouseEventTypes mouseEvent, int x, int y, MouseEventFlags flags, IntPtr userdata)
        {
            if (mouseEvent == MouseEventTypes.LButtonDown)
            {
                SquareCorners.Add(new Point2f(x, y));
                Console.WriteLine($"Point added: ({x}, {y})");
            }
        }

        //private void SortSquareCornersClockWise()
        //{
        //    Point upperRight;
        //    Point upperLeft;
        //    Point lowerLeft;
        //    Point lowerRight;

        //    // to do
        //}

        private void TransformAndCrop()
        {

            Point2f[] pointsFromOriginalPic = SquareCorners.ToArray();

            Point2f[] TargetPoints = new Point2f[]
            {
                new Point2f(0, 0),       // levý horní
                new Point2f(300, 0),     // pravý horní
                new Point2f(300, 300),   // pravý dolní
                new Point2f(0, 300)      // levý dolní
            };

            // Výpočet transformační matice
            Mat perspectiveMatrix = Cv2.GetPerspectiveTransform(pointsFromOriginalPic, TargetPoints);

            // Aplikace perspektivní transformace
            Mat transformedImage = new Mat();
            Cv2.WarpPerspective(Image, transformedImage, perspectiveMatrix, new Size(300, 300));

            // Uložení upraveného obrázku
            Cv2.ImShow("transf", transformedImage );
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            SaveImage(transformedImage, "result2.jpg");



        }


        private void SaveImage(Mat imageToSave, string imageName)
        {

            string outputPath = Path.Combine(@"..\..\..\output_images\", imageName);
            string PathToSave = Path.GetFullPath(Path.Combine(_basePath, outputPath));

            Cv2.ImWrite(PathToSave, imageToSave);
        }




    }



}
