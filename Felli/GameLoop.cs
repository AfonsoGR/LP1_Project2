using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    class GameLoop
    {
        private bool running;
        Renderer render;
        (Pieces[] white, Pieces[] black) pieces;
        string choiceMessage;
        public GameLoop()
        {
            choiceMessage = "Which way do you wish to move the piece?\n\n" +
                    "|7 -> Top Left |\t\t|8 ->    Top    |\t" +
                    "\t|9 ->   TopRight   |\n" +
                    "|4 ->   Left   |\t\t|  YOUR PIECE   |\t" +
                    "\t|6 ->    Right     |\n" +
                    "|1 -> Bot Left |\t\t|2 ->  Bottom   |\t" +
                    "\t|3 -> Bottom Right |\n";
            running = true;
        }

        public void Start()
        {
            GameSetup gameSetup = new GameSetup();

            Board board = gameSetup.CreateBoard(5, 5);
            pieces = gameSetup.CreatePieces(board);
            render = new Renderer(board, pieces);

            Update();
        }
        private void Update()
        {
            while (running)
            {
                GetChoice();

                render.Render("Press x if you want to quit now");

                char.TryParse(Console.ReadLine(), out char charr);
                if (charr == 'x')
                {
                    running = !running;
                }
            }
        }
        private void GetChoice()
        {
            string message = "inv";

            while (message != null)
            {
                render.Render(choiceMessage);
                message = pieces.white[0].PieceMovement();
                render.Render(message);

                if (message != null)
                {
                    Console.ReadKey();
                    GetChoice();
                }
            }
        }
    }
}
