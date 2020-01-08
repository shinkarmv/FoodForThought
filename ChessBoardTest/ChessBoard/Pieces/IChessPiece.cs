using System.Collections.Generic;

namespace ChessBoard
{
    internal interface IChessPiece
    {
        List<string> GetNextPossibleMoves(string fromCellPostion);
    }
}
