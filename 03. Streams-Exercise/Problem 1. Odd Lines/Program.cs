using System;
using System.IO;

namespace Problem_1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("../Materials/text.txt");

            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                   
                    if (lineNumber % 2 !=0)
                    {
                        Console.WriteLine(line);
                    }
                   
                    line = reader.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}
