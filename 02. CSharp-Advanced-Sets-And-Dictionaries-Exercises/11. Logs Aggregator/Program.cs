using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var users = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var ip = input[0];
                var userName = input[1];
                var duration = int.Parse(input[2]);

                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();
                }
                if (!users[userName].ContainsKey(ip))
                {
                    users[userName][ip] = 0;
                }
                users[userName][ip] += duration;                                
            }

            foreach (var u in users.OrderBy(u =>u.Key))
            {
                var user = u.Key;

                long totalDuration = u.Value.Select(i => i.Value).Sum();

                var ips = u.Value.Select(ip => ip.Key).OrderBy(i => i).ToArray();

                Console.WriteLine($"{user}: {totalDuration} [{string.Join(", ", ips)}]");
            }
        }
    }
}
