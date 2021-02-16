using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
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

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                int count = 0;

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                for (int j = 5; j < input.Length; j+=2)
                {
                    double tirePressure = double.Parse(input[j]);
                    int tireAge = int.Parse(input[j+1]);
                    Tire tire = new Tire(tirePressure, tireAge);
                    tires[count++] = tire;
                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string typeOfCargo = Console.ReadLine();
            List<Car> findedCars = new List<Car>();

            if(typeOfCargo == "fragile")
            {
                 findedCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1)).ToList();
            }
            else
            {
                findedCars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in findedCars)
            {
                Console.WriteLine(car.Model);
            }
            
        }
    }
}
