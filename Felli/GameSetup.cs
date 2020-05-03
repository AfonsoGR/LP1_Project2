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

        public void PieceSelection((Piece[] white, Piece[] black) pieces)
        {
            Console.WriteLine("There will be 2 players, choose amongst "
                + "you who will be Player 1 and Player 2. "
                + "Player 1 will choose his pieces first.\n"
                + "Player 1 choose which pieces you want to use:"
                + "\n\t>> Press B for the Black pieces <<"
                + "\n\t>> Press W for the White pieces <<");

            string pieceChoice = null;

            while (pieceChoice != "w" || pieceChoice != "b") 
            {
                pieceChoice = Console.ReadLine();
            }

            pieceChoice.ToLower();

            if (pieceChoice == "b")
            {
                Console.WriteLine(">> Player 1 will control the Black pieces\n"
                + ">> Player 2 will control the White pieces\n");

                Player player = new Player((ColorChoice)1, pieces.black);
            }
            else if (pieceChoice == "w")
            {
                Console.WriteLine(">> Player 1 will control the White pieces\n"
                + ">> Player 2 will control the Black pieces\n");

                Player player = new Player((ColorChoice)2, pieces.white);
            }
        }

        public void OrderSelection()
        {
            Console.WriteLine("Who goes/plays first?"
                + "\n\t>> The Black pieces <<"
                + "\n\t>> The White pieces <<");

            string orderChoice = null;

            while (orderChoice != "w" || orderChoice != "b")
            {
                orderChoice = Console.ReadLine();
            }

            if (orderChoice == "w")
            {
                Console.WriteLine("Player 1 will go/play first.");
            }
            else if (orderChoice == "b")
            {
                Console.WriteLine("Player 2 will go/play first.");
            }
        }
    }
}