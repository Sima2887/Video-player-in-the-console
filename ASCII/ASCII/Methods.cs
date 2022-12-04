using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII
{
    public static class Methods
    {
        private static int Count;
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
            Count = bitmaps.Count;

            Console.SetCursorPosition(55, 2);

            Console.Write(" Я получил " + bitmaps.Count + " кадров");

            Console.SetCursorPosition(80, 1);
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
                Console.Write("Выберети файл.....");

                if (OpenFile.ShowDialog() == DialogResult.OK)
                    break;
            }
            Console.SetCursorPosition(80, 0);
            Console.Write("[Успешно]\n -------------------------------------------------------------------- \n");

            return OpenFile.FileName;
        }
        public static Bitmap[] SetResezeBitmaps(this Bitmap[] bitmaps)
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Переобразование кадров в чёрно белый цвет.......  ");
            for (int i = 0; i < bitmaps.Length; i++)
            {
                bitmaps[i] = bitmaps[i].ResezeBitmap();
                Console.SetCursorPosition(25, 3);
                Console.Write("Сделоно " + i + " из " + Count);
            }
            Console.SetCursorPosition(80, 3);
            Console.Write("[Успешно]\n");
            return bitmaps;
        }
        private static Bitmap MatToBitmap(Mat mat)
        {
            using (var ms = mat.ToMemoryStream())
            {
                return (Bitmap)Image.FromStream(ms);
            }
        }
    }
}
