using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Game
    {
        public string ImageName { get; set; }

        public Game(string imgName)
        {
            ImageName = imgName;
        }

        public void Run()
        {
            ImageProcessor processor = new ImageProcessor(ImageName);
            
            GridProcessor cutter = new GridProcessor(processor.CropImage());

            Tile[,] grid = cutter.CutGridTo25SquaresAndAsignLandscapeToThem();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"{grid[i,j].Landscape} : {i}, {j}");
                }
                
            }

        }
    }
}
