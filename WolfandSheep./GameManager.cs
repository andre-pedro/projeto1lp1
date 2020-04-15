using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class GameManager
    {
        private int[,] Position { get; } = new int[0, 4];
        private Tile[,] grid = new Tile[8, 8];
        private bool player;

        private Render b;

        public GameManager(Render b)
        {
            this.b = b;
            player = true;

            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Tile(TileType.Empty);
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

            grid[0, num].Type = TileType.Wolf;
            grid[7, 0].Type = TileType.Sheep1;
            grid[7, 2].Type = TileType.Sheep2;
            grid[7, 4].Type = TileType.Sheep3;
            grid[7, 6].Type = TileType.Sheep4;

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

                }
            }
        }
    }
}
