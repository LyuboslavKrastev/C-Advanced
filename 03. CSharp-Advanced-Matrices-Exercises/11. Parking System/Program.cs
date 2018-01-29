using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._Parking_System
{

    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var r = dimensions[0];
            var c = dimensions[1];
            var result = new StringBuilder();

            var parking = new Dictionary<int, HashSet<int>>();
         
            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = tokens[0];
                var desiredRow = tokens[1];
                var desiredCol = tokens[2];

                var distanceTravelled = Math.Abs(desiredRow - entryRow) + 1;

                if (!parking.ContainsKey(desiredRow))
                {
                    parking[desiredRow] = new HashSet<int>();                   
                }

                if (!parking[desiredRow].Contains(desiredCol))
                {
                    parking[desiredRow].Add(desiredCol);
                    distanceTravelled += desiredCol;
                    result.AppendLine(distanceTravelled.ToString());
                }
                else
                {
                    var hasParked = false;
                    for (int i = 1; i < c - 1; i++)
                    {
                        if (desiredCol - i > 0 &&
                            !parking[desiredRow].Contains(desiredCol - i))
                        {
                            desiredCol -= i;
                            hasParked = true;
                            break;
                        }
                        else if (desiredCol + i < c &&
                                 !parking[desiredRow].Contains(desiredCol + i))
                        {
                            desiredCol += i;
                            hasParked = true;
                            break;
                        }
                    }
                        distanceTravelled += desiredCol;
                        if (hasParked == false)
                        {
                            result.AppendLine($"Row {desiredRow} full");
                        }
                        else
                        {
                            parking[desiredRow].Add(desiredCol);
                            result.AppendLine(distanceTravelled.ToString());
                        }
                    }
                }                             
            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
