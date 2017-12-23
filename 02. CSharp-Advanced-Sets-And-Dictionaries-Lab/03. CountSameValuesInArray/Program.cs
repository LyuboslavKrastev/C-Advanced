using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            var container = new SortedDictionary<Double, int>();

            foreach (var number in input)
            {
                if (!container.ContainsKey(number))
                {
                    container[number] = 0;
                }
                container[number]++;
            }

            foreach (var kvp in container)
            {
                Console.WriteLine("{0} - {1} times", kvp.Key, kvp.Value);
            }
        }
    }
}
