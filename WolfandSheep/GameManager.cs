using System;

namespace WolfandSheep
{
    public class GameManager
    {
        /// <summary>
        /// Bidimensional object array that holds the game objects 
        /// </summary>
        private object[,] grid = new object[8, 8];
        private bool player;
        private Wolf wolf;
        private Sheep sheep1;
        private Sheep sheep2;
        private Sheep sheep3;
        private Sheep sheep4;
        private Sheep playingSheep;
        private Render r;

        /// <summary>
        /// Game manager constructor & game startup
        /// </summary>
        /// <param name="r"></param>
        public GameManager(Render r)
        {
            this.r = r;
            player = false;

            //Cycle through the bidimensional array
            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    //populate the grid with the square objects 
                    grid[i, j] = new Square();
                }
            }
            SpawnEntities();

            GameLoop();
        }

        /// <summary>
        /// Spawn of the entities in the grid
        /// </summary>
        private void SpawnEntities()
        {
            Random rand = new Random();
            int num = 0;

            //Check if random is odd to spawn sheep in the desired position 
            while (num % 2 == 0)
            {
                num = rand.Next(1, 8);
            }

            //Spawn the wolf in the random position
            grid[0, num] = new Wolf(0, num);
            //Spawn the sheep
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

        /// <summary>
        /// Accepts user input and converts it into a game action
        /// </summary>
        private void GameLoop()
        {
            string input = null;

            // Infinite Game Loop
            while (true)
            {
                Console.Clear();
                // If wolf is playing
                if (player == false)
                {
                    //While the input is different from the possible moves
                    while (input != "7" && input != "9" && input != "1" && input != "3" && input != "s")
                    {
                        Console.Clear();
                        r.Draw(grid);
                        r.ShowMovementsText(player);
                        input = Console.ReadLine();

                        //If a movement is chosen  
                        if (input == "7" || input == "9" || input == "1" || input == "3")
                        {
                            //Convert input to Int and pass it as a direction  
                            wolf.Move((Direction)Convert.ToInt32(input));
                            //If Wolf movement is valid
                            if (CheckValidMovement(wolf))
                            {
                                //Previous Wolf positions in the grid become a square
                                grid[wolf.PreviousRow, wolf.PreviousColumn] = grid[wolf.Row, wolf.Column];
                                //The desired position receives the Wolf
                                grid[wolf.Row, wolf.Column] = wolf;
                            }
                            else
                            {
                                wolf.ResetMovement();
                                r.ShowInvalidMovementText();
                                input = null;
                            }
                        }
                    }
                    input = null;
                    //Switch player
                    player = !player;
                }
                // If sheep is playing
                else
                {
                    //While the input is different from the possible choices 
                    while (input != "1" && input != "2" && input != "3" && input != "4")
                    {
                        Console.Clear();
                        r.Draw(grid);
                        r.ShowSelectSheepText();
                        input = Console.ReadLine();
                    }

                    SelectPlayingSheep(input);
                    input = null;

                    //While the input is different from the possible moves
                    while (input != "7" && input != "9" && input != "s")
                    {
                        Console.Clear();
                        r.Draw(grid);
                        r.ShowMovementsText(player);
                        input = Console.ReadLine();

                        if (input == "7" || input == "9")
                        {
                            //Convert input to Int and pass it as a direction 
                            playingSheep.Move((Direction)Convert.ToInt32(input));
                            //If Sheep movement is valid
                            if (CheckValidMovement(playingSheep))
                            {
                                //Previous Sheep positions in the grid become a square
                                grid[playingSheep.PreviousRow, playingSheep.PreviousColumn] = grid[playingSheep.Row, playingSheep.Column];
                                //The desired position receives the Sheep
                                grid[playingSheep.Row, playingSheep.Column] = playingSheep;
                            }
                            else
                            {
                                playingSheep.ResetMovement();
                                r.ShowInvalidMovementText();
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

        /// <summary>
        /// Wolf and Sheep victory condition verification 
        /// </summary>
        /// <returns></returns>
        private bool CheckWin()
        {
            bool returnVal = false;

            //Check if wolf won
            if (wolf.Row == grid.GetLength(0) - 1)
            {
                returnVal = true;
                r.ShowWolfWinMessage();
            }
            //Check if sheep won
            else if (IsWolfSurrounded())
            {
                returnVal = true;
                r.ShowSheepWinMessage();
            }

            return returnVal;
        }

        /// <summary>
        /// Verification of the Wolf player's movement (if he's surrounded)
        /// </summary>
        /// <returns></returns>
        private bool IsWolfSurrounded()
        {
            bool returnVal = false;
            //Wolf's surroundings 
            bool northeast = false;
            bool northwest = false;
            bool southeast = false;
            bool southwest = false;

            //Move wolf to desired position 
            wolf.Move(Direction.NorthEast);
            //If movement is invalid, surrounding var is true 
            if (!CheckValidMovement(wolf))
            {
                northeast = true;
            }
            //Reset wolf position 
            wolf.ResetMovement();

            //Move wolf to desired position 
            wolf.Move(Direction.NorthWest);
            //If movement is invalid, surrounding var is true 
            if (!CheckValidMovement(wolf))
            {
                northwest = true;
            }
            //Reset wolf position 
            wolf.ResetMovement();

            //Move wolf to desired position 
            wolf.Move(Direction.SouthEast);
            //If movement is invalid, surrounding var is true 
            if (!CheckValidMovement(wolf))
            {
                southeast = true;
            }
            //Reset wolf position 
            wolf.ResetMovement();

            //Move wolf to desired position 
            wolf.Move(Direction.SouthWest);
            //If movement is invalid, surrounding var is true 
            if (!CheckValidMovement(wolf))
            {
                southwest = true;
            }
            //Reset wolf position 
            wolf.ResetMovement();

            //If all surroundings are block, movement is invalid
            if (northeast == true && northwest == true && southeast == true && southwest == true)
            {
                returnVal = true;
            }
            return returnVal;
        }

        /// <summary>
        /// Choice of sheep for movement
        /// </summary>
        /// <param name="input"></param>
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


        /// <summary>
        /// Verification of valid movements within the board
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CheckValidMovement(object obj)
        {
            bool returnValue = false;

            if (obj is Sheep)
            {
                // Check if outside of board bounds(sheep)
                if (playingSheep.Row < 0 || playingSheep.Row >= grid.GetLength(0) || playingSheep.Column < 0 || playingSheep.Column >= grid.GetLength(1))
                    returnValue = false;
                else
                {
                    //If desired position is empty, return true
                    if (grid[playingSheep.Row, playingSheep.Column] is Square)
                        returnValue = true;
                    else
                        returnValue = false;
                }
            }
            else
            {
                // Check if outside of board bounds(wolf)
                if (wolf.Row < 0 || wolf.Row >= grid.GetLength(0) || wolf.Column < 0 || wolf.Column >= grid.GetLength(1))
                    returnValue = false;
                else
                {
                    //If desired position is empty, return true
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
