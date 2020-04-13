using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    class Wolf
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

        public Wolf(
        string Name,
        char Char,
        int Column,
        int Row)
        {
            // Build Player
            this.Name = Name;
            this.Char = Char;
            this.Column = Column;
            this.Row = Row;
        }
        
        public void Move(int[,] Grid)
        {
            Render render = new Render();

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = 0;
                }
            }
            render.Draw(Grid);
        }

    }
}
