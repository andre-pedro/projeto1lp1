using System;
using System.Runtime.InteropServices;

namespace WolfandSheep
{
    class Program
    {
        /// <summary>
        /// Define a largura do tabuleiro
        /// </summary>
        private const byte width = 8;

        /// <summary>
        /// Define a altura do tabuleiro
        /// </summary>
        private const byte height = 8;

        /// <summary>
        /// Array bidimensional que cria um tabuleiro com largura e altura
        /// </summary>
        private static byte[,] board = new byte[width, height];

        /// <summary>
        /// Instancia posição do player em X (horizontal)
        /// </summary>
        private static byte playerPosX = 3;

        /// <summary>
        /// Instancia posição do player em Y (vertical)
        /// </summary>
        private static byte playerPosY = 0;

        static void Main(string[] args)
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
