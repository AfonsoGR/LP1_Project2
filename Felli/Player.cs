using System;

namespace Felli
{
    /// <summary>
    /// A player containing its color, pieces and choosing the players to move
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Stores the pieces of that player
        /// </summary>
        public Piece[] playerPieces;

        /// <summary>
        /// Stores the color of this player
        /// </summary>
        public ColorChoice ColorChoice { get; }

        /// <summary>
        /// Creates a new player with a color a players array
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
        /// Moves the players that matched the ID provided
        /// </summary>
        /// <param name="pieceChoice"> ID of the players wanted </param>
        /// <returns> A string message </returns>
        public string MovePiece(int pieceChoice, Player opositePlayer)
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
                    // Returns the message provided by the players movement
                    return playerPieces[i].PieceMovement
                        (opositePlayer, moveChoice);
                }
            }
            // Not used, only in case of bug
            return "That players no longer exists";
        }
    }
}