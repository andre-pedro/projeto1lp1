using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WolfandSheep
{
    public class GameManager
    {
        //
        private int[,] Position { get; } = new int[0, 4];
        private object[,] grid = new object[8, 8];
        private bool player;
        private Wolf wolf;
        private Sheep sheep1;
        private Sheep sheep2;
        private Sheep sheep3;
        private Sheep sheep4;
        private Sheep playingSheep;
        private Render b;

        public GameManager(Render b)
        {
            this.b = b;
            player = false;

            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Square();
                }
            }
            SpawnEntities();

            GameLoop();
        }

        private void SpawnEntities()
        {
            Random rand = new Random();
            int num = 0;

            //Check if random is odd
            while (num % 2 == 0)
            {
                num = rand.Next(1, 8);
            }

            grid[0, num] = new Wolf(0, num);
            grid[7, 0] = new Sheep(7, 0, 1);
            grid[7, 2] = new Sheep(7, 2, 2);
            grid[7, 4] = new Sheep(7, 4, 3);
            grid[7, 6] = new Sheep(7, 6, 4);

            wolf = (Wolf)grid[0, num];
            sheep1 = (Sheep)grid[7, 0];
            sheep2 = (Sheep)grid[7, 2];
            sheep3 = (Sheep)grid[7, 4];
            sheep4 = (Sheep)grid[7, 6];
        }

        private void GameLoop()
        {
            string input = null;

            // Infinite Game Loop
            while (true)
            {
                // If wolf is playing
                if (player == false)
                {
                    while (input != "7" && input != "9" && input != "1" && input != "3" && input != "s")
                    {
                        b.Draw(grid);
                        b.ShowMovementsText(player);
                        input = Console.ReadLine();

                        if (input == "7" || input == "9" || input == "1" || input == "3")
                        {
                            wolf.Move((Direction)Convert.ToInt32(input));
                            if (CheckValidMovement(wolf))
                            {
                                grid[wolf.PreviousRow, wolf.PreviousColumn] = grid[wolf.Row, wolf.Column];
                                grid[wolf.Row, wolf.Column] = wolf;
                            }
                            else
                            {
                                wolf.ResetMovement();
                                b.ShowInvalidMovementText();
                                input = null;
                            }
                        }
                    }
                    input = null;
                    player = !player;
                }
                // If sheep is playing
                else
                {
                    while (input != "1" && input != "2" && input != "3" && input != "4")
                    {
                        b.Draw(grid);
                        b.ShowSelectSheepText();
                        input = Console.ReadLine();
                    }

                    SelectPlayingSheep(input);
                    input = null;

                    while (input != "7" && input != "9" && input != "s")
                    {
                        b.Draw(grid);
                        b.ShowMovementsText(player);
                        input = Console.ReadLine();

                        if (input == "7" || input == "9")
                        {
                            playingSheep.Move((Direction)Convert.ToInt32(input));
                            if (CheckValidMovement(playingSheep))
                            {
                                grid[playingSheep.PreviousRow, playingSheep.PreviousColumn] = grid[playingSheep.Row, playingSheep.Column];
                                grid[playingSheep.Row, playingSheep.Column] = playingSheep;
                            }
                            else
                            {
                                playingSheep.ResetMovement();
                                b.ShowInvalidMovementText();
                                input = null;
                            }
                        }
                    }
                    input = null;
                    player = !player;
                }

                if (CheckWin())
                {
                    break;
                }

            }
        }

        private bool CheckWin()
        {
            bool returnVal = false;

            //check if wolf won
            if(wolf.Row == grid.GetLength(0) -1)
            {
                returnVal = true;
                b.ShowWolfWinMessage();
            }
            else if(IsWolfSurrounded())
            {
                returnVal = true;
                b.ShowSheepWinMessage();
            }

            return returnVal;
        }

        private bool IsWolfSurrounded()
        {
            bool returnVal = false;
            bool northeast = false;
            bool northwest = false;
            bool southeast = false;
            bool southwest = false;

            wolf.Move(Direction.NorthEast);
            if (!CheckValidMovement(wolf))
            {
                northeast = true;
            }
            wolf.Row = wolf.PreviousRow;
            wolf.Column = wolf.PreviousColumn;

            wolf.Move(Direction.NorthWest);
            if (!CheckValidMovement(wolf))
            {
                northwest = true;
            }
            wolf.Row = wolf.PreviousRow;
            wolf.Column = wolf.PreviousColumn;

            wolf.Move(Direction.SouthEast);
            if (!CheckValidMovement(wolf))
            {
                southeast = true;
            }
            wolf.Row = wolf.PreviousRow;
            wolf.Column = wolf.PreviousColumn;

            wolf.Move(Direction.SouthWest);
            if (!CheckValidMovement(wolf))
            {
                southwest = true;
            }
            wolf.Row = wolf.PreviousRow;
            wolf.Column = wolf.PreviousColumn;

            if (northeast == true && northwest == true && southeast == true && southwest == true)
            {
                returnVal = true;
            }
            return returnVal;
        }

        private void SelectPlayingSheep(string input)
        {
            switch (input)
            {
                case "1":
                    playingSheep = sheep1;
                    break;
                case "2":
                    playingSheep = sheep2;
                    break;
                case "3":
                    playingSheep = sheep3;
                    break;
                case "4":
                    playingSheep = sheep4;
                    break;
            }
        }

        private bool CheckValidMovement(object obj)
        {
            bool returnValue = false;

            if (obj is Sheep)
            {
                // Check if inside of board bounds
                if (playingSheep.Row < 0 || playingSheep.Row >= grid.GetLength(0) || playingSheep.Column < 0 || playingSheep.Column >= grid.GetLength(1))
                    returnValue = false;
                else
                {
                    if (grid[playingSheep.Row, playingSheep.Column] is Square)
                        returnValue = true;
                    else
                        returnValue = false;
                }
            }
            else
            {
                if (wolf.Row < 0 || wolf.Row >= grid.GetLength(0) || wolf.Column < 0 || wolf.Column >= grid.GetLength(1))
                    returnValue = false;
                else
                {
                    if (grid[wolf.Row, wolf.Column] is Square)
                        returnValue = true;
                    else
                        returnValue = false;
                }
            }
            return returnValue;
        }
    }
}
