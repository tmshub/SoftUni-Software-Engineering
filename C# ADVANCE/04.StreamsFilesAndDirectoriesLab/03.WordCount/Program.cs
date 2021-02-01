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
            string text = string.Empty;
            using (FileStream stream = new FileStream("../../../words.txt", FileMode.Open))
            {
                byte[] buffer = new byte[2];

                for (int i = 0; i < stream.Length / 2; i++)
                {
                    stream.Read(buffer, 0, 2);
                    text += (char)buffer[0];
                    text += (char)buffer[1];
                }
            }

            string[] words = text.Split();
            Dictionary<string, int> wordsAppearance = new Dictionary<string, int>();
            int maxWordLentgh = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxWordLentgh)
                {
                    maxWordLentgh = words[i].Length;
                }
                wordsAppearance.Add(words[i], 0);
            }

            string newText = File.ReadAllText("../../../text.txt");
            string[] splitedText = newText.ToLower().Split(new char[] { ' ', '.', ',', '\\', '/', '?', '-', '!' }
            , StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splitedText)
            {
                if (wordsAppearance.ContainsKey(item))
                {
                    wordsAppearance[item]+=1;
                }
            }


            foreach (var item in wordsAppearance.OrderByDescending(kvp => kvp.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }
}
