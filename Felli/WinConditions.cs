namespace Felli
{
    public class WinConditions
    {
        public ColorChoice WinCheck(Player player)
        {
            string lost = " ";

            for (int b = 0; b < player.playerPieces.Length; b++)
            {
                for (int i = 1; i < 8; i++)
                {
                    lost = player.playerPieces[b].PieceMovement(null, i);
                    if (lost == null)
                    {
                        break;
                    }
                }
                if (lost == null)
                {
                    break;
                }
            }
            if (lost != null)
            {
                return player.ColorChoice == ColorChoice.White? 
                    ColorChoice.Black : ColorChoice.White;
            }
            return ColorChoice.None;
        }
    }
}