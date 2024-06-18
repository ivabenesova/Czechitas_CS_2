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

        public LandscapeEnum Landscape
        {
            get
            {
                return GetLandscapeToTileFromItsColour();
            }
        }

        public int CrownNum { set; get; }
        public int x { set; get; }
        public int y { set; get; }


        public enum LandscapeEnum
        {
            Forest,
            Lake,
            Field,
            Swamp,
            Meadow,
            Mines,
            Unknown
        }

        private new Dictionary<LandscapeEnum, Scalar[]> colorRanges = new Dictionary<LandscapeEnum, Scalar[]>
        {
            { LandscapeEnum.Forest, new Scalar[] { new Scalar(40, 50, 50), new Scalar(60, 180, 120) } },
            { LandscapeEnum.Lake, new Scalar[] { new Scalar(75, 100, 120), new Scalar(130, 255, 255) } },
            { LandscapeEnum.Field, new Scalar[] { new Scalar(16, 120, 170), new Scalar(30, 255, 255) } }, 
            { LandscapeEnum.Swamp, new Scalar[] { new Scalar(20, 0, 100), new Scalar(45, 100, 160) } },
            { LandscapeEnum.Meadow, new Scalar[] { new Scalar(35, 100, 120), new Scalar(50, 255, 255) } },
            { LandscapeEnum.Mines, new Scalar[] { new Scalar(60, 20, 20), new Scalar(120, 100, 100) } },
            { LandscapeEnum.Unknown, new Scalar[] { new Scalar(0, 0, 0), new Scalar(360, 255, 255) } }
        };


        public LandscapeEnum GetLandscapeToTileFromItsColour()
        {
            Mat tileForLandscapeAssignment = Image;
            Mat hsvSquare = new Mat();

            Cv2.CvtColor(tileForLandscapeAssignment, hsvSquare, ColorConversionCodes.BGR2HSV);


            const double marginToKeepInPercent = 0.3;


            Mat marginMask = CreateMaskForFilteringOutTileCenter(marginToKeepInPercent, tileForLandscapeAssignment);


            Mat edgeArea = new Mat();
            hsvSquare.CopyTo(edgeArea, marginMask);
            
            Scalar meanHsv = Cv2.Mean(hsvSquare, marginMask);
            
            foreach (var colorRange in colorRanges)
            {
                
                if (IsWithinRange(meanHsv, colorRange.Value[0], colorRange.Value[1]))
                {
                    //Console.WriteLine($"Tile odpovídá barvě: {colorRange.Key}");
                    return colorRange.Key;
                }
            }

            return LandscapeEnum.Unknown;
        }

        // todo: oříznout i 5% kolem krajů
        private Mat CreateMaskForFilteringOutTileCenter(double marginWidthInPercent, Mat tileImage)
        {
            int edgeWidth = (int)(tileImage.Width * marginWidthInPercent);
            int edgeHeight = (int)(tileImage.Height * marginWidthInPercent);

            Mat edgeMask = Mat.Zeros(tileImage.Size(), MatType.CV_8U);

            Rect[] edges =
            {
                new Rect(0, 0, tileImage.Width, edgeHeight),
                new Rect(0, tileImage.Height - edgeHeight, tileImage.Width, edgeHeight),
                new Rect(0, 0, edgeWidth, tileImage.Height),
                new Rect(tileImage.Width - edgeWidth, 0, edgeWidth, tileImage.Height)
            };

            foreach (var edge in edges)
            {
                edgeMask.Rectangle(edge, Scalar.All(255), -1);
            }

            return edgeMask;
        }

        private bool IsWithinRange(Scalar value, Scalar lowerBound, Scalar upperBound)
        {
            return (value.Val0 >= lowerBound.Val0 && value.Val0 <= upperBound.Val0 &&
                    value.Val1 >= lowerBound.Val1 && value.Val1 <= upperBound.Val1 &&
                    value.Val2 >= lowerBound.Val2 && value.Val2 <= upperBound.Val2);
        }

        
    }
}

