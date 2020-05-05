namespace Felli
{
    /// <summary>
    /// Creates a board with the given size
    /// </summary>
    public class Board
    {
        // A bi-dimensional array containing a ColorChoice
        private readonly ColorChoice[,] boardPieces;

        /// <summary>
        /// The width of the board
        /// </summary>
        public int SizeX => boardPieces.GetLength(0);
        /// <summary>
        /// The height of the board
        /// </summary>
        public int SizeY => boardPieces.GetLength(1);

        /// <summary>
        /// Returns the value of the position or gives it a new value
        /// </summary>
        /// <param name="x"> The X on the array </param>
        /// <param name="y"> The Y on the array </param>
        /// <returns> The ColorChoice of the players </returns>
        public ColorChoice this[int x, int y]
        {
            get => boardPieces[x, y];
            set => boardPieces[x, y] = value;
        }

        /// <summary>
        /// Creates a new board with the given size
        /// </summary>
        /// <param name="xSize"> Height of the board </param>
        /// <param name="ySize"> Length of the board </param>
        public Board(int xSize, int ySize)
        {
            // Creates a new array with the dimensions provided
            boardPieces = new ColorChoice[ySize, xSize];
        }

        /// <summary>
        /// Generates the basic visual structure of the board
        /// </summary>
        public void SetBoardToInitState()
        {
            // Checks the upper part of the board
            for (int x = SizeX / 2, y = 0; x < SizeX; x++, y++)
            {
                // Assigns 'None' to the positions on top
                // Right position
                boardPieces[x, (SizeY / 2) + y] = ColorChoice.None;
                // Left position
                boardPieces[x, (SizeY / 2) - y] = ColorChoice.None;
                // Center position
                boardPieces[x, (SizeY / 2)] = ColorChoice.None;
            }
            // Checks the lower part of the board
            for (int x = SizeX / 2, y = 0; x >= 0; x--, y++)
            {
                // Assigns 'None' to the positions on the bottom
                // Right position
                boardPieces[x, (SizeY / 2) + y] = ColorChoice.None;
                // Left position
                boardPieces[x, (SizeY / 2) - y] = ColorChoice.None;
                // Center position
                boardPieces[x, (SizeY / 2)] = ColorChoice.None;
            }
        }
    }
}