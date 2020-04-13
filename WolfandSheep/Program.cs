using System;
using System.Runtime.InteropServices;

namespace WolfandSheep
{
    class Program
    {
        private static int[,] Grid { get; } = new int[8, 8];
        static void Main(string[] args)
        {
            Render b = new Render();
            b.Draw(Grid);
            Console.ReadLine();
        }


    }
}
