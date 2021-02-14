using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<int, int>> dictionary = new Dictionary<string, Func<int,int>>() {
                {"add", n => n +1 },
                { "subtract", n => n -1},
                {"multiply", n=>n*2 }

            };

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            while (command != "end")
            {
                if (dictionary.ContainsKey(command))
                {
                    Func<int, int> func = dictionary[command];
                    numbers = numbers.Select(func).ToList();
                }
                else
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
