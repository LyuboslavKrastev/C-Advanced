using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var type = Console.ReadLine();

        Predicate<int> isOdd = n => n % 2 != 0;
        Predicate<int> isEven = n => n % 2 == 0;

        var lowerBound = numbers[0];
        var upperBound = numbers[1];


        var result = new List<int>();

        for (int i = lowerBound; i <= upperBound; i++)
        {
            result.Add(i);
        }

        if (type == "even")
        {
            Console.WriteLine(string.Join(" ", result.Where(i => isEven(i))));
        }
        else
        {
            Console.WriteLine(string.Join(" ", result.Where(i => isOdd(i))));
        }

    }
}