using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split().ToList();

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                var tokens = input.Split();
                var mainCommand = tokens[0];
                var secondaryCommand = tokens[1];
                var commandParam = tokens[2];

                if (secondaryCommand == "StartsWith" || secondaryCommand == "EndsWith")
                {
                    people = endingOrBeginingMethod(people, mainCommand, secondaryCommand, commandParam);
                }
                else if (secondaryCommand == "Length")
                {
                    var length = int.Parse(commandParam);
                    people = lengthMethod(people, mainCommand, length);
                }
            }
            printResult(people);
        }

        private static void printResult(List<string> people)
        {
            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> lengthMethod(List<string> names, string command, int length)
        {
            if (command == "Double")
            {
                var matchingNames = names.Where(n => n.Length == length).ToList();
                for (int i = 0; i < names.Count; i++)
                {
                    var currentName = names[i];
                    if (currentName.Length == length)
                    {
                        names.Insert(i, currentName);
                        i++;
                    }
                }
            }
            else if (command == "Remove")
            {
                names = names.Where(n => n.Length != length).ToList();
            }
            return names;
        }
        private static List<string> endingOrBeginingMethod(List<string> names, string mainCommand, string secondaryCommand, string endingOrBeginning)
        {
            if (mainCommand == "Double")
            {
                if (secondaryCommand == "EndsWith")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        var currentName = names[i];
                        if (currentName.EndsWith(endingOrBeginning))
                        {
                            names.Insert(i, currentName);
                            i++;
                        }
                    }
                }
                else if (secondaryCommand == "StartsWith")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        var currentName = names[i];
                        if (currentName.StartsWith(endingOrBeginning))
                        {
                            names.Insert(i, currentName);
                            i++;
                        }
                    }
                }
            }
            else if (mainCommand == "Remove")
            {
                if (secondaryCommand == "EndsWith")
                {
                    names = names.Where(n => !n.EndsWith(endingOrBeginning)).ToList();
                }
                else
                {
                    names = names.Where(n => !n.StartsWith(endingOrBeginning)).ToList();
                }
            }
            return names;
        }
    }
}
