using System;
using System.Collections.Generic;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class ChessBoard
    {
        internal List<string> MakeNextMove(IChessPiece chessPiece, string fromCellPostion)
        {
            List<string> possibleCellPositions = new List<string>();
            if(chessPiece.GetMoventDirection() == MovementDirection.All)
            {
                // Get Horizantal Possible CellPositions
                GetHorizantalMovement(chessPiece, fromCellPostion, possibleCellPositions);
                GetVerticalMovement(chessPiece, fromCellPostion, possibleCellPositions);
                GetDiagonalMovement(chessPiece, fromCellPostion, possibleCellPositions);
            }
            else if (chessPiece.GetMoventDirection() == MovementDirection.Horizantal)
            {
                GetHorizantalMovement(chessPiece, fromCellPostion, possibleCellPositions);
            }
            else if (chessPiece.GetMoventDirection() == MovementDirection.Vertical)
            {
                GetVerticalMovement(chessPiece, fromCellPostion, possibleCellPositions);
            }
            else if (chessPiece.GetMoventDirection() == MovementDirection.Diagonal)
            {
                GetDiagonalMovement(chessPiece, fromCellPostion, possibleCellPositions);
            }
            return possibleCellPositions;
        }

        private void GetDiagonalMovement(IChessPiece chessPiece, string fromCellPostion, List<string> possibleCellPositions)
        {
            DiagonalMovement diagonalMovement = new DiagonalMovement();
            possibleCellPositions.AddRange(diagonalMovement.GetPossibleMoves(chessPiece, fromCellPostion));
        }

        private static void GetHorizantalMovement(IChessPiece chessPiece, string fromCellPostion, List<string> possibleCellPositions)
        {
            HorizantalMovement horizantalMovement = new HorizantalMovement();
            possibleCellPositions.AddRange(horizantalMovement.GetPossibleMoves(chessPiece, fromCellPostion));
        }

        private static void GetVerticalMovement(IChessPiece chessPiece, string fromCellPostion, List<string> possibleCellPositions)
        {
            VerticalMovement verticalMovement = new VerticalMovement();
            possibleCellPositions.AddRange(verticalMovement.GetPossibleMoves(chessPiece, fromCellPostion));
        }
    }
}
