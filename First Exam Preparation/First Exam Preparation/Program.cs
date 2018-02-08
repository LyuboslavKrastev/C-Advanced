using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int inputLength = input.Length;
            string firstMatchPattern = @"(?<match>\[\w+<\d+REGEH\d+>\w+\])";
            var firstRegex = new Regex(firstMatchPattern);
            var getDigits = new Regex(@"\d+");
            MatchCollection matches = firstRegex.Matches(input);
            var index = 0;
            string word = string.Empty;
            foreach (Match match in matches)
            {
                
                var currentMatch = match.Value;
                var indexOfOpeningBracket = currentMatch.IndexOf('<') + 1;
                var indexOfClosingBracket = currentMatch.IndexOf('>');

                currentMatch =
                    currentMatch.Substring(indexOfOpeningBracket, indexOfClosingBracket - indexOfOpeningBracket);

                MatchCollection numCollection = getDigits.Matches(currentMatch);
               
                foreach (var num in numCollection)
                {
                    var currNum = int.Parse(num.ToString());
                    if (currNum >= input.Length)
                    {
                        currNum %= input.Length;
                    }

                    index += currNum;

                    if (index >= input.Length)
                    {
                        index %= input.Length - 1;
                    }
                    var currentLetter = input[index];
                    word += currentLetter;
                }
             
            }
            Console.WriteLine(word);
        }
    }
}
