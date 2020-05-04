using System;
using System.Collections.Generic;

namespace Felli
{
    public class GameInstance
    {
        private readonly Board Board;
        private readonly List<Piece> blackPieces;
        private readonly List<Piece> whitePieces;

        public Player player1;
        public Player player2;

        public Renderer Graphics { get; private set; }

        public GameInstance(int x, int y)
        {
            Board = new Board(x, y);
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            Board.SetBoardToInitState();
            CreatePieces();

            Graphics = new Renderer(Board,
                (player1, player2));
        }

        private void CreatePieces()
        {
            int id = 1;

            for (int x = 0; x < Board.SizeX; x++)
            {
                if (x == Board.SizeX / 2)
                {
                    id = 1;
                }

                for (int y = 0; y < Board.SizeY; y++)
                {
                    if (Board[x, y] == ColorChoice.None && x < Board.SizeX / 2)
                    {
                        blackPieces.Add(new Piece
                            (ColorChoice.Black, Board, x, y, id));
                        id++;
                    }
                    if (Board[x, y] == ColorChoice.None && x > Board.SizeX / 2)
                    {
                        whitePieces.Add(new Piece
                            (ColorChoice.White, Board, x, y, id));
                        id++;
                    }
                }
            }
        }

        public void OrderSelection()
        {
            string orderChoice = null;

            while (!(orderChoice == "W") && !(orderChoice == "B"))
            {
                orderChoice = Console.ReadLine().ToUpper();
            }

            if ((ColorChoice)orderChoice[0] == ColorChoice.White)
            {
                player1 = new Player(ColorChoice.White, whitePieces.ToArray());
                player2 = new Player(ColorChoice.Black, blackPieces.ToArray());

                Graphics = new Renderer(Board,
                    (player1, player2));
            }
            else
            {
                player1 = new Player(ColorChoice.Black, blackPieces.ToArray());
                player2 = new Player(ColorChoice.White, whitePieces.ToArray());

                Graphics = new Renderer(Board,
                    (player2, player1));
            }

            player1.opositePlayer = player2;
            player2.opositePlayer = player1;
        }
    }
}