using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPlants = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var daysOfDeath = new int[numberOfPlants];
            var previousPlants = new Stack<int>();
            previousPlants.Push(0);

            for (int i = 1; i < numberOfPlants; i++)
            {
                var lastDeathDay = 0;

                while (previousPlants.Count()>0 && plants[previousPlants.Peek()] >= plants[i])
                {
                    lastDeathDay = Math.Max(lastDeathDay,daysOfDeath[previousPlants.Pop()]);
                }

                if (previousPlants.Count() > 0)
                {
                    daysOfDeath[i] = lastDeathDay + 1;
                }
                previousPlants.Push(i);
            }
            Console.WriteLine(daysOfDeath.Max());
        }
    }
}
