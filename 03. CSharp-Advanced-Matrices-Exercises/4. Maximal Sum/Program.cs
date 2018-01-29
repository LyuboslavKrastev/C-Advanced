using System;
using System.Linq;

namespace _4._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            var maxSumArray = new int[9];

            var matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray(); 
            }

            for (int row = 0; row < matrix.Length-2; row++)
            {
                var firstRow = matrix[row];
                var secondRow = matrix[row + 1];
                var thirdRow = matrix[row + 2];

                for (int i = 0; i < firstRow.Length-2; i++)
                {
                    var firstElements = firstRow.Skip(i).Take(3);
                    var secondElements = secondRow.Skip(i).Take(3);
                    var thirdElements = thirdRow.Skip(i).Take(3);

                    if (firstElements.Sum() + secondElements.Sum() + thirdElements.Sum() > maxSumArray.Sum())
                    {
                        maxSumArray = new int[9];
                        maxSumArray = firstElements.Concat(secondElements.Concat(thirdElements)).ToArray();
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSumArray.Sum()}");
            Console.WriteLine(string.Join(" ", maxSumArray.Take(3)));
            Console.WriteLine(string.Join(" ", maxSumArray.Skip(3).Take(3)));
            Console.WriteLine(string.Join(" ", maxSumArray.Skip(6).Take(3)));
        }
    }
}
