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

            GridProcessor cutter = new GridProcessor();

            GameGrid gameGrid = new GameGrid(cutter, processor.CropImage());

            Tile.LandscapeEnum something = gameGrid.GridArray[0, 0].Landscape;
            int someInt = (int)something;

            gameGrid.CalculateResult();


        }
    }
}
