using System.Collections.Generic;

namespace ChessBoard
{
    internal class Bishop : IChessPiece
    {
        private readonly MovementDirection _movementDirection;
        private readonly float _stepLimit;

        public Bishop()
        {
            _movementDirection = MovementDirection.Diagonal;
            _stepLimit = 8;
        }

        public List<string> GetNextPossibleMoves(string fromCellPostion)
        {
            DiagonalMovement diagonalMovement = new DiagonalMovement();
            return diagonalMovement.GetPossibleMoves(fromCellPostion, _stepLimit);
        }
    }
}
