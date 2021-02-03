using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("../../../text.txt");
            string line = string.Empty;
            int countOfLetters = 0;
            int punctoationMarksCount = 0;
            char[] punctoationMarks = new char[] { '.',',','?','-','!','\''};

            for (int i = 0; i < text.Length; i++)
            {
                line = text[i];

                for (int j = 0; j < line.Length; j++)
                {
                    if (char.IsLetter(line[j]))
                    {
                        countOfLetters++;
                    }
                    else if (punctoationMarks.Contains(line[j]))
                    {
                        punctoationMarksCount++;
                    }
                }

                text[i] = $"{text[i]} ({countOfLetters})({punctoationMarksCount})";
                countOfLetters = 0;
                punctoationMarksCount = 0;
            }

            for (int i = 0; i < text.Length; i++)
            {
                text[i] = "Line" + " " + (i+1) + ":" + text[i];
            }
            
            File.WriteAllLines("../../../output.txt", text);
                
        }
    }
}
