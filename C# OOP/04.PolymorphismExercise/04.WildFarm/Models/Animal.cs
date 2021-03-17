using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; }
        public  double Weight { get; set; }

        public int FoodEaten { get; set; }
        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> FoodType { get; }

        public abstract string ProducingSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
