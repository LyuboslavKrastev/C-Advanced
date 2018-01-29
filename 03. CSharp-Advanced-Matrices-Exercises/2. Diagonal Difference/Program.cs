using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = new long[rows][];
            long primarySum = 0;
            long secondarySum = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();

                var primaryElement = matrix[row][row];

                var secondaryIndex = matrix.Length - 1 - row;
                var secondaryElement = matrix[row][secondaryIndex];

                primarySum += primaryElement;
                secondarySum += secondaryElement;
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
