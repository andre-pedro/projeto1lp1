using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Wolf
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

        public Wolf(int column, int row, Direction dir)
        {
            // Build Player
            Column = column;
            Row = row;
            Dir = dir;
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
                    Row--; // Add column
                    break;

                case Direction.South:
                    Row++; // Subtract column
                    break;

                case Direction.NorthEast:
                    Column++; // Add column
                    Row--;
                    break;

                case Direction.NorthWest:
                    Column--; // Subtract column
                    Row--;
                    break;

                case Direction.SouthEast:
                    Column++;
                    Row++; // Add row
                    break;

                case Direction.SouthWest:
                    Column--;
                    Row++; // Subtract row
                    break;

                default:
                    break;
            }
        }

    }
}
