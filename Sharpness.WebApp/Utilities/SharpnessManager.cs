using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emgu.CV;
using System.Drawing;
using System.IO;
using System.Text;
using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;

namespace Sharpness.WebApp.Utilities
{
    public class SharpnessManager : ISharpnessManager
    {
        public double[] GetChannelsValues(string path)
        {
            throw new NotImplementedException();
        }

        public Reglament GetReglament(string Stain, string Organ, string Tissue)
        {
            var _repoReglaments = new ReglamentRepository();

            //TODO

            return _repoReglaments.GetReglamentByTitel("Default");
        }

        /// <summary>
        /// return double array with color intensity information of the sharpness map
        /// RGB
        /// {R,G,B}
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public double[] GetSemaphoreValues(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            //Red results[0], Green results[1], Yellow results[2]
            var results = new double [3];
            int red_absolute = 0;
            int green_absolute = 0;
            int yellow_absolute = 0;
            int alpha_absolute = 0;
            double sum = 0;
            double procent = 0.0;
            double red = 0.0;
            double green = 0.0;
            double yellow = 0.0;
            for (int x = 1; x < bitmap.Width; x++)
            {
                for (int y = 1; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).R == 255 && bitmap.GetPixel(x, y).G == 0 && bitmap.GetPixel(x, y).B == 0)
                        red_absolute++;
                    if (bitmap.GetPixel(x, y).G == 128 && bitmap.GetPixel(x, y).R == 0 && bitmap.GetPixel(x, y).B == 0)
                        green_absolute++;
                    if (bitmap.GetPixel(x, y).R == 255 && bitmap.GetPixel(x, y).G == 165)
                        yellow_absolute++;
                    if (bitmap.GetPixel(x, y).A == 0)
                        alpha_absolute++;
                }
            }
            sum = red_absolute + green_absolute + yellow_absolute;
            procent = sum / 100;
            //Map 
            red = red_absolute / procent * 100;
            green = green_absolute / procent;
            yellow = yellow_absolute / procent;
            results[0] = red;
            results[1] = green;
            results[2] = yellow;
            return results;
        }
    }
}