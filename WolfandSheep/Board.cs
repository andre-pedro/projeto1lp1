using System;
using System.Collections.Generic;
using System.Text;

namespace WolfandSheep
{
    public class Board
    {
        /// <summary>
        /// Define a largura do tabuleiro
        /// </summary>
        private const byte width = 8;

        /// <summary>
        /// Define a altura do tabuleiro
        /// </summary>
        private const byte height = 8;

        public void Render()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("0 ");
                }

                Console.WriteLine();
            }
        }
    }
}
