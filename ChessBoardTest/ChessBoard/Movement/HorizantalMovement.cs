using System;
using System.Collections.Generic;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class HorizantalMovement : IMovement
    {
        public List<string> GetPossibleMoves(IChessPiece chessPiece, string cellPostion)
        {            
            float stepLimit = chessPiece.GetStepLimit();
            var cellAxis = Cell.GetCellAxisPostion(cellPostion);
            List<string> horizantalCell = new List<string>();
            if (stepLimit == 1)
            {
                int leftMove = 1;
                int rightMove = 1;
                if (cellAxis.Item1 > 1)
                {
                    leftMove = cellAxis.Item1 - Convert.ToInt32(stepLimit);
                }

                if (cellAxis.Item1 < 8)
                {
                    rightMove = cellAxis.Item1 + Convert.ToInt32(stepLimit);
                }

                horizantalCell.Add(Cell.GetCell(leftMove, cellAxis.Item2));
                horizantalCell.Add(Cell.GetCell(rightMove, cellAxis.Item2));
            }
            return horizantalCell;
        }
    }
}
