using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0]!="Revision")
            {
                string shop = input[0];
                string food = input[1];
                double price = double.Parse(input[2]);

                if (dictionary.ContainsKey(shop))
                {
                    dictionary[shop].Add(food, price);
                }
                else
                {
                    dictionary.Add(shop, new Dictionary<string, double>());
                    dictionary[shop].Add(food, price);
                }

                input = Console.ReadLine().Split(", ");
            }

            foreach (var item in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var products in item.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
