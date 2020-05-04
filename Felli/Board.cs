namespace Felli
{
    public class Board
    {
        private readonly ColorChoice[,] boardPieces;

        public int SizeX => boardPieces.GetLength(0);

        public int SizeY => boardPieces.GetLength(1);

        public ColorChoice this[int x, int y]
        {
            get => boardPieces[x, y];
            set => boardPieces[x, y] = value;
        }

        public Board(int xSize, int ySize)
        {
            boardPieces = new ColorChoice[xSize, ySize];
        }

        public void SetBoardToInitState()
        {
            int y = 0;
            for (int x = SizeX / 2; x < SizeX; x++)
            {
                boardPieces[x, (SizeY / 2) + y] = ColorChoice.None;
                boardPieces[x, (SizeY / 2) - y] = ColorChoice.None;
                boardPieces[x, (SizeY / 2)] = ColorChoice.None;
                y++;
            }
            y = 0;
            for (int x = SizeX / 2; x >= 0; x--)
            {
                boardPieces[x, (SizeY / 2) + y] = ColorChoice.None;
                boardPieces[x, (SizeY / 2) - y] = ColorChoice.None;
                boardPieces[x, (SizeY / 2)] = ColorChoice.None;
                y++;
            }
        }
    }
}