namespace Felli
{
    /// <summary>
    /// Manages the win conditions
    /// </summary>
    public class WinConditions
    {
        /// <summary>
        /// Checks if the current the player has lost
        /// </summary>
        /// <param name="player"> Current state of the current player </param>
        /// <returns> Returns a value from ColorChoice enumerator </returns>
        public ColorChoice WinCheck(Player player)
        {
            // Assigns a value to 'lost' string
            string lost = " ";

            // Checks the player pieces along the board
            for (int b = 0; b < player.playerPieces.Length; b++)
            {
                // Checks all of the current player's pieces
                for (int i = 1; i < 9; i++)
                {
                    // Assigns movement value to 'lost' string
                    lost = player.playerPieces[b].PieceMovement(null, i);

                    // Checks if 'lost' is null
                    if (lost == null)
                    {
                        // Exits the for loop
                        break;
                    }
                }
                // Checks if the 'lost' string is null
                if (lost == null)
                {
                    // Exits the for loop
                    break;
                }
            }
            // Checks if 'lost' string isn't null
            if (lost != null)
            {
                // Returns the opposite color of the player that lost
                return player.ColorChoice == ColorChoice.White? 
                    ColorChoice.Black : ColorChoice.White;
            }
            // Returns value 'None' from the ColorChoice enumerator
            return ColorChoice.None;
        }
    }
}