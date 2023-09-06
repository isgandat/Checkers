using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Pieces
{
    public class RedPawnCheckerPiece : CheckerPiece, IRedPiece
    {
        public RedPawnCheckerPiece()
        {
            imageSource = "Resources/red60p.png";
        }

        
        /// Gets the minimax clone.

        /// returns= Clone to be used for minimax
        public override object GetMinimaxClone()
        {
            return new RedPawnCheckerPiece();
        }

        
        /// Gets the possible points for a red pawn checker.
        /// Red pawn checkers can only move up diagnally left or right. This method calls the base class ProcessUpMoves
        /// to generate the up moves.

        /// <param name="currentLocation">The current location.</param>
        /// <param name="checkerBoard">The checker board.</param>
        /// returns= List of possible moves
        public override List<CheckersMove> GetPossibleMoves(CheckersPoint currentLocation, CheckerBoard checkerBoard)
        {
            return ProcessUpMoves(currentLocation, checkerBoard);
        }

        
        /// Gets the string representation.

        /// returns= String representation
        public override string GetStringRep()
        {
            return "| r |";
        }
    }
}