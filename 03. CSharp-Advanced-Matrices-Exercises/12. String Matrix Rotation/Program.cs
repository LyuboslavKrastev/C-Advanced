using System;
using System.Linq;
using System.Collections.Generic;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {

            var degrees = int.Parse(Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .Last()) % 360;

            string input;
            var initialWords = new List<string>();
            var maxWordLength = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Length > maxWordLength)
                {
                    maxWordLength = input.Length;
                }
                initialWords.Add(input);
            }


            if (degrees == 0)
            {
                initialWords.ForEach(r => Console.WriteLine(r));
                Environment.Exit(0);
            }

            var matrix = new char[initialWords.Count, maxWordLength];

            for (int row = 0; row < initialWords.Count; row++)
            {

                for (int col = 0; col < maxWordLength; col++)
                {
                    if (col < initialWords[row].Length)
                    {
                        matrix[row,col] = initialWords[row][col];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
           
            if (degrees == 90)
            {
                for (int i = 0; i < 3; i++)
                {
                    matrix = RotateMatrixCounterClockwise(matrix);
                }
            }
            else if (degrees == 180)
            {
                for (int i = 0; i < 2; i++)
                {
                    matrix = RotateMatrixCounterClockwise(matrix);
                }
            }
            else if (degrees == 270)
            {
                matrix = RotateMatrixCounterClockwise(matrix);
            }

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0}", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }

        }
        //270 degrees
        static char[,] RotateMatrixCounterClockwise(char[,] oldMatrix)
        {
            char[,] newMatrix = new char[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }        
    }
}
