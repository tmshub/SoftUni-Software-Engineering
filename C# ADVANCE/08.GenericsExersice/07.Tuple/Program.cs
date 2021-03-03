using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] info = Console.ReadLine().Split();
            string name = info[0] + " " + info[1];
            string addres = info[2];
            Tuple<string, string> tuple = new Tuple<string, string>(name, addres);

            string[] info2 = Console.ReadLine().Split();
            string name2 = info2[0];
            int litters = int.Parse(info2[1]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(name2, litters);

            string[] info3 = Console.ReadLine().Split();
            int digit = int.Parse(info3[0]);
            double doubleDigit = double.Parse(info3[1]);
            Tuple<int, double> tuple3 = new Tuple<int, double>(digit, doubleDigit);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);

        }
    }
}
