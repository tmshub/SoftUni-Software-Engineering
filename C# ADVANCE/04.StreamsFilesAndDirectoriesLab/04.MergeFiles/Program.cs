using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstFile = File.ReadAllLines("../../../FileOne.txt");
            string[] secondFile = File.ReadAllLines("../../../FileTwo.txt");

            using (StreamWriter writer = new StreamWriter("../../../FileThree.txt"))
            {
                for (int i = 0; i < firstFile.Length; i++)
                {
                    writer.WriteLine(firstFile[i]);
                    writer.WriteLine(secondFile[i]);
                }
            }
        }
    }
}
