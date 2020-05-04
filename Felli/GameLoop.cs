using System;

namespace Felli
{
    internal class GameLoop
    {
        private readonly bool running;
        private readonly string choiceMessage;
        private readonly GameInstance game;

        public GameLoop()
        {
            choiceMessage = "Which way do you wish to move the piece?\n" +
                    "We advise using the NUMPAD due to the layout.\n\n" +
                    "|7 -> Top Left |\t\t|8 ->    Top    |\t" +
                    "\t|9 ->   TopRight   |\n" +
                    "|4 ->   Left   |\t\t|  YOUR PIECE   |\t" +
                    "\t|6 ->    Right     |\n" +
                    "|1 -> Bot Left |\t\t|2 ->  Bottom   |\t" +
                    "\t|3 -> Bottom Right |\n (press 0 to choose another piece";
            running = true;
            game = new GameInstance(5, 5);
        }

        public void Start()
        {
            game.Graphics.Render("Do you wish to read the rules?" +
                "\n Press Y to do so or anyother key to skip");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                // Creates a new GameRules
                GameRules rules = new GameRules();
                rules.GR(game.Graphics);
            }

            game.Graphics.Render("Who goes/plays first?"
                + "\n\t>> The Black pieces <<"
                + "\n\t>> The White pieces <<");

            game.OrderSelection();
            Update();
        }

        private void Update()
        {
            while (running)
            {
                GetChoice(game.player1);
                GetChoice(game.player2);

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
                game.Graphics.Render($"{player.colorChoice}s turn \n " +
                    $"Choose the piece you want to move 1 - " +
                    $"{player.playerPieces.Length}", player.colorChoice);

                int pieceChoice;
                while (!int.TryParse(Console.ReadLine(), out pieceChoice)
                    || pieceChoice < 1 || pieceChoice >
                    player.playerPieces.Length)
                {
                    game.Graphics.Render($"{player.colorChoice}s turn \n " +
                        $"Choose the piece you want to move 1 - " +
                        $"{player.playerPieces.Length}", player.colorChoice);
                }

                game.Graphics.Render(choiceMessage);
                message = player.MovePiece(pieceChoice);
                game.Graphics.Render(message);

                if (message != null)
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
