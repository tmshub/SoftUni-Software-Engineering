using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int size;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            size = 5;
        }

        //can live in SaltwaterAquarium
        public override int Size => this.size;
        public override void Eat()
        {
            size += 2;
        }
    }
}
