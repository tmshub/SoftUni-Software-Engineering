using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (dictionary.ContainsKey(text[i]))
                {
                    dictionary[text[i]]++;
                }
                else
                {
                    dictionary.Add(text[i], 1);
                }

            }
            foreach (var item in dictionary.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
