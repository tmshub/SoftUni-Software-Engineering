using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
   public interface ICitizen : IIdentification
    {
        public string Name { get;}
        public int Age { get;}
    }
}
