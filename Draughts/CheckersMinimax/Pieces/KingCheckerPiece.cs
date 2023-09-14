using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Pieces
{
    public abstract class KingCheckerPiece : CheckerPiece
    {
        
        /// Gets the possible moves.

        /// <param name="currentLocation">The current location.</param>
        /// <param name="checkerBoard">The checker board.</param>
        /// returns= List of possible moves
        public override List<CheckersMove> GetPossibleMoves(CheckersPoint currentLocation, CheckerBoard checkerBoard)
        {
            List<CheckersMove> list = new List<CheckersMove>();

            //Can we go down the board?
            list.AddRange(ProcessDownMoves(currentLocation, checkerBoard));

            //Can we go up the board?
            list.AddRange(ProcessUpMoves(currentLocation, checkerBoard));

            return GetPossibleMovesIncludingBishopLike(currentLocation,checkerBoard);
        }

        /// Gets the possible moves including bishop-like moves.

        /// <param name="currentLocation">The current location.</param>
        /// <param name="checkerBoard">The checker board.</param>
        /// returns= List of possible moves, including bishop-like moves.
        public List<CheckersMove> GetPossibleMovesIncludingBishopLike(CheckersPoint currentLocation, CheckerBoard checkerBoard)
        {
            List<CheckersMove> list = new List<CheckersMove>();

            // Include normal king moves (up and down)
            list.AddRange(ProcessDownMoves(currentLocation, checkerBoard));
            list.AddRange(ProcessUpMoves(currentLocation, checkerBoard));

            // Include bishop-like moves
            list.AddRange(GetBishopLikeMoves(currentLocation, checkerBoard));

            return list;
        }

        /// Gets the bishop-like moves for a king piece.

        /// <param name="currentLocation">The current location.</param>
        /// <param name="checkerBoard">The checker board.</param>
        /// returns= List of bishop-like moves.
        private List<CheckersMove> GetBishopLikeMoves(CheckersPoint currentLocation, CheckerBoard checkerBoard)
        {
            List<CheckersMove> list = new List<CheckersMove>();

            // Define the directions for bishop-like movement (diagonals)
            int[] verticalModifiers = { -1, -1, 1, 1 };
            int[] horizontalModifiers = { -1, 1, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int row = currentLocation.Row + verticalModifiers[i];
                int col = currentLocation.Column + horizontalModifiers[i];

                while (row >= 0 && row < 8 && col >= 0 && col < 8)
                {
                    CheckerPiece pieceOnPoint = checkerBoard.BoardArray[row][col].CheckersPoint.Checker;

                    if (pieceOnPoint == null || pieceOnPoint is NullCheckerPiece)
                    {
                        // The destination point is empty, we can go here
                        list.Add(new CheckersMove(currentLocation, new CheckersPoint(row, col)));
                    }
                    else
                    {
                        // The destination point is occupied, stop searching in this direction
                        break;
                    }

                    // Move to the next diagonal point
                    row += verticalModifiers[i];
                    col += horizontalModifiers[i];
                }
            }

            return list;
        }
    }
}
