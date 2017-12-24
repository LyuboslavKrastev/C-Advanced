using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new Stack<long>();
            var maxValue = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                if (input.Length == 2)
                {
                    var elementToPush = long.Parse(input[1]);
                    result.Push(elementToPush);
                    if (elementToPush > maxValue)
                    {
                        maxValue = elementToPush;
                    }
                }
                else
                {
                    var type = int.Parse(input[0]);
                    if (type == 2)
                    {
                        result.Pop();
                        if (result.Count > 0)
                        {
                            maxValue = result.Max();
                        }
                    }

                    else if (type == 3)
                    {
                        Console.WriteLine(maxValue);
                    }
                }
            }
        }
    }
}
