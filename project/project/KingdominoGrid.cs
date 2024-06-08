namespace project;

public class KingdominoGrid
{
    private int[,] KingdomLandscapeGrid { get; set; }
    private int[,] KingdomCrownGrid { get; set; }


    public KingdominoGrid(int[,] landscapeGrid, int[,] crownGrid)
    {
        KingdomLandscapeGrid = landscapeGrid; //podminka s velikosti?
        KingdomCrownGrid = crownGrid;
    }

    //Dictionary<int, string> landscapesIndexDict = new Dictionary<int, string>()
    //{
    //    {0, "none"},
    //    {1, "forest"},
    //    {2, "lake"},
    //    {3, "field"},
    //    {4, "swamp"},
    //    {5, "meadow"},
    //    {6, "mines"},
    //    {7, "castle"}
    //};


    // vlastně mi není jasné, jestli mám z dict udělat property - kdy mám dělat property a kdy to můžu vracet jako proměnou? 
    public Dictionary<int, Tuple<int, int>> FindClustersAndReturnDictWithClusterSizesAndCrownNumbers()
    {
        int clusterId = 1;
        int rowNumber = KingdomLandscapeGrid.GetLength(0);
        int colNumber = KingdomLandscapeGrid.GetLength(1);

        bool[,] visitedPositions = new bool[rowNumber, colNumber]; // array of bools

        Dictionary<int, Tuple<int, int>> clusters = new Dictionary<int, Tuple<int, int>>();

        for (int i = 0; i < rowNumber; i++)
        {
            for (int j = 0; j < colNumber; j++)
            {
                if (!visitedPositions[i, j])
                {

                    Tuple<int, int> sizeAndCrownNum = FindClusterAndReturnNumberOfTilesAndCrown(visitedPositions, i, j);
                    clusters.Add(clusterId, sizeAndCrownNum);
                    clusterId++;
                }
            }
        }
        return clusters;
    }

    public int CalculateResult(Dictionary<int, Tuple<int, int>> clusterDict)
    {
        int result = 0;
        foreach (KeyValuePair<int, Tuple<int, int>> item in clusterDict)
        {
            result += item.Value.Item1 * item.Value.Item2;
        }
        return result;
    }



    public Tuple<int, int> FindClusterAndReturnNumberOfTilesAndCrown(bool[,] visited, int rowIndex, int colIndex)
    {
        int idNumber = KingdomLandscapeGrid[rowIndex, colIndex];
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((rowIndex, colIndex));
        int clusterSize = 0;
        int crownNumberInCluster = 0;

        while (stack.Count > 0)
        {
            var (cx, cy) = stack.Pop();

            if (cx < 0 || cy < 0 || cx >= KingdomLandscapeGrid.GetLength(0) || cy >= KingdomLandscapeGrid.GetLength(1))
            {
                continue;
            }

            if (visited[cx, cy] || KingdomLandscapeGrid[cx, cy] != idNumber)
            {
                continue;
            }

            visited[cx, cy] = true;
            clusterSize++;

            if (KingdomCrownGrid[cx, cy] > 0)
            {
                crownNumberInCluster += KingdomCrownGrid[cx, cy];
            }

            for (int i = 0; i < 4; i++)
            {
                int nx = cx + dx[i];
                int ny = cy + dy[i];
                stack.Push((nx, ny));
            }
        }

        Tuple<int, int> tupleToReturn = new Tuple<int, int>(clusterSize, crownNumberInCluster);
        return tupleToReturn;
    }

}

