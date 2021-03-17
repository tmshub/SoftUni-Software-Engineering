using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
   public static class Validator
    {
        public static BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;

            if(type == "Druid")
            {
                return hero = new Druid(name);
            }
            else if(type == "Warrior")
            {
                return hero = new Warrior(name);
            }
            else if (type == "Paladin")
            {
               return hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                return hero = new Rogue(name);
            }

            throw new Exception("Invalid hero!");
        }
    }
}
