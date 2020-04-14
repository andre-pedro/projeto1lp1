using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Render
    {
        public void Draw(Tile[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {

                }

                Console.WriteLine();
            }
        }
        public void ShowPosition(int x, int y, char c)
        {
            // Set postion
            Console.SetCursorPosition(x, y);

            // Print
            Console.WriteLine(c);
        }
    }
}
