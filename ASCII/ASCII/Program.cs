using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                string FileName = Methods.GetFileName();

                Bitmap[] bitmaps = Methods.GetBitmaps(FileName);

                bitmaps = bitmaps.SetResezeBitmaps();

                //for (int i = 0; i < length; i++)
                //{

                //}

                //bitmap = bitmap.ResezeBitmap();

                //bitmap.GetBlackAndwhite();

                //var Charts =  bitmap.GetChars();

                //for (int i = 0; i < Charts.Length; i++)
                //{
                //    Console.WriteLine(Charts[i]);
                //}
                Console.ReadKey();
                Console.ReadKey();
            }
        }
    }
}
