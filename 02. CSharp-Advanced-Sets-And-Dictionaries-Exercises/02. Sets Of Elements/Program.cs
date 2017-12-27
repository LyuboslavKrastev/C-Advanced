using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var n = input[0];
            var m = input[1];

            var firstSet = new HashSet<int>();

            var secondSet = new HashSet<int>();

            var length = n + m;

            for (int i = 0; i < length; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }

            }

            var result = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
