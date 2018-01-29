using System;
using System.Collections.Generic;

namespace _06._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsThatPass = int.Parse(Console.ReadLine());
            var jam = new Queue<string>();
            var passed = 0;
            string input;
            while ((input=Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    var jamCheck = Math.Min(carsThatPass, jam.Count);
                    for (int i = 0; i < jamCheck; i++)
                    {
                        Console.WriteLine($"{jam.Dequeue()} passed!");
                        passed++;
                    }                  
                    continue;
                }
                jam.Enqueue(input);
            }

            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
