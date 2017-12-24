using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
 {
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new Queue<Pump>();

            for (int pumpIndex = 0; pumpIndex < n; pumpIndex++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                var fuelAmount = input[0];
                var distanceToNextPump = input[1];

                var currentPump = new Pump
                {
                    Index = pumpIndex,
                    FuelAmount = fuelAmount,
                    DistanceToNextPump = distanceToNextPump
                };

                pumps.Enqueue(currentPump);
            }

            for (int i = 0; i < pumps.Count; i++)
            {
                var startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);

                var currentPump = startingPump;

                var fuelTank = currentPump.FuelAmount;

                while (fuelTank >= currentPump.DistanceToNextPump)
                {
                    fuelTank -= currentPump.DistanceToNextPump;
                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    if (currentPump == startingPump)
                    {
                        Console.WriteLine(i);
                        return;
                    }

                    fuelTank += currentPump.FuelAmount;
                }
            }
        }
    }
}
