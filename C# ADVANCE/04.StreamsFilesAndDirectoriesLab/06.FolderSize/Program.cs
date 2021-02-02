using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = 0.0;
            string[] directories = Directory.GetDirectories("../../../TestFolder");
            string[] files = Directory.GetFiles("../../../TestFolder");

            foreach (var item in files)
            {
                FileInfo file = new FileInfo(item);
                size += file.Length;
            }
            
            Console.WriteLine(size/1024.0/1024.0);
        }
    }
}
