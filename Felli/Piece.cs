using System;

namespace Felli
{
    /// <summary>
    /// Sets up the game pieces to be placed on the board and their movement
    /// </summary>
    public class Piece
    {
        public Position piecePos;
        public ColorChoice visuals;
        private readonly Board board;
        public int id;

        public Piece(ColorChoice visuals, Board board, int row = 0,
            int column = 0, int iD = 0)
        {
            id = iD;
            piecePos = new Position(row, column);
            this.board = board;
            this.visuals = visuals;
        }

        public void PieceOnBoard()
        {
            board[piecePos.X, piecePos.Y] = visuals;
        }

        private string MovementCoordinates(int x, int y)
        {
            if ((board[piecePos.X + x, piecePos.Y + y] != visuals &&
                board[piecePos.X + x, piecePos.Y + y] != ColorChoice.None) &&
                (board[piecePos.X + (x + x), piecePos.Y + (y + y)] 
                == ColorChoice.None))
            { 
                piecePos += ((x + x), (y + y));
                return null;
            }
            else if (board[piecePos.X + x, piecePos.Y + y] == ColorChoice.None)
            {
                piecePos += (x, y);
                return null;
            }
            else
            {
                return "Your piece can't move that way.";
            }
        }
        public string PieceMovement()
        {
            int moveChoice;

            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                 moveChoice < 0 || moveChoice > 9 || moveChoice == 5)
            {
                ;
            }
            if (moveChoice == 0)
            {
                return "Canceled Piece Movement";
            }
            if (moveChoice == 1)
            {
                return piecePos.X < 5 && piecePos.Y > 0 ? 
                    MovementCoordinates(1, -1) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 2)
            {
                return piecePos.X < 5 ? 
                    MovementCoordinates(1, 0) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 3)
            {
                return piecePos.X < 5 && piecePos.Y < 5 ? 
                    MovementCoordinates(1, 1) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 4)
            {
                return piecePos.Y > 0 ? 
                    MovementCoordinates(0, -1) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 6)
            {
                return piecePos.Y < 5 ? 
                    MovementCoordinates(0, 1) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 7)
            {
                return piecePos.X > 0 && piecePos.Y > 0 ? 
                    MovementCoordinates(-1, -1) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 8)
            {
                return piecePos.X > 0 ? 
                    MovementCoordinates(-1, 0) 
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 9)
            {
                return piecePos.X > 0 && piecePos.Y < 5 ? 
                    MovementCoordinates(-1, 1) 
                    : "Your piece can't move that way.";
            }
            else
            {
                return "Please select valid option.";
            }
        }
    }
}