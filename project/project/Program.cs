﻿using System;

namespace project;


internal class Program
{
    static void Main(string[] args)
    {
        int[,] kingdomLandscapesArray = new int[5, 5]
        {
            {1,1,2,2,3},
            {1,1,2,2,3},
            {4,4,6,6,3},
            {1,1,2,6,2},
            {1,1,2,2,3}
        };

        int[,] kingdomCrownsArray = new int[5, 5]
        {
            {0,0,1,1,0},
            {0,0,0,0,1},
            {1,1,0,1,1},
            {0,0,1,1,0},
            {0,0,0,0,1}
        };

        KingdominoGrid kingdom1 = new KingdominoGrid(kingdomLandscapesArray, kingdomCrownsArray);


        Dictionary<int, Tuple<int, int>> clusters = kingdom1.FindClustersAndReturnDictWithClusterSizesAndCrownNumbers();

        Console.WriteLine($"výsledek: {kingdom1.CalculateResult(clusters)}");

        foreach (KeyValuePair<int, Tuple<int, int>> item in clusters)
        {
            {
                Console.WriteLine($"cluster no. {item.Key}: size {item.Value.Item1},  crowns {item.Value.Item2}");
            }
        }
    }
}

