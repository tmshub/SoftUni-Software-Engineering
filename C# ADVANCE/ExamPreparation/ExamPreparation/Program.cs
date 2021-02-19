using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>();
            Queue<int> roses = new Queue<int>();
            int flowersLeft = 0;
            int numOfwreahts = 0;

            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                lilies.Push(input[i]);
            }

            input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                roses.Enqueue(input[i]);
            }
            
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int liliesCount = lilies.Pop();
                int rosesCount = roses.Dequeue();
                int sum = liliesCount + rosesCount;

                if(liliesCount +  rosesCount == 15)
                {
                    numOfwreahts++;
                }
                else if(liliesCount + rosesCount > 15)
                {
                    if(sum % 2 == 0)
                    {
                        flowersLeft += 14;
                    }
                    else
                    {
                        numOfwreahts++;
                    }
                }
                else
                {
                    flowersLeft += sum;
                }
            }
            
            numOfwreahts += flowersLeft / 15;

            if(numOfwreahts >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {numOfwreahts} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - numOfwreahts} wreaths more!");
            }
        }
    }
}
