using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            var rows = input[0];
            var cols = input[1];

            var matrix = new int [rows][];
            var sum = 0;
            for (int i = 0; i < rows; i++)
            {
                 matrix[i] = Console.ReadLine()
                 .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();
                
                 sum += matrix[i].Sum();
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);                
        }
    }
}
