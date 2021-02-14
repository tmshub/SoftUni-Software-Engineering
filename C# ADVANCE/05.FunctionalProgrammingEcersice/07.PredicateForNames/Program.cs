using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLentgh = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, bool> func = names => names.Length <= namesLentgh;
            names = names.Where(func).ToList();

            Action < List<string>> printer = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printer(names);

           
        }
    }
}
