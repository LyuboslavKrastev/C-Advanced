using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var user = Console.ReadLine();
                result.Add(user);
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
