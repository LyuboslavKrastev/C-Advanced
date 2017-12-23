using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._MathPotato
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var steps = int.Parse(Console.ReadLine());

            var children = input.Split().ToArray();

            var stillInGame = new Queue<string>(children);

            var cicle = 1;

            while (stillInGame.Count > 1)
            {
                for (int i = 1; i < steps; i++)
                {
                    stillInGame.Enqueue(stillInGame.Dequeue());
                }

                if (IsPrime(cicle) == true)
                {
                    var primeChild = stillInGame.Peek();
                    Console.WriteLine("Prime {0}", primeChild);
                    cicle++;
                    continue;
                }

                var removedChild = stillInGame.Dequeue();

                Console.WriteLine("Removed {0}", removedChild);

                cicle++;
            }

            var winner = stillInGame.Dequeue();

            Console.WriteLine("Last is {0}", winner);
        }

        public static bool IsPrime(int num)
        {
            if (num == 1)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

