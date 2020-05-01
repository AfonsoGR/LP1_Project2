﻿using System;

namespace Felli
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new GameRules
            GameRules gameRules = new GameRules();

            // Calls the GR method from GameRules
            gameRules.GR(); 

            // Creates a new Board with the given dimensions
            Board board = new Board(5, 5);

            // Renders the board
            Render(board);
        }

        private static void Render(Board board)
        {
            // Clears the console
            Console.Clear();

            // A loop for the width of the board
            for (int x = 0; x < board.SizeX; x++)
            {
                // If it's at the end of the line writes an extra vertical bar
                Console.Write("\n");
                // A loop for the height of the board
                for (int y = 0; y < board.SizeY; y++)
                {
                    Console.Write($"{board[x, y]}");
                }
            }
        }
    }
}
