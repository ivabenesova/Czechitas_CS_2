namespace project;

public class GridData 
{

    // asi bude brzy useless
    public (int, int)[,] ResultGrid { get; set; }

    private const int MaxSize = 5;

    public GridData((int,int)[,] finalGrid)
    {
        if (finalGrid.GetLength(0) == MaxSize && finalGrid.GetLength(1) == MaxSize)
        {
            ResultGrid = finalGrid;
        }
    }

   

    private enum Landscapes
    {
        none, //0
        forest, //1
        lake, //2
        field, //3
        swamp,//4
        meadow, //5
        mines, //6
        castle //7
    };

    



}

