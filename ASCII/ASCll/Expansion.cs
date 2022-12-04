using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCll
{
    internal static class Expansion
    {
        private static string Gradient = "#G5J7?";
        private static int maxWidth = 400;
        private static double Length = 1.5;
        public static void GetBlackAndwhite(this Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixe = bitmap.GetPixel(x, y);
                    var color = (pixe.B + pixe.R + pixe.G) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(pixe.A, color, color, color));
                }
            }
        }
        public static Char[][] GetChars(this Bitmap bitmap)
        {
            Char[][] bitmapChars = new Char[bitmap.Height][];

            int id = bitmap.Width;

            for (int y = 0; y < bitmap.Height; y++)
            {
                bitmapChars[y] = new Char[id];

                for (int x = 0; x < id; x++)
                {
                    bitmapChars[y][x] = Gradient[Parse(bitmap.GetPixel(x, y).R)];
                }
            }
            return bitmapChars;
        }
        public static Bitmap ResezeBitmap(this Bitmap bitmap)
        {
            var newHeight = bitmap.Height / Length * maxWidth / bitmap.Width;
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
            return bitmap;
        }
        private static int Parse(double id)
        {
            return (int)Math.Round(id / (255 / (Gradient.Length - 1)));
        }
    }
}
