using System;
using System.Linq;

namespace _01.Vehicles
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

            Vehicle car = new Car(fuelQuantity, fuelConsumption);

            input = Console.ReadLine().Split();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            Vehicle truck = new Truck(fuelQuantity, fuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string methodType = command[0];
                string currentVehicle = command[1];

                if(methodType == "Drive")
                {
                    double distance = double.Parse(command[2]);

                    if(currentVehicle == "Car")
                    {
                        Console.WriteLine(car.Driving(distance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Driving(distance));
                    }
                }
                else
                {
                    double litters = double.Parse(command[2]);

                    if (currentVehicle == "Car")
                    {
                        car.Refueling(litters);
                    }
                    else
                    {
                        truck.Refueling(litters);
                    }
                }
            }

            Console.WriteLine(car.Show());
            Console.WriteLine(truck.Show());
        }
    }
}
