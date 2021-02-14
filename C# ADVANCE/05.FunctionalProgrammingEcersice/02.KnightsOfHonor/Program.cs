using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string[] names = input.Select(n => $"Sir {n}").ToArray();

            Action<string[]> printNames = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            printNames(names);
        }
    }
}
