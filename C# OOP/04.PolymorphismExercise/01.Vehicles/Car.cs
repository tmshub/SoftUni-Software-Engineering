using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelConsumption, double fuelQuantity)
            :base(fuelConsumption, fuelQuantity)
        {

        }
        public override string Driving(double distance)
        {
            double consumptionPerKm = FuelConsumption + 0.9;

            if(consumptionPerKm * distance <= FuelQuantity)
            {
                FuelQuantity -= consumptionPerKm * distance; 
                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
        }

        public override void Refueling(double litters)
        {
            FuelQuantity += litters;
        }

        public override string Show()
        {
            return $"{nameof(Car)}: {FuelQuantity:f2}";
        }

    }
}
