using System;

namespace Felli
{
    internal class GameLoop
    {
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
                    "\t|3 -> Bottom Right |\n\n" +
                    ">> Press 0 to choose another piece <<";
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
                + "\n\t>> For the Black pieces press B <<"
                + "\n\t>> For the White pieces press W <<");

            game.OrderSelection();
            Update();
        }

        private void Update()
        {
            WinConditions win = new WinConditions();
            while (true)
            {
                GetChoice(game.player1);

                if (win.WinCheck(game.player2) != ColorChoice.None)
                {
                    break;
                }

                GetChoice(game.player2);

                if (win.WinCheck(game.player1) != ColorChoice.None)
                {
                    break;
                }
            }
        }

        private void GetChoice(Player player)
        {
            string message = "inv";

            while (message != null)
            {
                game.Graphics.Render($"{player.ColorChoice}s turn \n " +
                    $"Choose the piece you want to move", player.ColorChoice);

                int pieceChoice;
                while (!int.TryParse(Console.ReadLine(), out pieceChoice)
                    || pieceChoice < 1 || pieceChoice > 6)
                {
                    game.Graphics.Render($"{player.ColorChoice}s turn \n " +
                        $"Choose the piece you want to move",
                        player.ColorChoice);
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
