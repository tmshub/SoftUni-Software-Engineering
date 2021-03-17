using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle : IDriveable
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; protected set; }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > TankCapacity || value < 0)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; protected set; }

        public string DriveEmpty(double distance)
        {
            if (FuelConsumption * distance <= FuelQuantity)
            {
                FuelQuantity -= FuelConsumption * distance;
                return $"Bus travelled {distance} km";
            }

            return "Bus needs refueling";
        }

        public abstract string Driving(double distance);

        public abstract void Refueling(double litters);

        public virtual string Show()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
