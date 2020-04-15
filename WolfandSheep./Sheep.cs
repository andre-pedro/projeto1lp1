using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Sheep
    {
        /// <summary>
        /// Column Property.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Row Property.
        /// </summary>
        public int Row { get; set; }

        public Direction Dir { get; set; }

        public int Id { get; set; }

        public Sheep(int column, int row, Direction dir, int id)
        {
            // Build Player
            Column = column;
            Row = row;
            Dir = dir;
            Id = id;
        }

        /// <summary>
        /// Move method of Player. Moves the Player.
        /// </summary>
        public void Move()
        {
            // Move according to direction
            switch (Dir)
            {
                case Direction.North:
                    Row--; 
                    break;

                case Direction.NorthEast:
                    Column++; 
                    Row--;
                    break;

                case Direction.NorthWest:
                    Column--; 
                    Row--;
                    break;

                default:
                    break;
            }
        }

    }
}
