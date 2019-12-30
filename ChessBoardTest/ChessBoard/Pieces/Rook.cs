[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class Rook : IChessPiece
    {
        public MovementDirection GetMoventDirection()
        {
            return MovementDirection.BiDirectional;
        }

        public float GetStepLimit()
        {
            return 8;
        }
    }
}
