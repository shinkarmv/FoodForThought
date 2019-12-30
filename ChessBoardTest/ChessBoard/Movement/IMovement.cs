using System.Collections.Generic;

namespace ChessBoard
{
    interface IMovement
    {
        List<string> GetPossibleMoves(IChessPiece chessPiece, string cellPostion);
    }
}
