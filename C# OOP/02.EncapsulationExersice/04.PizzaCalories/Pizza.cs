using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings = new List<Topping>();
        private Dough dough;

        public Pizza(Topping topping)
        {
            Toppings.Add(topping);
        }
        public Pizza(Dough dough, Topping topping)
        {
            Dough = dough;
            Toppings.Add(topping);
        }
        public string Name
        {
            get => this.name;
            private set
            {
                Validator.NameValidator(value, "Pizza name should be between 1 and 15 symbols.");
                this.name = value;
            }
        }
        public List<Topping> Toppings
        {
            get => this.toppings;
            private set
            {
                this.toppings = value;
            }
        }
        public Dough Dough
        {
            get => this.dough;
                private set
            {
                this.dough = value;
            }
        }


        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }

        public double GetCalories()
        {
            double sum = this.dough.CalculateCalories() + this.toppings.Sum(x => x.CalculateToppingCalories());
            return sum;
        }
    }
}
