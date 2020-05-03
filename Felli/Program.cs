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

            GameSetup game = new GameSetup();

            Board board = game.CreateBoard(5, 5);
            (Pieces[] white, Pieces[] black) pieces = game.CreatePieces(board);
            Renderer r = new Renderer(board, pieces);

            while (true)
            {
                r.Render();
                pieces.white[0].PieceMovement();
            }
        }
    }
}
