using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> chemicalElements = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    chemicalElements.Add(input[j]);
                }
            }
         
            foreach (var item in chemicalElements.OrderBy(k => k))
            {
                Console.Write(item+" ");
            }
        }
    }
}
