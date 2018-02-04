using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();

        Action<string[]> test = i => i.OrderByDescending(x => x).ToArray();
        test(input);

        Console.WriteLine(string.Join(Environment.NewLine, input));
    }
}