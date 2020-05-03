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

            for (int x = 0; x < board.SizeX; x++)
            {
                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] == ColorChoice.None && x < board.SizeX / 2)
                    {
                        blackPieces.Add(new Piece(ColorChoice.Black, board, x, y));
                    }
                    else if (board[x, y] == ColorChoice.None && x > board.SizeX / 2)
                    {
                        whitePieces.Add(new Piece(ColorChoice.White, board, x, y));
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

            while (orderChoice != 'W' || orderChoice != 'B')
            {
                orderChoice = Console.ReadLine().ToUpper()[0];
            }

            return (ColorChoice)orderChoice;
        }

        //public (Player, Player) PieceSelection((Piece[] white, Piece[] black) pieces)
        //{
        //    Console.WriteLine("There will be 2 players, choose amongst "
        //        + "you who will be Player 1 and Player 2. "
        //        + "Player 1 will choose his pieces first.\n"
        //        + "Player 1 choose which pieces you want to use:"
        //        + "\n\t>> Press B for the Black pieces <<"
        //        + "\n\t>> Press W for the White pieces <<");

        //    char pieceChoice = ' ';

        //    while (pieceChoice != 'W' || pieceChoice != 'B')
        //    {
        //        pieceChoice = Console.ReadLine().ToUpper()[0];
        //    }

        //    if (pieceChoice == 'B')
        //    {
        //        Console.WriteLine(">> Player 1 will control the Black pieces\n"
        //        + ">> Player 2 will control the White pieces\n");

        //        return (new Player((ColorChoice)pieceChoice, pieces.black), 
        //            new Player((ColorChoice)pieceChoice, pieces.white));
        //    }
        //    else if (pieceChoice == 'W')
        //    {
        //        Console.WriteLine(">> Player 1 will control the White pieces\n"
        //        + ">> Player 2 will control the Black pieces\n");

        //        return (new Player((ColorChoice)pieceChoice, pieces.white), 
        //            new Player((ColorChoice)pieceChoice, pieces.black));
        //    }
        //}
    }
}