using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._ParkingLot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parkingLot = new SortedSet<string>();

            var input = Console.ReadLine();


            while (input != "END")
            {
                var tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                var command = tokens[0];
                var carNumber = tokens[1];

                switch (command)
                {
                    case "IN":
                        parkingLot.Add(carNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(carNumber);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
            }
        }
    }
}
