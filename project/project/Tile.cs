using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace project
{
    internal class Tile
    {
        public Mat Image { get; set; }
        public string Landscape
        {
            get
            {
                return GetLandscapeToTileFromItsColour();
            }
        }
        public int CrownNum { set; get; }
        public int x { set; get; }
        public int y { set; get; }

        

        private new Dictionary<string, Scalar[]> colorRanges = new Dictionary<string, Scalar[]>
        {
            { "forest", new Scalar[] { new Scalar(40, 50, 50), new Scalar(60, 180, 120) } },
            { "lake", new Scalar[] { new Scalar(75, 100, 120), new Scalar(130, 255, 255) } },
            { "field", new Scalar[] { new Scalar(16, 120, 170), new Scalar(30, 255, 255) } }, 
            { "swamp", new Scalar[] { new Scalar(20, 0, 100), new Scalar(45, 100, 160) } },
            { "meadow", new Scalar[] { new Scalar(35, 100, 120), new Scalar(50, 255, 255) } },
            { "mines", new Scalar[] { new Scalar(60, 20, 20), new Scalar(120, 100, 100) } },
            { "castle", new Scalar[] { new Scalar(0, 0, 50), new Scalar(360, 10, 255) } }
        };


        public string GetLandscapeToTileFromItsColour()
        {
            const double edgePercent = 0.3;
            string unknown = "unknown";
            Mat square = Image;
            Mat hsvSquare = new Mat();


            Cv2.CvtColor(square, hsvSquare, ColorConversionCodes.BGR2HSV);

            int edgeWidth = (int)(square.Width * edgePercent);
            int edgeHeight = (int)(square.Height * edgePercent);

            Mat edgeMask = Mat.Zeros(square.Size(), MatType.CV_8U);

            Rect[] edges =
            {
                new Rect(0, 0, square.Width, edgeHeight),
                new Rect(0, square.Height - edgeHeight, square.Width, edgeHeight),
                new Rect(0, 0, edgeWidth, square.Height),
                new Rect(square.Width - edgeWidth, 0, edgeWidth, square.Height)
            };

            foreach (var edge in edges)
            {
                edgeMask.Rectangle(edge, Scalar.All(255), -1);
            }

            Mat edgeArea = new Mat();
            hsvSquare.CopyTo(edgeArea, edgeMask);


            Scalar meanHsv = Cv2.Mean(hsvSquare, edgeMask);
            Console.WriteLine($"Průměrná hodnota HSV: H = {meanHsv.Val0}, S = {meanHsv.Val1}, V = {meanHsv.Val2}");

            foreach (var colorRange in colorRanges)
            {
                //Cv2.ImShow("im", Image);
                //Cv2.WaitKey(0);
                //Cv2.DestroyAllWindows();
                if (IsWithinRange(meanHsv, colorRange.Value[0], colorRange.Value[1]))
                {
                    Console.WriteLine($"Tile odpovídá barvě: {colorRange.Key}");
                    return colorRange.Key;
                }
            }

            return "unknown";
        }



        private bool IsWithinRange(Scalar value, Scalar lowerBound, Scalar upperBound)
        {
            return (value.Val0 >= lowerBound.Val0 && value.Val0 <= upperBound.Val0 &&
                    value.Val1 >= lowerBound.Val1 && value.Val1 <= upperBound.Val1 &&
                    value.Val2 >= lowerBound.Val2 && value.Val2 <= upperBound.Val2);
        }

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
    }
}

