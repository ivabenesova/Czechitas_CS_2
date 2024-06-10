namespace project;

public class GridData 
{
    public (int, int)[,] ResultGrid { get; set; }
    

    public GridData((int,int)[,] finalGrid)
    {
        if (finalGrid.GetLength(0) == 5 && finalGrid.GetLength(1) == 5)
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

