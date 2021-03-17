using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.AnimalsTypes.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
           : base(name, weight, wingSize)
        {

        }
        public override double WeightMultiplier => 0.25;

        public override ICollection<Type> FoodType =>
            new List<Type> { typeof(Meat) };

        public override string ProducingSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString() + FoodEaten + "]";
        }
    }
}
