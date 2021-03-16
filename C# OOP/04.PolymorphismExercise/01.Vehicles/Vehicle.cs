using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }

        public abstract string Driving(double distance);

        public abstract void Refueling(double litters);

        public virtual string Show()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
