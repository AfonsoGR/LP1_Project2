using System;

namespace Felli
{
    /// <summary>
    /// Displays on screen text and waits for the user's input
    /// </summary>
    public class GameRules
    {
        /// <summary>
        /// Displays text on how to play the game and
        /// awaits for user input before proceeding
        /// </summary>
        public void GR(Renderer rend)
        {
            // Displays text on screen with information regarding the game
            rend.Render("Welcome to Felli!\nA 2 (two) player turn based "
                + "PVP game.\n"
                + "In this game the players will try to defeat eachother "
                + "by either capturing eachother's pieces or by making them "
                + "unable to move.\n"
                + "Each player will have access to 6 pieces. At the start of "
                + "the game the players will select who has the White pieces "
                + "and who has the Black pieces.\nAfterwards they will choose"
                + " who plays first. The players will then play by turns.\n\n"
                + "The movement of the pieces is dictated by the following "
                + "rules:\n\tThe pieces can only move on the lines of the "
                + "board.\n\tThey can move in any direction as long as there "
                + "is an open adjacent space/dot in that direction.\n\t"
                + "They can jump over an opponent's piece, eliminating that"
                + "piece, and landing afterwards on an adjacent open space. "
                + "\n\tIf there is no adjacent open space next to the consumed"
                + "piece then it can not be eliminated (like in checkers)."
                + "\n\tEach player can only move 1 (one) piece per turn.\n"
                + "\nThe game ends when one of the player is either out of "
                + "pieces or can not move any of his pieces, therefore "
                + "granting victory to his opponent.\n\n"
                + ">>>>>> Press any key when you are ready to start <<<<<<");

            // Waits for the user's input before proceeding
            Console.ReadKey();
        }
    }
}