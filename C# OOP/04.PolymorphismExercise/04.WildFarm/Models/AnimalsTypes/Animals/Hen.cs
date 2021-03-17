using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.AnimalsTypes.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => 0.35;

        public override ICollection<Type> FoodType =>
            new List<Type> { typeof(Meat), typeof(Vegetable),
            typeof(Seeds), typeof(Fruit)};

        public override string ProducingSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return base.ToString()+FoodEaten+"]";
        }
    }
}
