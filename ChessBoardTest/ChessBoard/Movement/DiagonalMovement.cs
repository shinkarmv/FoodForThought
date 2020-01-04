using System;
using System.Collections.Generic;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal class DiagonalMovement : IMovement
    {
        public List<string> GetPossibleMoves(string cellPostion, float stepLimit)
        {
            var cellAxis = Cell.GetCellAxisPostion(cellPostion);
            List<string> diagonalCell = new List<string>();
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
                    rightMove = cellAxis.Item2 + Convert.ToInt32(stepLimit);
                }

                diagonalCell.Add(Cell.GetCell(leftMove, cellAxis.Item2 - 1));
                diagonalCell.Add(Cell.GetCell(leftMove, cellAxis.Item2 + 1));
                diagonalCell.Add(Cell.GetCell(rightMove, cellAxis.Item2 - 1));
                diagonalCell.Add(Cell.GetCell(rightMove, cellAxis.Item2 + 1));
            }
            return diagonalCell;
        }
    }
}
