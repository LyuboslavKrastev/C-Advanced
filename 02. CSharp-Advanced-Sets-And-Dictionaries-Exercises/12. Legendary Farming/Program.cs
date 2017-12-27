using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>()
            {
                ["fragments"] = 0,
                ["motes"] = 0,
                ["shards"] = 0
            };


            var junk = new Dictionary<string, int>();

            string legendary = string.Empty;

            while (legendary.Length == 0)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input.Length; i += 2)
                {
                    var quantity = int.Parse(input[i]);
                    var material = input[i + 1].ToLower();

                    if (materials.ContainsKey(material))
                    {
                        materials[material] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk[material] = 0;
                        }
                        junk[material] += quantity;
                    }

                    var checkMaterials = materials.FirstOrDefault(m => m.Value >= 250).Key;

                    if (checkMaterials != null)
                    {
                        legendary = determineLegendary(checkMaterials);
                        materials[checkMaterials] -= 250;
                        break;
                    }
                }
            }
            Console.WriteLine($"{legendary} obtained!");
            foreach (var m in materials.OrderByDescending(v => v.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{m.Key}: {m.Value}");
            }

            foreach (var j in junk.OrderBy(m => m.Key))
            {
                Console.WriteLine($"{j.Key}: {j.Value}");
            }
        }

        private static string determineLegendary(string material)
        {
            var legendary = string.Empty;
            switch (material)
            {
                case "fragments":
                    legendary = "Valanyr";
                    break;
                case "shards":
                    legendary = "Shadowmourne";
                    break;
                case "motes":
                    legendary = "Dragonwrath";
                    break;
            }
            return legendary;
        }
    }
}
