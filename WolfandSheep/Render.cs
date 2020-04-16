using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Render
    {
        //
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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                Console.WriteLine("It's the Wolf's turn. Pick a number from the numpad to move");
                Console.WriteLine("7   9");
                Console.WriteLine(@" \ / ");
                Console.WriteLine(@" / \ ");
                Console.WriteLine("1   3");
                Console.WriteLine(@"or press ""s"" to skip!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("It's the Sheep's turn. Pick a number from the numpad to move");
                Console.WriteLine("7   9");
                Console.WriteLine(@" \ / ");
                Console.WriteLine(@"or press ""s"" to skip!");
                Console.WriteLine();
            }
        }

        public void ShowInvalidMovementText()
        {
            Console.WriteLine();
            Console.WriteLine(@"This movement is invalid. Please select it again or insert ""s"" to skip your turn.");
            Console.WriteLine();
        }

        public void ShowSheepWinMessage()
        {
            Console.Clear();
            Console.WriteLine(" Player 2 - Sheep - won the game");
        }

        public void ShowWolfWinMessage()
        {
            Console.Clear();
            Console.WriteLine(" Player 1 - Wolf - won the game");
        }

        public void MainMenu()
        {

            Console.Clear();
            Console.WriteLine(@" _    _       _  __                _ _____ _");
            Console.WriteLine(@"| |  | |     | |/ _|              | / ___ | |");
            Console.WriteLine(@"| |  | | ___ | | |_ __ _ _ __   __| \ `--.| |__   ___  ___ _ __");
            Console.WriteLine(@"| |/\| |/ _ \| |  _/ _` | '_ \ / _` |`--. \ '_ \ / _ \/ _ \ '_ \ ");
            Console.WriteLine(@"\  /\  / (_) | | || (_| | | | | (_| /\__/ / | | | __ / __ / |_) |");
            Console.WriteLine(@" \/  \/ \___/|_|_| \__,_|_| |_|\__,_\____/|_| |_|\___|\___| .__/");
            Console.WriteLine(@"                                                          | |");
            Console.WriteLine(@"                                                          |_|");
            Console.WriteLine("a game developed by André Pedro and Inês Martins!");
            Console.WriteLine();
            Console.WriteLine("Rules of the Game:");
            Console.WriteLine("* aaaaaaa");
            Console.WriteLine("* bbbbbbb");
            Console.WriteLine("* ccccccc");
            Console.WriteLine("* ddddddd");
            Console.WriteLine("Press Enter to start!");
            ConsoleKeyInfo enter = Console.ReadKey();

            if (enter.Key == ConsoleKey.Enter)
            {
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong input. Press any key to try again!");
                Console.ReadKey();
                MainMenu();
            }
        }
    }
}
