using System;
using System.Collections.Generic;

namespace _02.VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = input[0];
                double fuelQuantity = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                double tankCapacity = double.Parse(input[3]);

                if(type == "Car")
                {
                    Vehicle car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    vehicles.Add(type, car);
                }
                else if(type == "Truck")
                {
                    Vehicle truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    vehicles.Add(type, truck);
                }
                else if(type == "Bus")
                {
                    Vehicle bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    vehicles.Add(type, bus);
                }
            }
            

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string methodType = command[0];
                string currentVehicle = command[1];

                if (methodType == "Drive")
                {
                    double distance = double.Parse(command[2]);

                    Console.WriteLine(vehicles[currentVehicle].Driving(distance));
                }
                else if(methodType == "Refuel")
                {
                    double litters = double.Parse(command[2]);
                    try
                    {
                        vehicles[currentVehicle].Refueling(litters);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if(methodType == "DriveEmpty")
                {
                    double distance = double.Parse(command[2]);
                    Console.WriteLine(vehicles[currentVehicle].DriveEmpty(distance));
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Value.Show());
            }
        }
    }
}
