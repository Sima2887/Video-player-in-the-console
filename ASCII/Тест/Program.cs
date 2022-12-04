
using Aardvark.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Controls.UI.WinForms;

namespace Тест
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var videoFile = @"C:\Users\ЕTFFF\Downloads\видео.mp4";
            var capture = new VisioForge.Types.GST.VideoCapture(videoFile);
            var image = new Mat();

            capture.Read(image);
            Bitmap frame = BitmapConverter.ToBitmap(image);
            Console.WriteLine(frame.GetPixel(0, 0));
        }
    }
}
