using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> allClothes = new Stack<int>(clothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int countOfRacks = 1;
            int rack = 0;

            while (allClothes.Count > 0)
            {
                if (rack + allClothes.Peek() < rackCapacity)
                {
                    rack += allClothes.Pop();
                }
                else if (rack + allClothes.Peek() == rackCapacity)
                {
                    if(allClothes.Count == 1)
                    {
                        break;
                    }
                    countOfRacks++;
                    rack = 0;
                    allClothes.Pop();

                }
                else if (rack + allClothes.Peek() > rackCapacity)
                {
                    countOfRacks++;
                    rack = allClothes.Pop();
                }
                else if (allClothes.Count == 1)
                {
                    countOfRacks++;
                    allClothes.Pop();
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
