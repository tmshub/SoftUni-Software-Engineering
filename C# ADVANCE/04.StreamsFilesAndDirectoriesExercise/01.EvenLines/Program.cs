using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int count = 0;
                Regex pattern = new Regex(@"[-,.!?]");
               
                while (line!=null)
                {
                    if (count % 2 == 0)
                    {
                        line = pattern.Replace(line, "@");
                        string[] evenLines = line.Split().Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", evenLines));
                    }
                   
                    count++;
                    line = reader.ReadLine();
                }

            }

        }
    }
}
