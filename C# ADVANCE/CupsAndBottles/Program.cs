using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> queueOfCups = new Stack<int>(cups.Reverse());
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackOfBottles = new Stack<int>(bottles);
            int remainigWater = 0;

            while (queueOfCups.Any() && stackOfBottles.Any())
            {
                if(stackOfBottles.Peek() >= queueOfCups.Peek())
                {
                    remainigWater += stackOfBottles.Pop() - queueOfCups.Pop();
                }
                else
                {
                    int waterNeeded = queueOfCups.Pop() - stackOfBottles.Pop();
                    queueOfCups.Push(waterNeeded);
                   
                }
            }
            if (queueOfCups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueOfCups)}");
                Console.WriteLine($"Wasted litters of water: {remainigWater}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackOfBottles)}");
                Console.WriteLine($"Wasted litters of water: {remainigWater}");
            }
        }
    }
}
