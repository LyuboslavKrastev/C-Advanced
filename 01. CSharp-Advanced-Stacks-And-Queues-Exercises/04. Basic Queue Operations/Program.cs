using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var elementCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToEnqueue = elementCommands[0];
            int elementsToDequeue = elementCommands[1];
            int elementToCheck = elementCommands[2];

            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            foreach (int e in elements)
            {
                queue.Enqueue(e);
            }


            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (queue.Any(e => e == elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
