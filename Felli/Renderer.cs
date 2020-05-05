using System;

namespace Felli
{
    /// <summary>
    /// Displays the current board and messages
    /// </summary>
    public class Renderer
    {
        // Stores the board
        private readonly Board board;
        // Stores a string for the board lines
        private readonly string[] connectors;
        // Stores both of the players
        private (Player p1, Player p2) players;

        /// <summary>
        /// Creates a Rednerer to display the board
        /// </summary>
        /// <param name="board"> The board created </param>
        /// <param name="players"> Both players </param>
        public Renderer(Board board, (Player, Player) players)
        {
            // Assigns the board the one given
            this.board = board;
            // Assigns the players the ones given
            this.players = players;
            // Creates a string of the possible connectors
            connectors = new string[6] { @"\", "|", "/", "/", "|", @"\" };
        }

        /// <summary>
        /// Renders the board and a message if any is given
        /// </summary>
        /// <param name="message"> The message to be rendered </param>
        /// <param name="color"> A color from the color enum </param>
        public void Render(string message = null,
            ColorChoice color = ColorChoice.None)
        {
            // Resets the board visuals to the default
            SetBoardVisuals();

            // Clears the console
            Console.Clear();

            // Creates an integer and gives it a value
            int nDashes = board.SizeX - board.SizeX / 2;

            // creates an integer and gives it a value
            int nSpaces = -1;

            // A loop for the width of the board
            for (int x = 0; x < board.SizeX; x++)
            {
                // Writes a line
                Console.WriteLine();

                // Creates an integer for the number of dashes
                int nDashSets = 0;

                // Checks if it's in the upper or middle of the board
                if (x <= board.SizeX / 2)
                {
                    // Decrements nDashes by one
                    nDashes--;
                    // Increments nSpaces by one
                    nSpaces++;
                }
                else
                {
                    // Increments nDashes by one
                    nDashes++;
                    // Decrements nSpaces by one
                    nSpaces--;
                }

                // Draws the spaces before the actual board
                DrawSpaces(x, nSpaces);

                // A loop for the height of the board
                for (int y = 0; y < board.SizeY; y++)
                {
                    // Checks if that position on the board has a value
                    if (board[x, y] != default)
                    {
                        // Renders the character on that position
                        Console.Write($"{(char)board[x, y]}");

                        // If the color provided is white
                        if (color == ColorChoice.White)
                        {
                            // Renders the IDs of the white pieces
                            ShowNumberID(new Position(x, y),
                                players.p1.playerPieces);
                        }
                        // If the color provided is black
                        else if (color == ColorChoice.Black)
                        {
                            // Renders the IDs of the black pieces
                            ShowNumberID(new Position(x, y),
                                players.p2.playerPieces);
                        }

                        // Checks if the amount of dashes drawn is less than 2
                        if (nDashSets < 2)
                        {
                            // Increments the nDashSets by one
                            nDashSets++;

                            // Renders two dashes for each nDashes
                            for (int o = 0; o < nDashes; o++)
                            {
                                Console.Write("--");
                            }
                        }
                    }
                }
                // Draws the lines connecting the points
                DrawConnectors(x);
            }
            // Draws a message box below the board
            DrawMessageBox(message);
        }

        /// <summary>
        /// Shows the ID number of each piece of the given player
        /// </summary>
        /// <param name="pos"> The current position coordinate </param>
        /// <param name="player"> Player to have the pieces rendered </param>
        private void ShowNumberID(Position pos, Piece[] player)
        {
            // Cycles through all the pieces
            for (int i = 0; i < player.Length; i++)
            {
                // Checks if the piece is at the position provided
                if (player[i].PiecePos == pos)
                {
                    // Displays that piece ID
                    Console.Write(player[i].ID);
                    // Exits the loop
                    break;
                }
            }
        }

        /// <summary>
        /// Applies the visuals of every piece to the board
        /// </summary>
        private void SetBoardVisuals()
        {
            // Resets the board visuals to it's original state
            board.SetBoardToInitState();

            // Checks if the players aren't null
            if (players.p1 != null && players.p2 != null)
            {
                // Checks every piece from player1
                for (int white = 0;
                    white < players.p1.playerPieces.Length; white++)
                {
                    // Sets their position on the board their actual position
                    players.p1.playerPieces[white].PieceOnBoard();
                }
                // Checks every piece from player2
                for (int black = 0;
                    black < players.p2.playerPieces.Length; black++)
                {
                    // Sets their position on the board their actual position
                    players.p2.playerPieces[black].PieceOnBoard();
                }
            }
        }

        /// <summary>
        /// Draws spaces for the board to be centered
        /// </summary>
        /// <param name="x"> The current x value </param>
        /// <param name="nSpaces"> Number of needed spaces </param>
        private void DrawSpaces(int x, int nSpaces)
        {
            // Displays empty spaces
            Console.Write("  ");

            // Cycles for the amount of spaces needed
            for (int p = 0; p < nSpaces; p++)
            {
                // Writes a space
                Console.Write("  ");
            }

            // if it's in the middle of the board
            if (x == board.SizeX / 2)
            {
                // Writes an extra empty space
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Draws the lines between the points
        /// </summary>
        /// <param name="x"> The current x </param>
        private void DrawConnectors(int x)
        {
            // Changes lines and shows a space
            Console.Write("\n  ");

            // Sets the index number to 0 or 3 depending on which half it is
            int indexN = x < board.SizeX / 2 ? 0 : 3;

            // A loop for the height of the board
            for (int y = 0; y < board.SizeY; y++)
            {
                // If it's at the top part of the board
                if (x < board.SizeX / 2)
                {
                    // If that position has value
                    if (board[x, y] != default)
                    {
                        // Writes the connector and adds 1 to indexN
                        Console.Write($"{connectors[indexN]}  "); indexN++;
                    }
                    else
                    {
                        // Writes an empty space
                        Console.Write("  ");
                    }
                }
                // If the next X is acessible and is at the bottom of the board
                else if (x + 1 < board.SizeX && x >= board.SizeX / 2)
                {
                    // If that position has value
                    if (board[x + 1, y] != default)
                    {
                        // Writes the connector and adds 1 to indexN
                        Console.Write($"{connectors[indexN]}  "); indexN++;
                    }
                    else
                    {
                        // Writes an empty space
                        Console.Write("  ");
                    }
                }
            }
        }

        /// <summary>
        /// Draws a text box for displaying extra information
        /// </summary>
        /// <param name="message"> The message provided </param>
        private void DrawMessageBox(string message)
        {
            // Cheks if the message has something
            if (message != null)
            {
                // Splits the message by the '\n' char
                string[] splitMessage = message.Split('\n');
                // Creates a string to be used as decoration
                string flair = "+-------------------+--------------------+" +
                                "---------------------+-------------------+";

                // Changes lines and displays the flair
                Console.WriteLine("\n" + flair + "\n");

                // Checks all the strings on the splitMessage array
                for (int i = 0; i < splitMessage.Length; i++)
                {
                    // Saves the amount of spaces before and after in order for
                    // the message to be centered
                    int spaceLen = (flair.Length - splitMessage[i].Length) / 2;

                    // A loop for the amount of spaces needed
                    for (int p = 0; p < spaceLen; p++)
                    {
                        // Writes an empty space
                        Console.Write(" ");
                    }

                    // Displays the message provided 
                    Console.Write(splitMessage[i]);

                    // A loop for the amount of spaces needed
                    for (int p = 0; p < spaceLen; p++)
                    {
                        // Writes an empty space
                        Console.Write(" ");
                    }

                    // Changes lines
                    Console.WriteLine();
                }
                // Changes lines and displays the flair
                Console.WriteLine("\n" + flair);
            }
        }
    }
}