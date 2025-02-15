﻿using System;
using System.Collections.Generic;

namespace Felli
{
    /// <summary>
    /// Creates the needed variables and stores them here
    /// </summary>
    public class GameInstance
    {
        // Variable to store the board
        private readonly Board board;

        // Stores the black pieces created
        private readonly List<Piece> blackPieces;

        // Stores the white pieces created
        private readonly List<Piece> whitePieces;

        /// <summary>
        /// The player that will play first
        /// </summary>
        public Player Player1 { get; private set; }

        /// <summary>
        /// The player that will play second
        /// </summary>
        public Player Player2 { get; private set; }

        /// <summary>
        /// Class used to render the board and messages
        /// </summary>
        public Renderer Graphics { get; private set; }

        /// <summary>
        /// A GameInstance that creates and stores a board, the players and
        /// the renderer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameInstance(int x, int y)
        {
            // Creates a new Board with the provided x and y dimensions
            board = new Board(x, y);
            // Creates a new list of black pieces
            blackPieces = new List<Piece>();
            // Creates a new list of white pieces
            whitePieces = new List<Piece>();

            // Set's the board to the initial state
            board.SetBoardToInitState();
            // Generates the pieces of both players
            CreatePieces();

            // Creates a new Renderer providing the players and the board
            Graphics = new Renderer(board, (Player1, Player2));
        }

        /// <summary>
        /// Creates and stores the pieces of both players
        /// </summary>
        private void CreatePieces()
        {
            // Starts the ID at 1
            int id = 1;

            // Loops through the board width
            for (int x = 0; x < board.SizeX; x++)
            {
                // Checks if the x is at the middle
                if (x == board.SizeX / 2)
                {
                    // resets the ID back to one
                    id = 1;
                }

                // Loops through the board height
                for (int y = 0; y < board.SizeY; y++)
                {
                    // Checks if there's no players and it's at the top half
                    if (board[x, y] == ColorChoice.None && x < board.SizeX / 2)
                    {
                        // Adds a new black players on the X and Y
                        // providing the ID
                        blackPieces.Add(new Piece
                            (ColorChoice.Black, board, x, y, id));
                        // Increments the ID by one;
                        id++;
                    }
                    if (board[x, y] == ColorChoice.None && x > board.SizeX / 2)
                    {
                        // Adds a new white players on the X and Y
                        // providing the ID
                        whitePieces.Add(new Piece
                            (ColorChoice.White, board, x, y, id));
                        // Increments the ID by one;
                        id++;
                    }
                }
            }
        }

        /// <summary>
        /// Select the color/player that plays first
        /// </summary>
        public void OrderSelection()
        {
            // Creates a string to store the color choice
            string orderChoice = null;

            // Checks input while it's not wither W or B
            while (!(orderChoice == "W") && !(orderChoice == "B"))
            {
                // Equals the string above to the input
                orderChoice = Console.ReadLine().ToUpper();
            }

            // Checks if the color chosen is white
            if ((ColorChoice)orderChoice[0] == ColorChoice.White)
            {
                // The first player is assigned the white pieces
                Player1 = new Player(ColorChoice.White, whitePieces.ToArray());
                // The second player is assigned the black pieces
                Player2 = new Player(ColorChoice.Black, blackPieces.ToArray());

                // Creates a new render with the new players
                Graphics = new Renderer(board, (Player1, Player2));
            }
            else
            {
                // The first player is assigned the black pieces
                Player1 = new Player(ColorChoice.Black, blackPieces.ToArray());
                // The second player is assigned the white pieces
                Player2 = new Player(ColorChoice.White, whitePieces.ToArray());

                // Creates a new render with the new players
                Graphics = new Renderer(board, (Player2, Player1));
            }
        }
    }
}