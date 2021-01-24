using System;
using System.Collections.Generic;

namespace TarafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queueOfCars = new Queue<string>();

            string command = Console.ReadLine();
            int countOfPassedCars = 0;

            while (command!="end")
            {
                if(command == "green")
                {
                    if (queueOfCars.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{queueOfCars.Dequeue()} passed!");
                            countOfPassedCars++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < queueOfCars.Count; i++)
                        {
                            Console.WriteLine($"{queueOfCars.Dequeue()} passed!");
                            countOfPassedCars++;
                            i = -1;
                        }
                    }
                }
                else
                {
                    queueOfCars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(countOfPassedCars+" cars passed the crossroads.");
        }
    }
}
