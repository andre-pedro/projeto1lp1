using System;
using System.Runtime.InteropServices;

namespace WolfandSheep
{
    public class Program
    {
        //
        static void Main(string[] args)
        {

            Render r = new Render();
            r.MainMenu();
            GameManager gm = new GameManager(r);

            Console.ReadLine();
        }


    }
}
