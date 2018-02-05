using System;
using System.IO;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputFilePath = "../Materials/text.txt";

            string outputPath = "../Output/output.txt";                  

            using (var reader = new StreamReader(inputFilePath))
            {
                using (var writer = new StreamWriter(outputPath))
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {line}");

                        line = reader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
    }
}
