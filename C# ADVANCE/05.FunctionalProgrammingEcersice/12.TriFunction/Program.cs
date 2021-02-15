using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().ToArray();

            Func<string, int, bool> func = (n, m) =>
             {
                 int result = 0;

                 for (int i = 0; i < n.Length; i++)
                 {
                     result += n[i];
                 }
                 if (result >= m)
                 {
                     return true;
                 }
                 return false;
             };

            Func<string[], Func<string, int, bool>, string> result = (names, func) =>
               {

                   for (int i = 0; i < names.Length; i++)
                   {
                       if(func(names[i], num))
                       {
                           return names[i];
                       }
                   }

                   return string.Empty;
               };

            Console.WriteLine(result(names,func));
        }
    }
}
