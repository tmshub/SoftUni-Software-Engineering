using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
   public interface ICitizen : IIdentification
    {
        public string Name { get;}
        public int Age { get;}
    }
}
