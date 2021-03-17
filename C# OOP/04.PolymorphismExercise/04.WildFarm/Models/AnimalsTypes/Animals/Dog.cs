﻿using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.AnimalsTypes.Animals
{
   public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier => 0.40;

        public override ICollection<Type> FoodType =>
            new List<Type> { typeof(Meat) };

        public override string ProducingSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString()+$"{Weight}, {LivingRegion}, {FoodEaten}]";
        }

    }
}
