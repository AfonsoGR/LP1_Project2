using System;

namespace Felli
{
    /// <summary>
    /// Class containing the main loop of the game
    /// </summary>
    public class GameLoop
    {
        // Stores a string for the message for each players decision
        private readonly string choiceMessage;
        // Creates a GameInstace of the game
        private readonly GameInstance game;
        // Creates an instance of the win checker
        private readonly WinConditions win;
        // Number of pieces on the board for a player at the start
        private int maxPieceN;

        /// <summary>
        /// Constructor of the GameLoop class
        /// </summary>
        public GameLoop()
        {
            // Assigns a message to the choiceMessage string
            choiceMessage = "Which way do you wish to move the players?\n" +
                    "We advise using the NUMPAD due to the layout.\n\n" +
                    "|7 -> Top Left |\t\t|8 ->    Top    |\t" +
                    "\t|9 ->   TopRight   |\n" +
                    "|4 ->   Left   |\t\t|  YOUR PIECE   |\t" +
                    "\t|6 ->    Right     |\n" +
                    "|1 -> Bot Left |\t\t|2 ->  Bottom   |\t" +
                    "\t|3 -> Bottom Right |\n\n" +
                    ">> Press 0 to choose another players <<";

            // Creates a new GameInstance passing the size of the board
            game = new GameInstance(5, 5);
            // Creates a new WinConditions
            win = new WinConditions();
        }

        /// <summary>
        /// Start method of the game, creating and starting the needed
        /// parameters
        /// </summary>
        public void Start()
        {
            // Displays the board along with a message
            game.Graphics.Render("Do you wish to read the rules?" +
                "\n Press Y to do so or any other key to skip");

            // Checks if the user pressed Y
            if (Console.ReadLine().ToUpper() == "Y")
            {
                // Creates a new GameRules
                GameRules rules = new GameRules();
                // Displays the gamerules to the user
                rules.DisplayGameRules(game.Graphics);
            }

            // Displays the board along with a message
            game.Graphics.Render("\t\tWho goes/plays first?"
                + "\n\t >> For the Black pieces press B <<"
                + "\n\t >> For the White pieces press W <<");

            // Defines which color plays first
            game.OrderSelection();

            // Gets the current number of pieces for the first player
            maxPieceN = game.Player1.playerPieces.Length;

            // Calls the Update Method
            Update();
        }

        /// <summary>
        /// Main loop of the game, updates inputs, visuals and winner check 
        /// </summary>
        private void Update()
        {
            // Loops the game until someone wins
            while (true)
            {
                // Asks the user to perform a move
                DoPlayerMovement(game.Player1);

                // Checks if there's a winner
                if (win.WinCheck(game.Player2) != ColorChoice.None)
                {
                    // Displays the board along with a message
                    game.Graphics.Render($"The {game.Player2.ColorChoice}" + 
                        "Pieces Win!");

                    // Asks for input from the user
                    Console.ReadKey();

                    // Leaves the while loop 
                    break;
                }
                // Asks the user to perform a move
                DoPlayerMovement(game.Player2);

                // Checks if there's a winner
                if (win.WinCheck(game.Player1) != ColorChoice.None)
                {
                    // Displays the board along with a message
                    game.Graphics.Render($"The {game.Player1.ColorChoice}" + 
                        "Pieces Win!");

                    // Asks for input from the user
                    Console.ReadKey();

                    // Leaves the while loop 
                    break;
                }
            }
        }

        private void DoPlayerMovement(Player player)
        {
            // Creates an empty string
            string message = " ";
            // Creates a message displaying which turn it is
            string turnMessage = $"{player.ColorChoice}s turn " +
                $"\nChoose the players you want to move";

            // Performs a loop while the message isn't null
            while (message != null)
            {
                // Displays the board along with a message
                game.Graphics.Render(turnMessage, player.ColorChoice);

                // Creates an integer to store the wanted players
                int pieceChoice;

                // Asks for input until it's a valid one
                while (!int.TryParse(Console.ReadLine(), out pieceChoice)
                    || pieceChoice < 1 || pieceChoice > maxPieceN)
                {
                    // Displays the board along with a message
                    game.Graphics.Render(turnMessage, player.ColorChoice);
                }

                // Displays the board along with a message
                game.Graphics.Render(choiceMessage);

                // Does the movement of that players returning a string if it can
                message = player.MovePiece(pieceChoice);

                // Displays the board along with a message
                game.Graphics.Render(message);

                // If it couldn't do the move (string as value)
                if (message != null)
                {
                    // Asks the user for input
                    Console.ReadKey();
                }
            }
        }
    }
}