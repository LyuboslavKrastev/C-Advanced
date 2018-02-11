using System;
using System.Collections.Generic;
using System.Linq;
namespace Problem_4___Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var infoIndex = int.Parse(Console.ReadLine());
            string input;

            var people = new Dictionary<string, Dictionary<string, string>>();
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var tokens = input.Split(new char[] { '=', ';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = tokens[0];
                if (!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();
                }
                for (int i = 1; i < tokens.Length; i++)
                {
                    var currentInfo = tokens[i].Split(':');
                    if (!people[name].ContainsKey(currentInfo[0]))
                    {
                        people[name][currentInfo[0]] = "";
                    }
                    people[name][currentInfo[0]] = currentInfo[1];
                }

            }
            var killTarget = Console.ReadLine().Split()[1];
            if (people.ContainsKey(killTarget))
            {
                Console.WriteLine($"Info on {killTarget}:");
                var targetInfoIndex = 0;
                foreach (var test in people[killTarget])
                {
                    targetInfoIndex += test.Key.Length;
                    targetInfoIndex += test.Value.Length;
                }

                foreach (var info in people[killTarget].OrderBy(v => v.Key))
                {
                    Console.WriteLine($"---{info.Key}: {info.Value}");
                }
                Console.WriteLine($"Info index: {targetInfoIndex}");
                if (targetInfoIndex >= infoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {infoIndex-targetInfoIndex} more info.");
                }
            }
        }
    }
}
