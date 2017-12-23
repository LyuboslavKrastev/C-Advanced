using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SimpleCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var tokens = input.Split().ToArray();

            var stack = new Stack<string>(tokens.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operand = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (operand == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else if (operand == "-")
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
