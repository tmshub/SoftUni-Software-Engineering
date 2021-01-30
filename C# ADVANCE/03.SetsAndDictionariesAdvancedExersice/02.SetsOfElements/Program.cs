using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int firstSetCount = n[0];
            int secondSetCount = n[1];

            for (int i = 0; i < firstSetCount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }
            for (int i = 0; i < secondSetCount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (firstSet.Contains(input))
                {
                    secondSet.Add(input);
                }
            }

            foreach (var item in firstSet)
            {
                if(firstSet.Contains(item) && secondSet.Contains(item))
                {
                    Console.Write(item+" ");
                }
            }
        }
    }
}
