using System;
using System.Collections.Generic;

namespace _04._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedDictionary = new SortedDictionary<char, int>();

            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];
                if (!sortedDictionary.ContainsKey(currentSymbol))
                {
                    sortedDictionary[currentSymbol] = 0;
                }

                sortedDictionary[currentSymbol]++;
            }

            foreach (var s in sortedDictionary)
            {
                Console.WriteLine($"{s.Key}: {s.Value}");
            }
        }
    }
}
