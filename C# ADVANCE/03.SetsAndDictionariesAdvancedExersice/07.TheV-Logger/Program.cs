using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,SortedSet<string>>> dictionary = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Statistics")
            {
                if (input[1] == "joined")
                {
                    if (!dictionary.ContainsKey(input[0]))
                    {
                        dictionary.Add(input[0], new Dictionary<string, SortedSet<string>>());
                        dictionary[input[0]].Add("followers", new SortedSet<string>());
                        dictionary[input[0]].Add("following", new SortedSet<string>());
                    }
                }
                else if (input[1] == "followed")
                {
                    if (dictionary.ContainsKey(input[0]) && dictionary.ContainsKey(input[2]) && input[0] != input[2])
                    {
                        if (!dictionary[input[2]]["followers"].Contains(input[0]))
                        {
                            dictionary[input[2]]["followers"].Add(input[0]);
                            dictionary[input[0]]["following"].Add(input[2]);
                        }
                    }
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int count = 0;
            Console.WriteLine($"The V-Logger has a total of {dictionary.Count} vloggers in its logs.");

            foreach (var item in dictionary.OrderByDescending(k => k.Value["followers"].Count)
                .ThenBy(v => v.Value["following"].Count).ToDictionary(k=>k.Key, v=>v.Value))
            {
                Console.WriteLine($"{++count}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                if (count == 1)
                {
                    foreach (var kvp in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {kvp}");
                    }
                }
            }


        }
    }
}
