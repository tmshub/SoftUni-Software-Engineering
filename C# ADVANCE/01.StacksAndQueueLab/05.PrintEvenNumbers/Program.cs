using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueOfDigits = new Queue<int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    queueOfDigits.Enqueue(input[i]);
                }
            }

            Console.Write(string.Join(", " ,queueOfDigits));
        }
    }
}
