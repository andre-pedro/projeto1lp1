using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class GameManager
    {
        private int[,] Position { get; } = new int[0, 4];
        private Tile[,] grid = new Tile[8, 8];

        private Render b;

        public GameManager(Render b)
        {
            this.b = b;

            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Tile(TileType.Empty);
                }
            }
            SpawnEntities();

            b.Draw(grid);
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
            grid[7, 0].Type = TileType.Sheep;
            grid[7, 2].Type = TileType.Sheep;
            grid[7, 4].Type = TileType.Sheep;
            grid[7, 6].Type = TileType.Sheep;



        }
    }
}
