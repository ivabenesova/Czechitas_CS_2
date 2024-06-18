using System;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Image = System.Drawing.Image;

namespace project;


class Program
{
    static void Main(string[] args)
    {
        string nameOfFile = "kingdomino3.jpg";

        Game newGame = new Game(nameOfFile);

        newGame.Run();
    }
}

