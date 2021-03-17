using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.AnimalsTypes.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiplier => 0.30;

        public override ICollection<Type> FoodType =>
            new List<Type> { typeof(Vegetable), typeof(Meat) };

        public override string ProducingSound()
        {
            return "Meow";
        }


        public override string ToString()
        {
            return base.ToString() + FoodEaten + "]";
        }

    }
}
