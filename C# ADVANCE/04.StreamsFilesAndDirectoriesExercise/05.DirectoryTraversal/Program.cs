using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();

            string[] files = Directory.GetFiles("../../../");

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                if (!dictionary.ContainsKey(file.Extension))
                {
                    dictionary.Add(file.Extension, new Dictionary<string, double>());
                }
                dictionary[file.Extension].Add(file.Name, file.Length/1024);
            }
            using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DirectoryTraversal.txt"))
            {
                foreach (var item in dictionary.OrderByDescending(v => v.Value.Count).ThenBy(k => k.Key))
                {
                    writer.WriteLine(item.Key);
                    foreach (var kvp in item.Value.OrderByDescending(v => v.Value))
                    {
                        writer.WriteLine($"--{kvp.Key} - {kvp.Value:f2}kb");
                    }
                }
            }
        }
    }
}
