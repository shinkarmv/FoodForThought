namespace ChessBoard
{
    internal class Bishop : IChessPiece
    {
        public MovementDirection GetMoventDirection()
        {
            return MovementDirection.Diagonal;
        }
        public float GetStepLimit()
        {
            return 8;
        }
    }
}
