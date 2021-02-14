using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = numbers[0];
            int end = numbers[1];

            Func<int, int, List<int>> generateRange = (star, end) =>
              {
                  List<int> range = new List<int>();

                  for (int i = start; i <= end; i++)
                  {
                      range.Add(i);
                  }
                  return range;
              };

            string command = Console.ReadLine();
            List<int> nums = new List<int>();
            
            if (command == "odd")
            {
                nums = generateRange(start, end).Where(n => n % 2 != 0).ToList();
            }
            else
            {
                nums = generateRange(start, end).Where(n => n % 2 == 0).ToList();
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
