using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ")
                .Select(double.Parse)
                .Select(n => n*1.20)
                .ToArray();
           
            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }


        }
    }
}
