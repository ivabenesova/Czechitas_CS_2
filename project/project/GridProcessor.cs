using OpenCvSharp;
using OpenCvSharp.ImgHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class GridProcessor
    {
        private Mat _image;

        public Mat Image { get; set; }

        
        public GridProcessor(Mat imgToCut)
        {
            Image = imgToCut;
        }

        public Tile[,] CutGridTo25SquaresAndAsignLandscapeToThem()
        {

            Tile[,] squaresArray = new Tile[GameGrid.NumberOfSquaresOnSide, GameGrid.NumberOfSquaresOnSide];
            int squareSide = Image.Height / GameGrid.NumberOfSquaresOnSide;

            Console.WriteLine(Image.Height);
            Console.WriteLine(Image.Width);

        for (int y = 0; y < GameGrid.NumberOfSquaresOnSide; y++)
            {
                for (int x = 0; x < GameGrid.NumberOfSquaresOnSide; x++)
                {
                    Tile newTile = new Tile();

                    int startX = x * squareSide;
                    int startY = y * squareSide;

                    Rect square = new Rect(startX, startY, squareSide, squareSide);

                    newTile.Image = new Mat(Image, square);
                    newTile.x = x;
                    newTile.y = y;
                    newTile.CrownNum = 1;
                    squaresArray[y,x] = newTile;
                }
            }

            return squaresArray;
        }

        
    }
}
