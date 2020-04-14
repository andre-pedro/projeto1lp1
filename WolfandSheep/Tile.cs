using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Tile
    {
        public TileType Type { get; set; }

        /// <summary>
        /// Creates Tile Constructor
        /// </summary>
        public Tile(TileType type)
        {
            Type = type;
        }
    }
}
