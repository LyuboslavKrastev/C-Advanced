using System;
using System.Collections.Generic;

namespace _02._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipInvitations = new SortedSet<string>();
            var normalInvitations = new SortedSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (Char.IsDigit(input[0]))
                {
                    vipInvitations.Add(input);
                }
                else
                {
                    normalInvitations.Add(input);
                }
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (Char.IsDigit(input[0]))
                {
                    vipInvitations.Remove(input);
                }
                else
                {
                    normalInvitations.Remove(input);
                }
                input = Console.ReadLine();
            }

            var totalCount = normalInvitations.Count + vipInvitations.Count;
            Console.WriteLine(totalCount);
            if (vipInvitations.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipInvitations));
            }
            if (normalInvitations.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, normalInvitations));
            }
        }
    }
}
