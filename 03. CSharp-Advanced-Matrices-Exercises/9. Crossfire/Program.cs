using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var n = dimensions[0];
            var m = dimensions[1];

            var matrix = new List<List<int>>();
            var filler = 1;

            for (int row = 0; row < n; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < m; col++)
                {
                    matrix[row].Add(filler);
                    filler++;
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var tokens = input
                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse).ToArray();

                var targetRow = tokens[0];
                var targetCol = tokens[1];
                var radius = tokens[2];

                for (int row = targetRow - radius; row <= targetRow + radius; row++)
                {
                    if (IsInMatrix(row, targetCol, matrix))
                    {
                        matrix[row][targetCol] = 0;
                    }
                }
                for (int col = targetCol - radius; col <= targetCol + radius; col++)
                {
                    if (IsInMatrix(targetRow, col, matrix))
                    {
                        matrix[targetRow][col] = 0;
                    }
                }

                for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
                    {
                        matrix[rowIndex].RemoveAll(x => x == 0);

                        if (matrix[rowIndex].Count == 0)
                        {
                            matrix.RemoveAt(rowIndex);
                            rowIndex--;
                        }
                    }
                }           
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        private static bool IsInMatrix(int row, int col, List<List<int>> matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Count && col < matrix[row].Count;
        }
    }
}
