using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizza = Console.ReadLine().Split();
            string pizzName = pizza[1];
            double pizzaCalories = 0;

            string[] doughInfo = Console.ReadLine().Split();
            string dough = doughInfo[1];
            string typeOfDough = doughInfo[2];
            int doughWeight = int.Parse(doughInfo[3]);
            try
            {
                Dough dough1 = new Dough(dough, typeOfDough, doughWeight);
                string[] toppingInfo = Console.ReadLine().Split();
                string topping = toppingInfo[1];
                int toppingWeight = int.Parse(toppingInfo[2]);
                Topping topping1 = new Topping(topping, toppingWeight);
                Pizza pizza1 = new Pizza(dough1, topping1);
                string[] nextTopping = Console.ReadLine().Split();

                while (nextTopping[0] != "END")
                {
                    string newTopping = nextTopping[1];
                    int newToppingWeight = int.Parse(nextTopping[2]);

                    Topping topping2 = new Topping(newTopping, newToppingWeight);
                    pizza1.AddTopping(topping2);
                    nextTopping = Console.ReadLine().Split();
                }
            Console.WriteLine($"{pizzName} - {pizza1.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }


        }
    }
}
