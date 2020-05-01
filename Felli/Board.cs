using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    public class Board
    {
        private readonly char[,] boardPieces;

        public int SizeX => boardPieces.GetLength(0);

        public int SizeY => boardPieces.GetLength(1);

        public char this[int x, int y]
        {
            get => boardPieces[x, y];
            set => boardPieces[x, y] = value;
        }

        public Board(int xSize, int ySize)
        {
            boardPieces = new char[xSize, ySize];

            int y = 0;
            for (int x = xSize / 2; x < xSize; x++)
            {
                boardPieces[x, (ySize / 2) + y] = 'o';
                boardPieces[x, (ySize / 2) - y] = 'o';
                boardPieces[x, (ySize / 2)] = 'o';
                y++;
            }
            y = 0;
            for (int x = xSize / 2; x >= 0; x--)
            {
                boardPieces[x, (ySize / 2) + y] = 'o';
                boardPieces[x, (ySize / 2) - y] = 'o';
                boardPieces[x, (ySize / 2)] = 'o';
                y++;
            }

        }
    }
}
