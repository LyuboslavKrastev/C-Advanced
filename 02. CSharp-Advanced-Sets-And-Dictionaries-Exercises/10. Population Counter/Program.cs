using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();

            string input;

            while ((input = Console.ReadLine()) != "report")
            {
                var tokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var town = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new Dictionary<string, long>();
                    countries[country]["totalPopulation"] = 0;
                }
                if (!countries[country].ContainsKey(town))
                {
                    countries[country][town] = 0;
                }

                countries[country]["totalPopulation"] += population;
                countries[country][town] += population;
            }

            foreach (var c in countries.OrderByDescending(c => c.Value["totalPopulation"]))
            {
                Console.WriteLine($"{c.Key} (total population: {c.Value["totalPopulation"]})");

                var towns = c.Value.Where(t => t.Key != "totalPopulation")
                    .OrderByDescending(t => t.Value)
                    .Select(t => $"=>{t.Key}: {t.Value}").ToArray();

                var result = string.Join(Environment.NewLine, towns);
                Console.WriteLine(result);
            }
        }
    }
}
