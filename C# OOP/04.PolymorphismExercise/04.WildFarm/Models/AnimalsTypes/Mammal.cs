﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.AnimalsTypes
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }

       
    }
}
