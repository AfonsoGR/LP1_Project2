using System.Collections.Generic;

namespace Felli
{
    /// <summary>
    /// Sets up the game pieces to be placed on the board and their movement
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// Define public Position variable 'piecePos'
        /// </summary>
        public Position piecePos;
        
        /// <summary>
        /// Define public ColorChoice variable 'visuals'
        /// </summary>
        public ColorChoice visuals;
        
        /// <summary>
        /// Define private readonly variable 'board'
        /// </summary>
        private readonly Board board;

        /// <summary>
        /// Define public int variable 'id'
        /// </summary>
        public int id;

        /// <summary>
        /// Constructor for creating new pieces
        /// </summary>
        /// <param name="visuals"> Piece's 'visuals' appearance </param>
        /// <param name="board"> Current state of the board </param>
        /// <param name="row"> Piece's X position </param>
        /// <param name="column"> Piece's Y position </param>
        /// <param name="iD"> Each piece's corresponding ID </param>
        public Piece(ColorChoice visuals, Board board, int row = 0,
            int column = 0, int iD = 0)
        {
            // Assigns value to 'id'
            id = iD;

            // X
            piecePos = new Position(row, column);

            // X
            this.board = board;

            // X
            this.visuals = visuals;
        }

        /// <summary>
        /// Display's the pieces 'visuals' on their positions in the board
        /// </summary>
        public void PieceOnBoard()
        {
            // Displays the corresponding 'visuals' of the pieces on the board
            board[piecePos.X, piecePos.Y] = visuals;
        }

        /// <summary>
        /// Manages the piece's coordinates when they move
        /// </summary>
        /// <param name="player"> Current state of the player </param>
        /// <param name="x"> Movement value in the X axis </param>
        /// <param name="y"> Movement value in the Y axis </param>
        /// <returns></returns>
        private string MovementCoordinates(Player player, int x, int y)
        {
            // Defines bool variable 'canMov' and assigns a value
            bool canMove = false;

            // Defines int variable 'nextX' and assigns a value
            int nextX = x + x;
            
            // Defines int variable 'nextY' and assigns a value
            int nextY = y + y;

            // Checks if the current piece is on 
            // the top or bottom line of the board
            if (piecePos.X == board.SizeX - 1 || piecePos.X == 0)
            {
                // Assigns new value to 'nextY'
                nextY = y * 2 + y * 2;
            }

            // Checks if the player stays inside the board after he moves
            if ((piecePos.X + nextX >= 0 && piecePos.Y + nextY >= 0 &&
                piecePos.X + nextX < board.SizeX &&
                piecePos.Y + nextY < board.SizeY))
            {
                // Assigns new value to 'canMove'
                canMove = (board[piecePos.X + nextX, piecePos.Y + nextY]
                == ColorChoice.None);
            }

            // Checks if the player can capture the piece in his way
            if (board[piecePos.X + x, piecePos.Y + y] != visuals &&
                board[piecePos.X + x, piecePos.Y + y] != ColorChoice.None &&
                canMove)
            {
                // Checks if the player isn't null
                if (player != null)
                {
                    // Creates a new Position
                    Position position =
                        new Position(piecePos.X + nextX / 2,
                        piecePos.Y + nextY / 2);
                    
                    // Calls CapturePiece method to capture a piece
                    CapturePiece(player, position);

                    // Calculates new position for the piece 
                    piecePos += (nextX, nextY);
                }
                // Returns null
                return null;
            }
            // Checks if the player can move to the next open space
            else if (board[piecePos.X + x, piecePos.Y + y] == ColorChoice.None)
            {
                // Checks if the player isn't null
                if (player != null)
                {
                    // Calculates new position for the piece
                    piecePos += (x, y);
                }
                // Returns null
                return null;
            }
            // Previous conditions weren't met
            else
            {
                // Returns string
                return "Your piece can't move that way.";
            }
        }

