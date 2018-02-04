using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Array.Sort(numbers, customComparator);

        Console.WriteLine(string.Join(" ", numbers));

    }

    public static int customComparator(int x, int y)
    {
        int result = 0;
        Func<int, int> remindChecker = i => Math.Abs(i % 2);

        if (remindChecker(x) == remindChecker(y))
        {
            result = x.CompareTo(y);
        }
        else
        {
            result = remindChecker(x).CompareTo(remindChecker(y));
        }
        return result;
    }
}