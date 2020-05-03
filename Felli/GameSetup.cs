using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    public class GameSetup
    {
        private List<Pieces> blackPieces;
        private List<Pieces> whitePieces;

        public GameSetup()
        {
            blackPieces = new List<Pieces>();
            whitePieces = new List<Pieces>();
        }
        public (Pieces[], Pieces[]) SetupPieces(Board board)
        {
            for (int x = 0; x < board.SizeX; x++)
            {
                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] == 'o' && x < board.SizeX / 2)
                    {
                        blackPieces.Add(new Pieces('B', x, y));
                    }
                    else if (board[x, y] == 'o' && x > board.SizeX / 2)
                    {
                        whitePieces.Add(new Pieces('W', x, y));
                    }
                }
            }
            return (whitePieces.ToArray(), blackPieces.ToArray());
        }
    }

}