        /// <summary>
        /// Manages piece capturing
        /// </summary>
        /// <param name="player"> Current state of the player </param>
        /// <param name="position"> Current state of the position </param>
        public void CapturePiece(Player player, Position position)
        {
            // Saves the pieces that have been captured 
            List<Piece> capturedPieces = new List<Piece>();

            // Checks all of the opposite player's pieces
            for (int i = 0; i < player.playerPieces.Length; i++)
            {
                // Checks if a specific piece's position is different from their position ???????????????????????????????????????????????????????????????????? 
                if (player.playerPieces[i].piecePos != position)
                {
                    // Adds the piece to the list of captured pieces
                    capturedPieces.Add(player.playerPieces[i]);
                }
            }

            // Assigns 'playerPieces' to 'capturedPieces' 
            // and converts them to an array
            player.playerPieces = capturedPieces.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opositePlayer"> State of the opposite player </param>
        /// <param name="moveChoice"> Stores user movement choice </param>
        /// <returns></returns>
        public string PieceMovement(Player opositePlayer, int moveChoice)
        {
            // Calls Restrictions method and assigns it to string
            string invalidMove = Restrictions(moveChoice);

            // Checks if 'invalidMove' isn't null
            if (invalidMove != null)
            {
                // Returns 'invalidMove'
                return invalidMove;
            }

            // Checks player's movement choice
            if (moveChoice == 0)
            {
                // Returns string
                return "Canceled Piece Movement";
            }
            // Checks player's movement choice
            else if (moveChoice == 1)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.X < 4 && piecePos.Y > 0 ?
                    MovementCoordinates(opositePlayer, 1, -1)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 2)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.X < 4 ?
                    MovementCoordinates(opositePlayer, 1, 0)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 3)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.X < 4 && piecePos.Y < 4 ?
                    MovementCoordinates(opositePlayer, 1, 1)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 4)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.Y > 0 ?
                    MovementCoordinates(opositePlayer, 0, -1)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 6)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.Y < 4 ?
                    MovementCoordinates(opositePlayer, 0, 1)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 7)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.X > 0 && piecePos.Y > 0 ?
                    MovementCoordinates(opositePlayer, -1, -1)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 8)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.X > 0 ?
                    MovementCoordinates(opositePlayer, -1, 0)
                    : "Your piece can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 9)
            {
                // Checks if the piece can move that way, 
                // returns string if it can't
                return piecePos.X > 0 && piecePos.Y < 4 ?
                    MovementCoordinates(opositePlayer, -1, 1)
                    : "Your piece can't move that way.";
            }
            // Previous conditions weren't met
            else
            {
                // Returns string
                return "Please select valid option.";
            }
        }

        /// <summary>
        /// Manages specific movement restrictions
        /// </summary>
        /// <param name="moveChoice"> Stores user's movement choice </param>
        /// <returns></returns>
        private string Restrictions(int moveChoice)
        {
            // Checks if a piece is in a specific X and Y coordinate
            if (piecePos.X != board.SizeX / 2 && piecePos.Y == board.SizeY / 2)
            {
                // Checks the player's movement choice
                if (moveChoice == 1 || moveChoice == 3 ||
                    moveChoice == 7 || moveChoice == 9)
                {
                    // Returns string
                    return "Your piece can't move that way";
                }
            }

            // Checks if a piece is in a specific X and Y coordinate
            if (piecePos.X == 1 && piecePos.Y == 1)
            {
                // Checks the player's movement choice
                if (moveChoice == 9)
                {
                    // Returns string
                    return "Your piece can't move that way";
                }
            }

            // Checks if a piece is in a specific X and Y coordinate
            if (piecePos.X == 3 && piecePos.Y == 1)
            {
                // Checks the player's movement choice
                if (moveChoice == 3)
                {
                    // Returns string
                    return "Your piece can't move that way";
                }
            }

            // Checks if a piece is in a specific X and Y coordinate
            if (piecePos.X == 1 && piecePos.Y == 3)
            {
                // Checks the player's movement choice
                if (moveChoice == 7)
                {
                    // Returns string
                    return "Your piece can't move that way";
                }
            }

            // Checks if a piece is in a specific X and Y coordinate
            if (piecePos.X == 3 && piecePos.Y == 3)
            {
                // Checks the player's movement choice
                if (moveChoice == 1)
                {
                    // Returns string
                    return "Your piece can't move that way";
                }
            }
            // Returns null
            return null;
        }
    }
}