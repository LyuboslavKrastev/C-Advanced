using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var previousText = new Stack<string>();
            var text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        previousText.Push(text);
                        text += input[1];
                        break;

                    case 2:
                        previousText.Push(text);
                        var count = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - count);
                        break;

                    case 3:
                        var index = int.Parse(input[1]);
                        Console.WriteLine(text[index-1]);
                        break;

                    case 4:
                        text = previousText.Pop();
                        break;
                }
            }
        }
    }
}
