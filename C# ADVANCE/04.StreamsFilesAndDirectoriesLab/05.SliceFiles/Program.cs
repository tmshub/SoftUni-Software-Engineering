using System;
using System.IO;

namespace _05.SliceFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                byte[] buffer = new byte[reader.Length / 4];

                for (int i = 1; i <= 4; i++)
                {
                    reader.Read(buffer, 0, (int)reader.Length / 4);

                    using (FileStream writer = new FileStream($"../../../Part-{i}.txt", FileMode.Create))
                    {
                        writer.Write(buffer, 0, (int)reader.Length / 4);
                    }
                 }
            }
        }
    }
}
