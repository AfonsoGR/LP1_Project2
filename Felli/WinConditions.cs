using System;
using System.Collections.Generic;

namespace Felli
{
    public class WinConditions
    {
        public void WinCheck(Board board, Pieces pieces)
        {
            List<(int, int)> neighbours = new List<(int, int)>();

            // Checks the spaces along the width of the board
            for (int x = 0; x < board.SizeX; x++)
            {
                // Checks the spaces along the height of the board
                for (int y = 0; y < board.SizeY; y++)
                {
                    // Converts negative values to positives in the X axis
                    float distX = Math.Abs(Math.Abs(x) -
                        Math.Abs(pieces.piecePos.X));

                    // Converts negative values to positives in the Y axis
                    float distY = Math.Abs(Math.Abs(y) -
                        Math.Abs(pieces.piecePos.Y));

                    // Checks if there is another piece in the diagonal
                    if ((distX == 1 && distY == 1))
                    {
                        // Adds neighbour to List
                        neighbours.Add((x, y));
                    }
                }
            }
            // Int to save the occupiedCells value
            int occupiedCells = 0;

            // Checks if the surrounding cells are blocked
            for (int k = 0; k < neighbours.Count; k++)
            {
                // Checks if neighbour cell is occupied
                if (board[neighbours[k].Item1, neighbours[k].Item2] != 'o')
                {
                    // Increments blockedCells
                    occupiedCells++;
                }
            }
        }
    }
}