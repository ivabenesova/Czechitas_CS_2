using OpenCvSharp;
using OpenCvSharp.ImgHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class CutGridToSquares
    {
        private Mat _image;

        public string FilePath { get; set; }
        public Mat Image { get; set; }

        private string _basePath = AppDomain.CurrentDomain.BaseDirectory;

        private const int NumberOfSquaresInRowOrCol = 5;

        Mat[,] squaresArray = new Mat[NumberOfSquaresInRowOrCol, NumberOfSquaresInRowOrCol];

        public CutGridToSquares()
        {
            string relativePath = @"..\..\..\output_images\result2.jpg";
            FilePath = Path.GetFullPath(Path.Combine(_basePath, relativePath));
            
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

        public void CutGridTo25Squares()
        {
            int squareHeight = Image.Height / NumberOfSquaresInRowOrCol; // zjednodušit na jedno číslo?
            int squareWidth = Image.Width / NumberOfSquaresInRowOrCol;

            // Rozřezání obrázku na čtverečky
            for (int y = 0; y < NumberOfSquaresInRowOrCol; y++)
            {
                for (int x = 0; x < NumberOfSquaresInRowOrCol; x++)
                {

                    int startX = x * squareWidth;
                    int startY = y * squareHeight;

                    Rect rect = new Rect(startX, startY, squareWidth, squareHeight);

                    squaresArray[y, x] = new Mat(Image, rect);
                }
            }

           

            // !!
            //foreach (var square in squaresArray)
            //{
            //    square.Dispose();
            //}

            ///
            Console.WriteLine("Obrázek byl úspěšně rozřezán a čtverečky byly uloženy do pole.");

            var colorRanges = new Dictionary<string, Scalar[]>
            {
                { "forest", new Scalar[] { new Scalar(40, 50, 50), new Scalar(60, 180, 120) } }, 
                { "lake", new Scalar[] { new Scalar(75, 100, 120), new Scalar(130, 255, 255) } }, 
                { "field", new Scalar[] { new Scalar(16, 140, 170), new Scalar(30, 255, 255) } }, //ok
                { "swamp", new Scalar[] { new Scalar(10, 0, 100), new Scalar(30, 100, 160) } }, 
                { "meadow", new Scalar[] { new Scalar(35, 50, 120), new Scalar(50, 255, 255) } }, 
                { "mines", new Scalar[] { new Scalar(35, 50, 50), new Scalar(85, 255, 255) } },  
                { "castle", new Scalar[] { new Scalar(0, 0, 50), new Scalar(360, 10, 255) } } 
            };

            //private enum Landscapes
            //{
            //    none, //0
            //    forest, //1
            //    lake, //2
            //    field, //3
            //    swamp,//4
            //    meadow, //5
            //    mines, //6
            //    castle //7
            //};

            double edgePercent = 0.3;

            // Kategorizace čtverečků podle barvy
            for (int i = 0; i < NumberOfSquaresInRowOrCol; i++)
            {
                for (int j = 0; j < NumberOfSquaresInRowOrCol; j++)
                {
                    Mat square = squaresArray[i, j];
                    Mat hsvSquare = new Mat();
                    
                    Cv2.CvtColor(square, hsvSquare, ColorConversionCodes.BGR2HSV);

                    int edgeWidth = (int)(square.Width * edgePercent);
                    int edgeHeight = (int)(square.Height * edgePercent);

                    // Vytvoření masky pro okraje
                    Mat edgeMask = Mat.Zeros(square.Size(), MatType.CV_8U);

                    // Vyplnění masky okrajovými oblastmi
                    Rect[] edges = {
                        new Rect(0, 0, square.Width, edgeHeight), // Horní okraj
                        new Rect(0, square.Height - edgeHeight, square.Width, edgeHeight), // Dolní okraj
                        new Rect(0, 0, edgeWidth, square.Height), // Levý okraj
                        new Rect(square.Width - edgeWidth, 0, edgeWidth, square.Height) // Pravý okraj
                    };

                    foreach (var edge in edges)
                    {
                        edgeMask.Rectangle(edge, Scalar.All(255), -1);
                    }

                    // Vytvoření matice pro okraje
                    Mat edgeArea = new Mat();
                    hsvSquare.CopyTo(edgeArea, edgeMask);

                    // Výpočet průměrné HSV hodnoty pro okraje
                    Scalar meanHsv = Cv2.Mean(hsvSquare, edgeMask);
                    Console.WriteLine($"Průměrná hodnota HSV: H = {meanHsv.Val0}, S = {meanHsv.Val1}, V = {meanHsv.Val2}");

                    // Porovnání průměrné hodnoty s barevnými rozsahy
                    foreach (var colorRange in colorRanges)
                    {
                        if (IsWithinRange(meanHsv, colorRange.Value[0], colorRange.Value[1]))
                        {
                            Console.WriteLine($"Čtvereček {i}, {j} odpovídá barvě: {colorRange.Key}");
                            break;
                        }
                    }
                }
            }

        }

        private bool IsWithinRange(Scalar value, Scalar lowerBound, Scalar upperBound)
        {
            return (value.Val0 >= lowerBound.Val0 && value.Val0 <= upperBound.Val0 &&
                    value.Val1 >= lowerBound.Val1 && value.Val1 <= upperBound.Val1 &&
                    value.Val2 >= lowerBound.Val2 && value.Val2 <= upperBound.Val2);
        }

    }
}
