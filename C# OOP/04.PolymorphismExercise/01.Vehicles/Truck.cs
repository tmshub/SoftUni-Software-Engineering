using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelConsumption, double fuelQuantity)
            : base(fuelConsumption, fuelQuantity)
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
            FuelQuantity += litters * 0.95;
        }

        public override string Show()
        {
            return $"{nameof(Truck)}: {FuelQuantity:f2}";
        }
    }
}
