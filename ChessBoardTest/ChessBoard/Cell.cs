using System;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{    
    internal static class Cell
    {
        public static string GetCell(int xPos, int yPos)
        {
            string rowAlphabate = GetRowAlphabate(xPos);
            if (rowAlphabate == null)
                throw new System.Exception("Invalid Row Alphabate");
            return rowAlphabate + yPos.ToString();
        }

        public static (int, int) GetCellAxisPostion(string cellPostion)
        {
            int? rowNumber = GetRowNumber(cellPostion.Substring(0,1));
            if (rowNumber == null)
                throw new System.Exception("Invalid Row Number");
            return (Convert.ToInt32(rowNumber), Convert.ToInt32(cellPostion.Substring(1, 1)));
        }

        private static string GetRowAlphabate(int xPos)
        {
            switch (xPos)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                case 5: return "E";
                case 6: return "F";
                case 7: return "G";
                case 8: return "H";
            }
            return null;
        }

        private static int? GetRowNumber(string xPos)
        {
            switch (xPos.ToLower())
            {
                case "a": return 1;
                case "b": return 2;
                case "c": return 3;
                case "d": return 4;
                case "e": return 5;
                case "f": return 6;
                case "g": return 7;
                case "h": return 8;
            }
            return null;
        }
    }
}
