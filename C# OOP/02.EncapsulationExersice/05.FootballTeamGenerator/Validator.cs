using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public static class Validator
    {
        public static void IsInRange(double value, string message)
        {
            if(value<0 || value > 100)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
