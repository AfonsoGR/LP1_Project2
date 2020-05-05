using System;

namespace Felli
{
    /// <summary>
    /// Main class of the program calls game start
    /// </summary>
    class Program
    {
        /// <summary>
        /// Game initialization and game loop
        /// </summary>
        /// <param name="args"> Arguments passed through console </param>
        private static void Main(string[] args)
        {
            // Creates a variable of GameLoop
            GameLoop game;

            // Runs a new game until the player's decide to stop
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

                // Checks for user input is "Y"
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    // Exits the while loop
                    break;
                }
            }
        }
    }
}