using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class GameManager
    {
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
            player = true;

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
            while (true)
            {
                b.Draw(grid);
                if (player == false)
                {
                    b.ShowMovementsText(player);
                }
                else
                {
                    while (input != "1" && input != "2" && input != "3" && input != "4")
                    {
                        b.ShowSelectSheepText();
                        input = Console.ReadLine();
                    }

                    SelectPlayingSheep(input);
                    b.ShowMovementsText(player);
                    Console.ReadKey();
                }
            }
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
    }
}
