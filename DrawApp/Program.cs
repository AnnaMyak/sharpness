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
            Bitmap bitmap = new Bitmap(@"C:\Users\AnnaToshiba2\Desktop\WSI\meta_old\sharpness\data1.png");

            int red_absolute = 0;
            int green_absolute = 0;
            int yellow_absolute = 0;
            int alpha_absolute = 0;
            double sum = 0;
            double procent = 0.0;
            double red = 0.0;
            double green = 0.0;
            double yellow = 0.0;
            for(int x=1; x<bitmap.Width;x++)
            {
                for (int y=1; y<bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).R == 255 && bitmap.GetPixel(x, y).G==0&& bitmap.GetPixel(x, y).B==0)
                        red_absolute++;
                    if (bitmap.GetPixel(x, y).G ==128&& bitmap.GetPixel(x, y).R == 0 && bitmap.GetPixel(x, y).B == 0)
                        green_absolute++;
                    if (bitmap.GetPixel(x, y).R==255&& bitmap.GetPixel(x, y).G == 165)
                        yellow_absolute++;
                    if (bitmap.GetPixel(x, y).A== 0)
                        alpha_absolute++;
                }
            }
            sum = red_absolute + green_absolute + yellow_absolute;
            procent = sum / 100;
            Console.WriteLine("Red:"+ red_absolute);
            Console.WriteLine("Green:" + green_absolute);
            Console.WriteLine("Yellow:" + yellow_absolute);
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Procent: " + procent);
            //Map 
            red = red_absolute / procent*100;
            green = green_absolute / procent;
            yellow = yellow_absolute / procent;
            Console.WriteLine("Map Red: " +red);
            Console.WriteLine("Map Green: " + green);
            Console.WriteLine("Map Yellow: " + yellow);
            while (true) { }



        }
    }
}
