using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> enginesInfo = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                string power = input[1];
                string displacement = "n/a";
                string efficiency = "n/a";

                bool isDigit = false;

                if (input.Length > 2)
                {
                    int num = 0;
                    isDigit = Int32.TryParse(input[2], out num);
                }

                if (input.Length == 3 && isDigit)
                {
                    displacement = input[2];
                    Engine engine = new Engine(model, power, displacement, efficiency);
                    enginesInfo.Add(engine);
                }
                if(input.Length == 3 && !isDigit)
                {
                    efficiency = input[2];
                    Engine engine = new Engine(model, power, displacement, efficiency);
                    enginesInfo.Add(engine);
                }
                if(input.Length == 4)
                {
                   displacement = input[2];
                   efficiency = input[3];
                   Engine engine = new Engine(model, power, displacement, efficiency);
                    enginesInfo.Add(engine);
                }
                if(input.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    enginesInfo.Add(engine);
                }
                
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string power = carInfo[1];
                string weight = "n/a";
                string color = "n/a";

                bool isDigit = false;

                if (carInfo.Length > 2)
                {
                    int num = 0;
                    isDigit = Int32.TryParse(carInfo[2], out num);
                }
                
                List<Engine> currentEngine = enginesInfo.Where(x => x.Model == power).ToList();

                if (carInfo.Length == 3 && isDigit)
                {
                    weight = carInfo[2];
                    Car car = new Car(model, currentEngine[0], weight, color);
                    cars.Add(car);
                }
                if(carInfo.Length == 3 && !isDigit)
                {
                    color = carInfo[2];
                    Car car = new Car(model, currentEngine[0], weight, color);
                    cars.Add(car);
                }
                if (carInfo.Length == 4)
                {
                    weight = carInfo[2];
                    color = carInfo[3];
                    Car car = new Car(model, currentEngine[0], weight, color);
                    cars.Add(car);
                }
                if(carInfo.Length == 2)
                {
                    Car car = new Car(model, currentEngine[0]);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model+":");
                Console.WriteLine("  "+car.Engine.Model+":");
                Console.WriteLine("    "+"Power: "+car.Engine.Power);
                Console.WriteLine("    "+ "Displacement: " + car.Engine.Displacement);
                Console.WriteLine("    "+ "Efficiency: " + car.Engine.Efficiency);
                Console.WriteLine("  " + "Weight: "+ car.Weight);
                Console.WriteLine("  " + "Color: " + car.Color);
            }
        }
    }
}
