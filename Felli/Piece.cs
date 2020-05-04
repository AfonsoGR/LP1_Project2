using System;
using System.Collections.Generic;

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

        private string MovementCoordinates(Player player, int x, int y)
        {
            if ((board[piecePos.X + x, piecePos.Y + y] != visuals &&
                board[piecePos.X + x, piecePos.Y + y] != ColorChoice.None) &&
                (board[piecePos.X + (x + x), piecePos.Y + (y + y)]
                == ColorChoice.None))
            {
                Position position =
                    new Position(piecePos.X + x, piecePos.Y + y);
                CapturePiece(player, position);
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

        public void CapturePiece(Player player, Position position)
        {
            List<Piece> capturedPieces = new List<Piece>();

            for (int i = 0; i < player.playerPieces.Length; i++)
            {
                if (player.playerPieces[i].piecePos != position)
                {
                    capturedPieces.Add(player.playerPieces[i]);
                }
            }

            player.playerPieces = capturedPieces.ToArray();
        }

        public string PieceMovement(Player opositePlayer)
        {
            int moveChoice;

            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                 moveChoice < 0 || moveChoice > 9 || moveChoice == 5)
            {
                ;
            }

            if (piecePos.X != board.SizeX / 2 && piecePos.Y == board.SizeY / 2)
            {
                if (moveChoice == 1 || moveChoice == 3 ||
                    moveChoice == 7 || moveChoice == 9)
                {
                    return "Your piece can't move that way";
                }
            }

            if (moveChoice == 0)
            {
                return "Canceled Piece Movement";
            }
            else if (moveChoice == 1)
            {
                return piecePos.X < 4 && piecePos.Y > 0 ?
                    MovementCoordinates(opositePlayer, 1, -1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 2)
            {
                return piecePos.X < 4 ?
                    MovementCoordinates(opositePlayer, 1, 0)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 3)
            {
                return piecePos.X < 4 && piecePos.Y < 4 ?
                    MovementCoordinates(opositePlayer, 1, 1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 4)
            {
                return piecePos.Y > 0 ?
                    MovementCoordinates(opositePlayer, 0, -1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 6)
            {
                return piecePos.Y < 4 ?
                    MovementCoordinates(opositePlayer, 0, 1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 7)
            {
                return piecePos.X > 0 && piecePos.Y > 0 ?
                    MovementCoordinates(opositePlayer, -1, -1)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 8)
            {
                return piecePos.X > 0 ?
                    MovementCoordinates(opositePlayer, -1, 0)
                    : "Your piece can't move that way.";
            }
            else if (moveChoice == 9)
            {
                return piecePos.X > 0 && piecePos.Y < 4 ?
                    MovementCoordinates(opositePlayer, -1, 1)
                    : "Your piece can't move that way.";
            }
            else
            {
                return "Please select valid option.";
            }
        }
    }
}