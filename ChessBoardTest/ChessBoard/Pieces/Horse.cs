namespace ChessBoard
{
    internal class Horse : IChessPiece
    {
        public MovementDirection GetMoventDirection()
        {
            return MovementDirection.BiDirectional;
        }

        public float GetStepLimit()
        {
            return 2.5f;
        }
    }
}