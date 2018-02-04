using System;
using System.Linq;

namespace Problem_13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToArray();
            Func<string, int> strToSum = s => s.Select(x => (int)x).Sum();
            Console.WriteLine(names.FirstOrDefault(x => strToSum(x) >= n));         
        }
    }
}
