namespace ChessBoard
{
    internal class Pawn : IChessPiece
    {
        // As per the assumption mention in the problem statement - It cannot move Diagonally
        public MovementDirection GetMoventDirection()
        {
            return MovementDirection.Vertical;
        }

        public float GetStepLimit()
        {
            return 1;
        }
    }
}
