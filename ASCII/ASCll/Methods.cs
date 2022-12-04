using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ASCll
{
    internal static class Methods
    {
        private static int Count = 400;

        public static Bitmap[] GetBitmaps(string videoFile)
        {
            Console.Write("Получаю кадры из видео.......  ");

            List<Bitmap> bitmaps = new List<Bitmap>();

            var capture = new VideoCapture(videoFile);
            var image = new Mat();

            while (true)
            {
                try
                {
                    capture.Read(image);
                    bitmaps.Add(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image));
                }
                catch
                {
                    break;
                }
            }

            Console.SetCursorPosition(55, 2);

            Console.Write(" Я получил " + bitmaps.Count + " кадров");

            Console.SetCursorPosition(80, 2);
            Console.Write("[Успешно]");

            return bitmaps.ToArray();
        }
        public static string GetFileName()
        {
            var OpenFile = new OpenFileDialog
            {
                Filter = "Images | *"
            };

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Выбор файла.....");

                if (OpenFile.ShowDialog() == DialogResult.OK)
                    break;
            }
            Console.SetCursorPosition(80, 0);
            Console.Write("[Успешно]\n -------------------------------------------------------------------- \n");

            return OpenFile.FileName;
        }
        public static Bitmap[] SetResezeBitmaps(Bitmap[] bitmaps)
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Изменение размеров кадров.......  ");
            for (int i = 0; i < bitmaps.Length; i++)
            {
                bitmaps[i] = bitmaps[i].ResezeBitmap();
                Console.SetCursorPosition(56, 3);
                Console.Write("Сделоно " + (i + 1) + " из " + bitmaps.Length);
            }
            Console.SetCursorPosition(80, 3);
            Console.Write("[Успешно]\n");
            return bitmaps;
        }
        public static Bitmap[] GetBlackAndWhiteBitmaps(Bitmap[] bitmaps)
        {
            Console.SetCursorPosition(0, 4);
            Console.Write("Делаю чёрно белые кадры.......");

            for (int i = 0; i < bitmaps.Length; i++)
            {
                bitmaps[i].GetBlackAndwhite();
                Console.SetCursorPosition(56, 4);
                Console.Write("Сделоно " + (i + 1) + " из " + bitmaps.Length);
            }

            Console.SetCursorPosition(80, 4);
            Console.Write("[Успешно]\n");



            Console.SetCursorPosition(80, 4);
            Console.Write("[Успешно]"); 

            return bitmaps;
        }
        public static List<Char[][]> GetASCII(Bitmap[] bitmaps)
        {
            List<Char[][]> chars = new List<char[][]>();

            Console.SetCursorPosition(0, 5);
            Console.Write("Делаю ASCII графику.......");
            for (int i = 0; i < bitmaps.Length; i++)
            {
                chars.Add(bitmaps[i].GetChars());
                Console.SetCursorPosition(56, 5);
                Console.Write("Сделоно " + (i + 1) + " из " + bitmaps.Length);
            }
            Console.SetCursorPosition(80, 5);
            Console.Write("[Успешно]\n");
            return chars;
        }
    }
}
