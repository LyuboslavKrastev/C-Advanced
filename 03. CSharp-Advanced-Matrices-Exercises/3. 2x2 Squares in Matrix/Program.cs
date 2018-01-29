using System;
using System.Linq;

namespace _3._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            var equalSquares = 0;
            var matrix = new string[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            for (int rowIndex = 0; rowIndex < matrix.Length-1; rowIndex++)
            {
                var currentRow = matrix[rowIndex];
                var nextRow = matrix[rowIndex + 1];

                for (int colIndex = 0; colIndex < currentRow.Length-1; colIndex++)
                {
                    if (currentRow[colIndex] == currentRow[colIndex + 1]
                        && currentRow[colIndex] == nextRow[colIndex]
                        && currentRow[colIndex] == nextRow[colIndex + 1])
                    {
                        equalSquares++;
                    }
                }
            }
            Console.WriteLine(equalSquares);
        }
    }
}
