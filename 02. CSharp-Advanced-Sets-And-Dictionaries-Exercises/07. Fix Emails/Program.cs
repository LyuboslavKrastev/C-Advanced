using System;
using System.Collections.Generic;

namespace _07._Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();

            var input = Console.ReadLine();

            while (input != "stop")
            {
                var name = input;
                var email = Console.ReadLine();

                if (email.ToLower().EndsWith("us") || email.ToLower().EndsWith("uk"))
                {
                    input = Console.ReadLine();
                    continue;
                }

                emails[name] = email;

                input = Console.ReadLine();
            }

            foreach (var u in emails)
            {
                Console.WriteLine($"{u.Key} -> {u.Value}");
            }
        }
    }
}
