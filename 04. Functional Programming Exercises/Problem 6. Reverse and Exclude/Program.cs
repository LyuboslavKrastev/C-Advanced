using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var delimeter = int.Parse(Console.ReadLine());

        Func<int[], int, int[]> reverser = (arr, d) => arr.Where(x => x % d != 0).Reverse().ToArray();

        numbers = reverser(numbers, delimeter);
        Console.WriteLine(string.Join(" ", numbers));
    }
}