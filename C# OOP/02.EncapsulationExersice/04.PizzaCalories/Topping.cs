using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                Validator.IsValidToppingProduct(value.ToLower(), $"Cannot place {value} on top of your pizza.");
                this.type = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.IsIndexOutSide(value, $"{Type} weight should be in the range [1..50].");
                this.weight = value;
            }
        }

        public double CalculateToppingCalories()
        {
            double product = 0.0;
            double result = 0.0;

            switch (Type.ToLower())
            {
                case "meat":
                    product = 1.2;
                    break;
                case "veggies":
                    product = 0.8;
                    break;
                case "cheese":
                    product = 1.1;
                    break;
                case "sauce":
                    product = 0.9;
                    break;
            }

            return result = 2 * Weight * product;
        }
    }
}
