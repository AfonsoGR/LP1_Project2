using System;

namespace Felli
{
    public class Pieces
    {
        public Position piecePos;
        public char visuals;

        public Pieces(char visuals, int row = 0, int column = 0)
        {
            Position position = new Position(row, column);

            this.visuals = visuals;
        }

        public void PieceOnBoard(Board board)
        {
            board[piecePos.X, piecePos.Y] = visuals;
        }

        public void PieceMovement(Board board)
        {
            Console.WriteLine("Which way do you wish to move the piece?\n"
            + "\t1 -> Top Left\t\t2 -> Top\t3 -> TopRight\n"
            + "\t4 -> Bottom Left\t5 -> Bottom\t6 -> Bottom Right");

            int moveChoice;

            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                moveChoice < 1 || moveChoice > 6);

            if (moveChoice == 1)
            {

            }
            else if (moveChoice == 2)
            {
                
            }
            else if (moveChoice == 3)
            {
                
            }
            else if (moveChoice == 4)
            {
                
            }
            else if (moveChoice == 5)
            {
                
            }
            else if (moveChoice == 6)
            {

            }
            else
            {
                Console.WriteLine("Your piece can't move that way.\n");

                PieceMovement(board);
            }
        }
    }
}