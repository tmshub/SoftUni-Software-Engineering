using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (dictionary.ContainsKey(input))
                {
                    dictionary[input]++;
                }
                else
                {
                    dictionary.Add(input,1);
                }
            }

            foreach (var item in dictionary)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
