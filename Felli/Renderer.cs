﻿using System;

namespace Felli
{
    class Renderer
    {
        private readonly Board board;
        private readonly string[] connectors;

        public Renderer(Board board)
        {
            connectors = new string[6] { @"\", "|", "/", "/", "|", @"\" };
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

                if (x <= board.SizeX / 2)
                {
                    l--;
                    z++;
                }
                else
                {
                    l++;
                    z--;
                }

                DrawSpaces(l, x, z);

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
                DrawConnectors(x);
            }
        }

        private void DrawSpaces(int l, int x, int z)
        {
            if (x == board.SizeX / 2)
            {
                Console.Write(" ");
            }

            for (int p = 0; p < z; p++)
            {
                Console.Write(" ");
            }
        }

        private void DrawConnectors(int x)
        {
            Console.Write("\n");

            int ç = x < board.SizeX / 2 ? 0 : 3;

            for (int y = 0; y < board.SizeY; y++)
            {
                if (x < board.SizeX / 2)
                {
                    if (board[x, y] != default)
                    {
                        Console.Write(connectors[ç]); ç++;
                    }
                    else
                        Console.Write("  ");
                }
                else if (x + 1 < board.SizeX && x >= board.SizeX / 2)
                {
                    if (board[x + 1, y] != default)
                    {
                        Console.Write(connectors[ç]); ç++;
                    }
                    else
                        Console.Write("  ");
                }
            }
        }
    }
}