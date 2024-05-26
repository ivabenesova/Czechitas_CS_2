namespace _07_ukol;

internal class Triangle : GraphicObject
{
    public int Side { set; get; }

    public Triangle(int sideLength, ConsoleColor color) : base(color)
    {
        Side = sideLength;
    }

    public override void Draw()
    {
        base.Draw();
        for (int i = 0; i < Side; i++)
        {
            Console.WriteLine(new string('#', (Side - i)));
        }
    }
}