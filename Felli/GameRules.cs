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
        public void DisplayGameRules(Renderer rend)
        {
            // Displays text on screen with information regarding the game
            rend.Render("Welcome to Felli!\n\nA 2 (two) player turn based "
                + "PVP game.\n\n"
                + "In this game the players will try to defeat eachother  \n"
                + "by either capturing eachother's pieces or by making    \n" 
                + "them unable to move.                                   \n\n"
                + "Each player will have access to 6 pieces. At the start \n"
                + "of the game the players will select who has the White  \n"
                + "piecesand who has the Black pieces.                    \n"
                + "Afterwards they will choose who plays first.           \n"
                + "The players will then play by turns.                   \n\n"
                + "The movement of the pieces is dictated by the          \n"
                + "following rules:                                       \n\t"
                + "\nThe pieces can only move on the lines of the board.\n\n\t"
                + "They can move in any direction as long as there        \n\t"
                + "is an open adjacent space/dot in that direction.     \n\n\t"
                + "They can jump over an opponent's pieces, eliminating   \n\t"
                + "that player's piece, and landing afterwards on an      \n\t"
                + "adjacent  open space.                                \n\n\t"
                + "If there is no adjacent open space next to the consumed\n\t"
                + "player's piece then it can not be eliminated           \n\t"
                + "(like in checkers).                                  \n\n\t"
                + "Each player can only move 1 (one) piece per turn.      \n\n"
                + "The game ends when one of the player is either out of  \n"
                + "pieces or can not move any of his pieces, therefore    \n"
                + "granting victory to his opponent.                      \n\n"
                + ">>>>>> Press any key when you are ready to start <<<<<<");

            // Waits for the user's input before proceeding
            Console.ReadKey();
        }
    }
}