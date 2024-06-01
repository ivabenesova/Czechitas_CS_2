namespace _07_ukol;

internal class Rectangle : GraphicObject
{
    public int Height { set; get; }
    public int Width { set; get; }

    public Rectangle(int sideHeight, int sideWidth, ConsoleColor color) : base(color)
    {
        Height = sideHeight;
        Width = sideWidth;
    }

    public override void Draw()
    {
        base.Draw();
        for (int i = 0; i < Height; i++)
        {
            Console.WriteLine(new string('#', Width));
        }
    }
}