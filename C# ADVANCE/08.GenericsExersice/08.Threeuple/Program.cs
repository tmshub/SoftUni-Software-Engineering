using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] info = input.Split();
            string name = info[0] + " " + info[1];
            string addres = info[2];
            string town = input.Substring(name.Length + addres.Length +2);
            Threeuple<string, string, string> threeuple = new Threeuple<string, string, string>(name, addres, town);

            string[] info1 = Console.ReadLine().Split();
            string name2 = info1[0];
            string littersOfBeer = info1[1];
            bool isDrunk = false;
            if (info1[2] == "drunk")
            {
                isDrunk = true;
            }
            else
            {
                isDrunk = false;

            }
            Threeuple<string, string, bool> threeuple2 = new Threeuple<string, string, bool>(name2, littersOfBeer, isDrunk);

            string[] info2 = Console.ReadLine().Split();
            string name3 = info2[0];
            double accountBalance = double.Parse(info2[1]);
            string bankName = info2[2];
            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(name3, accountBalance, bankName);

            Console.WriteLine(threeuple);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}
