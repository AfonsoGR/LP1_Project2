using System;

namespace Felli
{
    /// <summary>
    /// Sets up the game pieces to be placed on the board and their movement
    /// </summary>
    public class Piece
    {
        public Position piecePos;
        private ColorChoice visuals;
        private Board board;

        public Piece(ColorChoice visuals, Board board, int row = 0, int column = 0)
        {
            piecePos = new Position(row, column);
            this.board = board;
            this.visuals = visuals;
        }

        public void PieceOnBoard()
        {
            board[piecePos.X, piecePos.Y] = visuals;
        }

        public string PieceMovement()
        {
            int moveChoice;

            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                 moveChoice < 1 || moveChoice > 9 || moveChoice == 5);

            if (moveChoice == 1)
            {
                if (piecePos.X < 5 && piecePos.Y > 0
                    && board[piecePos.X + 1, piecePos.Y - 1] == ColorChoice.None)
                {
                    piecePos += (1, -1); 
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }
            else if (moveChoice == 2)
            {
                if (piecePos.X < 5
                    && board[piecePos.X + 1, piecePos.Y] == ColorChoice.None)
                {
                    piecePos += (1, 0);
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }
            else if (moveChoice == 3)
            {
                if (piecePos.X < 5 && piecePos.Y < 5
                    && board[piecePos.X + 1, piecePos.Y + 1] == ColorChoice.None)
                {
                    piecePos += (1, 1);
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }
            else if (moveChoice == 4)
            {
                if (piecePos.Y > 0
                    && board[piecePos.X, piecePos.Y - 1] == ColorChoice.None)
                {
                    piecePos += (0, -1);
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }
            else if (moveChoice == 6)
            {
                if (piecePos.Y < 5
                    && board[piecePos.X, piecePos.Y + 1] == ColorChoice.None)
                {
                    piecePos += (0, 1); 
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }
            else if (moveChoice == 7)
            {
                if (piecePos.X > 0 && piecePos.Y < 5
                    && board[piecePos.X - 1, piecePos.Y - 1] == ColorChoice.None)
                {
                    piecePos += (-1, -1);
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }            
            else if (moveChoice == 8)
            {
                if (piecePos.X > 0
                    && board[piecePos.X - 1, piecePos.Y] == ColorChoice.None)
                {
                    piecePos += (-1, 0);
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }            
            else if (moveChoice == 9)
            {
                if (piecePos.X > 0 && piecePos.Y < 5
                    && board[piecePos.X - 1, piecePos.Y + 1] == ColorChoice.None)
                {
                    piecePos += (-1, 1);
                    return null;
                }
                else
                    return "Your piece can't move that way.";
            }
            else
                return "Please select valid option.";
        }
    }
}