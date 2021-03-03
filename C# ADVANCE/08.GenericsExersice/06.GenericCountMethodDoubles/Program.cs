using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDoubles
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            Box<double> box = new Box<double>(list);

            Console.WriteLine(box.CompareElements(double.Parse(Console.ReadLine())));
        }
    }
}
