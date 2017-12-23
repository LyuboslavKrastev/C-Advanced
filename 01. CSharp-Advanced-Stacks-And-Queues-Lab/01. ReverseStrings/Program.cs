using System;
using System.Collections.Generic;

namespace _01._ReverseStrings
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<string>();

            for (var i = 0; i < input.Length; i++)
            {
                stack.Push(input[i].ToString());
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
