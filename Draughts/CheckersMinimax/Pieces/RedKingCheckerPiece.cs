using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Pieces
{
    public class RedKingCheckerPiece : KingCheckerPiece, IRedPiece
    {
        
        /// Initializes a new instance of the <see cref="RedKingCheckerPiece"/> class.

        public RedKingCheckerPiece()
        {
            imageSource = "Resources/red60p_king.png";
        }

        
        /// Gets the minimax clone.

        /// returns= Minimax clone of this object
        public override object GetMinimaxClone()
        {
            return new RedKingCheckerPiece();
        }

        
        /// Gets the string rep.

        /// returns= String representation
        public override string GetStringRep()
        {
            return "| R |";
        }
    }
}
