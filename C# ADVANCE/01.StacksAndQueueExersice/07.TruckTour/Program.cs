using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> amountOfPetrol = new Queue<int>(3);
            Queue<int> distance = new Queue<int>(3);
            int[] originalDistance = new int[n];
            int[] originalAmount = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] petrolPumps = Console.ReadLine().Split().Select(int.Parse).ToArray();
                amountOfPetrol.Enqueue(petrolPumps[0]);
                distance.Enqueue(petrolPumps[1]);
                originalDistance[i] = petrolPumps[1];
                originalAmount[i] = petrolPumps[0];
            }
            int result = 0;
            int count = 0;
            int index = 0;
            while (count < n)
            {
                result = (result + amountOfPetrol.Peek()) - distance.Peek();

                if (result >= 0)
                {
                    int currentDistance = distance.Dequeue();
                    int currentAmount = amountOfPetrol.Dequeue();
                    distance.Enqueue(currentDistance);
                    amountOfPetrol.Enqueue(currentAmount);
                    count++;
                    if (count == 1)
                    {
                        for (int i = 0; i < originalDistance.Length; i++)

                        {
                            if (originalDistance[i] == currentDistance && originalAmount[i] == currentAmount)
                            {
                                index = i;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    int currentDistance = distance.Dequeue();
                    int currentAmount = amountOfPetrol.Dequeue();
                    distance.Enqueue(currentDistance);
                    amountOfPetrol.Enqueue(currentAmount);
                    count = 0;
                    result = 0;
                }
            }

            Console.WriteLine(index);
        }
    }
}
