using System;
using System.Collections.Generic;

namespace ChessBoard
{
    internal class VerticalMovement : IMovement
    {
        public List<string> GetPossibleMoves(IChessPiece chessPiece, string cellPostion)
        {
            float stepLimit = chessPiece.GetStepLimit();
            var cellAxis = Cell.GetCellAxisPostion(cellPostion);
            List<string> verticalCell = new List<string>();
            if (stepLimit == 1)
            {
                int leftMove = 1;
                int rightMove = 1;
                if (cellAxis.Item2 > 1)
                {
                    leftMove = cellAxis.Item2 - Convert.ToInt32(stepLimit);
                }

                if (cellAxis.Item2 < 8)
                {
                    rightMove = cellAxis.Item2 + Convert.ToInt32(stepLimit);
                }

                verticalCell.Add(Cell.GetCell(cellAxis.Item1, leftMove));
                verticalCell.Add(Cell.GetCell(cellAxis.Item1, rightMove));
            }
            return verticalCell;
        }
    }
}
