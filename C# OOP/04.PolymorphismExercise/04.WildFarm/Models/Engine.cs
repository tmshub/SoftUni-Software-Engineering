using _04.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Engine
    {
        private ICollection<Animal> animals;
        public Engine()
        {
            animals = new HashSet<Animal>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = command[0];
                string name = command[1];
                double weight = double.Parse(command[2]);
                string[] animalInfo = command.Skip(3).ToArray();

                Animal animal = AnimalFactory.CreateAnimal(type, name, weight, animalInfo);
                Console.WriteLine(animal.ProducingSound());
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Assembly assembly = Assembly.GetExecutingAssembly();

                Type food = assembly.GetTypes().FirstOrDefault(x => x.Name == command[0]);
                int quantity = int.Parse(command[1]);

                try
                {
                    animal = FoodFactory.CreateFood(animal, food, quantity);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }

            
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
