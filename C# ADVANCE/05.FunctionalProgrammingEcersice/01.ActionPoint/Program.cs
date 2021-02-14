using System;
using System.Linq;

namespace _05.FunctionalProgrammingEcersice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split()
                ;

            Action<string[]> printNames = n => Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(names);
        }
    }
}
