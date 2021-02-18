using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] tiresInfo = Console.ReadLine().Split();
            Dictionary<string, Tire[]> tires = new Dictionary<string, Tire[]>();
            int count = 1;

            while (tiresInfo[0]!="No more tires")
            {
                for (int i = 0; i < tiresInfo.Length; i+=2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i+1]);
                    tires.Add("tire" + count.ToString(), new Tire[8]);

                    tires["tire" + count.ToString()][i] = year;
                }
                

                
            }
        }
    }
}
