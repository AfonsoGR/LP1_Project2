using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    class Renderer
    {
        private readonly Board board;
        private string[,] boardPieces;
        public Renderer(Board board)
        {
            boardPieces = new string[5, 5];
            this.board = board;
        }
        public void Render()
        {
            // Clears the console
            Console.Clear();

            int l = board.SizeX - board.SizeX / 2;
            int z = -1;

            // A loop for the width of the board
            for (int x = 0; x < board.SizeX; x++)
            {
                Console.Write("\n");

                int nLines = 0;

                if (x <= board.SizeX / 2) l--;
                else l++;

                if (x <= board.SizeX / 2) z++;
                else z--;

                if (x == board.SizeX / 2)
                {
                    Console.Write(" ");
                }

                for (int p = 0; p < z; p++)
                {
                    Console.Write(" ");
                }

                // A loop for the height of the board
                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] != default)
                    {
                        Console.Write($"{board[x, y]}");

                        if (nLines < 2)
                        {
                            nLines++;
                            for (int o = 0; o < l; o++)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                }

                //if (x < board.SizeX / 2)
                //{
                //    Console.Write("\n");
                //    Console.Write(@"\");
                //    for (int o = 0; o < l; o++)
                //    {
                //        Console.Write(" ");
                //    }

                //    Console.Write("|");
                //    for (int o = 0; o < l; o++)
                //    {
                //        Console.Write(" ");
                //    }

                //    Console.Write("/");
                //}
                //else
                //{
                //    Console.Write("\n");
                //    Console.Write(@"/");
                //    for (int o = 0; o < l; o++)
                //    {
                //        Console.Write(" ");
                //    }

                //    Console.Write("|");
                //    for (int o = 0; o < l; o++)
                //    {
                //        Console.Write(" ");
                //    }

                //    Console.Write(@"\");
                //}
            }
        }
    }
}
