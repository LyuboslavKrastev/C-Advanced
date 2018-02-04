using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        var number = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split().ToArray();

        Predicate<string> passes = n => n.Length <= number;

        Func<string[], string[]> nameFilter = i => i.Where(x => passes(x)).ToArray();

        names = nameFilter(names);

        Console.WriteLine(string.Join(Environment.NewLine, names));

    }
}