using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ASCII_Video
{
    internal class Program
    {
        private static Bitmap[] bitmaps;
        [STAThread]
        static void Main(string[] args)
        {
            string File = @"C:\Users\Елисей\Downloads\Time Lapse Video of Tall Buildings.mp4";
            
            //Methods.GetFileName(); // Получение пути к файлу

            var Date = DateTime.Now;

            bitmaps = Methods.GetBitmaps(File); // Разрезать видео по кадрам и получить их

            bitmaps = Methods.SetResezeBitmaps(bitmaps); // Уменьшить размер картинки

            bitmaps = Methods.GetBlackAndWhiteBitmaps(bitmaps); // Сделать видео чёрно белым

            var list = Methods.GetASCII(bitmaps); // Превратить в ASCII

            var Date2 = DateTime.Now;

            Console.WriteLine("\n" + Date);
            Console.WriteLine(Date2);

            Console.ReadKey();

            for (int i = 0; i < list.Count; i++)
            {
                Console.SetCursorPosition(0, 0);
                for (int j = 0; j < list[i].Length; j++)
                {
                    Console.WriteLine(list[i][j]);
                }
            }
        }
    }
}
