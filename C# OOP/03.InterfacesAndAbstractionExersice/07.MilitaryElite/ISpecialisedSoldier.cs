using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ISpecialisedSoldier
    {
        public Corps Corps { get; set; }

        void Add(Corps corps);
    }
}
