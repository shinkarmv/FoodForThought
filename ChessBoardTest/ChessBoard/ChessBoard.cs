using System.Collections.Generic;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class ChessBoard
    {
        internal List<string> MakeNextMove(IChessPiece chessPiece, string fromCellPostion)
        {
            List<string> possibleCellPositions = new List<string>();
            possibleCellPositions.AddRange(chessPiece.GetNextPossibleMoves(fromCellPostion));
            return possibleCellPositions;
        }
    }
}