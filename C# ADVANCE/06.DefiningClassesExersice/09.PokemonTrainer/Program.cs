using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
       public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (input[0]!="Tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                 trainers[trainerName].AddPokemon(pokemon);
                input = Console.ReadLine().Split();
            }

            string command = Console.ReadLine();

            while (command!="End")
            {
                foreach (var trainer in trainers.Values)
                {
                    trainer.CheckElement(command);
                }
                
                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.Values.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
            }
        }
    }
}
