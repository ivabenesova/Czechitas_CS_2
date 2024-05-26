namespace _07_ukol;

internal class Text : GraphicObject
{
    public string TextContent { set; get; }


    public Text(string text, ConsoleColor color) : base(color)
    {
        TextContent = text;
    }

    public override void Draw()
    {
        base.Draw();
        Console.WriteLine(TextContent);
    }
}