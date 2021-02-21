using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuest = new HashSet<string>();
            HashSet<string> normalGuest = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                guests.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            while (input != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);
            foreach (var item in guests)
            {
                if (char.IsDigit(item[0]))
                {
                    vipGuest.Add(item);
                }
                else
                {
                    normalGuest.Add(item);
                }
            }
            if (vipGuest.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuest));
            }
            if (normalGuest.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, normalGuest));
            }
        }
    }
}
