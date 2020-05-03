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
        }
        public void SetBoardToInitState()
        {
            int y = 0;
            for (int x = SizeX / 2; x < SizeX; x++)
            {
                boardPieces[x, (SizeY / 2) + y] = 'o';
                boardPieces[x, (SizeY / 2) - y] = 'o';
                boardPieces[x, (SizeY / 2)] = 'o';
                y++;
            }
            y = 0;
            for (int x = SizeX / 2; x >= 0; x--)
            {
                boardPieces[x, (SizeY / 2) + y] = 'o';
                boardPieces[x, (SizeY / 2) - y] = 'o';
                boardPieces[x, (SizeY / 2)] = 'o';
                y++;
            }
        }
    }
}