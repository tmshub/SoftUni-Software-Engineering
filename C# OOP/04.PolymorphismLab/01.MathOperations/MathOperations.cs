using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            int x = a + b;

            return x;
        }
        public double Add(double a, double b, double c)
        {
            double x = a + b + c;

            return x;
        }
        public decimal Add(decimal a, decimal b, decimal c)
        {
            decimal x = a + b + c;

            return x;
        }
    }
}
