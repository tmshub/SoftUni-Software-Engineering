using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public static class Validation
    {
        public static double IsZeroOrNegativeNumber(double value, string type)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }

            return value;
        }
    }
}
