using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemon = new List<Pokemon>();
        }
        
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemon.Add(pokemon);
        }

        public void CheckElement(string element)
        {
            foreach (var item in Pokemon)
            {
                if(item.Element == element)
                {
                    NumberOfBadges++;
                    break;
                }
                else
                {
                    item.Health -= 10;
                }
            }

            for (int i = 0; i < Pokemon.Count; i++)
            {
                if(Pokemon[i].Health <= 0)
                {
                    Pokemon.RemoveAt(i);
                    i--;
                }
            }
        }
        
    }
}
