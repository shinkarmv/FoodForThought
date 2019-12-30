[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class King : IChessPiece
    {
        public MovementDirection GetMoventDirection()
        {
            return MovementDirection.All;
        }

        public float GetStepLimit()
        {
            return 1;
        }
    }
}
