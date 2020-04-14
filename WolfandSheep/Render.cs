using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Render
    {
        private bool color = true;

        public void Draw(Tile[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    SwitchTextColor();

                    Console.Write(SetSymbol(grid[i, j]) + " ");

                    if(j == grid.GetLength(1)-1)
                    {
                        SwitchTextColor();
                    }
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
                    Console.ForegroundColor = ConsoleColor.White;
                    s = "W";
                    break;
                case TileType.Sheep:
                    Console.ForegroundColor = ConsoleColor.White;
                    s = "S";
                    break;
            }
            return s;
        }

        private void SwitchTextColor()
        {
            color = !color;

            if (color == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }

        }

    }
}
