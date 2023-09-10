using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CheckersMinimax.Pieces
{
    public class NullCheckerPiece : CheckerPiece
    {
        
        /// Initializes a new instance of the <see cref="NullCheckerPiece"/> class.

        public NullCheckerPiece()
        {
            imageSource = null;
        }

        
        /// Builds the checker image source.

        /// returns= Image source object
        public override ImageSource BuildCheckerImageSource()
        {
            return null;
        }

        
        /// Gets the minimax clone.

        /// returns= clone to be used for minimax
        public override object GetMinimaxClone()
        {
            return new NullCheckerPiece();
        }

        
        /// Gets the possible moves. Null Checker Piece has no moves

        /// <param name="currentLocation">The current location.</param>
        /// <param name="checkerBoard">The checker board.</param>
        /// returns= List of possible moves for this checkerpiece
        public override List<CheckersMove> GetPossibleMoves(CheckersPoint currentLocation, CheckerBoard checkerBoard)
        {
            return new List<CheckersMove>();
        }

        
        /// Gets the string rep.

        /// returns= String representation
        public override string GetStringRep()
        {
            return "|   |";
        }
    }
}
