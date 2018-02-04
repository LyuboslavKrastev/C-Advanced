//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        private static List<int> gems;
        public static void Main(string[] args)
        {
            gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            var commands = new Dictionary
                <string, Dictionary<int, Predicate<int>>>(); // determines if a filter can be applied

            while ((command = Console.ReadLine()) != "Forge")
            {
                var tokens = command.Split(';');
                var currentCommand = tokens[0];
                var filterType = tokens[1];
                var filterParam = int.Parse(tokens[2]);

                if (currentCommand == "Exclude")
                {
                    var filterFunction = GetFunction(filterType, filterParam);

                    if (!commands.ContainsKey(filterType))
                    {
                        commands[filterType] = new Dictionary<int, Predicate<int>>();

                    }
                    commands[filterType].Add(filterParam, filterFunction);
                }
                else
                {
                    commands[filterType].Remove(filterParam);
                }
            }
            gems = Filter(commands);
            Console.WriteLine(string.Join(" ", gems));
        }
        private static List<int> Filter(Dictionary
                <string, Dictionary<int, Predicate<int>>> filters)
        {
            var result = new List<int>();
            for (var i = 0; i < gems.Count; i++)
            {
                var isFiltered = false;
                foreach (var filter in filters)
                {
                    foreach (var predicate in filter.Value)
                    {
                        if (predicate.Value(i))
                        {
                            isFiltered = true;
                            break;
                        }
                    }
                }
                if (isFiltered == false)
                {
                    result.Add(gems[i]);
                }
            }
            return result;
        }
        private static Predicate<int> GetFunction(string filterType, int filterParam)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return x => (x <= 0 ? 0 : gems[x - 1]) + gems[x] == filterParam;
                case "Sum Right":
                    return x => (x >= gems.Count - 1 ? 0 : gems[x + 1]) + gems[x] == filterParam;
                case "Sum Left Right":
                    return x => (x <= 0 ? 0 : gems[x - 1]) + gems[x]
                        + (x >= gems.Count - 1 ? 0 : gems[x + 1]) == filterParam;
            }

            return null;
        }
    }
}