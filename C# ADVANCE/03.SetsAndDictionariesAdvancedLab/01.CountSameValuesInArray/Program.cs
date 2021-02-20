using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] seccuence = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, double> occurrences = new Dictionary<double, double>();

            for (int i = 0; i < seccuence.Length; i++)
            {
                if (!occurrences.ContainsKey(seccuence[i]))
                {
                    occurrences.Add(seccuence[i], 0);
                }
                occurrences[seccuence[i]]++;
            }

            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
