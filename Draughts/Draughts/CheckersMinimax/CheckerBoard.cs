using CheckersMinimax.AI;
using CheckersMinimax.Clone;
using CheckersMinimax.Pieces;
using CheckersMinimax.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace CheckersMinimax
{
    [Serializable]

    
    /// The Checkerboard class. This class holds the two dimentional board array ([Row][Column]) and evaluates the heuristics for the board
    /// </summary>
    public class CheckerBoard : IMinimaxClonable
    {
        private static readonly Settings Settings = Settings.Default;

        
        /// Gets or sets the board array. Board represents [Row][Column]

        /// <value>
        /// The board array.
        /// </value>
        public List<List<CheckersSquareUserControl>> BoardArray { get; set; } = new List<List<CheckersSquareUserControl>>();

        
        /// Gets or sets the current player turn.

        /// <value>
        /// The current player turn.
        /// </value>
        public PlayerColor CurrentPlayerTurn { get; set; }

        public CheckerBoard()
        {
            CurrentPlayerTurn = DetermineWhosFirst();
        }

        
        /// Makes the board.

        /// <param name="routedEventHandler">The routed event handler.</param>
        public void MakeBoard(RoutedEventHandler routedEventHandler)
        {


       

            int count = 0;
            for (int row = 0; row < 8; row++)
            {
                BoardArray.Add(new List<CheckersSquareUserControl>());

                for (int column = 0; column < 8; column++)
                {
                    CheckersSquareUserControl checkerSquareUC;
                    if (row % 2 == 0)
                    {
                        if (column % 2 == 0)
                        {
                            checkerSquareUC = new CheckersSquareUserControl(
                                Brushes.Red,
                                new CheckersPoint(row, column, CheckerPieceType.nullPiece),
                                routedEventHandler);
                        }
                        else
                        {
                            if (row < 3)
                            {
                                checkerSquareUC = new CheckersSquareUserControl(
                                    Brushes.Black,
                                    new CheckersPoint(row, column, CheckerPieceType.BlackPawn),
                                    routedEventHandler);
                            }
                            else if (row > 4)
                            {
                                checkerSquareUC = new CheckersSquareUserControl(
                                    Brushes.Black,
                                    new CheckersPoint(row, column, CheckerPieceType.RedPawn),
                                    routedEventHandler);
                            }
                            else
                            {
                                checkerSquareUC = new CheckersSquareUserControl(
                                    Brushes.Black,
                                    new CheckersPoint(row, column, CheckerPieceType.nullPiece),
                                    routedEventHandler);
                            }
                        }
                    }
                    else
                    {
                        if (column % 2 == 0)
                        {
                            if (row < 3)
                            {
                                checkerSquareUC = new CheckersSquareUserControl(
                                    Brushes.Black,
                                    new CheckersPoint(row, column, CheckerPieceType.BlackPawn),
                                    routedEventHandler);
                            }
                            else if (row > 4)
                            {
                                checkerSquareUC = new CheckersSquareUserControl(
                                    Brushes.Black,
                                    new CheckersPoint(row, column, CheckerPieceType.RedPawn),
                                    routedEventHandler);
                            }
                            else
                            {
                                //empty middle spot
                                checkerSquareUC = new CheckersSquareUserControl(
                                    Brushes.Black,
                                    new CheckersPoint(row, column, CheckerPieceType.nullPiece),
                                    routedEventHandler);
                            }
                        }
                        else
                        {
                            checkerSquareUC = new CheckersSquareUserControl(
                                Brushes.Red,
                                new CheckersPoint(row, column, CheckerPieceType.nullPiece),
                                routedEventHandler);
                        }
                    }

                    count++;
                    BoardArray[row].Add(checkerSquareUC);
                }
            }
        }

        
        /// Checks the current board for a winner

        /// returns= Null if no winner was found, PlayerColor enum if so
        public object GetWinner()
        {
            List<CheckersPoint> redCheckerPoints = GetPointsForColor<IRedPiece>();
            List<CheckersPoint> blackCheckerPoints = GetPointsForColor<IBlackPiece>();

            /// MessageBox.Show(blackCheckerPoints.Count.ToString());
            if (blackCheckerPoints.Count == 0)
            {
                return PlayerColor.Red;
            }
            else if (redCheckerPoints.Count == 0)
            {
                return PlayerColor.Black;
            }
            else
            {
                return null;
            }
        }

        
        /// Gets all of points that have a checker on it of the ColorInterface type param

        /// <typeparam name="ColorInterface">The type of the color interface.</typeparam>
        /// returns= List of checkers points
        public List<CheckersPoint> GetPointsForColor<ColorInterface>()
        {
            List<CheckersPoint> listOfColor = new List<CheckersPoint>();

            foreach (List<CheckersSquareUserControl> list in BoardArray)
            {
                foreach (CheckersSquareUserControl squareUC in list)
                {
                    if (squareUC.CheckersPoint.Checker != null && squareUC.CheckersPoint.Checker is ColorInterface)
                    {
                        listOfColor.Add(squareUC.CheckersPoint);
                    }
                }
            }

            return listOfColor;
        }

        
        /// Return a heuristic value for a winning board

        /// <param name="rootPlayer">The minimax root player.</param>
        /// returns= heuristic for the board
        public int ScoreWin(PlayerColor rootPlayer)
        {
            int score = 0;
            object winningColor = this.GetWinner();

            if (winningColor != null && winningColor is PlayerColor winnerColor)
            {
                if (rootPlayer == PlayerColor.Red)
                {
                    if (winnerColor == PlayerColor.Red)
                    {
                        score = int.MaxValue;
                    }
                    else
                    {
                        score = int.MinValue;
                    }
                }
                else
                {
                    if (winnerColor == PlayerColor.Black)
                    {
                        score = int.MaxValue;
                    }
                    else
                    {
                        score = int.MinValue;
                    }
                }
            }
            return score;

        }

        
        /// Return a heuristic value for the board. This evaluation checks the number of pieces each player has.

        /// <param name="rootPlayer">The minimax root player.</param>
        /// returns= heuristic for the board
        public int ScoreA(PlayerColor rootPlayer)
        {
            int score = 0;
            int kingWorth = Settings.KingWorth;
            int pawnWorth = Settings.PawnWorth;

            if (rootPlayer == PlayerColor.Red)
            {
                if (Settings.RunningGeneticAlgo)
                {
                    kingWorth = Genetic.RandomGenome.GetRandomGenomeInstance().KingWorthGene;
                    pawnWorth = Genetic.RandomGenome.GetRandomGenomeInstance().PawnWorthGene;
                }

                foreach (CheckersPoint point in GetPointsForColor<IBlackPiece>())
                {
                    score -= point.Checker is KingCheckerPiece ? kingWorth : pawnWorth;
                }

                foreach (CheckersPoint point in GetPointsForColor<IRedPiece>())
                {
                    score += point.Checker is KingCheckerPiece ? kingWorth : pawnWorth;
                }
            }
            else
            {
                if (Settings.RunningGeneticAlgo)
                {
                    kingWorth = Genetic.WinningGenome.GetWinningGenomeInstance().KingWorthGene;
                    pawnWorth = Genetic.WinningGenome.GetWinningGenomeInstance().PawnWorthGene;
                }

                foreach (CheckersPoint point in GetPointsForColor<IBlackPiece>())
                {
                    score += point.Checker is KingCheckerPiece ? kingWorth : pawnWorth;
                }

                foreach (CheckersPoint point in GetPointsForColor<IRedPiece>())
                {
                    score -= point.Checker is KingCheckerPiece ? kingWorth : pawnWorth;
                }
            }

            return score;
        }

        
        /// Return a heuristic value for the board. This evaluation checks how close a piece is to becoming a king

        /// <param name="rootPlayer">The minimax root player.</param>
        /// returns= heuristic for the board
        public int ScoreB(PlayerColor rootPlayer)
        {
            int score = 0;

            foreach (List<CheckersSquareUserControl> list in BoardArray)
            {
                foreach (CheckersSquareUserControl squareUC in list)
                {
                    if (squareUC.CheckersPoint.Checker != null && !(squareUC.CheckersPoint.Checker is KingCheckerPiece))
                    {
                        if (rootPlayer == PlayerColor.Black)
                        {
                            if (squareUC.CheckersPoint.Checker is IRedPiece)
                            {
                                //Closer to top means red is closer to being king
                                score -= (squareUC.CheckersPoint.Row - 7) * -1;
                            }

                            if (squareUC.CheckersPoint.Checker is IBlackPiece)
                            {
                                //Closer to bottom means that black is closer to being a king
                                score += squareUC.CheckersPoint.Row;
                            }
                        }
                        else
                        {
                            if (squareUC.CheckersPoint.Checker is IRedPiece)
                            {
                                //Closer to top means red is closer to being king
                                score += (squareUC.CheckersPoint.Row - 7) * -1;
                            }

                            if (squareUC.CheckersPoint.Checker is IBlackPiece)
                            {
                                //Closer to bottom means that black is closer to being a king
                                score -= squareUC.CheckersPoint.Row;
                            }
                        }
                    }
                }
            }

            return score;
        }

        
        /// Return a heuristic value for the board. This evaluation checks to see if any pieces are in danger

        /// <param name="rootPlayer">The minimax root player.</param>
        /// returns= heuristic for the board
        public int ScoreC(PlayerColor rootPlayer)
        {
            int score = 0;
            int kingDangerValue = Settings.KingDangerValue;
            int pawnDangerValue = Settings.PawnDangerValue;

            if (Settings.RunningGeneticAlgo)
            {
                if (rootPlayer == PlayerColor.Red)
                {
                    kingDangerValue = Genetic.RandomGenome.GetRandomGenomeInstance().KingDangerValueGene;
                    pawnDangerValue = Genetic.RandomGenome.GetRandomGenomeInstance().PawnDangerValueGene;
                }
                else
                {
                    kingDangerValue = Genetic.WinningGenome.GetWinningGenomeInstance().KingDangerValueGene;
                    pawnDangerValue = Genetic.WinningGenome.GetWinningGenomeInstance().PawnDangerValueGene;
                }
            }

            List<CheckersMove> movesForOtherPlayer = GetMovesForPlayer();

            foreach (CheckersMove move in movesForOtherPlayer)
            {
                CheckersMove moveToCheck = move;
                do
                {
                    if (moveToCheck.JumpedPoint != null)
                    {
                        //A piece is in danger
                        if (moveToCheck.JumpedPoint.Checker is KingCheckerPiece)
                        {
                            score -= kingDangerValue;
                        }
                        else
                        {
                            score -= pawnDangerValue;
                        }
                    }

                    moveToCheck = moveToCheck.NextMove;
                }
                while (moveToCheck != null);
            }
            
            return score;
        }

        
        /// Swaps the turn.

        public void SwapTurns()
        {
            if (CurrentPlayerTurn == PlayerColor.Red)
            {
                CurrentPlayerTurn = PlayerColor.Black;
            }
            else
            {
                CurrentPlayerTurn = PlayerColor.Red;
            }
        }

        
        /// Returns a list of moves for the current players turn

        /// returns= List of moves for the current players turn
        /// <exception cref="ArgumentException">Unknown Player Color</exception>
        public List<CheckersMove> GetMovesForPlayer()
        {
            List<CheckersPoint> playersPoints = null;

            if (CurrentPlayerTurn == PlayerColor.Red)
            {
                playersPoints = GetPointsForColor<IRedPiece>();
            }
            else if (CurrentPlayerTurn == PlayerColor.Black)
            {
                playersPoints = GetPointsForColor<IBlackPiece>();
            }
            else
            {
                throw new ArgumentException("Unknown Player Color");
            }

            List<CheckersMove> allAvailableMoves = new List<CheckersMove>();
            foreach (CheckersPoint checkerPoint in playersPoints)
            {
                allAvailableMoves.AddRange(checkerPoint.GetPossibleMoves(this));
            }

            //If we have jump moves, filter out non jumps
            List<CheckersMove> jumpMoves = new List<CheckersMove>();
            foreach (CheckersMove move in allAvailableMoves)
            {
                if (move.JumpedPoint != null)
                {
                    jumpMoves.Add(move);
                }
            }

            if (jumpMoves.Count > 0)
            {
                return jumpMoves;
            }
            else
            {
                return allAvailableMoves;
            }
        }

        
        /// Makes the move on the board. Returns a boolean that represents if the turn was finished after making this move

        /// <param name="moveToMake">Move to make</param>
        /// returns= True if the turn is over
        public bool MakeMoveOnBoard(CheckersMove moveToMake)
        {
            return MakeMoveOnBoard(moveToMake, true);
        }

        
        /// Makes the move on the board.

        /// <param name="moveToMake">The move to make.</param>
        /// <param name="swapTurn">if set to <c>true</c> [swap turn].</param>
        /// returns= true if the current turn was finished
        public bool MakeMoveOnBoard(CheckersMove moveToMake, bool swapTurn)
        {
            CheckersPoint moveSource = moveToMake.SourcePoint;
            CheckersPoint moveDestination = moveToMake.DestinationPoint;

            //was this a cancel?
            if (moveSource != moveDestination)
            {
                CheckersPoint realDestination = this.BoardArray[moveDestination.Row][moveDestination.Column].CheckersPoint;
                CheckersPoint realSource = this.BoardArray[moveSource.Row][moveSource.Column].CheckersPoint;

                realDestination.Checker = (CheckerPiece)realSource.Checker.GetMinimaxClone();
                realSource.Checker = CheckerPieceFactory.GetCheckerPiece(CheckerPieceType.nullPiece);

                //was this a jump move?
                CheckersPoint jumpedPoint = moveToMake.JumpedPoint;
                if (jumpedPoint != null)
                {
                    //delete the checker piece that was jumped
                    CheckersSquareUserControl jumpedSquareUserControl = this.BoardArray[jumpedPoint.Row][jumpedPoint.Column];
                    jumpedSquareUserControl.CheckersPoint.Checker = CheckerPieceFactory.GetCheckerPiece(CheckerPieceType.nullPiece);
                    jumpedSquareUserControl.UpdateSquare();
                }

                //Is this piece a king now?
                if (!(realDestination.Checker is KingCheckerPiece)
                    && (realDestination.Row == 7 || realDestination.Row == 0))
                {
                    //Should be a king now
                    if (realDestination.Checker is IRedPiece)
                    {
                        realDestination.Checker = new RedKingCheckerPiece();
                    }
                    else
                    {
                        realDestination.Checker = new BlackKingCheckerPiece();
                    }
                }

                //Is this players turn over?
                if (moveToMake.NextMove == null && swapTurn)
                {
                    //Swap the current players turn
                    SwapTurns();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        
        /// Returns a <see cref="System.String" /> that represents this instance.

        /// returns= 
        /// A <see cref="System.String" /> that represents this instance.
        /// 
        public override string ToString()
        {
            StringBuilder boardString = new StringBuilder();
            foreach (List<CheckersSquareUserControl> list in BoardArray)
            {
                StringBuilder rowBuilder = new StringBuilder();
                foreach (CheckersSquareUserControl squareUC in list)
                {
                    if (squareUC.CheckersPoint.Checker != null)
                    {
                        //There is a piece here
                        rowBuilder.Append(squareUC.CheckersPoint.Checker.GetStringRep());
                    }
                }

                boardString.AppendLine(rowBuilder.ToString());
            }

            return boardString.ToString();
        }

        
        /// Gets the minimax clone.

        /// returns= Clone needed for minimax
        public object GetMinimaxClone()
        {
            List<List<CheckersSquareUserControl>> rows = new List<List<CheckersSquareUserControl>>();

            for (int row = 0; row < this.BoardArray.Count; row++)
            {
                List<CheckersSquareUserControl> columns = new List<CheckersSquareUserControl>();
                for (int col = 0; col < this.BoardArray[row].Count; col++)
                {
                    columns.Add((CheckersSquareUserControl)this.BoardArray[row][col].GetMinimaxClone());
                }

                rows.Add(columns);
            }

            return new CheckerBoard
            {
                CurrentPlayerTurn = this.CurrentPlayerTurn,
                BoardArray = rows
            };
        }

        
        /// Determines the whos first.

        /// returns= PlayerColor enum of whos first
        private PlayerColor DetermineWhosFirst()
        {
            if (Settings.WhosFirst.Equals("black", StringComparison.CurrentCultureIgnoreCase))
            {
                return PlayerColor.Black;
            }
            else
            {
                //If the user enters something other than black, default to red
                return PlayerColor.Red;
            }
        }
    }
}
