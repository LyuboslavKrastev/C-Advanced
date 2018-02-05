using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = "../Materials/words.txt";
            var inputPath = "../Materials/text.txt";
            string outputPath = "../Output/result.txt";
            var wordsKeeper = new Dictionary<string, int>();

            using (var wordReader = new StreamReader(wordsPath))
            {
                string wordLine;
                while ((wordLine = wordReader.ReadLine()) != null)
                {
                    if (!wordsKeeper.ContainsKey(wordLine))
                    {
                        wordsKeeper[wordLine] = 0;
                    }
                    using (var TextReader = new StreamReader(inputPath))
                    {
                        string textLine;

                        while ((textLine = TextReader.ReadLine()) != null)
                        {
                            var currentLine = textLine
                                .Split(new char[] {' ', ',', '!', '-', '?', '.'})
                                .Select(w => w.ToLower())
                                .ToArray();

                            wordsKeeper[wordLine] += currentLine.Where(w => w == wordLine).Count();
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var word in wordsKeeper.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }            

        }
    }
}
