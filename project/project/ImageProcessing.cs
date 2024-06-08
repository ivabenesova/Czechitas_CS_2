using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace project; 
internal class ImageProcessing
{
    private Bitmap _image;
    
    public string FilePath { get; set; }
    public Bitmap Image { get; set; }

    public ImageProcessing(string filePath)
    {
        FilePath = filePath;
        try
        {
            using (Bitmap image = new Bitmap(filePath))
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

