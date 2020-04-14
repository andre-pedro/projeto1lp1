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
                    Console.Write(SetSymbol(grid[i, j]) + " ");
                }

                Console.WriteLine();
            }
        }

        public string SetSymbol(Tile tile)
        {
            string s = null;

            switch (tile.Type)
            {
                case TileType.Empty:
                    s = "■";
                    break;
                case TileType.Wolf:
                    s = "W";
                    break;
                case TileType.Sheep:
                    s = "S";
                    break;
            }
            return s;
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
