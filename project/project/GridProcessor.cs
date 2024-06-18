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
        
        public GridProcessor()
        {
        }

        public Tile[,] CutGridTo25SquaresAndAsignLandscapeToThem(Mat imgToCut)
        {

            Tile[,] squaresArray = new Tile[GameGrid.NumberOfSquaresOnSide, GameGrid.NumberOfSquaresOnSide];
            int squareSide = imgToCut.Height / GameGrid.NumberOfSquaresOnSide;


        for (int y = 0; y < GameGrid.NumberOfSquaresOnSide; y++)
            {
                for (int x = 0; x < GameGrid.NumberOfSquaresOnSide; x++)
                {
                    Tile newTile = new Tile();

                    int startX = x * squareSide;
                    int startY = y * squareSide;

                    Rect square = new Rect(startX, startY, squareSide, squareSide);

                    newTile.Image = new Mat(imgToCut, square);
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
