using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Kilometer = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Kilometer);
                cars.Add(car);
            }

            string[] command = Console.ReadLine().Split();
            
            while (command[0]!="End")
            {
                string model = command[1];
                double amountDistance = double.Parse(command[2]);
                Car car = cars.FirstOrDefault(x => x.Model == model);
                car.CarDrive(amountDistance);
                command = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
