using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split().ToList();
            var filteredGuests = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                var tokens = input.Split(new char[] { ';' });

                var mainCommand = tokens[0];
                var secondaryCommand = tokens[1];
                var commandParameter = tokens[2];

                if (mainCommand == "Add filter")
                {
                    addFilter(guests, filteredGuests, secondaryCommand, commandParameter);
                }
                else if (mainCommand == "Remove filter")
                {
                    filteredGuests = removeFilter(filteredGuests, secondaryCommand, commandParameter);
                }
            }
            guests = guests.Where(p => !filteredGuests.Contains(p)).ToList();
            Console.WriteLine(string.Join(" ", guests));
        }
        private static List<string> addFilter(List<string> guests, List<string> filteredGuests, string secondaryCommand, string commandParameter)
        {
            if (secondaryCommand == "Starts with")
            {
                filteredGuests.AddRange(guests.Where(s => s.StartsWith(commandParameter)));
            }
            else if (secondaryCommand == "Ends with")
            {
                filteredGuests.AddRange(guests.Where(s => s.EndsWith(commandParameter)));
            }
            else if (secondaryCommand == "Contains")
            {
                filteredGuests.AddRange(guests.Where(s => s.Contains(commandParameter)));
            }
            else if (secondaryCommand == "Length")
            {
                var length = int.Parse(commandParameter);
                filteredGuests.AddRange(guests.Where(s => s.Length == length));
            }
            return filteredGuests;
        }

        private static List<string> removeFilter(List<string> filteredGuests, string secondaryCommand, string commandParameter)
        {
            if (secondaryCommand == "Starts with")
            {
                filteredGuests.RemoveAll(n => n.StartsWith(commandParameter));
            }
            else if (secondaryCommand == "Ends with")
            {
                filteredGuests.RemoveAll(s => s.EndsWith(commandParameter));
            }
            else if (secondaryCommand == "Contains")
            {
                filteredGuests.RemoveAll(s => s.Contains(commandParameter));
            }
            else if (secondaryCommand == "Length")
            {
                var length = int.Parse(commandParameter);
                filteredGuests.RemoveAll(s => s.Length == length);
            }

            return filteredGuests;
        }
    }
}
