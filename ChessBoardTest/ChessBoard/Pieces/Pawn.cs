using System.Collections.Generic;
namespace ChessBoard
{
    internal class Pawn : IChessPiece
    {
        private readonly MovementDirection _movementDirection;
        private readonly float _stepLimit;

        public Pawn()
        {
            // As per the assumption mention in the problem statement - It cannot move Diagonally
            _movementDirection = MovementDirection.Vertical;
            _stepLimit = 1;
        }

        public List<string> GetNextPossibleMoves(string fromCellPostion)
        {
            VerticalMovement verticalMovement = new VerticalMovement();
            return verticalMovement.GetPossibleMoves(fromCellPostion, _stepLimit);
        }
    }
}
