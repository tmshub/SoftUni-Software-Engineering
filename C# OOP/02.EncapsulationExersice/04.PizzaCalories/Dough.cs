using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int minWeight = 1;
        private const int maxWeight = 200;

        private string dough;
        private string typeOfDough;
        private int weight;
        public Dough(string dough, string typeOfDough, int weight)
        {
            Doughh = dough;
            TypeOfDough = typeOfDough;
            Weight = weight;
        }
        public string Doughh
        {
            get => this.dough;
            private set
            {
                Validator.IsValidDough(value.ToLower(), "Invalid type of dough.");
                this.dough = value;
            }
        }
        public string TypeOfDough
        {
            get => this.typeOfDough;
            private set
            {
                Validator.isValidTypeOfDough(value.ToLower(), "Invalid type of dough.");
                this.typeOfDough = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.IsValidRange(value, "Dough weight should be in the range[1..200].");
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double doughCalories = 0.0;
            double typeOfDoughCalories = 0.0;
            double weight = this.Weight;

            double result = 0.0;

            switch (this.Doughh.ToLower())
            {
                case "white":
                    doughCalories = 1.5;
                    break;
                case "wholegrain":
                    doughCalories = 1.0;
                    break;
            }

            switch (this.TypeOfDough.ToLower())
            {
                case "crispy":
                    typeOfDoughCalories = 0.9;
                    break;
                        case "chewy":
                    typeOfDoughCalories = 1.1;
                    break;
                case "homemade":
                    typeOfDoughCalories = 1.0;
                    break;
            }

            return result = 2 * weight * doughCalories * typeOfDoughCalories;
        }
    }
}
