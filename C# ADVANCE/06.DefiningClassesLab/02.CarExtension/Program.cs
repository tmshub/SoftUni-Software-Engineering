﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1993;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(0.5);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
