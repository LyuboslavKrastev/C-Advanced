using System;

namespace _4._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());

            var pascalTriangle = new long[height][];

            for (int row = 0; row < height; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                pascalTriangle[row][0] = 1;
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1;

                for (int col = 1; col < pascalTriangle[row].Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];

                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
