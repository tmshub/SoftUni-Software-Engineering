using System;
using System.Collections.Generic;

namespace HotPatato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childrens = Console.ReadLine().Split();
            int numOfPassed = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(childrens);
            int count = 0;

            while (queue.Count > 1)
            {
                count++;

                if(count == numOfPassed)
                {
                    count = 0;
                    Console.WriteLine("Removed "+queue.Dequeue());
                }
                else
                {
                    string firstChildren = queue.Dequeue();
                    queue.Enqueue(firstChildren);
                }
            }
            Console.WriteLine("Last is "+queue.Dequeue());
        }
    }
}
