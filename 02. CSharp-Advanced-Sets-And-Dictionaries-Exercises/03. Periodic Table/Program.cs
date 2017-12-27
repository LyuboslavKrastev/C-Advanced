using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new SortedSet<string>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split();

                foreach (var e in elements)
                {
                    table.Add(e);
                }
            }
            Console.WriteLine(string.Join(" ", table));
        }
    }
}
