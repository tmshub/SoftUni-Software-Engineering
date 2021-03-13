using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IPet : IBirthDate
    {
        public string Name { get;}
        public string BirthDate { get; }
    }
}
