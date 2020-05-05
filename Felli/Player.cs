using System;

namespace Felli
{
    /// <summary>
    /// A player containing its color, pieces and choosing the piece to move
    /// </summary>
    public class Player
    {
        // Stores the pieces of that player
        public Piece[] playerPieces;
        // Stores the oponent
        public Player opositePlayer;
        // Stores the color of this player
        public ColorChoice ColorChoice { get; }

        /// <summary>
        /// Creates a new player with a color a piece array
        /// </summary>
        /// <param name="color"> The color of the player </param>
        /// <param name="pieces"> An array of pieces </param>
        public Player(ColorChoice color, Piece[] pieces)
        {
            // Sets the playerPieces the array received
            playerPieces = pieces;
            // Sets the color to the color received
            ColorChoice = color;
        }

        /// <summary>
        /// Moves the piece that matched the ID provided
        /// </summary>
        /// <param name="pieceChoice"> ID of the piece wanted </param>
        /// <returns> A string message </returns>
        public string MovePiece(int pieceChoice)
        {
            // Checks all of the player pieces
            for (int i = 0; i < playerPieces.Length; i++)
            {
                // Checks if any of the pieces matches the ID
                if (pieceChoice == playerPieces[i].ID)
                {
                    // Stores the move choice of the player
                    int moveChoice;

                    // Looks for input while it's not a expected one
                    while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                         moveChoice < 0 || moveChoice > 9 || moveChoice == 5)
                    {
                        ;
                    }
                    // Returns the message provided by the piece movement
                    return playerPieces[i].PieceMovement
                        (opositePlayer, moveChoice);
                }
            }
            // Not used, only in case of bug
            return "That piece no longer exists";
        }
    }
}