using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueOfOrders = new Queue<int>(orders);
            Console.WriteLine(queueOfOrders.Max());
            bool isSuccesed = true;

            while (queueOfOrders.Count>0)
            {
                if(queueOfOrders.Peek() <= foodQuantity)
                {
                    foodQuantity -= queueOfOrders.Dequeue();
                }
                else
                {
                    isSuccesed = false;
                    break;
                }
            }

            if (isSuccesed)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                Console.Write(string.Join(" ", queueOfOrders));
            }
        }
    }
}
