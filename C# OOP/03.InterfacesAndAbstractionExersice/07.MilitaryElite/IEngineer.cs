using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<Repair> Repairs { get; }

        void Add(Repair repair);
    }
}
