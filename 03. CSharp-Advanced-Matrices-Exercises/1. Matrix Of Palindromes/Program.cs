using System;
using System.Linq;

namespace _1._Matrix_Of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var rows = input[0];
            var cols = input[1];

            var matrix = new string[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var letterCounter = row;
                matrix[row] = new string[cols];


                for (int i = 0; i < matrix[row].Length; i++)
                {
                    var currentPalindrom = $"{alphabet[row]}{alphabet[letterCounter]}{alphabet[row]}";
                    matrix[row][i] = currentPalindrom;
                    letterCounter++;
                }
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
