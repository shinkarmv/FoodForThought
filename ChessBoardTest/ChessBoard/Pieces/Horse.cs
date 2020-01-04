using System.Collections.Generic;

namespace ChessBoard
{
    internal class Horse : IChessPiece
    {
        private readonly MovementDirection _movementDirection;
        private readonly float _stepLimit;

        public Horse()
        {
            _movementDirection = MovementDirection.BiDirectional;
            _stepLimit = 2.5f;
        }

        public List<string> GetNextPossibleMoves(string fromCellPostion)
        {
            throw new System.NotImplementedException();
        }
    }
}