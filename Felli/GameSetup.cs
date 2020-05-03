using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    public class GameSetup
    {
        public (Piece[], Piece[]) CreatePieces(Board board)
        {
            List<Piece> blackPieces = new List<Piece>();

            List<Piece> whitePieces = new List<Piece>();

            for (int x = 0; x < board.SizeX; x++)
            {
                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] == 'o' && x < board.SizeX / 2)
                    {
                        blackPieces.Add(new Piece('B', board, x, y));
                    }
                    else if (board[x, y] == 'o' && x > board.SizeX / 2)
                    {
                        whitePieces.Add(new Piece('W', board, x, y));
                    }
                }
            }
            return (whitePieces.ToArray(), blackPieces.ToArray());
        }
        public Board CreateBoard(int x, int y)
        {
            Board board = new Board(x, y);
            board.SetBoardToInitState();

            return board;
        }
    }

}
