using System;
using System.Collections.Generic;

namespace StacksAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < command.Length; i++)
            {
                stack.Push(int.Parse(command[i]));
            }
            command = Console.ReadLine().ToLower().Split();

            while (command[0]!="end")
            {
                if(command[0] == "add")
                {
                    stack.Push(int.Parse(command[1]));
                    stack.Push(int.Parse(command[2]));
                }
                else if(command[0] == "remove")
                {
                    if (int.Parse(command[1]) < stack.Count)
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower().Split();
            }
            int sum = 0;
            foreach (var item in stack)
            {
                sum += item;
            }

            Console.WriteLine("Sum: "+sum);
        }
    }
}
