using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filter = i => char.IsUpper(i[0]);
            string text = Console.ReadLine();

            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            arr = arr.Where(filter).ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

    }
}
