using OpenCvSharp;
using OpenCvSharp.ImgHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class GridCutter
    {
        private Mat _image;

        public Mat Image { get; set; }


        Tile[,] squaresArray = new Tile[GameGrid.NumberOfSquaresOnSide, GameGrid.NumberOfSquaresOnSide];

        public GridCutter(Mat imgToCut)
        {
            Image = imgToCut;
        }

        public void CutGridTo25Squares()
        {
            int squareSide = Image.Height / GameGrid.NumberOfSquaresOnSide;

            for (int y = 0; y < GameGrid.NumberOfSquaresOnSide; y++)
            {
                for (int x = 0; x < GameGrid.NumberOfSquaresOnSide; x++)
                {

                    int startX = x * squareSide;
                    int startY = y * squareSide;

                    Rect rect = new Rect(startX, startY, squareSide, squareSide);

                    squaresArray[y, x].Image = new Mat(Image, rect);
                }
            }
            Console.WriteLine("Obrázek byl úspěšně rozřezán a čtverečky byly uloženy do pole."); // remove
        }

        

    }
}
