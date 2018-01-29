using System;
using System.Linq;

namespace _7._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var firstPiece = new int[n][];
            var secondPiece = new int[n][];
            var finalPiece = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstPiece[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                secondPiece[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                int[] front = firstPiece[i];
                int[] back = secondPiece[i].Reverse().ToArray();
                int[] combined = front.Concat(back).ToArray();
                finalPiece[i] = combined;
            }

            var rowLength = finalPiece[0].Length;

            if (finalPiece.Any(f => f.Length != rowLength ))
            {
                var totalNumber = 0;

                foreach (var row in finalPiece)
                {
                    totalNumber += row.Length;
                }
                Console.WriteLine($"The total number of cells is: {totalNumber}");
            }
            else
            {
                foreach (var row in finalPiece)
                {
                    Console.WriteLine($"[{string.Join(", ", row)}]");
                }
            }
        }
    }
}
