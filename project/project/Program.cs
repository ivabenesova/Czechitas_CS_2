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

        //ImageCropper detector = new ImageCropper(relativePath);

        //detector.UserAddsCornersOfGridAndCoordinatesAreSavedIntoList();


        //GridProcessor cutter = new GridProcessor();
        //cutter.CutGridTo25Squares();



        //(int, int)[,] kingdomLandscapesArray = new (int, int)[5, 5]
        //{
        //    { (1, 0), (1, 0), (2, 1), (2, 1), (3, 0) },
        //    { (1, 0), (1, 0), (2, 0), (2, 0), (3, 1) },
        //    { (4, 1), (4, 1), (6, 0), (6, 1), (3, 1) },
        //    { (1, 0), (1, 0), (2, 1), (6, 1), (2, 0) },
        //    { (1, 0), (1, 0), (2, 0), (2, 0), (3, 1) },
        //};



        //GridData kingdom1 = new GridData(kingdomLandscapesArray);
        //GridCalculator calculator = new GridCalculator(kingdom1);
        //calculator.CalculateResult();

    }
}

