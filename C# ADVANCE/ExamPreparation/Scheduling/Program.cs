using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>();
            Queue<int> threads = new Queue<int>();

            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                tasks.Push(input[i]);
            }

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                threads.Enqueue(input[i]);
            }

            int task = int.Parse(Console.ReadLine());

            while (true)
            {
                if(threads.Peek() >= tasks.Peek())
                {
                    if (tasks.Peek() == task)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                        Console.WriteLine(string.Join(" ", threads));
                        return;
                    }
                    int currentThread = threads.Dequeue();
                    int currentTask = tasks.Pop();
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    if (tasks.Peek() == task)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                        Console.WriteLine(string.Join(" ", threads));
                        return;
                    }
                    threads.Dequeue();
                }
            }
        }
    }
}
