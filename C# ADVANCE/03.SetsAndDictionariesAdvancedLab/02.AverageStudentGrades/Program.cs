using System;
using System.Collections.Generic;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> dictionary = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (!dictionary.ContainsKey(input[0]))
                {
                    dictionary.Add(input[0], new List<decimal>());
                }

                dictionary[input[0]].Add(decimal.Parse(input[1]));
            }
            foreach (var item in dictionary)
            {
                Console.Write(item.Key+" -> ");
                decimal averageScore = 0;
                foreach (var grade in item.Value)
                {
                    averageScore += grade;
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {averageScore / item.Value.Count:f2})");
            }
        }
    }
}
