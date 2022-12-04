using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Тест2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Count = 200;
            Bitmap[] bitmaps = new Bitmap[519];
            for (int i = 0; i < Math.Ceiling((double)bitmaps.Length / Count); i++)
            {
                int id = Count * i;
                id = id + Count < bitmaps.Length ? Count + id : bitmaps.Length;

                int StopID = id;
                int StartID = Count * i;

                Console.WriteLine("StopID:" + StopID + " StartID:" + StartID);
            }
        }
    }
}
