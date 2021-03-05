using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();
            try
            {
                persons = GetPersons();
                products = GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            while (true)
            {
                var line = Console.ReadLine();

                if(line == "END")
                {
                    break;
                }

                var input = line.Split();

                var personName = input[0];
                var productName = input[1];

                var person = persons[personName];
                var product = products[productName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var person in persons.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Person> GetPersons()
        {
            var result = new Dictionary<string, Person>();

            var parts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var currentPart = part.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = currentPart[0];
                var money = decimal.Parse(currentPart[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }

        public static Dictionary<string, Product> GetProducts()
        {
            var result = new Dictionary<string, Product>();

            var parts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var currentPart = part.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = currentPart[0];
                var cost = decimal.Parse(currentPart[1]);

                result[name] = new Product(name, cost);
            }

            return result;
        }
    }
}
