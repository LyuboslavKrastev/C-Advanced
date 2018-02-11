using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_3___Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }
            string text = sb.ToString();
            // var regex = @"\{[\x00-\x7F]+\}|\[[\x00-\x7F]+\]";
            var regex = @"(\[(?:\[??[^\[{]*?\]))|(\{(?:\[??[^\[{]*?\}))";

        var matchCollection = Regex.Matches(text, regex);

            var validMatches = new List<string>();
            var validNumbers = new List<KeyValuePair<string, int>>();
            foreach (Match match in matchCollection)
            {
                var number = "";
                var currentMatch = match.ToString();

                var currMatchLength = currentMatch.Length;
                var digInARow = 0;
                for (int i = 0; i < currentMatch.Length; i++)
                {                   
                    if (Char.IsDigit(currentMatch[i]))
                    {
                        digInARow++;
                        number += currentMatch[i];
                    }
                }
                if (digInARow >= 3)
                {
                    validNumbers.Add(new KeyValuePair<string, int>(number, currentMatch.Length));
                } 
            }
            foreach (var number in validNumbers)
            {
                if (number.Key.Length % 3 == 0)
                {
                    List<string> result = Split(number.Key, 3).ToList();
                    foreach (var nu in result)
                    {
                        var newNumber = int.Parse(nu) - number.Value;
                        char c = Convert.ToChar(newNumber);
                        Console.Write(c);
                    }
                }
            }           
        }
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
