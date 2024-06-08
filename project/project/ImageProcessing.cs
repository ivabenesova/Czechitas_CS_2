using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace project; 
internal class ImageProcessing
{
    private Bitmap _image;
    
    public string FilePath { get; set; }
    public Bitmap Image { get; set; }

    private string basePath = AppDomain.CurrentDomain.BaseDirectory;

    public ImageProcessing(string filePath)
    {
        FilePath = Path.GetFullPath(Path.Combine(basePath, filePath));
    try

    {
            using (Bitmap image = new Bitmap(FilePath))
            {

                Console.WriteLine($"Image with dimensions {image.Width}x{image.Height}, format: {image.PixelFormat} succesfully loaded.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Došlo k chybě při načítání obrázku: " + e.Message);
        }
    }



        

    

     
    

}

