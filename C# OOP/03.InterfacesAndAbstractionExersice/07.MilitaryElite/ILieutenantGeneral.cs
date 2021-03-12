using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<Private> Soldiers { get; }

        void Add(Private @private);
        
    }
}
