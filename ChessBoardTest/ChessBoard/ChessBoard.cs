using System.Collections.Generic;

namespace ChessBoard
{
    internal class ChessBoard
    {
        public ChessBoard()
        {

        }

        internal List<string> MakeNextMove(IChessPiece chessPiece, string fromCellPostion)
        {
            List<string> possibleCellPositions = new List<string>();
            if(chessPiece.GetMoventDirection() == MovementDirection.All)
            {
                // Get Horizantal Possible CellPositions
                HorizantalMovement horizantalMovement = new HorizantalMovement();
                possibleCellPositions.AddRange(horizantalMovement.GetPossibleMoves(chessPiece, fromCellPostion));
            }
            return possibleCellPositions;
        }
    }
}
