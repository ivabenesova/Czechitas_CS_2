using OpenCvSharp;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Point = OpenCvSharp.Point;

namespace project
{
    internal class ImageCropper 
    {
        private Mat _image;

        public Mat Image { get; set; }

        public ImageCropper(Mat imgToProcess)
        {
            Image = imgToProcess;
        }
        List<Point2f> SquareCorners = new List<Point2f>();


        public Mat CropGridInImage()
        {
            ResizeImage();
            LetUserToAddCornersOfGridAndSaveCoordinatesIntoList();
            return TransformAndCrop();
        }


        public void LetUserToAddCornersOfGridAndSaveCoordinatesIntoList()
        {
            Console.WriteLine("Označte na fotografii rohy hracího pole v následujícím pořadí: " +
                              "1. levý horní, 2. pravý horní, 3. pravý dolní a 4. levý dolní.");

            Cv2.SetMouseCallback("Image", OnMouse);
            while (true)
            {
                Mat tempImage = Image.Clone();

                foreach (var point2f in SquareCorners)
                {
                    Point pointInt = new Point((int)point2f.X, (int)point2f.Y);
                    Cv2.Circle(tempImage, pointInt, 5, new Scalar(0, 0, 255), 2);
                }

                Cv2.ImShow("Image", tempImage);
                int key = Cv2.WaitKey(20);
                if (key == 27 || SquareCorners.Count == 4) // key 27 == Esc: ends the program
                {
                    break;
                }
            }
            Cv2.DestroyAllWindows();
        }


        private void ResizeImage()
        {
            const int desiredHeight = 600;
            int newWidth = (int)((double)Image.Width / Image.Height * desiredHeight);

            Cv2.NamedWindow("Image");
            Cv2.ResizeWindow("Image", newWidth, desiredHeight);
        }


        private void OnMouse(MouseEventTypes mouseEvent, int x, int y, MouseEventFlags flags, IntPtr userdata)
        {
            if (mouseEvent == MouseEventTypes.LButtonDown)
            {
                SquareCorners.Add(new Point2f(x, y));
                Console.WriteLine($"Point added: ({x}, {y})");
            }
        }


        private Mat TransformAndCrop()
        {
            Point2f[] pointsFromOriginalPic = SquareCorners.ToArray();   // seřadit a odstranit vnucené pořadí z instrukcí

            Point2f[] TargetPoints = new Point2f[]
            {
                new Point2f(0, 0),       
                new Point2f(600, 0),     
                new Point2f(600, 600),   
                new Point2f(0, 600)     
            };

            Mat perspectiveMatrix = Cv2.GetPerspectiveTransform(pointsFromOriginalPic, TargetPoints);

            Mat transformedImage = new Mat();
            Cv2.WarpPerspective(Image, transformedImage, perspectiveMatrix, new Size(600, 600));

            Cv2.ImShow("Transformed Image", transformedImage);    // později odstranit, pro kontrolu
            Cv2.WaitKey(0);                             // později odstranit, pro kontrolu
            Cv2.DestroyAllWindows();
            return transformedImage;
        }
    }



}
