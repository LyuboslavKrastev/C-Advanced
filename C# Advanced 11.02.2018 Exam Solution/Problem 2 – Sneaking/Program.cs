using System;
using System.Linq;
using System.Collections.Generic;
namespace Problem_2___Sneaking
{
    public class Position
    {
        public int row { get; set; }
        public int col { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var Sam = new Position();
            var Niko = new Position();
            bool NikoIsDead = false;
            var samIsDead = false;
            var room = new char[n][];
            FillRoom(n, Sam, Niko, room);

            var directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];
                //move enemies
                for (int rowIndex = 0; rowIndex < room.Length; rowIndex++)
                {
                    var foundEnemy = false;
                    if (room[rowIndex].Contains('N'))
                    {
                        continue;
                    }
                    for (int colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                    {
                        if (foundEnemy)
                        {
                            break;
                        }
                        var enemyDirection = room[rowIndex][colIndex];
                        if (enemyDirection == 'b' || enemyDirection == 'd')
                        {
                            foundEnemy = true;
                            Position currentEnemy = new Position();
                            currentEnemy.row = rowIndex;
                            currentEnemy.col = colIndex;
                            bool switchedPositions;

                          
                            enemyDirection = checkEnemy(room, rowIndex, colIndex, enemyDirection, out currentEnemy, out switchedPositions);
                           
                            //KILL SAM
                            if (currentEnemy.row == Sam.row)
                            {
                                if (enemyDirection == 'b' && Sam.col > currentEnemy.col)
                                {
                                    room[Sam.row][Sam.col] = 'X';
                                    
                                    samIsDead = true;
                                }
                                else if (enemyDirection == 'd' && Sam.col < currentEnemy.col)
                                {
                                    room[Sam.row][Sam.col] = 'X';
                                    samIsDead = true;
                                }
                            }

                            if (!switchedPositions)
                            {
                                MoveEnemy(room, rowIndex, colIndex, enemyDirection, currentEnemy);
                                colIndex++;
                            }                          
                            
                        }
                    }
                }

                var futurePosition = new Position();

                if (samIsDead)
                {
                    Console.WriteLine($"Sam died at {Sam.row}, {Sam.col}");
                    PrintMatrix(room);
                    return;
                }
                switch (currentDirection)
                {
                    case 'U':
                        futurePosition.row = Sam.row - 1;
                        futurePosition.col = Sam.col;
                        if (IsInMatrix(futurePosition.row, futurePosition.col, room))
                        {
                            NikoIsDead = CheckForNiko(NikoIsDead, room, futurePosition);
                            room[Sam.row][Sam.col] = '.';
                            Sam.row = futurePosition.row;

                            room[Sam.row][Sam.col] = 'S';
                            if (NikoIsDead)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                room[Niko.row][Niko.col] = 'X';
                                PrintMatrix(room);
                                return;
                            }
                        }
                        break;
                    case 'D':
                        futurePosition.row = Sam.row + 1;
                        futurePosition.col = Sam.col;
                        if (IsInMatrix(futurePosition.row, futurePosition.col, room))
                        {
                            NikoIsDead = CheckForNiko(NikoIsDead, room, futurePosition);
                            room[Sam.row][Sam.col] = '.';
                            Sam.row = futurePosition.row;

                            room[Sam.row][Sam.col] = 'S';
                            if (NikoIsDead)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                room[Niko.row][Niko.col] = 'X';
                                PrintMatrix(room);
                                return;
                            }
                        }
                        break;

                    case 'R':
                        futurePosition.row = Sam.row;
                        futurePosition.col = Sam.col + 1;
                        if (IsInMatrix(futurePosition.row, futurePosition.col, room))
                        {
                            NikoIsDead = CheckForNiko(NikoIsDead, room, futurePosition);
                            room[Sam.row][Sam.col] = '.';

                            Sam.col = futurePosition.col;
                            room[Sam.row][Sam.col] = 'S';
                            if (NikoIsDead)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                room[Niko.row][Niko.col] = 'X';
                                PrintMatrix(room);
                                return;
                            }
                        }
                        break;
                    case 'L':
                        futurePosition.row = Sam.row;
                        futurePosition.col = Sam.col - 1;
                        if (IsInMatrix(futurePosition.row, futurePosition.col, room))
                        {
                            NikoIsDead = CheckForNiko(NikoIsDead, room, futurePosition);
                            room[Sam.row][Sam.col] = '.';

                            Sam.col = futurePosition.col;
                            room[Sam.row][Sam.col] = 'S';
                            if (NikoIsDead)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                room[Niko.row][Niko.col] = 'X';
                                PrintMatrix(room);
                                return;
                            }
                        }
                        break;

                    case 'W':
                        break;
                }            
            }
        }

        private static void PrintMatrix(char[][] room)
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char checkEnemy(char[][] room, int rowIndex, int colIndex, char enemyDirection, out Position currentEnemy, out bool switchedPositions)
        {
            currentEnemy = new Position()
            {
                row = rowIndex,
                col = colIndex
            };
            switchedPositions = false;

            if (room[rowIndex][colIndex] == 'b' && currentEnemy.col + 1 > room[rowIndex].Length - 1)
            {
                room[rowIndex][colIndex] = 'd';
                enemyDirection = 'd';
                switchedPositions = true;
            }
            else
            {
                if (room[rowIndex][colIndex] == 'd' && currentEnemy.col - 1 < 0)
                {
                    room[rowIndex][colIndex] = 'b';
                    enemyDirection = 'b';
                    switchedPositions = true;
                }
            }


            return enemyDirection;
        }

        private static void MoveEnemy(char[][] room, int rowIndex, int colIndex, char enemyDirection, Position currentEnemy)
        {
            if (enemyDirection == 'b')
            {
                //move right
                room[rowIndex][colIndex] = '.';
                room[rowIndex][colIndex + 1] = 'b';
                currentEnemy.col++;
            }
            else
            {
                // move left
                room[rowIndex][colIndex] = '.';
                room[rowIndex][colIndex - 1] = 'd';
                currentEnemy.col--;
            }
        }

        private static void FillRoom(int n, Position Sam, Position Niko, char[][] room)
        {
            for (int row = 0; row < n; row++)
            {
                var floor = Console.ReadLine();
                room[row] = new char[floor.Length];
                for (int col = 0; col < floor.Length; col++)
                {
                    room[row][col] = floor[col];
                    if (floor[col] == 'S')
                    {
                        Sam.row = row;
                        Sam.col = col;
                    }
                    else if (floor[col] == 'N')
                    {
                        Niko.row = row;
                        Niko.col = col;
                    }
                }
            }
        }

        private static bool CheckForNiko(bool NikoIsDead, char[][] room, Position futurePosition)
        {
            var searchedRow = futurePosition.row;
            if (room[searchedRow].Contains('N'))
            {
                NikoIsDead = true;
            }
            return NikoIsDead;
        }
        private static bool IsInMatrix(int targetRow, int targetCol, char[][] board)
        {
            bool validRow = targetRow >= 0 && targetRow <= board.Length - 1;
            bool validCol = targetCol >= 0 && targetCol <= board[0].Length - 1;

            return validRow && validCol;
        }
    }
}
