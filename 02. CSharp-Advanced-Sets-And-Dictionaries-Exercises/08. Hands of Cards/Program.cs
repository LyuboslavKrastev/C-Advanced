using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, HashSet<int>>();

            string input;

            while ((input = Console.ReadLine()) != "JOKER")
            {
                var tokens = input.Split(':').ToArray();
                string player = tokens[0];
                var cards = tokens[1].Split(new string[] {",", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => calcValue(e)).ToList();

                if (!players.ContainsKey(player))
                {
                    players[player] = new HashSet<int>();
                }

                players[player].UnionWith(cards);


            }

            foreach (var p in players)
            {
                Console.WriteLine($"{p.Key}: {p.Value.Sum()}");
            }
        }
        private static int calcValue(string a)
        {
            var cardPowers = new Dictionary<string, int>();
            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;
            for (int i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }
            var cardTypes = new Dictionary<string, int>();
            cardTypes["S"] = 4;
            cardTypes["H"] = 3;
            cardTypes["D"] = 2;
            cardTypes["C"] = 1;
            var cardPower = a.Substring(0, a.Length - 1);
            var cardType = a.Substring(a.Length - 1);

            var result = cardPowers[cardPower] * cardTypes[cardType];
            return result;

        }
    }
}
