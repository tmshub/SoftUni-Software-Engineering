using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public static class Validator
    {
        public static void IsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsNegativeNumber(decimal value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
