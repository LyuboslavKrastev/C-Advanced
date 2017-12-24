using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = long.Parse(Console.ReadLine());

            var elements = new Queue<long>();

            elements.Enqueue(firstNumber);
            var result = new StringBuilder();

            for (int i = 0; i < 50; i++)
            {
                long firstElement = elements.Peek() + 1;
                long secondElement = 2 * elements.Peek() + 1;
                long thirdElement = elements.Peek() + 2;

                elements.Enqueue(firstElement);
                elements.Enqueue(secondElement);
                elements.Enqueue(thirdElement);

                result.Append(elements.Dequeue() + " ");
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
