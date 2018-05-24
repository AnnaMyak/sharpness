using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawApp
{
    public class PictureHistogram
    {
        private Bitmap m_bitmap;
        public enum Channel
        {
            Red,
            Green,
            Blue,
            Alpha
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">Instance of bitmap object</param>
        public PictureHistogram(Bitmap bitmap)
        {
            this.m_bitmap = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path of bitmap picture</param>
        public PictureHistogram(string path)
        {
            this.m_bitmap = new Bitmap(path);
        }

        /// <summary>
        /// Extract a map of picture (2D Array) for a specific channel
        /// </summary>
        /// <param name="channel_index">Channel to extract</param>
        /// <returns>Pixel Map</returns>
        public byte[,] pixelMap(Channel channel_index)
        {
            int size = this.m_bitmap.Width * this.m_bitmap.Height;
            int picture_width = this.m_bitmap.Width;
            int picture_height = this.m_bitmap.Height;
            byte[,] pixels_map = new byte[picture_width, picture_height];

            for (int i = 0; i < picture_height; i++)
            {
                for (int j = 0; j < picture_width; j++)
                {
                    Color color = this.m_bitmap.GetPixel(j, i);
                    byte color_intensity = 0;
                    switch (channel_index)
                    {
                        case Channel.Red:
                            color_intensity = color.R;
                            break;
                        case Channel.Green:
                            color_intensity = color.G;
                            break;
                        case Channel.Blue:
                            color_intensity = color.B;
                            break;
                        case Channel.Alpha:
                            color_intensity = color.A;
                            break;
                    }

                    pixels_map[j, i] = color_intensity;
                }
            }

            return pixels_map;
        }

    }
}
