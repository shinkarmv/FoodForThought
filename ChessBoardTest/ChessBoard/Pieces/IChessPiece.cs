namespace ChessBoard
{
    internal interface IChessPiece
    {
        MovementDirection GetMoventDirection();

        float GetStepLimit();
    }
}
