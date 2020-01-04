using System.Collections.Generic;

namespace ChessBoard
{
    interface IMovement
    {
        List<string> GetPossibleMoves(string cellPostion, float stepLimit);
    }
}
