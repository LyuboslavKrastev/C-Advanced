using System;
using System.Collections.Generic;
using System.Linq;
namespace _8._Radioactive_Mutant_Vampire_Bunnies
{  
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var n = input[0];
            var m = input[1];
            var cave = new char[n][];

            var playerLocation = new Point();
            var gameEnds = false;
            var win = false;
            

            // fill up initial cave
            for (int i = 0; i < n; i++)
            {
                cave[i] = Console.ReadLine().ToCharArray();

                FindPlayer(playerLocation, cave, i);

            }

            var directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {              
                var currentDirection = directions[i];

                cave[playerLocation.Row][playerLocation.Col] = '.';

                switch (currentDirection)
                {
                    case 'L':
                        playerLocation.Col--;
                        if (playerLocation.Col >= 0)
                        {
                            if (cave[playerLocation.Row][playerLocation.Col] == 'B')
                            {
                                gameEnds = true;
                            }
                            else
                            {
                                cave[playerLocation.Row][playerLocation.Col] = 'P';
                            }

                        }
                        else
                        {
                            playerLocation.Col++;
                            win = true;
                            gameEnds = true;
                        }
                        break;

                    case 'R':
                        playerLocation.Col++;
                        if (playerLocation.Col < cave[playerLocation.Row].Length)
                        {                          
                            if (cave[playerLocation.Row][playerLocation.Col] == 'B')
                            {
                                gameEnds = true;
                            }
                            else
                            {
                                cave[playerLocation.Row][playerLocation.Col] = 'P';
                            }
                        }
                        else
                        {
                            playerLocation.Col--;
                            win = true;
                            gameEnds = true;
                        }
                        break;

                    case 'U':
                        playerLocation.Row--;

                        if (playerLocation.Row >= 0)
                        {                          
                            if (cave[playerLocation.Row][playerLocation.Col] == 'B')
                            {
                                gameEnds = true;
                            }
                            else
                            {
                                cave[playerLocation.Row][playerLocation.Col] = 'P';
                            }
                        }
                        else
                        {
                            playerLocation.Row++;
                            win = true;
                            gameEnds = true;
                        }
                        break;

                    case 'D':
                        playerLocation.Row++;
                        if (playerLocation.Row < cave.Length)
                        {

                            if (cave[playerLocation.Row][playerLocation.Col] == 'B')
                            {
                                gameEnds = true;
                            }
                            else
                            {
                                cave[playerLocation.Row][playerLocation.Col] = 'P';
                            }
                        }
                        else
                        {
                            playerLocation.Row--;
                            win = true;
                            gameEnds = true;
                        }
                        break;
                }

                // multiply bunnies
                for (int row = 0; row < cave.Length; row++)
                {                   
                    for (int col = 0; col < cave[row].Length; col++)
                    {
                        if (cave[row][col] == 'B')
                        {
                            var bunnyRow = row;
                            var bunnyCol = col;
                            //leftBunny
                            if (bunnyRow-1 >= 0)
                            {
                                if (cave[bunnyRow-1][bunnyCol] == 'P')
                                {
                                    cave[bunnyRow - 1][bunnyCol] = 'b';
                                    gameEnds = true;
                                }
                                else if (cave[bunnyRow - 1][bunnyCol] == '.')
                                {
                                    cave[bunnyRow - 1][bunnyCol] = 'b';
                                }
                               
                            }
                            //rightBunny
                            if (bunnyRow + 1 < cave.Length)
                            {
                                if (cave[bunnyRow + 1][bunnyCol] == 'P')
                                {
                                    gameEnds = true;
                                    cave[bunnyRow + 1][bunnyCol] = 'b';
                                }
                                else if (cave[bunnyRow + 1][bunnyCol] == '.')
                                {
                                    cave[bunnyRow + 1][bunnyCol] = 'b';
                                }

                            }
                            //upBunny
                            if (bunnyCol - 1 >=0)
                            {
                                if (cave[bunnyRow][bunnyCol-1] == 'P')
                                {
                                    cave[bunnyRow][bunnyCol - 1] = 'b';
                                    gameEnds = true;
                                }
                                else if (cave[bunnyRow][bunnyCol - 1] == '.')
                                {                               
                                    cave[bunnyRow][bunnyCol - 1] = 'b';
                                }

                            }
                            //downBunny
                            if (bunnyCol + 1 < cave[bunnyRow].Length)
                            {
                                if (cave[bunnyRow][bunnyCol+1] == 'P')
                                {
                                    cave[bunnyRow][bunnyCol + 1] = 'b';
                                    gameEnds = true;
                                }
                                else if (cave[bunnyRow][bunnyCol + 1] == '.')
                                {
                                    cave[bunnyRow][bunnyCol + 1] = 'b';
                                }                               
                            }
                        }
                    }
                              
                }
                //grow Bunnies
                for (int growRow = 0; growRow < cave.Length; growRow++)
                {
                    for (int growCol = 0; growCol < cave[growRow].Length; growCol++)
                    {
                        if (cave[growRow][growCol] == 'b')
                        {
                            cave[growRow][growCol] = 'B';
                        }
                    }
                }

                if (gameEnds == true)
                {
                    break;
                }
            }
            foreach (var item in cave)
            {
                Console.WriteLine(string.Join("", item));
            }
            if (win == true)
            {
                Console.WriteLine($"won: {playerLocation.Row} {playerLocation.Col}");
            }
            else
            {
                Console.WriteLine($"dead: {playerLocation.Row} {playerLocation.Col}");
            }
        }

        private static void FindPlayer(Point playerLocation, char[][] cave, int i)
        {
            for (int i1 = 0; i1 < cave[i].Length; i1++)
            {
                if (cave[i][i1] == 'P')
                {
                    playerLocation.Row = i;
                    playerLocation.Col = i1;
                    break;
                }
            }
        }
    }
}
