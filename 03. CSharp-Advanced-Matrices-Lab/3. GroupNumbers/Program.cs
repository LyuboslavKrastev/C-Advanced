using System;
using System.Linq;

namespace _3._GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var firstRow = input.Where(e => Math.Abs(e) % 3 == 0).ToArray();
            var secondRow = input.Where(e => Math.Abs(e) % 3 == 1).ToArray();
            var thirdRow = input.Where(e => Math.Abs(e) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", firstRow));
            Console.WriteLine(string.Join(" ", secondRow));
            Console.WriteLine(string.Join(" ", thirdRow));

        }
    }
}
