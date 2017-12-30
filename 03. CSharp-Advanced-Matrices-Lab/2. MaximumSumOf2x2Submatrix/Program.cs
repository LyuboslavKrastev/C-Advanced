using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._MaximumSumOf2x2Submatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];

            var matrix = new int[rows][];
            var biggestSum = 0;
            var bestCombinationIndexes = new KeyValuePair<int, int>();

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            }


            for (int rowIndex = 0; rowIndex < matrix.Length-1; rowIndex++)
            {

                var currentRow = matrix[rowIndex];
                for (int colIndex = 0; colIndex < currentRow.Length-1; colIndex++)
                {
                    var firstRowSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1];
                    var secondRowSum = matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];
                    var currentSum = firstRowSum + secondRowSum;

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;

                        bestCombinationIndexes = new KeyValuePair<int, int>(rowIndex, colIndex);
                    }
                }
            }
            int bestRowsIndex = bestCombinationIndexes.Key;
            var bestColsIndex = bestCombinationIndexes.Value;

            Console.WriteLine($"{matrix[bestRowsIndex][bestColsIndex]} {matrix[bestRowsIndex][bestColsIndex+1]}");
            Console.WriteLine($"{matrix[bestRowsIndex+1][bestColsIndex]} {matrix[bestRowsIndex+1][bestColsIndex+1]}");
            Console.WriteLine(biggestSum);


        }
    }
}
