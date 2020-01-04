using System.Collections.Generic;

namespace ChessBoard
{
    internal class Queen : IChessPiece
    {
        private readonly MovementDirection _movementDirection;
        private readonly float _stepLimit;

        public Queen()
        {
            _movementDirection = MovementDirection.All;
            _stepLimit = 8;
        }

        public List<string> GetNextPossibleMoves(string fromCellPostion)
        {
            List<string> possibleMoves = new List<string>();
            HorizantalMovement horizantalMovement = new HorizantalMovement();
            possibleMoves.AddRange(horizantalMovement.GetPossibleMoves(fromCellPostion, _stepLimit));

            VerticalMovement verticalMovement = new VerticalMovement();
            possibleMoves.AddRange(verticalMovement.GetPossibleMoves(fromCellPostion, _stepLimit));

            DiagonalMovement diagonalMovement = new DiagonalMovement();
            possibleMoves.AddRange(diagonalMovement.GetPossibleMoves(fromCellPostion, _stepLimit));
            return possibleMoves;
        }
    }
}
