using _04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
   public static class FoodFactory
    {
        public static Animal CreateFood(Animal animal, Type food, int quantity)
        {
            if (!animal.FoodType.Contains(food))
            {
                throw new Exception($"{animal.GetType().Name} does not eat {food.Name}!");
            }

            animal.FoodEaten += quantity;
            animal.Weight += animal.WeightMultiplier * animal.FoodEaten;
            return animal;
        }
    }
}
