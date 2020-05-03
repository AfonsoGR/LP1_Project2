using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    public class GameSetup
    {
        public (Pieces[], Pieces[]) CreatePieces(Board board)
        {
            List<Pieces> blackPieces = new List<Pieces>();

            List<Pieces> whitePieces = new List<Pieces>();

            for (int x = 0; x < board.SizeX; x++)
            {
                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] == 'o' && x < board.SizeX / 2)
                    {
                        blackPieces.Add(new Pieces('B', board, x, y));
                    }
                    else if (board[x, y] == 'o' && x > board.SizeX / 2)
                    {
                        whitePieces.Add(new Pieces('W', board, x, y));
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
