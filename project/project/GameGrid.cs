using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using static project.GridData;

namespace project
{
    internal class GameGrid
    {
        public const int NumberOfSquaresOnSide = 5;

        private GridProcessor _processor;
        private Tile[,] _gridArray;
        private Mat imageOfGrid;

        public Tile[,] GridArray { get; set; }
        public Mat ImageOfGrid { get; set; }

        public GameGrid(GridProcessor gridProcessor, Mat imgToCut)
        {
            _processor = gridProcessor;
            GridArray = _processor.CutGridTo25SquaresAndAsignLandscapeToThem(imgToCut);
        }


        // todo collect coordinates of clusters/write cluster number to Tile for further visualization

        public Dictionary<int, (int, int)> ClustersWithLandscapeAndCrownNum { get; set; }

        public void CalculateResult()
        {
            int result = 0;

            FindClustersAndReturnDictWithClusterSizesAndCrownNumbers();

            foreach (KeyValuePair<int, (int, int)> item in ClustersWithLandscapeAndCrownNum)
            {
                result += item.Value.Item1; //* item.Value.Item2)/; // edit after adding reasonable crown numbers
            }

            Console.WriteLine($"vysledne skore: {result}");
        }


        private void FindClustersAndReturnDictWithClusterSizesAndCrownNumbers()
        {
            int clusterId = 1;

            int rowNumber = GridArray.GetLength(0);
            int colNumber = GridArray.GetLength(1);

            bool[,] isVisitedArray = new bool[rowNumber, colNumber];

            ClustersWithLandscapeAndCrownNum = new Dictionary<int, (int, int)>();

            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < colNumber; j++)
                {
                    if (!isVisitedArray[i, j])
                    {
                        (int, int) TileAndCrownNumberInCLuster = FindClusterAndReturnNumberOfTilesAndCrown(isVisitedArray, i, j);
                        ClustersWithLandscapeAndCrownNum.Add(clusterId, TileAndCrownNumberInCLuster);
                        clusterId++;
                    }
                }
            }
        }
        

        public (int, int) FindClusterAndReturnNumberOfTilesAndCrown(bool[,] visited, int rowIndex, int colIndex)
        {
            Tile.LandscapeEnum currentLandscape = GridArray[rowIndex, colIndex].Landscape;
            int[] shifX = { -1, 1, 0, 0 };
            int[] shiftY = { 0, 0, -1, 1 };
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((rowIndex, colIndex));
            int clusterSize = 0;
            int crownNumberInCluster = 0;

            while (stack.Count > 0)
            {
                var (currentX, currentY) = stack.Pop();


                if (currentX < 0 || currentY < 0 || currentX >= GridArray.GetLength(0) ||
                    currentY >= GridArray.GetLength(1))
                {
                    continue;
                }

                if (visited[currentX, currentY] || GridArray[currentX, currentY].Landscape != currentLandscape)
                {
                    continue;
                }

                visited[currentX, currentY] = true;
                clusterSize++;

                if (GridArray[currentX, currentY].CrownNum > 0)
                {
                    crownNumberInCluster += GridArray[currentX, currentY].CrownNum;
                }

                
                for (int i = 0; i < 4; i++)
                {
                    int neighborX = currentX + shifX[i];
                    int neighborY = currentY + shiftY[i];
                    stack.Push((neighborX, neighborY));
                }
            }

            (int, int) tupleToReturn = (clusterSize, crownNumberInCluster);
            Console.WriteLine(tupleToReturn.Item1);
            return tupleToReturn;
        }
    }

}

