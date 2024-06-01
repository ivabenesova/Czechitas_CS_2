using System.Drawing;
using System.Security.Principal;

namespace _07_ukol;

internal class Program
{
    static void Main(string[] args)
    {
        Triangle triangleA = new Triangle(5, ConsoleColor.White);
        Rectangle rectangleB = new Rectangle(7, 5, ConsoleColor.Blue);
        Text textAHoj = new Text("ahoj", ConsoleColor.DarkMagenta);

        List<GraphicObject> objects = new List<GraphicObject>() { triangleA, rectangleB, textAHoj };
        foreach (GraphicObject obj in objects)
        {
            obj.Draw();
            Console.WriteLine();
        }
    }
}
