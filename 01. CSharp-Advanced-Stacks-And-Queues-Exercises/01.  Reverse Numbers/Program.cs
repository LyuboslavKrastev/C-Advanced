﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var result = new Stack<int>(input);

            while (result.Count > 0)
            {
                Console.Write(result.Pop() + " ");
            }
        }
    }
}
