using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Render
    {
        public void Draw(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Square square = new Square();

                    Console.Write(square.Sqr);
                }

                Console.WriteLine();
            }
        }
    }
}
