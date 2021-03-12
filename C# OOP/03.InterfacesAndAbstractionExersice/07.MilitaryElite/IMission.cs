using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IMission
    {
        public string Name { get; set; }
        public State State { get; set; }
    }
}
