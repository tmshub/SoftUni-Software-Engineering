using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackOfBullets = new Stack<int>(bullets);
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueOfKeys = new Queue<int>(keys);
            int salary = int.Parse(Console.ReadLine());
            int reloadingCount = 0;
            int spendMoney = 0;

            while (stackOfBullets.Any() && queueOfKeys.Any())
            {
                if (stackOfBullets.Peek() <= queueOfKeys.Peek())
                {
                    stackOfBullets.Pop();
                    queueOfKeys.Dequeue();
                    Console.WriteLine("Bang!");
                    reloadingCount++;
                    spendMoney += bulletPrice;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackOfBullets.Pop();
                    reloadingCount++;
                    spendMoney += bulletPrice;
                }
                if (reloadingCount == sizeOfGunBarrel && stackOfBullets.Count>0)
                {
                    reloadingCount = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            if (queueOfKeys.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfKeys.Count}");
            }
            else
            {
                salary -= spendMoney;
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${salary}");
            }

        }
    }
}
