using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dragonKeeper = new Dictionary<string, HashSet<Dragon>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var type = input[0];
                var name = input[1];

                int damage;
                if (!int.TryParse(input[2], out damage))
                {
                    damage = 45;
                }

                int health;
                if (!int.TryParse(input[3], out health))
                {
                    health = 250;
                }

                int armor;
                if (!int.TryParse(input[4], out armor))
                {
                    armor = 10;
                }

               

                if (!dragonKeeper.ContainsKey(type))
                {
                    dragonKeeper[type] = new HashSet<Dragon>();
                }

                var updateDragon = dragonKeeper[type].FirstOrDefault(d => d.Name == name);

                if (updateDragon == null)
                {
                    var currentDragon = new Dragon
                    {
                        Name = name,
                        Damage = damage,
                        Health = health,
                        Armor = armor
                    };
                    dragonKeeper[type].Add(currentDragon);
                }
                else
                {
                    updateDragon.Damage = damage;
                    updateDragon.Armor = armor;
                    updateDragon.Health = health;
                }

               
            }

            foreach (var type in dragonKeeper)
            {
                var avgDamage = type.Value.Select(t => t.Damage).Average();
                var avgHealth = type.Value.Select(t => t.Health).Average();
                var avgArmor = type.Value.Select(t => t.Armor).Average();
                Console.WriteLine($"{type.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");
                foreach (var dragon in type.Value.OrderBy(d => d.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor} ");
                }              
            }
        }
    }
}
