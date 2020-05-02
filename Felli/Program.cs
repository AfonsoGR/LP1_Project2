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
            Renderer r = new Renderer(board);
            r.Render();

            Position pos = new Position(1, 2);

            Console.WriteLine(pos.ToString());
            pos += (1, 1);

            Console.WriteLine(pos.ToString());
        }
    }
}
