using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ICollection<BaseHero> heroes = new HashSet<BaseHero>();

            while (heroes.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    heroes.Add(Validator.CreateHero(heroName, heroType));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroPower = 0;

            foreach (var hero in heroes)
            {
                heroPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if(heroPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
