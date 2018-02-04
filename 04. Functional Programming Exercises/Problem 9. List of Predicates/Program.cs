using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var top = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(n =>n).ToArray();
            var result = new List<int>();

            for (int i = 1; i <= top; i++)
            {
                result.Add(i);
            }

            foreach (var n in numbers)
            {
                result = result.Where(num => num % n == 0).ToList();
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
