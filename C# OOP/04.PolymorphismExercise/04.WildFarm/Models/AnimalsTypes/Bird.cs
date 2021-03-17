﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.AnimalsTypes
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize)
            :base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, ";
        }

    }
}
