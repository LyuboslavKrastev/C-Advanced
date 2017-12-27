using System;
using System.Collections.Generic;

namespace _06._A_Miner_s_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var minerResources = new Dictionary<string, long>();

            var resource = Console.ReadLine();

            while (resource != "stop")
            {
                var amount = long.Parse(Console.ReadLine());

                if (!minerResources.ContainsKey(resource))
                {
                    minerResources[resource] = 0;
                }

                minerResources[resource] += amount;

                resource = Console.ReadLine();

            }

            foreach (var r in minerResources)
            {
                Console.WriteLine($"{r.Key} -> {r.Value}");
            }
        }
    }
}
