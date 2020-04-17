using System;

namespace WolfandSheep
{

    public class Render
    {
        //Bool to alternate between colors
        private bool color = true;

        /// <summary>
        /// Draw the grid on the console
        /// </summary>
        /// <param name="grid"></param>
        public void Draw(object[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                //Iterate through the grid  
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    SwitchTextColor();

                    Console.Write(SetSymbol(grid[i, j]) + " ");

                    //If we found the end of the row switch color 
                    if (j == grid.GetLength(1) - 1)
                    {
                        SwitchTextColor();
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Graphical character of the board and game pieces   
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Change the colors of the board in a checkered pattern
        /// </summary>
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

        /// <summary>
        /// Playable sheep choice text
        /// </summary>
        public void ShowSelectSheepText()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Pick a sheep from 1-4 to play!");
            Console.WriteLine();
        }


        /// <summary>
        /// Show player movement text
        /// </summary>
        /// <param name="player"></param>
        public void ShowMovementsText(bool player)
        {
            Console.ForegroundColor = ConsoleColor.White;
            ///Wolf movement  
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
            ///Sheep movemet
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

        /// <summary>
        /// Invalid movement text 
        /// </summary>
        public void ShowInvalidMovementText()
        {
            Console.WriteLine();
            Console.WriteLine(@"This movement is invalid. Please select it again or insert ""s"" to skip your turn.");
            Console.WriteLine();
        }

        /// <summary>
        /// If sheep wins the game text
        /// </summary>
        public void ShowSheepWinMessage()
        {
            Console.Clear();
            Console.WriteLine(" Player 2 - Sheep - won the game!");
            Console.ReadKey();
            MainMenu();
        }

        /// <summary>
        /// If wolf wins the game text
        /// </summary>
        public void ShowWolfWinMessage()
        {
            Console.Clear();
            Console.WriteLine(" Player 1 - Wolf - won the game!");
            Console.ReadKey();
            MainMenu();
        }

        /// <summary>
        /// Rules text 
        /// </summary>
        public void MainMenu()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@" _    _       _  __                _ _____ _");
            Console.WriteLine(@"| |  | |     | |/ _|              | / ___ | |");
            Console.WriteLine(@"| |  | | ___ | | |_ __ _ _ __   __| \ `--.| |__   ___  ___ _ __");
            Console.WriteLine(@"| |/\| |/ _ \| |  _/ _` | '_ \ / _` |`--. \ '_ \ / _ \/ _ \ '_ \ ");
            Console.WriteLine(@"\  /\  / (_) | | || (_| | | | | (_| /\__/ / | | | __ / __ / |_) |");
            Console.WriteLine(@" \/  \/ \___/|_|_| \__,_|_| |_|\__,_\____/|_| |_|\___|\___| .__/");
            Console.WriteLine(@"                                                          | |");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"a game developed by André Pedro and Inês Martins!");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"         |_|");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Rules of the Game:");
            Console.WriteLine();
            Console.WriteLine("Movement:");
            Console.WriteLine("  * The first player controls the Wolf (W), whereas the second controls four Sheep (1, 2, 3, 4).");
            Console.WriteLine("  * The Wolf plays first, spawning in a random position on the first row of the board." +
                "\n    It can move in every diagonal, by using the 1, 3, 7 and 9 keys on the numpad.");
            Console.WriteLine("  * Afterwards, it’s the Sheep’s turn. Select a sheep from the herd to move." +
                "\n    Sheep can only move in forward diagonals (by selecting either 7 or 9 on the numpad)." +
                "\n    Only one sheep can move per turn.");
            Console.WriteLine("Objectives:");
            Console.WriteLine("  * The Wolf's objective is to reach a sheep's original square (the last row).");
            Console.WriteLine("  * The Sheep's objective is to surround the wolf, stopping him from moving.");
            Console.WriteLine();
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
