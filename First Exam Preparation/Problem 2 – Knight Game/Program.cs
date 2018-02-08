using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Knight_Game
{

    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
            var board = new char[boardSize][];
            var knightsToBeRemoved = 0;
            bool optimizedBoard = false;

            FillUpBoard(boardSize, board);

            while (optimizedBoard == false)
            {
                var knightsKeeper = new List<Knight>();
                FindKnights(boardSize, board, knightsKeeper);
                if (!knightsKeeper.Any())
                {
                    optimizedBoard = true;
                    break;
                }
                var mostDangerousKnight = knightsKeeper.OrderByDescending(k => k.canAttack).First();
                board[mostDangerousKnight.row][mostDangerousKnight.col] = '0';
              //  PrintBoard(board, mostDangerousKnight);
                knightsToBeRemoved++;
            }
            Console.WriteLine(knightsToBeRemoved);
        }

        private static void PrintBoard(char[][] board, Knight mostDangerousKnight)
        {
            Console.WriteLine($"Removed position {mostDangerousKnight.row} {mostDangerousKnight.col}");
            foreach (var row in board)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.WriteLine();
        }

        private static void FindKnights(int boardSize, char[][] board, List<Knight> knightsKeeper)
        {
            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                for (int colIndex = 0; colIndex < boardSize; colIndex++)
                {
                    if (board[rowIndex][colIndex] == 'K')
                    {
                        GetKnight(board, knightsKeeper, rowIndex, colIndex);
                    }
                }
            }
        }

        private static void GetKnight(char[][] board, List<Knight> knightsKeeper, int rowIndex, int colIndex)
        {
            var currentKnight = new Knight()
            {
                row = rowIndex,
                col = colIndex
            };

            var firstPosition = new KeyValuePair<int, int>(rowIndex - 2, colIndex + 1);
            var secondPosition = new KeyValuePair<int, int>(rowIndex - 2, colIndex - 1);
            var thirdPosition = new KeyValuePair<int, int>(rowIndex + 2, colIndex + 1);
            var fourthPosition = new KeyValuePair<int, int>(rowIndex + 2, colIndex - 1);

            var fifthPosition = new KeyValuePair<int, int>(rowIndex - 1, colIndex + 2);
            var sixthPosition = new KeyValuePair<int, int>(rowIndex - 1, colIndex - 2);
            var seventhPosition = new KeyValuePair<int, int>(rowIndex + 1, colIndex + 2);
            var eightPosition = new KeyValuePair<int, int>(rowIndex + 1, colIndex - 2);

            if (IsInMatrix(firstPosition.Key, firstPosition.Value, board))
            {
                if (board[firstPosition.Key][firstPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(secondPosition.Key, secondPosition.Value, board))
            {
                if (board[secondPosition.Key][secondPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(thirdPosition.Key, thirdPosition.Value, board))
            {
                if (board[thirdPosition.Key][thirdPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(fourthPosition.Key, fourthPosition.Value, board))
            {
                if (board[fourthPosition.Key][fourthPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(fifthPosition.Key, fifthPosition.Value, board))
            {
                if (board[fifthPosition.Key][fifthPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(sixthPosition.Key, sixthPosition.Value, board))
            {
                if (board[sixthPosition.Key][sixthPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(seventhPosition.Key, seventhPosition.Value, board))
            {
                if (board[seventhPosition.Key][seventhPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (IsInMatrix(eightPosition.Key, eightPosition.Value, board))
            {
                if (board[eightPosition.Key][eightPosition.Value] == 'K')
                {
                    currentKnight.canAttack += 1;
                }
            }
            if (currentKnight.canAttack > 0)
            {
                knightsKeeper.Add(currentKnight);
            }
            
        }

        private static void FillUpBoard(int boardSize, char[][] board)
        {
            for (int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().ToArray();
            }
        }

        private static bool IsInMatrix(int row, int col, char[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }
    }  
}
