using System;
using System.Linq;
using System.Collections.Generic;
namespace Problem_1___Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var pricePerBullet = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());

            var bulletInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var lockInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToArray();

            var inteligenceValue = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(bulletInput);
            var bulletsFired = 0;
            var locks = new Queue<int>(lockInput);
            var moneyEarned = 0;

            while (true)
            {
                if (bulletsFired == sizeOfGunBarrel && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsFired = 0;
                    continue;
                }
                if (bullets.Count == 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
                if (locks.Count == 0)
                {
                    moneyEarned += inteligenceValue;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }

                bulletsFired++;
                var bullet = bullets.Pop();
                var currentLock = locks.Peek();

                moneyEarned -= pricePerBullet;

                if (bullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                    continue;
                }

                Console.WriteLine("Bang!");
                locks.Dequeue();

            }
        }
    }
}
