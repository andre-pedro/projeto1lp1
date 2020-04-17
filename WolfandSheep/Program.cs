using System;

namespace WolfandSheep
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            //Create game variables
            Render r = new Render();
            r.MainMenu();
            GameManager gm = new GameManager(r);

            Console.ReadLine();
        }


    }
}
