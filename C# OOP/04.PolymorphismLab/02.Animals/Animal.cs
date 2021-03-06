﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, string food)
        {
            Name = name;
            Food = food;
        }

        public string Name { get; set; }
        public string Food { get; set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {Food}";
        }
    }
}
