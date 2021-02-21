using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");
            HashSet<string> cars = new HashSet<string>();

            while (input[0]!="END")
            {
                string command = input[0];
                string carNumber = input[1];

                if(command == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }

                input = Console.ReadLine().Split(", ");
            }

            if(cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
