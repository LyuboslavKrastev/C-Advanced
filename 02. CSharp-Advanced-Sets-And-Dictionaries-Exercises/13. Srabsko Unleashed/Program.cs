using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13._Srabsko_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            var pattern = @"^(?<Singer>[a-zA-Z]+\s?[a-zA-Z]*) @(?<Venue>[a-zA-Z]+\s?[a-zA-Z]*) (?<Price>\d+) (?<Tickets>\d+)$";
            var checkValidity = new Regex(pattern);

            var events = new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (!checkValidity.IsMatch(input)) 
                {
                    continue;
                }

                var extractValues = checkValidity.Match(input);

                string singer = extractValues.Groups["Singer"].Value.ToString();
                var venue = extractValues.Groups["Venue"].Value.ToString();
                var price = int.Parse(extractValues.Groups["Price"].Value.ToString());
                var ticketsCount = int.Parse(extractValues.Groups["Tickets"].Value.ToString());
                var profit = price * ticketsCount;

                if (!events.ContainsKey(venue))
                {
                    events[venue] = new Dictionary<string, long>();
                }

                if (!events[venue].ContainsKey(singer))
                {
                    events[venue][singer] = 0; 
                }
                events[venue][singer] += profit;
            }

            foreach (var city in events)
            {
                Console.WriteLine(city.Key);

                foreach (var singer in city.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
