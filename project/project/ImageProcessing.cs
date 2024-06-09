using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using static System.Net.Mime.MediaTypeNames;


namespace project;

internal class ImageProcessing
{
    private Bitmap _image;

    public string FilePath { get; set; }
    public Mat Image { get; set; }

    private string _basePath = AppDomain.CurrentDomain.BaseDirectory;

    public ImageProcessing(string filePath)
    {
        FilePath = Path.GetFullPath(Path.Combine(_basePath, filePath));
        Console.WriteLine(FilePath);
        try
        {
            Image = Cv2.ImRead(FilePath);
            Console.WriteLine($"Image with dimensions {Image.Width}x{Image.Height} succesfully loaded.");
            ;
        }
        catch (Exception e)
        {
            Console.WriteLine("Can not load image: " + e.Message);
        }
    }

    public void ImageTransformations() //in progress
    {
        using (Image = Cv2.ImRead(FilePath))
        {
            // to black and white
            Mat grayImg = new Mat();
            Cv2.CvtColor(Image, grayImg, ColorConversionCodes.BGR2GRAY);

            //Gaussian blur 
            Mat blurred = new Mat();
            Cv2.GaussianBlur(grayImg, blurred, new OpenCvSharp.Size(5, 5), 0);

            //detect edges
            Mat edges = new Mat();
            Cv2.Canny(blurred, edges, 50, 150);

           

           
            /////////////////////////// chatgpt magic

            // Zobrazení výsledného obrazu
            Cv2.ImShow("Detected Rectangles", Image);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            
            SaveImage(Image, "result.jpg");
        }
    }

    

    public void SaveImage(Mat imageToSave, string imageName)
    {   
        
        string outputPath = Path.Combine(@"..\..\..\output_images\", imageName);
        string PathToSave = Path.GetFullPath(Path.Combine(_basePath, outputPath));

        Cv2.ImWrite(PathToSave, imageToSave);
    }
}

