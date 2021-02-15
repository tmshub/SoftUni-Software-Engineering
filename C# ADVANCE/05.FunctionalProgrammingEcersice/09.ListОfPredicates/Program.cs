using System;
using System.Linq;

namespace _09.ListОfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[]> generateNums = n =>
            {
                int[] result = new int[n];

                for (int i = 1; i <= n; i++)
                {
                    result[i - 1] = i;
                }
                return result;
            };
            int[] numbers = generateNums(n);
            Func<int, int, bool> func = (n, dividers) => n % dividers == 0;

            foreach (var item in numbers)
            {
                if (dividers.All(d => func(item, d)))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
