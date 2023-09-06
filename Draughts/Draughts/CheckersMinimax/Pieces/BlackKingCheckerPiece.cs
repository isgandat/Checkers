using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Pieces
{
    public class BlackKingCheckerPiece : KingCheckerPiece, IBlackPiece
    {
        
        /// Initializes a new instance of the <see cref="BlackKingCheckerPiece"/> class.

        public BlackKingCheckerPiece()
        {
            imageSource = "Resources/black60p_king.png";
        }

        
        /// Gets the minimax clone.

        /// returns= 
        /// clone to be used for minimax
        /// 
        public override object GetMinimaxClone()
        {
            return new BlackKingCheckerPiece();
        }

        
        /// Gets the string rep.

        /// returns= 
        /// String representation used for debugging
        /// 
        public override string GetStringRep()
        {
            return "| B |";
        }
    }
}
