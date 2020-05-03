using System;

namespace Felli
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new GameRules
            GameRules gameRules = new GameRules();

            // Calls the GR method from GameRules
            gameRules.GR(); 

            // Creates a new Board with the given dimensions
            Board board = new Board(5, 5);

            Renderer r = new Renderer(board);
            GameSetup game = new GameSetup();

            (Pieces[] white, Pieces[] black) pieces = game.SetupPieces(board);

            foreach(Pieces a in pieces.white)
            {
                a.PieceOnBoard(board);
            }
            foreach (Pieces a in pieces.black)
            {
                a.PieceOnBoard(board);
            }

            while (true)
            {

                r.Render();
                pieces.white[0].PieceMovement(board);
                pieces.white[0].PieceOnBoard(board);
            }
        }
    }
}
