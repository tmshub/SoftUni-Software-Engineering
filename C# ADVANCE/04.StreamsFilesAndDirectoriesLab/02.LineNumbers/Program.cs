using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string text = reader.ReadLine();
                int count = 1;
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (text!=null)
                    {
                        writer.WriteLine($"{count}. {text}");
                        text = reader.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}
