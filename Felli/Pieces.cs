using System;

namespace Felli
{
    /// <summary>
    /// Sets up the game pieces to be placed on the board and their movement
    /// </summary>
    public class Pieces
    {
        public Position piecePos;
        public char visuals;

        public Pieces(char visuals, int row = 0, int column = 0)
        {
            piecePos = new Position(row, column);

            this.visuals = visuals;
        }

        public void PieceOnBoard(Board board)
        {
            board[piecePos.X, piecePos.Y] = visuals;
        }

        public void PieceMovement(Board board)
        {
            Console.WriteLine("Which way do you wish to move the piece?\n"
            + "\t1 -> Left\t3 -> Top Left\t\t5 -> Top\t7 -> TopRight\n"
            + "\t2 -> Right\t4 -> Bottom Left\t6 -> Bottom\t8 -> "
            + "Bottom Right");

            int moveChoice;

            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                moveChoice < 1 || moveChoice > 8);

            if (moveChoice == 1)
            {
                if (piecePos.Y > 0 
                    && board[piecePos.X, piecePos.Y - 1] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (0, -1);
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }
            }
            else if (moveChoice == 2)
            {
                if (piecePos.Y < 5 
                    && board[piecePos.X, piecePos.Y + 1] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (0, 1);;
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }
            }
            else if (moveChoice == 3)
            {
                if (piecePos.X > 0 && piecePos.Y < 5 
                    && board[piecePos.X - 1, piecePos.Y + 1] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (-1, 1);;
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }
            }
            else if (moveChoice == 4)
            {
                if (piecePos.X < 5 && piecePos.Y > 0 
                    && board[piecePos.X + 1, piecePos.Y - 1] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (1, -1);
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }                
            }
            else if (moveChoice == 5)
            {
                if (piecePos.X > 0 
                    && board[piecePos.X -1, piecePos.Y] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (-1, 0);
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }                
            }
            else if (moveChoice == 6)
            {
                if (piecePos.X < 5 
                    && board[piecePos.X + 1, piecePos.Y] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (1, 0);
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }
            }
            else if (moveChoice == 7)
            {
                if (piecePos.X > 0 && piecePos.Y < 5 
                    && board[piecePos.X - 1, piecePos.Y + 1] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (-1, 1);
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }
            }
            else if (moveChoice == 8)
            {
                if (piecePos.X < 5 && piecePos.Y < 5 
                    && board[piecePos.X + 1, piecePos.Y + 1] == 'o')
                {
                    board[piecePos.X, piecePos.Y] = 'o';
                    piecePos += (1, 1);
                }
                else
                {
                    Console.WriteLine("Your piece can't move that way.\n");

                    PieceMovement(board);
                }
            }
            else
            {
                Console.WriteLine("That choice isn't valid.\n");

                PieceMovement(board);
            }
        }
    }
}