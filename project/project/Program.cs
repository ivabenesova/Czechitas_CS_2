using System;

namespace project;
internal class Program
{
    Dictionary<int, string> landscapesDict = new Dictionary<int, string>()
    {
        {0, "none"},
        {1, "forest"},
        {2, "lake"},
        {3, "field"}, 
        {4,"swamp"},
        {5, "meadow"},
        {6, "mines"}, 
        {7, "castle"}
    };

    int[,] kingdomLandscapesArray = new int[5,5] 
        {
        {1,1,2,2,3},
        {1,1,2,2,3},
        {4,4,6,6,3},
        {1,1,2,6,2},
        {1,1,2,2,3}
        };
    int[,] kingdomCrownssArray = new int[5,5] 
        {
        {0,0,1,1,0},
        {0,0,0,0,1},
        {1,1,0,1,1},
        {0,0,1,1,0},
        {0,0,0,0,1}
        };

    Dictionary<int, List<int>> clusters = new Dictionary<int, List<int>>{};
    static Dictionary<int, List<int>> FindClusters(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        bool[,] visited = new bool[rows, cols]; // array of bools
        Dictionary<int, List<int>> clusters = new Dictionary<int, List<int>>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (!visited[i, j])
                {
                    int number = matrix[i, j];
                    int size = DFS(matrix, visited, i, j, number);

                    if (size > 1)
                    {
                        if (!clusters.ContainsKey(number))
                        {
                            clusters[number] = new List<int>();
                        }
                        clusters[number].Add(size);
                    }
                }
            }
        }

        return clusters;
    }

    static int DFS(int[,] matrix, bool[,] visited, int x, int y, int number)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((x, y));
        int size = 0;

        while (stack.Count > 0)
        {
            var (cx, cy) = stack.Pop();

            if (cx < 0 || cy < 0 || cx >= matrix.GetLength(0) || cy >= matrix.GetLength(1))
            {
                continue;
            }

            if (visited[cx, cy] || matrix[cx, cy] != number)
            {
                continue;
            }

            visited[cx, cy] = true;
            size++;

            for (int i = 0; i < 4; i++)
            {
                int nx = cx + dx[i];
                int ny = cy + dy[i];
                stack.Push((nx, ny));
            }
        }

        return size;
    }


    static void Main(string[] args)
    {
       
 
    }
}

