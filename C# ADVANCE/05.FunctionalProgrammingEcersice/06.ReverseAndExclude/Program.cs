using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            numbers.Reverse();
            List<int> result = new List<int>();
             result = numbers.Where(n => n % divider != 0).ToList();
            Console.WriteLine(string.Join(" ",result));
           
        }
    }
}
