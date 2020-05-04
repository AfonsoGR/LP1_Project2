namespace Felli
{
    /// <summary>
    /// 
    /// </summary>
    public class Player
    {
        public Piece[] playerPieces;
        public ColorChoice colorChoice;
        public Player opositePlayer;

        public Player(ColorChoice color, Piece[] pieces, Player other)
        {
            opositePlayer = other;
            playerPieces = pieces;
            colorChoice = color;
        }

        public string MovePiece(int pieceChoice)
        {
            for (int i = 0; i < playerPieces.Length; i++)
            {
                if (pieceChoice == playerPieces[i].id)
                {
                    return playerPieces[i].PieceMovement(opositePlayer);
                }
            }
            return null;
        }
    }
}