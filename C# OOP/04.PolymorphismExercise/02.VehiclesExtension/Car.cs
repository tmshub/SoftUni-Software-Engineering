using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption, tankCapacity)
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
            if (litters <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            if (FuelQuantity + litters > TankCapacity)
            {
                throw new Exception($"Cannot fit {litters} fuel in the tank");

            }
            FuelQuantity += litters;
        }

        public override string Show()
        {
            return base.Show();
        }

    }
}
