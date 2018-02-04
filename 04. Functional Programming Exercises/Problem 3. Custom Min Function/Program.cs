using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();

        Func<string[], int> customMin = i => i.Select(int.Parse).Min();

        Console.WriteLine(customMin(input));
    }
}