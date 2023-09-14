using CheckersMinimax.Clone;
using CheckersMinimax.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax
{
    public class CheckersPoint : IMinimaxClonable
    {
        
        /// Gets or sets the row.

        /// <value>
        /// The row.
        /// </value>
        public int Row { get; set; }

        
        /// Gets or sets the column.

        /// <value>
        /// The column.
        /// </value>
        public int Column { get; set; }

        
        /// Gets or sets the checker piece.

        /// <value>
        /// The checker.
        /// </value>
        public CheckerPiece Checker { get; set; }

        
        /// Initializes a new instance of the <see cref="CheckersPoint"/> class.

        public CheckersPoint()
        {
        }

        
        /// Initializes a new instance of the <see cref="CheckersPoint"/> class.

        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="checker">The checker.</param>
        public CheckersPoint(int row, int column, CheckerPiece checker)
        {
            Row = row;
            Column = column;
            Checker = checker;
        }

        
        /// Initializes a new instance of the <see cref="CheckersPoint"/> class.

        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="checkerPieceType">Type of the checker piece.</param>
        public CheckersPoint(int row, int column, CheckerPieceType checkerPieceType)
        {
            Row = row;
            Column = column;
            Checker = CheckerPieceFactory.GetCheckerPiece(checkerPieceType);
        }

        
        /// Initializes a new instance of the <see cref="CheckersPoint"/> class.

        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public CheckersPoint(int row, int column)
        {
            Row = row;
            Column = column;
            Checker = CheckerPieceFactory.GetCheckerPiece(CheckerPieceType.nullPiece);
        }

        
        /// Returns a list of all the possible moves on the passed in board for this particular point

        /// <param name="checkerBoard">The checker board to find moves on</param>
        /// returns= list of all the possible moves on the passed in board for this particular point
        public List<CheckersMove> GetPossibleMoves(CheckerBoard checkerBoard)
        {
            return Checker.GetPossibleMoves(this, checkerBoard);
        }

        
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.

        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// returns= 
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// 
        public override bool Equals(object obj)
        {
            if ((obj != null) && (obj is CheckersPoint otherPoint))
            {
                return this.Column == otherPoint.Column && this.Row == otherPoint.Row;
            }
            else
            {
                return false;
            }
        }

        
        /// Returns a hash code for this instance.

        /// returns= 
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// 
        public override int GetHashCode()
        {
            int hashCode = 13;
            hashCode += Row.GetHashCode();
            hashCode += Column.GetHashCode();
            return hashCode;
        }

        
        /// Gets the minimax clone. For this class it is essentially a deep copy

        /// returns= Minimax Clone of this class
        public object GetMinimaxClone()
        {
            CheckersPoint deepClone = new CheckersPoint()
            {
                Checker = (CheckerPiece)this.Checker.GetMinimaxClone(),
                Column = this.Column,
                Row = this.Row
            };

            return deepClone;
        }
    }
}
