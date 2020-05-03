using System;

namespace Felli
{
    /// <summary>
    /// 
    /// </summary>
    public class Player
    {
        public Piece[] playerPieces;
        public Player(ColorChoice color, Piece[] pieces)
        {
            playerPieces = pieces;
            ColorChoice colorChoice = color; 
        }
    }
}