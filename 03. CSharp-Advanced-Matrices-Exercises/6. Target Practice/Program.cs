using System;
using System.Collections.Generic;

namespace _6._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' });
            var snake = Console.ReadLine().ToCharArray();

            var shot = Console.ReadLine().Split(new char[] { ' ' });

            var impactRow = int.Parse(shot[0]);
            var impactCol = int.Parse(shot[1]);
            var radius = int.Parse(shot[2]);

            var r = int.Parse(input[0]);
            var c = int.Parse(input[1]);

            var matrix = new char[r][];

            SeedMatrix(matrix, snake, c);

            Shoot(impactRow, impactCol, radius, matrix);

            for (int row = matrix.Length - 1; row > 0; row--)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        continue;
                    }
                    var fallCounter = row - 1;

                    while (fallCounter > 0)
                    {
                        if (matrix[fallCounter][col] != ' ')
                        {
                            break;
                        }
                        fallCounter--;
                    }

                    matrix[row][col] = matrix[fallCounter][col];
                    matrix[fallCounter][col] = ' ';
                }
            }


            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }

        }

        private static void Shoot(int impactRow, int impactCol, int radius, char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var dx = Math.Abs(row - impactRow);
                    var dy = Math.Abs(col - impactCol);

                    if (Math.Pow(dx, 2) + Math.Pow(dy, 2) <= Math.Pow(radius, 2))
                    {
                        matrix[row][col] = ' ';
                    }

                }
            }
        }

        private static void SeedMatrix(char[][] matrix, char[] snake, int columns)
        {
            var snakeIndex = 0;
            var direction = 0; // 0 = left, 1 = right
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[columns];

                if (direction == 0)
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                    direction = 1; //right
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                    direction = 0;
                }

            }
        }

    }
}
