using System.Collections.Generic;

namespace Felli
{
    /// <summary>
    /// Sets up the game pieces to be placed on the board and their movement
    /// </summary>
    public class Piece
    {
        public Position PiecePos { get; private set; }
        public int ID { get; }

        private readonly ColorChoice visuals;
        private readonly Board board;

        public Piece(ColorChoice visuals, Board board, int row = 0,
            int column = 0, int iD = 0)
        {
            ID = iD;
            PiecePos = new Position(row, column);
            this.board = board;
            this.visuals = visuals;
        }

        public void PieceOnBoard()
        {
            board[PiecePos.X, PiecePos.Y] = visuals;
        }

        private string TryCaptureOrMove(Player player, int x, int y)
        {
            bool canMove = false;

            int nextX = x + x;
            int nextY = y + y;

            if (PiecePos.X == board.SizeX - 1 || PiecePos.X == 0)
            {
                nextY = y * 2 + y * 2;
            }

            if ((PiecePos.X + nextX >= 0 && PiecePos.Y + nextY >= 0 &&
                PiecePos.X + nextX < board.SizeX &&
                PiecePos.Y + nextY < board.SizeY))
            {
                canMove = (board[PiecePos.X + nextX, PiecePos.Y + nextY]
                == ColorChoice.None);
            }

            if (board[PiecePos.X + x, PiecePos.Y + y] != visuals &&
                board[PiecePos.X + x, PiecePos.Y + y] != ColorChoice.None &&
                canMove)
            {
                if (player != null)
                {
                    Position position =
                        new Position(PiecePos.X + nextX / 2, PiecePos.Y + nextY / 2);
                    CapturePiece(player, position);

                    PiecePos += (nextX, nextY);
                }
                return null;
            }
            else if (board[PiecePos.X + x, PiecePos.Y + y] == ColorChoice.None)
            {
                if (player != null)
                {
                    PiecePos += (x, y);
                }
                return null;
            }
            else
            {
                return "Your piece can't move that way.";
            }
        }

        private void CapturePiece(Player player, Position position)
        {
            List<Piece> capturedPieces = new List<Piece>();

            for (int i = 0; i < player.playerPieces.Length; i++)
            {
                if (player.playerPieces[i].PiecePos != position)
                {
                    capturedPieces.Add(player.playerPieces[i]);
                }
            }

            player.playerPieces = capturedPieces.ToArray();
        }

        public string PieceMovement(Player opositePlayer, int moveChoice)
        {
            string invalidMove = Restrictions(moveChoice);

            if (invalidMove != null)
            {
                return invalidMove;
            }

            if (moveChoice == 0)
            {
                return "Canceled Piece Movement";
            }
            else if (moveChoice == 1)
            {
                return PiecePos.X < 4 && PiecePos.Y > 0 ?
                    TryCaptureOrMove(opositePlayer, 1, -1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 2)
            {
                return PiecePos.X < 4 ?
                    TryCaptureOrMove(opositePlayer, 1, 0)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 3)
            {
                return PiecePos.X < 4 && PiecePos.Y < 4 ?
                    TryCaptureOrMove(opositePlayer, 1, 1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 4)
            {
                return PiecePos.Y > 0 ?
                    TryCaptureOrMove(opositePlayer, 0, -1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 6)
            {
                return PiecePos.Y < 4 ?
                    TryCaptureOrMove(opositePlayer, 0, 1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 7)
            {
                return PiecePos.X > 0 && PiecePos.Y > 0 ?
                    TryCaptureOrMove(opositePlayer, -1, -1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 8)
            {
                return PiecePos.X > 0 ?
                    TryCaptureOrMove(opositePlayer, -1, 0)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 9)
            {
                return PiecePos.X > 0 && PiecePos.Y < 4 ?
                    TryCaptureOrMove(opositePlayer, -1, 1)
                    : "Your piece can't move that way.";
            }
            else
            {
                return "Please select valid option.";
            }
        }

        private string Restrictions(int moveChoice)
        {
            if (PiecePos.X != board.SizeX / 2 && PiecePos.Y == board.SizeY / 2)
            {
                if (moveChoice == 1 || moveChoice == 3 ||
                    moveChoice == 7 || moveChoice == 9)
                {
                    return "Your piece can't move that way";
                }
            }

            if (PiecePos.X == 1 && PiecePos.Y == 1)
            {
                if (moveChoice == 9)
                {
                    return "Your piece can't move that way";
                }
            }

            if (PiecePos.X == 3 && PiecePos.Y == 1)
            {
                if (moveChoice == 3)
                {
                    return "Your piece can't move that way";
                }
            }

            if (PiecePos.X == 1 && PiecePos.Y == 3)
            {
                if (moveChoice == 7)
                {
                    return "Your piece can't move that way";
                }
            }

            if (PiecePos.X == 3 && PiecePos.Y == 3)
            {
                if (moveChoice == 1)
                {
                    return "Your piece can't move that way";
                }
            }
            return null;
        }
    }
}