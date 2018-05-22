using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Image img = Image.FromFile(@"C:\Users\AnnaToshiba2\Desktop\WSI\meta\sharpness\result.png");
            int[] totals = new int[] { 0, 0, 0 };
            int width = img.Width;
            int height = img.Height;

            //Color clr = img.GetPixel(8, 21); // Get the color of pixel at position 5,5
            //int red = clr.R;
            //int green = clr.G;
            //int blue = clr.B;

            //Console.WriteLine("Red: ", red.ToString());
            //Console.WriteLine("Green: ", green.ToString());
            //Console.WriteLine("Blue: ", blue.ToString());

            Bitmap b = new Bitmap(img);
            Color pixelColor = b.GetPixel(8, 21);
            
            Console.WriteLine("Red: ", Convert.ToInt32(pixelColor.R));
            //Console.WriteLine("Green: ", pixelColor.R);

            while (true) { }



        }
    }
}
