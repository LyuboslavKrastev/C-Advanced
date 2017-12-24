using System;
using System.Collections.Generic;

namespace _08._Recursive_Fibonacci
{    
    class Program
    {
        public static Dictionary<int, long> memorization = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());           

            Console.WriteLine(Fibonacci(input));
        }

        static long Fibonacci(int n)
        {

            if (memorization.ContainsKey(n))
            {
                return memorization[n];
            }

            if (n <= 2)
            {
                return 1;
            }
            else
            {
                return memorization[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
