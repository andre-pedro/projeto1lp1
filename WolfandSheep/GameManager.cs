using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class GameManager
    {
        private int[,] Position { get; } = new int[0, 4];
        private Tile[,] Grid { get; } = new Tile[8, 8];

        private Render b;

        public GameManager(Render b)
        {
            this.b = b;

            foreach (Tile tile in Grid)
            {
                tile.Type = TileType.Empty;
            }
            SpawnEntities();

            b.Draw(Grid);
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

            Grid[0, num].Type = TileType.Wolf;
            Grid[7, 0].Type = TileType.Sheep;
            Grid[7, 2].Type = TileType.Sheep;
            Grid[7, 4].Type = TileType.Sheep;
            Grid[7, 6].Type = TileType.Sheep;



        }
    }
}
