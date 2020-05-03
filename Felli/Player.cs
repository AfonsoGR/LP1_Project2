using System;

namespace Felli
{
    /// <summary>
    /// 
    /// </summary>
    public class Player
    {
        public Piece[] playerPieces;
        public ColorChoice colorChoice;

        public Player(ColorChoice color, Piece[] pieces)
        {
            playerPieces = pieces;
            colorChoice = color; 
        }
    }
}