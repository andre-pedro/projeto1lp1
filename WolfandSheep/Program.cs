using System;
using System.Runtime.InteropServices;

namespace WolfandSheep
{
    class Program
    {
        private const byte width = 8;
        private const byte height = 8;

        private static byte[,] board = new byte[width, height];

        static void Main(string[] args)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("0 ");
                }

                Console.WriteLine();
            } 

        }
    }
}
