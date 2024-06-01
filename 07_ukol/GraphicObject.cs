namespace _07_ukol;

internal class GraphicObject
{
    public ConsoleColor Color { get; set; }

    public GraphicObject(ConsoleColor color)
    {
        Color = color;
    }

    public virtual void Draw()
    {
        Console.ForegroundColor = Color;
    }
}