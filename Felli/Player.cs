using System;

namespace Felli
{
    /// <summary>
    /// 
    /// </summary>
    public class Player
    {
        public Piece[] playerPieces;
        public ColorChoice ColorChoice { get; }
        public Player opositePlayer;

        public Player(ColorChoice color, Piece[] pieces)
        {
            playerPieces = pieces;
            ColorChoice = color;
        }

        public string MovePiece(int pieceChoice)
        {
            for (int i = 0; i < playerPieces.Length; i++)
            {
                if (pieceChoice == playerPieces[i].id)
                {
                    int moveChoice;

                    while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                         moveChoice < 0 || moveChoice > 9 || moveChoice == 5)
                    {
                        ;
                    }
                    return playerPieces[i].PieceMovement(opositePlayer, moveChoice);
                }
            }
            return "That piece no longer exists";
        }
    }
}