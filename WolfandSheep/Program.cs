using System;
using System.Runtime.InteropServices;

namespace WolfandSheep
{
    public class Program
    {
        //
        static void Main(string[] args)
        {
            Render b = new Render();
            GameManager gm = new GameManager(b);
            //Wolf w = new Wolf("wolf", 'W', 3, 0, Direction.Down);

            Console.ReadLine();
        }


    }
}
