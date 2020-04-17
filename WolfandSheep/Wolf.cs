
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

        /// <summary>
        /// Previous column position 
        /// </summary>
        public int PreviousColumn { get; private set; }

        /// <summary>
        /// Previous row position
        /// </summary>
        public int PreviousRow { get; private set; }

        /// <summary>
        /// Create Wolf values
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Wolf(int row, int column)
        {
            Row = row;
            Column = column;
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

        /// <summary>
        /// Undo the last move made (wolf)
        /// </summary>
        public void ResetMovement()
        {
            Row = PreviousRow;
            Column = PreviousColumn;
        }

    }
}
