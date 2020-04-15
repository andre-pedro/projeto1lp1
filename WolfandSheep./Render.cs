﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Render
    {
        private bool color = true;

        public void Draw(object[,] grid)
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

        public string SetSymbol(object obj)
        {
            string s = null;

            if (obj is Square)
            {
                s = "■";
            }
            else if (obj is Sheep)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Sheep sheep = (Sheep)obj;
                switch (sheep.Id)
                {
                    case 1:
                        s = "1";
                        break;

                    case 2:
                        s = "2";
                        break;

                    case 3:
                        s = "3";
                        break;

                    case 4:
                        s = "4";
                        break;
                }

            }
            else if (obj is Wolf)
            {
                Console.ForegroundColor = ConsoleColor.White;
                s = "W";
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Pick a sheep from 1-4 to play!");
            Console.WriteLine();
        }

        public void ShowMovementsText(bool player)
        {
            Console.ForegroundColor = ConsoleColor.White;

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