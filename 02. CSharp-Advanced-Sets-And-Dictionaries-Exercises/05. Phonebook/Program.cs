using System;
using System.Collections.Generic;

namespace _05._Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();

            var input = Console.ReadLine();

            while (input != "search")
            {
                var tokens = input.Split('-');

                var name = tokens[0];
                var number = tokens[1];

                phoneBook[name] = number;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                var searchFor = input;

                if (phoneBook.ContainsKey(searchFor))
                {
                    Console.WriteLine($"{searchFor} -> {phoneBook[searchFor]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchFor} does not exist.");
                }


                input = Console.ReadLine();
            }
        }
    }
}
