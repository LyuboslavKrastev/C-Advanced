using System;
using System.Collections.Generic;

namespace _03._DecimalToBinaryConverter
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.WriteLine("0");
                return;
            }

            var stack = new Stack<string>();

            while (input > 0)
            {
                var currbinary = (input % 2).ToString();
                input /= 2;
                stack.Push(currbinary);
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}

