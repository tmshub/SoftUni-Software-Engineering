using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ICommando : IMission
    {
        IReadOnlyCollection<Missions> Missions { get; }

        void CompleteMission(Missions mission);
    }
}
