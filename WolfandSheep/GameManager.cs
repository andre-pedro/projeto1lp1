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

            foreach(Tile sq in Grid)
            {
                sq.Type = TileType.Empty;
            }

            b.Draw(Grid);
        }

        public void SpawnSheep()
        {
            Grid[7, 0].Type = TileType.Sheep;
        }
    }
}
