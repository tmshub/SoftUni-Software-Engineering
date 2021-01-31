using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dictionary = 
                new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contest = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input!= "end of contests")
            {
                string[] splitedInput = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string exam = splitedInput[0];
                string password = splitedInput[1];

                contest.Add(exam,password);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input!="end of submissions")
            {
                string[] splitedInput = input.Split("=>");
                string exam = splitedInput[0];
                string password = splitedInput[1];
                string studentName = splitedInput[2];
                int points = int.Parse(splitedInput[3]);

                if (contest.ContainsKey(exam))
                {
                    if (contest[exam].Contains(password))
                    {
                        if (!dictionary.ContainsKey(studentName))
                        {
                            dictionary.Add(studentName, new Dictionary<string, int>());
                            dictionary[studentName].Add(exam, points);
                        }
                        else
                        {
                            if (dictionary[studentName].ContainsKey(exam))
                            {
                                if (dictionary[studentName][exam] < points)
                                {
                                    dictionary[studentName][exam] = points;
                                }
                            }
                            else
                            {
                                dictionary[studentName].Add(exam, points);
                            }
                            
                        }
                        
                    }
                }

                input = Console.ReadLine();
            }
            SortedDictionary<string, int> candidatesPoints = new SortedDictionary<string, int>();
            
            foreach (var item in dictionary)
            {
                if (!candidatesPoints.ContainsKey(item.Key))
                {
                    candidatesPoints.Add(item.Key, item.Value.Values.Sum());
                }
            }
            int bestPoints = candidatesPoints.Values.Max();

            foreach (var item in candidatesPoints)
            {
                if(item.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {item.Key} with total {bestPoints} points.");
                }
            }
            Console.WriteLine("Ranking: ");
            foreach (var item in dictionary.OrderBy(k=>k.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var kvp in item.Value.OrderByDescending(v=>v.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
