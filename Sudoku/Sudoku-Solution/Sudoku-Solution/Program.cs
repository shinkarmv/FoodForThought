using System;
using System.Linq;
using System.Text;

namespace Sudoku_Solution
{
    class Program
    {
        private static char[] firstRow = new char[9];
        private static char[] secondRow = new char[9];
        private static char[] thirdRow = new char[9];

        private static char[] fourthRow = new char[9];
        private static char[] fifthRow = new char[9];
        private static char[] sixthRow = new char[9];

        private static char[] seventhRow = new char[9];
        private static char[] eighthRow = new char[9];
        private static char[] ninthRow = new char[9];
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the value from 1 - 9 in random manner");

            string row = Console.ReadLine();

            int i = 0;
            foreach (char item in row.ToList())
            {
                firstRow[i] = item;
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Please find the output of Sudoku problem with given input");
            Console.WriteLine();

            PrepareSecondLayerOfBlock(firstRow, secondRow);
            PrepareThirdLayerBlock(firstRow, thirdRow);
            FillForuthRow();
            PrepareSecondLayerOfBlock(fourthRow, fifthRow);
            PrepareThirdLayerBlock(fourthRow, sixthRow);
            FillSeventhRow();
            PrepareSecondLayerOfBlock(seventhRow, eighthRow);
            PrepareThirdLayerBlock(seventhRow, ninthRow);

            Console.WriteLine("------------------------------------------------------------------------------------------");
            PrintRow(firstRow);
            PrintRow(secondRow);
            PrintRow(thirdRow);
            PrintRow(fourthRow);
            PrintRow(fifthRow);
            PrintRow(sixthRow);
            PrintRow(seventhRow);
            PrintRow(eighthRow);
            PrintRow(ninthRow);

            Console.ReadLine();
        }

        private static void PrepareSecondLayerOfBlock(char[] inputRow, char[] outputRow)
        {
            for (int i = 0, j = 3; j < 6; i++, j++)
            {
                outputRow[i] = inputRow[j];
            }
            for (int i = 3, j = 6; j < 9; i++, j++)
            {
                outputRow[i] = inputRow[j];
            }
            for (int i = 6, j = 0; j < 3; i++, j++)
            {
                outputRow[i] = inputRow[j];
            }
        }

        private static void PrepareThirdLayerBlock(char[] inputRow, char[] outputRow)
        {
            for (int i = 0, j = 6; j < 9; i++, j++)
            {
                outputRow[i] = inputRow[j];
            }
            for (int i = 3, j = 0; j < 3; i++, j++)
            {
                outputRow[i] = inputRow[j];
            }
            for (int i = 6, j = 3; j < 6; i++, j++)
            {
                outputRow[i] = inputRow[j];
            }
        }

        private static void FillForuthRow()
        {
            // change location of 0th to 2nd
            fourthRow[2] = firstRow[0];
            // change location of 3rd to 5th
            fourthRow[5] = firstRow[3];
            // change location of 6th to 8th
            fourthRow[8] = firstRow[6];

            for (int i = 0, j = 1; j < 3; i++, j++)
            {
                fourthRow[i] = firstRow[j];
            }
            for (int i = 3, j = 4; j < 6; i++, j++)
            {
                fourthRow[i] = firstRow[j];
            }
            for (int i = 6, j = 7; j < 9; i++, j++)
            {
                fourthRow[i] = firstRow[j];
            }
        }
        
        private static void FillSeventhRow()
        {
            // change location of 2nd to 0th
            seventhRow[0] = firstRow[2];
            // change location of 5th to 3rd
            seventhRow[3] = firstRow[5];
            // change location of 8th to 6th
            seventhRow[6] = firstRow[8];

            for (int i = 1, j = 0; j < 2; i++, j++)
            {
                seventhRow[i] = firstRow[j];
            }
            for (int i = 4, j = 3; j < 5; i++, j++)
            {
                seventhRow[i] = firstRow[j];
            }
            for (int i = 7, j = 6; j < 8; i++, j++)
            {
                seventhRow[i] = firstRow[j];
            }
        }

        private static void PrintRow(char[] rowValues)
        {
            StringBuilder rowDetails = new StringBuilder();
            foreach (var item in rowValues)
            {
                rowDetails.Append("|    " +item.ToString() + "    ");
            }
            rowDetails.Append("|");
            Console.WriteLine(rowDetails.ToString());
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
    }
}
