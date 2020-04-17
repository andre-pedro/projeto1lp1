
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

        /// <summary>
        /// Previous column position
        /// </summary>
        public int PreviousColumn { get; private set; }

        /// <summary>
        /// Previous row position
        /// </summary>
        public int PreviousRow { get; private set; }

        /// <summary>
        /// Sheep unic Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Create Sheep values
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="id"></param>
        public Sheep(int row, int column, int id)
        {
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

        /// <summary>
        /// Undo the last move made (sheep)
        /// </summary>
        public void ResetMovement()
        {
            Row = PreviousRow;
            Column = PreviousColumn;
        }

    }
}
