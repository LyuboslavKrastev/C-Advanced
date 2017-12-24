using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var stackFibonacci = new Stack<long>();

            stackFibonacci.Push(0); stackFibonacci.Push(1);

            for (int i = 1; i < input; i++)
            {
                var previous = stackFibonacci.Pop();
                var next = previous + stackFibonacci.Peek();

                stackFibonacci.Push(previous);
                stackFibonacci.Push(next);
            }
                Console.WriteLine(stackFibonacci.Peek());
            }
        }
    }

