using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Heigan_Dance
{   
    class Program
    {
        static void Main(string[] args)
        {
            var room = new int[15][];
            var playerDamage = double.Parse(Console.ReadLine());
            var fatalSpell = string.Empty;
            for (int i = 0; i < 15; i++)
            {
                room[i] = new int[15];
                for (int i1 = 0; i1 < 15; i1++)
                {
                    room[i][i1] = 0;
                }
            }
            var player = new Player();
            var heigan = new Heigan();

            while (player.isDead == false && heigan.isDead == false)
            {
                heigan.takeDamage(playerDamage);

                if (player.isPlagued == true)
                {
                    player.plagueDamage();
                }

                if (player.isDead || heigan.isDead)
                {
                    if (player.isDead)
                    {
                        player.fatalSpell = "Plague Cloud";
                    }
                    break;
                }

                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var spell = input[0];
                var spellRow = int.Parse(input[1]);
                var spellCol = int.Parse(input[2]);

                var spellArea = new List<Position>();

                castSpell(room, spellRow, spellCol, spellArea);

                var playerIsInAoe = spellArea
                    .Any(p => p.row == player.currentPosition.row && p.col == player.currentPosition.col);

                if (playerIsInAoe)
                {
                    if (spell == "Eruption")
                    {
                        var upRow = player.currentPosition.row - 1;
                        var downRow = player.currentPosition.row + 1;
                        var leftPosition = player.currentPosition.col - 1;
                        var rightPosition = player.currentPosition.col + 1;
                        tryToMove(room, player, spellArea, upRow, downRow, leftPosition, rightPosition);

                        playerIsInAoe = spellArea
                         .Any(p => p.row == player.currentPosition.row && p.col == player.currentPosition.col);

                        if (playerIsInAoe)
                        {
                            player.eruptionDamage();
                        }

                    }
                    else if (spell == "Cloud")
                    {
                        var upRow = player.currentPosition.row - 1;
                        var downRow = player.currentPosition.row + 1;
                        var leftPosition = player.currentPosition.col - 1;
                        var rightPosition = player.currentPosition.col + 1;
                        tryToMove(room, player, spellArea, upRow, downRow, leftPosition, rightPosition);

                        playerIsInAoe = spellArea
                         .Any(p => p.row == player.currentPosition.row && p.col == player.currentPosition.col);

                        if (playerIsInAoe)
                        {
                            player.isPlagued = true;
                            player.hitPoints -= 3500;
                        }
                        spell = "Plague Cloud";
                    }
                }
                if (player.isDead)
                {
                    player.fatalSpell = spell;
                }
            }
            heigan.printResult();
            player.printResult();
        }

        private static void castSpell(int[][] room, int spellRow, int spellCol, List<Position> spellArea)
        {
            var centerOfSpell = new Position(spellRow, spellCol);
            var leftOfSpell = new Position(spellRow, spellCol - 1);
            var upperLeft = new Position(spellRow - 1, spellCol - 1);
            var downLeft = new Position(spellRow + 1, spellCol - 1);

            var rightOfSpell = new Position(spellRow, spellCol + 1);
            var upperRight = new Position(spellRow - 1, spellCol + 1);
            var downRight = new Position(spellRow + 1, spellCol + 1);
            var upOfSpell = new Position(spellRow - 1, spellCol);
            var downofSpell = new Position(spellRow + 1, spellCol);

            if (IsInMatrix(centerOfSpell.row, centerOfSpell.col, room))
            {
                spellArea.Add(centerOfSpell);
            }
            if (IsInMatrix(leftOfSpell.row, leftOfSpell.col, room))
            {
                spellArea.Add(leftOfSpell);
            }
            if (IsInMatrix(upperLeft.row, upperLeft.col, room))
            {
                spellArea.Add(upperLeft);
            }
            if (IsInMatrix(downLeft.row, downLeft.col, room))
            {
                spellArea.Add(downLeft);
            }
            if (IsInMatrix(rightOfSpell.row, rightOfSpell.col, room))
            {
                spellArea.Add(rightOfSpell);
            }
            if (IsInMatrix(upperRight.row, upperRight.col, room))
            {
                spellArea.Add(upperRight);
            }
            if (IsInMatrix(downRight.row, downRight.col, room))
            {
                spellArea.Add(downRight);
            }
            if (IsInMatrix(upOfSpell.row, upOfSpell.col, room))
            {
                spellArea.Add(upOfSpell);
            }
            if (IsInMatrix(downofSpell.row, downofSpell.col, room))
            {
                spellArea.Add(downofSpell);
            }
        }

        private static void tryToMove(int[][] room, Player player, List<Position> spellArea, int upRow, int downRow, int leftPosition, int rightPosition)
        {
            //up
            if (IsInMatrix(upRow, player.currentPosition.col, room))
            {
                var futurePosition = new Position
                    (player.currentPosition.row - 1, player.currentPosition.col);

                if (!spellArea.Any(s => s.row == futurePosition.row && s.col == futurePosition.col))
                {
                    player.currentPosition = futurePosition;
                    return;
                }
            }
            //right
            if (IsInMatrix(player.currentPosition.row, rightPosition, room))
            {
                var futurePosition = new Position
                    (player.currentPosition.row, player.currentPosition.col + 1);

                if (!spellArea.Any(s => s.row == futurePosition.row && s.col == futurePosition.col))
                {
                    player.currentPosition = futurePosition;
                    return;
                }
            }
            //down
            if (IsInMatrix(downRow, player.currentPosition.col, room))
            {
                var futurePosition = new Position
                (player.currentPosition.row + 1, player.currentPosition.col);

                if (!spellArea.Any(s => s.row == futurePosition.row && s.col == futurePosition.col))
                {
                    player.currentPosition = futurePosition;
                    return;
                }
            }
            //left
            if (IsInMatrix(player.currentPosition.row, leftPosition, room))
            {
                var futurePosition = new Position
                  (player.currentPosition.row, player.currentPosition.col - 1);

                if (!spellArea.Any(s => s.row == futurePosition.row && s.col == futurePosition.col))
                {
                    player.currentPosition = futurePosition;
                    return;
                }
            }
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }
    }
}
