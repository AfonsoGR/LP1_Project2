using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    class GameLoop
    {
        private bool running;
        Renderer render;
        (Piece[] white, Piece[] black) piece;
        readonly string choiceMessage;
        private Board board;

        Player player1;
        Player player2;
        public GameLoop()
        {
            choiceMessage = "Which way do you wish to move the piece?\n" +
                    "We advise using the NUMPAD due to the layout.\n\n" +
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

            board = gameSetup.CreateBoard(5, 5);
            piece = gameSetup.CreatePieces(board);
            render = new Renderer(board, piece);

            render.Render("Who goes/plays first?"
                + "\n\t>> The Black pieces <<"
                + "\n\t>> The White pieces <<");

            ColorChoice firstToPlay = gameSetup.OrderSelection();

            if (firstToPlay == ColorChoice.White)
            {
                player1 = new Player(ColorChoice.White, piece.white);
                player2 = new Player(ColorChoice.Black, piece.black);
            }
            else
            {
                player1 = new Player(ColorChoice.Black, piece.black);
                player2 = new Player(ColorChoice.White, piece.white);
            }

            Update();
        }

        private void Update()
        {
            while (running)
            {
                GetChoice(player1);
                GetChoice(player2);

                render.Render("Press x if you want to quit now");

                char.TryParse(Console.ReadLine(), out char charr);
                if (charr == 'x')
                {
                    running = !running;
                }
            }
        }

        private void GetChoice(Player player)
        {
            string message = "inv";

            while (message != null)
            {
                render.Render(choiceMessage, player.colorChoice);
                message = player.playerPieces[0].PieceMovement();
                render.Render(message);

                if (message != null)
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
