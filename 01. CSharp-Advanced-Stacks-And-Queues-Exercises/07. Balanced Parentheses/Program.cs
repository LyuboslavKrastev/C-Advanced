using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var validOpening = new char[] { '{', '[', '(' };

            var input = Console.ReadLine();

            var parenthesesChecker = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentParentheses = input[i];

                if (validOpening.Contains(currentParentheses))
                {
                    parenthesesChecker.Push(currentParentheses);
                }
                else
                {
                    if (!parenthesesChecker.Any())
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (currentParentheses)
                    {
                        case '}':
                            if (parenthesesChecker.Pop()!='{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ')':
                            if (parenthesesChecker.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (parenthesesChecker.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
