using _04.WildFarm.Models;
using _04.WildFarm.Models.AnimalsTypes.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string type, string name, double weight, string[] animalInfo)
        {
            Animal animal = null;

            if(animalInfo.Length == 2)
            {
                string livingRegion = animalInfo[0];
                string breed = animalInfo[1];

                if(type == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
            }
            else
            {
                double wingSize = 0.0;
                bool isBird = double.TryParse(animalInfo[0], out wingSize);

                if (isBird)
                {
                    if(type == "Owl")
                    {
                        animal = new Owl(name, weight, wingSize);
                    }
                    else
                    {
                        animal = new Hen(name, weight, wingSize);
                    }
                }
                else
                {
                    string livingRegion = animalInfo[0];

                    if(type == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    else
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                }
            }

            return animal;
        }

    }
}
