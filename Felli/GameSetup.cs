using System;
using System.Collections.Generic;

namespace Felli
{
    public class GameSetup
    {
        public (Piece[], Piece[]) CreatePieces(Board board)
        {
            List<Piece> blackPieces = new List<Piece>();

            List<Piece> whitePieces = new List<Piece>();

            int id = 1;

            for (int x = 0; x < board.SizeX; x++)
            {
                if (x == board.SizeX / 2) id = 1;

                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] == ColorChoice.None && x < board.SizeX / 2)
                    {
                        blackPieces.Add(new Piece
                            (ColorChoice.Black, board, x, y, id));
                        id++;
                    }
                    else if (board[x, y] == ColorChoice.None && x > board.SizeX / 2)
                    {
                        whitePieces.Add(new Piece
                            (ColorChoice.White, board, x, y, id));
                        id++;
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

        public ColorChoice OrderSelection()
        {
            char orderChoice = ' ';

            while (!(orderChoice == 'W') && !(orderChoice == 'B'))
            {
                orderChoice = Console.ReadLine().ToUpper()[0];
            }

            return (ColorChoice)orderChoice;
        }
    }
}