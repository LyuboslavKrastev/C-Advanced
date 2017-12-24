using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandIntegers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var elementsToPush = commandIntegers[0];

            var elementsToPop = commandIntegers[1];

            var lookingFor = commandIntegers[2];

            var result = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                result.Push(input[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                result.Pop();
            }

            if (result.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }


            if (result.Contains(lookingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(result.Min());
            }

        }
    }
}
