using System;
using System.Collections.Generic;

namespace _04._MatchingBrackets
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var indexStack = new Stack<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexStack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var startIndex = indexStack.Pop();
                    var endIndex = i;
                    var length = endIndex - startIndex + 1;

                    var result = input.Substring(startIndex, length);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
