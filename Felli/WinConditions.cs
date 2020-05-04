using System;
using System.Collections.Generic;

namespace Felli
{
    public class WinConditions
    {
        public void WinCheck(Player player)
        {
            string lost = "Nope";

            for (int b = 0; b < player.playerPieces.Length; b++)
            {
                for (int i = 1; i < 8; i++)
                {
                    lost = player.playerPieces[b].PieceMovement(null, i);
                    if (lost == null) break;
                }
                if (lost == null) break;
            }
            if (lost != null)
            {
                Console.WriteLine($"{player.ColorChoice} nigga lost!");
                Console.ReadLine();
            }
            //List<(int, int)> neighbours = new List<(int, int)>();

            //// Checks the spaces along the width of the board
            //for (int x = 0; x < board.SizeX; x++)
            //{
            //    // Checks the spaces along the height of the board
            //    for (int y = 0; y < board.SizeY; y++)
            //    {
            //        // Converts negative values to positives in the X axis
            //        float distX = Math.Abs(Math.Abs(x) -
            //            Math.Abs(piece.piecePos.X));

            //        // Converts negative values to positives in the Y axis
            //        float distY = Math.Abs(Math.Abs(y) -
            //            Math.Abs(piece.piecePos.Y));

            //        // Checks if there is another piece in the diagonal
            //        if ((distX == 1 && distY == 1))
            //        {
            //            // Adds neighbour to List
            //            neighbours.Add((x, y));
            //        }
            //    }
            //}
            //// Int to save the occupiedCells value
            //int occupiedCells = 0;

            //// Checks if the surrounding cells are blocked
            //for (int k = 0; k < neighbours.Count; k++)
            //{
            //    // Checks if neighbour cell is occupied
            //    if (board[neighbours[k].Item1,
            //        neighbours[k].Item2] != ColorChoice.None)
            //    {
            //        // Increments blockedCells
            //        occupiedCells++;
            //    }
            //}
        }
    }
}