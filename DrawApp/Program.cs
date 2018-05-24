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
            Bitmap bitmap = new Bitmap(@"C:\Users\AnnaToshiba2\Desktop\WSI\Sharpness_WebApp_Uploads\admin@example.com\WSI Test\CMU-1Debug.png");



           // Bitmap bitmap = new Bitmap(path);
            //Red results[0], Blue results[1]
            var results = new double[2];
            int red_absolute = 0;
            int blue_absolute = 0;

            double sum = 0;
            double procent = 0.0;
            double red = 0.0;
            double blue = 0.0;
            for (int x = 1; x < bitmap.Width; x++)
            {
                for (int y = 1; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).R == 255)
                        red_absolute++;
                    if (bitmap.GetPixel(x, y).R < 170 && bitmap.GetPixel(x, y).B < 150)
                        blue_absolute++;

                }
            }
            sum = red_absolute + blue_absolute;
            procent = sum / 100;
            //Map 
            red = red_absolute / procent;
            blue = blue_absolute / procent;

            results[0] = red;
            results[1] = blue;

            Console.WriteLine("Red "+red);
            Console.WriteLine("Blue " + blue);
            while (true) { }



        }
    }
}
