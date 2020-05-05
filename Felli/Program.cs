using System;

namespace Felli
{
    /// <summary>
    /// Main class of the program cointaning the game loop
    /// </summary>
    class Program
    {
        /// <summary>
        /// Game initialization and game loop
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            GameLoop game;

            // Main loop of the game
            while (true)
            {
                // Creates a new game loop
                game = new GameLoop();

                // Calls Start method from GameLoop.cs
                game.Start();

                // Clears the console
                Console.Clear();

                // Displays on text message for the players
                Console.WriteLine("Do you wish to play again?\nPress Y if " +
                    "you do, press any other key to leave");

                // Checks for user input
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    // Exits the while loop
                    break;
                }
            }
        }
    }
}