using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            string[] text = File.ReadAllLines("../../../text.txt");
            Dictionary<string, int> wordsAppear = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                wordsAppear.Add(words[i].ToLower(), 0);
            }

            for (int i = 0; i < text.Length; i++)
            {
                string[] line = text[i].ToLower().Split(new char[] { '.', ',', '?', '!', '-',' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    if (wordsAppear.ContainsKey(line[j]))
                    {
                        wordsAppear[line[j]]++;
                    }
                }
            }
            int count = 0;
            foreach (var item in wordsAppear)
            {
                string lines = $"{item.Key} - {item.Value}";
                words[count] = lines;
                count++;
            }
            File.WriteAllLines("../../../actualresults.txt", words);
            int count2 = 0;
            foreach (var item in wordsAppear.OrderByDescending(v => v.Value))
            {
                string lines = $"{item.Key} - {item.Value}";
                words[count2] = lines;
                count2++;
            }
            File.WriteAllLines("../../../expectedResult.txt", words);

        }

    }
}
