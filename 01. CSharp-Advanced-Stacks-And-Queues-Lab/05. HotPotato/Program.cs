using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._HotPotato
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var steps = int.Parse(Console.ReadLine());

            var children = input.Split().ToArray();

            var stillInGame = new Queue<string>(children);


            while (stillInGame.Count > 1)
            {
                for (int i = 1; i < steps; i++)
                {
                    stillInGame.Enqueue(stillInGame.Dequeue());
                }

                var removedChild = stillInGame.Dequeue();

                Console.WriteLine("Removed {0}", removedChild);
            }

            var winner = stillInGame.Dequeue();

            Console.WriteLine("Last is {0}", winner);
        }
    }
}
