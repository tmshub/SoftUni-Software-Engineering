using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumber = n =>
            {

                int minValue = int.MaxValue;

                foreach (var item in numbers)
                {
                    if (item < minValue)
                    {
                        minValue = item;
                    }
                }

                return minValue;
            };
           
            Console.WriteLine(minNumber(numbers));
        }
    }
}
