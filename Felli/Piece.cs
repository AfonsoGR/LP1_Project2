using System.Collections.Generic;

namespace Felli
{
    /// <summary>
    /// Sets up the game pieces to be placed on the board and their movement
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// Define public Position variable 'PiecePos'
        /// </summary>
        public Position PiecePos { get; private set; }
        
        /// <summary>
        /// Saves the ID of the pieces 
        /// </summary>
        public int ID { get; }

        // Saves visuals aspect of the pieces
        private ColorChoice visuals;
        
        // Saves the board
        private readonly Board board;

        /// <summary>
        /// Constructor for creating new pieces
        /// </summary>
        /// <param name="visuals"> Piece's 'visuals' appearance </param>
        /// <param name="board"> Current state of the board </param>
        /// <param name="row"> Piece's X position </param>
        /// <param name="column"> Piece's Y position </param>
        /// <param name="iD"> This players's corresponding ID </param>
        public Piece(ColorChoice visuals, Board board, int row = 0,
            int column = 0, int iD = 0)
        {
            // Assigns value to 'ID'
            ID = iD;

            // Creates new players's position
            PiecePos = new Position(row, column);

            // Assigns board to the one given
            this.board = board;

            // Assigns visuals to the one given
            this.visuals = visuals;
        }

        /// <summary>
        /// Updates the pieces' visuals on their positions in the board
        /// </summary>
        public void PieceOnBoard()
        {
            // Update the corresponding 'visuals' of the pieces on the board
            board[PiecePos.X, PiecePos.Y] = visuals;
        }

        /// <summary>
        /// Manages the players's ability to capture or move
        /// </summary>
        /// <param name="player"> Current state of the opposite player </param>
        /// <param name="x"> Movement value in the X axis </param>
        /// <param name="y"> Movement value in the Y axis </param>
        /// <returns></returns>
        private string CaptureOrMove(Player player, int x, int y)
        {
            // Defines bool variable 'canMov' and assigns a value
            bool canMove = false;

            // Defines int variable 'nextX' and assigns a value
            int nextX = x + x;
            
            // Defines int variable 'nextY' and assigns a value
            int nextY = y + y;

            // Checks if the current players is on 
            // the top or bottom line of the board
            if ((PiecePos.X == board.SizeX - 1 && x == 0) || 
                (PiecePos.X == 0 && x == 0))
            {
                // Assigns new value to 'nextY'
                nextY = (y * 2 ) + (y * 2) ;
            }

            // Checks if the player will stay inside the board after he moves
            if ((PiecePos.X + nextX >= 0 && PiecePos.Y + nextY >= 0 &&
                PiecePos.X + nextX < board.SizeX &&
                PiecePos.Y + nextY < board.SizeY))
            {
                // Checks if there is an open space after the 
                // players that is going to be captured
                canMove = (board[PiecePos.X + nextX, PiecePos.Y + nextY]
                == ColorChoice.None);
            }

            // Checks if the player can capture the players in his way
            if (board[PiecePos.X + nextX/2, PiecePos.Y + nextY/2] != visuals &&
                board[PiecePos.X + nextX/2 , PiecePos.Y + nextY/2] != ColorChoice.None &&
                canMove)
            {
                // Checks if the player isn't null
                if (player != null)
                {
                    // Creates a new Position where the captured players is
                    Position position =
                        new Position(PiecePos.X + nextX / 2,
                        PiecePos.Y + nextY / 2);
                    
                    // Calls CapturePiece method 
                    CapturePiece(player, position);

                    // Calculates new position for the players 
                    PiecePos += (nextX, nextY);
                }
                // Returns null
                return null;
            }
            // Checks if the player can move to the next open space
            else if (board[PiecePos.X + x, PiecePos.Y + nextY / 2] 
                == ColorChoice.None)
            {
                // Checks if the player isn't null
                if (player != null)
                {
                    // Calculates new position for the current players
                    PiecePos += (x, nextY / 2);
                }
                // Returns null
                return null;
            }
            // Previous conditions weren't met
            else
            {
                // Returns a message
                return "Your players can't move that way.";
            }
        }

