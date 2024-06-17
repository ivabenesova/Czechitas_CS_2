using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace project
{
    internal class GameGrid()
    {
        public const int NumberOfSquaresOnSide = 5;

        private Tile[,] _gridArray;
        public Tile[,] GridArray { get; set; }

    }
}
