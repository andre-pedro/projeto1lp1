using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Wolf
    {
        /// <summary>
        /// Name Property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Char Property.
        /// </summary>
        public char Char { get; set; }

        /// <summary>
        /// Column Property.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Row Property.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Direction Property.
        /// </summary>
        public Direction Direction { get; set; }

        public Wolf(
            string Name,
            char Char,
            int Column,
            int Row,
            Direction Direction)
        {
            // Build Player
            this.Name = Name;
            this.Char = Char;
            this.Column = Column;
            this.Row = Row;
            this.Direction = Direction;
        }

        /// <summary>
        /// Move method of Player. Moves the Player.
        /// </summary>
        public void Move()
        {
            // Move according to direction
            switch (Direction)
            {
                case Direction.Right:
                    Column++; // Add column
                    break;

                case Direction.Left:
                    Column--; // Subtract column
                    break;

                case Direction.Up:
                    Row--; // Add row
                    break;

                case Direction.Down:
                    Row++; // Subtract row
                    break;

                default:
                    break;
            }
        }

    }
}
