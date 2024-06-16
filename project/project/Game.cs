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
            GameGrid grid = new GameGrid();
            ImageProcessor processor = new ImageProcessor(ImageName);
        }
    }
}
