namespace ChessBoard
{
    internal class Queen : IChessPiece
    {
        public MovementDirection GetMoventDirection()
        {
            return MovementDirection.All;
        }

        public float GetStepLimit()
        {
            return 8;
        }
    }
}
