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

                    if (j == grid.GetLength(1) - 1)
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
                case TileType.Sheep1:
                    Console.ForegroundColor = ConsoleColor.White;
                    s = "1";
                    break;
                case TileType.Sheep2:
                    Console.ForegroundColor = ConsoleColor.White;
                    s = "2";
                    break;
                case TileType.Sheep3:
                    Console.ForegroundColor = ConsoleColor.White;
                    s = "3";
                    break;
                case TileType.Sheep4:
                    Console.ForegroundColor = ConsoleColor.White;
                    s = "4";
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

        public void ShowSelectSheepText()
        {
            Console.WriteLine();
            Console.WriteLine("Pick a sheep from 1-4 to play!");
            Console.WriteLine();
        }

        public void ShowMovementsText(bool player)
        {
            if (player == false)
            {
                Console.WriteLine();
                Console.WriteLine("I am Wolf. Pick a number from the numpad to move!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("I am Sheep. Pick a number from the numpad to move!");
                Console.WriteLine();

            }
        }
    }
}
