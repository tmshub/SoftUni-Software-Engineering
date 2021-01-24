using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueueExersise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int s = input[1];
            int x = input[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(!stack.Contains(x) && stack.Count>0)
            {
                int minValue = int.MaxValue;

                foreach (var item in stack)
                {
                    if (minValue > item)
                    {
                        minValue = item;
                    }
                }

                Console.WriteLine(minValue);
            }
            else if(stack.Count == 0)
            {
                Console.WriteLine(0);
            }

        }
    }
}
