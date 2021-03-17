using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle, IDriveable
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public string DriveEmpty(double distance)
        {
            if (FuelConsumption * distance <= FuelQuantity)
            {
                FuelQuantity -= FuelConsumption * distance;
                return $"Bus travelled {distance} km";
            }

            return "Bus needs refueling";

        }

        public override string Driving(double distance)
        {

            double consumptionPerKm = FuelConsumption + 1.4;

            if (consumptionPerKm * distance <= FuelQuantity)
            {
                FuelQuantity -= consumptionPerKm * distance;
                return $"Bus travelled {distance} km";
            }

            return "Bus needs refueling";
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