        /// <summary>
        /// Manages players capturing
        /// </summary>
        /// <param name="player"> Current state of the opposite player </param>
        /// <param name="position"> Position of players to be captured </param>
        private void CapturePiece(Player player, Position position)
        {
            // Saves the pieces that haven't been captured 
            List<Piece> newPlayerPieces = new List<Piece>();

            // Checks all of the opposite player's pieces
            for (int i = 0; i < player.playerPieces.Length; i++)
            {
                // Checks if a players's position is different from 
                // the given position
                if (player.playerPieces[i].PiecePos != position)
                {
                    // Adds the players to the list of newPlayerPieces
                    newPlayerPieces.Add(player.playerPieces[i]);
                }
            }

            // Replaces the opposite player's pieces by 'newPlayerPieces'
            player.playerPieces = newPlayerPieces.ToArray();
        }

        /// <summary>
        /// Manages players movement 
        /// </summary>
        /// <param name="opositePlayer"> State of the opposite player </param>
        /// <param name="moveChoice"> Given movement choice </param>
        /// <returns></returns>
        public string PieceMovement(Player opositePlayer, int moveChoice)
        {
            // Calls Restrictions method and assigns it to 'invalidMove' string
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
                // Returns a message
                return "Canceled Piece Movement";
            }
            // Checks player's movement choice
            else if (moveChoice == 1)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.X < 4 && PiecePos.Y > 0 ?
                    CaptureOrMove(opositePlayer, 1, -1)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 2)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.X < 4 ?
                    CaptureOrMove(opositePlayer, 1, 0)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 3)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.X < 4 && PiecePos.Y < 4 ?
                    CaptureOrMove(opositePlayer, 1, 1)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 4)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.Y > 0 ?
                    CaptureOrMove(opositePlayer, 0, -1)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 6)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.Y < 4 ?
                    CaptureOrMove(opositePlayer, 0, 1)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 7)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.X > 0 && PiecePos.Y > 0 ?
                    CaptureOrMove(opositePlayer, -1, -1)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 8)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.X > 0 ?
                    CaptureOrMove(opositePlayer, -1, 0)
                    : "Your players can't move that way.";
            }
            // Checks the player's movement choice
            else if (moveChoice == 9)
            {
                // Checks if the players can move that way, 
                // returns string if it can't
                return PiecePos.X > 0 && PiecePos.Y < 4 ?
                    CaptureOrMove(opositePlayer, -1, 1)
                    : "Your players can't move that way.";
            }
            // Previous conditions weren't met
            else
            {
                // Returns a message
                return "Please select valid option.";
            }
        }

        /// <summary>
        /// Manages specific movement restrictions
        /// </summary>
        /// <param name="moveChoice"> Given movement choice </param>
        /// <returns> Returns a message </returns>
        private string Restrictions(int moveChoice)
        {
            // Checks if a players is in a specific X and Y coordinates
            if (PiecePos.X != board.SizeX / 2 && PiecePos.Y == board.SizeY / 2)
            {
                // Checks the player's movement choice
                if (moveChoice == 1 || moveChoice == 3 ||
                    moveChoice == 7 || moveChoice == 9)
                {
                    // Returns a message
                    return "Your players can't move that way";
                }
            }

            // Checks if a players is in a specific X and Y coordinates
            if (PiecePos.X == 1 && PiecePos.Y == 1)
            {
                // Checks the player's movement choice
                if (moveChoice == 9)
                {
                    // Returns a message
                    return "Your players can't move that way";
                }
            }

            // Checks if a players is in a specific X and Y coordinates
            if (PiecePos.X == 3 && PiecePos.Y == 1)
            {
                // Checks the player's movement choice
                if (moveChoice == 3)
                {
                    // Returns a message
                    return "Your players can't move that way";
                }
            }

            // Checks if a players is in a specific X and Y coordinates
            if (PiecePos.X == 1 && PiecePos.Y == 3)
            {
                // Checks the player's movement choice
                if (moveChoice == 7)
                {
                    // Returns a message
                    return "Your players can't move that way";
                }
            }

            // Checks if a players is in a specific X and Y coordinates
            if (PiecePos.X == 3 && PiecePos.Y == 3)
            {
                // Checks the player's movement choice
                if (moveChoice == 1)
                {
                    // Returns a message
                    return "Your players can't move that way";
                }
            }
            // Returns null
            return null;
        }
    }
}