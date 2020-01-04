using System.Collections.Generic;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class Rook : IChessPiece
    {
        private readonly MovementDirection _movementDirection;
        private readonly float _stepLimit;

        public Rook()
        {
            _movementDirection = MovementDirection.BiDirectional;
            _stepLimit = 8;
        }


        public List<string> GetNextPossibleMoves(string fromCellPostion)
        {
            List<string> possibleMoves = new List<string>();
            HorizantalMovement horizantalMovement = new HorizantalMovement();
            possibleMoves.AddRange(horizantalMovement.GetPossibleMoves(fromCellPostion, _stepLimit));

            VerticalMovement verticalMovement = new VerticalMovement();
            possibleMoves.AddRange(verticalMovement.GetPossibleMoves(fromCellPostion, _stepLimit));

            return possibleMoves;
        }

    }
}
