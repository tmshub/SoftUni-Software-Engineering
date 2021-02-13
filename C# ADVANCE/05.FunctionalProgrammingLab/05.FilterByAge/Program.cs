using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] names = Console.ReadLine().Split(", ");
                dictionary.Add(names[0], int.Parse(names[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<string, int, string, List<string>> func = (condition, age, format) =>
               {
                   List<string> result = new List<string>();

                    if (condition == "younger")
                   {
                       if (format == "age")
                       {
                           foreach (var item in dictionary)
                           {
                               if (item.Value < age)
                               {
                                   result.Add(item.Value.ToString());
                               }
                           }
                       }
                       else if(format == "name")
                       {
                           foreach (var item in dictionary)
                           {
                               if (item.Value < age)
                               {
                                   result.Add(item.Key);
                               }
                           }
                       }
                       else if(format == "name age")
                       {
                           foreach (var item in dictionary)
                           {
                               if (item.Value < age)
                               {
                                   result.Add($"{item.Key} - {item.Value}");
                               }
                           }
                       }
                   }
                    else if(condition == "older")
                   {
                       if (format == "age")
                       {
                           foreach (var item in dictionary)
                           {
                               if (item.Value >= age)
                               {
                                   result.Add(item.Value.ToString());
                               }
                           }
                       }
                       else if (format == "name")
                       {
                           foreach (var item in dictionary)
                           {
                               if (item.Value >= age)
                               {
                                   result.Add(item.Key);
                               }
                           }
                       }
                       else if (format == "name age")
                       {
                           foreach (var item in dictionary)
                           {
                               if (item.Value >= age)
                               {
                                   result.Add($"{item.Key} - {item.Value}");
                               }
                           }
                       }
                   }

                   return result;
               };

            Console.WriteLine(string.Join(Environment.NewLine, func(condition,age,format)));
        }
    }
}
