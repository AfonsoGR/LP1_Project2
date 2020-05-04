using System;

namespace Felli
{
    internal class GameLoop
    {
        private readonly bool running;
        private Renderer render;
        private (Piece[] white, Piece[] black) piece;
        private readonly string choiceMessage;
        private Board board;
        private Player player1;
        private Player player2;

        public GameLoop()
        {
            choiceMessage = "Which way do you wish to move the piece?\n" +
                    "We advise using the NUMPAD due to the layout.\n\n" +
                    "|7 -> Top Left |\t\t|8 ->    Top    |\t" +
                    "\t|9 ->   TopRight   |\n" +
                    "|4 ->   Left   |\t\t|  YOUR PIECE   |\t" +
                    "\t|6 ->    Right     |\n" +
                    "|1 -> Bot Left |\t\t|2 ->  Bottom   |\t" +
                    "\t|3 -> Bottom Right |\n\n" +
                    ">> Press 0 to choose another piece <<";
            running = true;
        }

        public void Start()
        {
            GameSetup gameSetup = new GameSetup();

            board = gameSetup.CreateBoard(5, 5);
            piece = gameSetup.CreatePieces(board);
            render = new Renderer(board, piece);

            render.Render("Who goes/plays first?"
                + "\n\t>> For the Black pieces press B <<"
                + "\n\t>> For the White pieces press W <<");

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

                //render.Render("Press x if you want to quit now");

                //char.TryParse(Console.ReadLine(), out char charr);
                //if (charr == 'x')
                //{
                //    running = !running;
                //}
            }
        }

        private void GetChoice(Player player)
        {
            string message = "inv";

            while (message != null)
            {
                render.Render($"{player.colorChoice}s turn \n " +
                    $"Choose the piece you want to move 1 - " +
                    $"{player.playerPieces.Length}", player.colorChoice);

                int pieceChoice;
                while (!int.TryParse(Console.ReadLine(), out pieceChoice)
                    || pieceChoice < 1 || pieceChoice >
                    player.playerPieces.Length)
                {
                    render.Render($"{player.colorChoice}s turn \n " +
                        $"Choose the piece you want to move 1 - " +
                        $"{player.playerPieces.Length}", player.colorChoice);
                }

                render.Render(choiceMessage);
                message = player.MovePiece(pieceChoice);
                render.Render(message);

                if (message != null)
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
