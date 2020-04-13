using System;
using System.Runtime.InteropServices;

namespace WolfandSheep
{
    class Program
    {
        private static int[,] Position { get; } = new int[0, 4];
        private static int[,] Grid { get; } = new int[8, 8];
        static void Main(string[] args)
        {
            Render b = new Render();
            Wolf w = new Wolf("wolf", 'W', 3, 0, Direction.Down);
            b.Draw(Grid);
            b.ShowPosition(w.Column, w.Row, w.Char);
            Console.ReadLine();
        }


    }
}
