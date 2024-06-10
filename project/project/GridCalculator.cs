using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp.Aruco;

namespace project
{
    public class GridCalculator
    {
        public GridData Grid { get; }

        public GridCalculator(GridData grid)
        {
            Grid = grid;
        }

        public Dictionary<int, (int, int)> ClustersWithLandscapeAndCrownNum { get; set; }


        public void CalculateResult()
        {
            int result = 0;

            FindClustersAndReturnDictWithClusterSizesAndCrownNumbers();

            foreach (KeyValuePair<int, (int, int)> item in ClustersWithLandscapeAndCrownNum)
            {
                result += item.Value.Item1 * item.Value.Item2;
            }

            Console.WriteLine(result);
        }


        private void FindClustersAndReturnDictWithClusterSizesAndCrownNumbers()
        {
            int clusterId = 1;

            int rowNumber = Grid.ResultGrid.GetLength(0);
            int colNumber = Grid.ResultGrid.GetLength(1);

            bool[,] visitedPositions = new bool[rowNumber, colNumber];

            ClustersWithLandscapeAndCrownNum = new Dictionary<int, (int, int)>();

            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < colNumber; j++)
                {
                    if (!visitedPositions[i, j])
                    {
                        (int, int) sizeAndCrownNum = FindClusterAndReturnNumberOfTilesAndCrown(visitedPositions, i, j);
                        ClustersWithLandscapeAndCrownNum.Add(clusterId, sizeAndCrownNum);
                        clusterId++;
                    }
                }
            }
        }


        public (int, int) FindClusterAndReturnNumberOfTilesAndCrown(bool[,] visited, int rowIndex, int colIndex)
        {
            int idNumber = Grid.ResultGrid[rowIndex, colIndex].Item1;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((rowIndex, colIndex));
            int clusterSize = 0;
            int crownNumberInCluster = 0;

            while (stack.Count > 0)
            {
                var (cx, cy) = stack.Pop();

                if (cx < 0 || cy < 0 || cx >= Grid.ResultGrid.GetLength(0) || cy >= Grid.ResultGrid.GetLength(1))
                {
                    continue;
                }

                if (visited[cx, cy] || Grid.ResultGrid[cx, cy].Item1 != idNumber)
                {
                    continue;
                }

                visited[cx, cy] = true;
                clusterSize++;

                if (Grid.ResultGrid[cx, cy].Item2 > 0)
                {
                    crownNumberInCluster += Grid.ResultGrid[cx, cy].Item2;
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = cx + dx[i];
                    int ny = cy + dy[i];
                    stack.Push((nx, ny));
                }
            }
            (int, int) tupleToReturn = (clusterSize, crownNumberInCluster);
            return tupleToReturn;
        }
    }


}
