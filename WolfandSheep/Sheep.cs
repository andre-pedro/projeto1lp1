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
        public int PreviousColumn { get; private set; }
        public int PreviousRow { get; private set; }
        public int Id { get; set; }

        public Sheep(int row, int column, int id)
        {
            // Build Player
            Row = row;
            Column = column;
            Id = id;
        }

        /// <summary>
        /// Move method of Player. Moves the Player.
        /// </summary>
        public void Move(Direction dir)
        {
            PreviousColumn = Column;
            PreviousRow = Row;

            // Move according to direction
            switch (dir)
            {
                case Direction.North:
                    Row -= 2;
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

        public void ResetMovement()
        {
            Row = PreviousRow;
            Column = PreviousColumn;
        }

    }
}
