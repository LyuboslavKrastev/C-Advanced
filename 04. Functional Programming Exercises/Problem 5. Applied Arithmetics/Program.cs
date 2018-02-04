using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        string command;

        Func<int[], int[]> addFunc = i => i.Select(x => x += 1).ToArray();
        Func<int[], int[]> multiplyFunc = i => i.Select(x => x *= 2).ToArray();
        Func<int[], int[]> subsFunc = i => i.Select(x => x -= 1).ToArray();

        while ((command = Console.ReadLine()) != "end")
        {
            switch (command)
            {
                case "add":
                    numbers = addFunc(numbers);
                    break;

                case "multiply":
                    numbers = multiplyFunc(numbers);
                    break;

                case "subtract":
                    numbers = subsFunc(numbers);
                    break;

                case "print":
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
            }
        }

    }
}