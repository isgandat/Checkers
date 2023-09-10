using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Pieces
{
    public class BlackPawnCheckerPiece : CheckerPiece, IBlackPiece
    {
        
        /// Initializes a new instance of the <see cref="BlackPawnCheckerPiece"/> class.

        public BlackPawnCheckerPiece()
        {
            imageSource = "Resources/black60p.png";
        }

        
        /// Gets the minimax clone.

        /// returns= 
        /// clone to be used for minimax
        /// 
        public override object GetMinimaxClone()
        {
            return new BlackPawnCheckerPiece();
        }

        
        /// Gets the possible moves.

        /// <param name="currentLocation">The current location.</param>
        /// <param name="checkerBoard">The checker board.</param>
        /// returns= 
        /// List of possible moves for this piece
        /// 
        public override List<CheckersMove> GetPossibleMoves(CheckersPoint currentLocation, CheckerBoard checkerBoard)
        {
            return ProcessDownMoves(currentLocation, checkerBoard);
        }

        
        /// Gets the string rep.

        /// returns= 
        /// String representation used for debugging
        /// 
        public override string GetStringRep()
        {
            return "| b |";
        }
    }
}
