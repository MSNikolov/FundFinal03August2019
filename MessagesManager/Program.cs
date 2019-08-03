using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var cap = int.Parse(Console.ReadLine());

            var stats = new Dictionary<string, int[]>();

            var input = Console.ReadLine();

            while (input != "Statistics")
            {
                var command = input.Split('=');

                switch (command[0])
                {
                    case "Add":
                        if (!stats.ContainsKey(command[1]))
                        {
                            stats.Add(command[1], new int[2]);
                            stats[command[1]][0] = int.Parse(command[2]);
                            stats[command[1]][1] = int.Parse(command[3]);
                        }
                        break;
                    case "Message":
                        var sender = command[1];
                        var receiver = command[2];
                        if (stats.ContainsKey(sender) && stats.ContainsKey(receiver))
                        {
                            stats[sender][0]++;
                            if (stats[sender].Sum() == cap)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");
                                stats.Remove(sender);
                            }
                            stats[receiver][1]++;
                            if (stats[receiver].Sum() == cap)
                            {
                                Console.WriteLine($"{receiver} reached the capacity!");
                                stats.Remove(receiver);
                            }
                        }
                        break;
                    case "Empty":
                        var user = command[1];
                        if (user == "All")
                        {
                            stats.Clear();
                        }
                        else
                        {
                            if (stats.ContainsKey(user))
                            stats.Remove(user);
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {stats.Count}");

            var results = stats.OrderByDescending(s => s.Value[1]).ThenBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var user in results)
            {
                Console.WriteLine($"{user.Key} - {user.Value.Sum()}");
            }
        }
    }
}
