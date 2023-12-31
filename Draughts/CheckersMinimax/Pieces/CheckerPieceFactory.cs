﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMinimax.Pieces
{
    public static class CheckerPieceFactory
    {
        
        /// Gets the checker piece.

        /// <param name="type">The type.</param>
        /// returns= Checkerpiece from the factory
        /// <exception cref="ArgumentException">Enum to Checker Piece not defined</exception>
        public static CheckerPiece GetCheckerPiece(CheckerPieceType type)
        {
            switch (type)
            {
                case CheckerPieceType.RedPawn:
                    return new RedPawnCheckerPiece();
                case CheckerPieceType.RedKing:
                    return new RedKingCheckerPiece();
                case CheckerPieceType.BlackPawn:
                    return new BlackPawnCheckerPiece();
                case CheckerPieceType.BlackKing:
                    return new BlackKingCheckerPiece();
                case CheckerPieceType.nullPiece:
                    return new NullCheckerPiece();
                default:
                    throw new ArgumentException("Enum to Checker Piece not defined");
            }
        }
    }
}
