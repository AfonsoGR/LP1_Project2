using System;

namespace Felli
{
    public class Renderer
    {
        private readonly Board board;
        private readonly string[] connectors;
        private (Player, Player) piece;

        public Renderer(Board board, (Player, Player) piece)
        {
            this.piece = piece;
            connectors = new string[6] { @"\", "|", "/", "/", "|", @"\" };
            this.board = board;
        }

        public void Render(string message = null,
            ColorChoice color = ColorChoice.None)
        {
            SetBoardVisuals();

            // Clears the console
            Console.Clear();

            int l = board.SizeX - board.SizeX / 2;

            int z = -1;

            // A loop for the width of the board
            for (int x = 0; x < board.SizeX; x++)
            {
                Console.Write("\n");

                int nLines = 0;

                if (x <= board.SizeX / 2)
                {
                    l--;
                    z++;
                }
                else
                {
                    l++;
                    z--;
                }

                DrawSpaces(x, z);

                // A loop for the height of the board
                for (int y = 0; y < board.SizeY; y++)
                {
                    if (board[x, y] != default)
                    {
                        if (color == ColorChoice.White)
                        {
                            ShowNumberID(x, y, piece.Item1.playerPieces);
                        }
                        else if (color == ColorChoice.Black)
                        {
                            ShowNumberID(x, y, piece.Item2.playerPieces);
                        }
                        else
                        {
                            Console.Write($"{(char)board[x, y]}");
                        }

                        if (nLines < 2)
                        {
                            nLines++;
                            for (int o = 0; o < l; o++)
                            {
                                Console.Write("--");
                            }
                        }
                    }
                }
                DrawConnectors(x);
            }
            DrawMessageBox(message);
        }
        private void ShowNumberID(int k, int l, Piece[] piece)
        {
            Console.Write($"{(char)board[k, l]}");
            for (int x = 0; x < piece.Length; x++)
            {
                if (piece[x].piecePos.X == k &&
                    piece[x].piecePos.Y == l)
                {
                    Console.Write(piece[x].id);
                    break;
                }
            }
        }
        private void SetBoardVisuals()
        {
            board.SetBoardToInitState();

            if (piece.Item1 != null && piece.Item2 != null)
            {
                for (int white = 0; 
                    white < piece.Item1.playerPieces.Length; white++)
                {
                    piece.Item1.playerPieces[white].PieceOnBoard();
                }
                for (int black = 0; 
                    black < piece.Item2.playerPieces.Length; black++)
                {
                    piece.Item2.playerPieces[black].PieceOnBoard();
                }
            }
        }

        private void DrawSpaces(int x, int z)
        {
            Console.Write("  ");
            if (x == board.SizeX / 2)
            {
                Console.Write(" ");
            }

            for (int p = 0; p < z; p++)
            {
                Console.Write("  ");
            }
        }

        private void DrawConnectors(int x)
        {
            Console.Write("\n  ");

            int ç = x < board.SizeX / 2 ? 0 : 3;

            for (int y = 0; y < board.SizeY; y++)
            {
                if (x < board.SizeX / 2)
                {
                    if (board[x, y] != default)
                    {
                        Console.Write($"{connectors[ç]}  "); ç++;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                else if (x + 1 < board.SizeX && x >= board.SizeX / 2)
                {
                    if (board[x + 1, y] != default)
                    {
                        Console.Write($"{connectors[ç]}  "); ç++;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
        }
        private void DrawMessageBox(string message)
        {
            string flair = "--------------------.--------------------." +
                "---------------------.--------------------";
            if (message != null)
            {
                Console.WriteLine();
                Console.WriteLine(flair);
                int spaceLen = (83 - message.Length) / 2;
                for (int p = 0; p < spaceLen; p++)
                {
                    Console.Write(" ");
                }
                Console.Write(message);
                for (int p = 0; p < spaceLen; p++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine(flair);
            }
        }
    }
}