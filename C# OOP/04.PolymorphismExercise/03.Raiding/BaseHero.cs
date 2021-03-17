using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public virtual int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
