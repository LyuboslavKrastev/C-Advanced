using System;
using System.Linq;
namespace _5._Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            var matrix = new int[rows][];
            var counter = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];
                for (int i = 0; i < matrix[row].Length; i++)
                {
                    matrix[row][i] = counter;
                    counter++;
                }
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var colOrRow = int.Parse(tokens[0]);
                var direction = tokens[1];
                var moves = int.Parse(tokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(matrix, colOrRow, moves);
                        break;
                    case "down":
                        MoveDown(matrix, colOrRow, moves);
                        break;
                    case "left":
                        MoveLeft(matrix, colOrRow, moves);
                        break;
                    case "right":
                        MoveRight(matrix, colOrRow, moves);
                        break;
                }
            }
            var correctElement = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentElement = matrix[row][col];
                    var elementFound = false;

                    if (currentElement != correctElement)
                    {
                        var checkRow = 0;
                        while (elementFound == false)
                        {                           
                            if (!matrix[checkRow].Contains(correctElement))
                            {
                                checkRow++;
                                continue;
                            }

                            int column = matrix[checkRow].Select((s, i) => new { i, s })
                            .Where(t => t.s == correctElement)
                             .Select(t => t.i).FirstOrDefault();

                            matrix[checkRow][column] = matrix[row][col];
                            matrix[row][col] = correctElement;

                            Console.WriteLine($"Swap {(row, col)} with {(checkRow, column)}");
                            elementFound = true;
                        }
                    }
                    
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    correctElement++;
                }
            }
        }
        private static void MoveUp(int[][] matrix, int column, int moves)
        {
            for (int turns = 0; turns < moves % matrix.Length; turns++)
            {

                var firstElement = matrix[0][column];

                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][column] = matrix[row + 1][column];
                }

                matrix[matrix.Length - 1][column] = firstElement;

            }
        }

        private static void MoveDown(int[][] matrix, int column, int moves)
        {
            for (int turns = 0; turns < moves % matrix.Length; turns++)
            {
                var lastElement = matrix[matrix.Length - 1][column];

                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    matrix[row][column] = matrix[row - 1][column];
                }

                matrix[0][column] = lastElement;
            }
        }

        private static void MoveLeft(int[][] matrix, int row, int moves)
        {

            for (int turns = 0; turns < moves % matrix[row].Length; turns++)
            {
                var firstElement = matrix[row][0];

                for (int i = 0; i < matrix[row].Length - 1; i++)
                {
                    matrix[row][i] = matrix[row][i + 1];
                }

                matrix[row][matrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveRight(int[][] matrix, int row, int moves)
        {
            for (int turns = 0; turns < moves % matrix[row].Length; turns++)
            {
                var rowLength = matrix[row].Length - 1;
                var lastElement = matrix[row][rowLength];

                for (int i = rowLength; i > 0; i--)
                {
                    matrix[row][i] = matrix[row][i - 1];
                }

                matrix[row][0] = lastElement;
            }

        }
    }
}
