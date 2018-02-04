using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();

        Action<string> knightTitles = i => Console.WriteLine("Sir " + i);

        Array.ForEach(input, knightTitles);

    }
}