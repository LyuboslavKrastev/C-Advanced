using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            //IP=192.23.30.40 message='Hello&derps.' user=destroyer

            string input;

            var userTracker = new Dictionary<string, Dictionary<string, int>>();



            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = tokens[1];
                var message = tokens[3];
                var user = tokens[5];

                if (!userTracker.ContainsKey(user))
                {
                    userTracker[user] = new Dictionary<string, int>();
                }
                if (!userTracker[user].ContainsKey(ip))
                {
                    userTracker[user][ip] = 0;
                }
                userTracker[user][ip]++;
            }

            foreach (var user in userTracker.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}: ");

                var userLogs = user.Value.Select(l => $"{l.Key} => {l.Value}").ToArray();
                var result = string.Join($", ", userLogs);

                Console.WriteLine($"{result}.");
            }
        }
    }
}
