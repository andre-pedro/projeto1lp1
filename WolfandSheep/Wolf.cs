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

        public Wolf(int row, int column)
        {
            // Build Player
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Move method of Player. Moves the Player.
        /// </summary>
        public void Move(Direction dir)
        {
            // Move according to direction
            switch (dir)
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
