using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override string Driving(double distance)
        {
            double consumptionPerKm = FuelConsumption + 1.6;

            if (consumptionPerKm * distance <= FuelQuantity)
            {
                FuelQuantity -= consumptionPerKm * distance;
                return $"Truck travelled {distance} km";
            }

            return "Truck needs refueling";
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
            FuelQuantity += litters*0.95;
        }

        public override string Show()
        {
            return base.Show();
        }
    }
}
