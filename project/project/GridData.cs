namespace project;

public class GridData 
{
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
        none,
        forest,
        lake,
        field,
        swamp,
        meadow,
        mines,
        castle
    };

    



}

