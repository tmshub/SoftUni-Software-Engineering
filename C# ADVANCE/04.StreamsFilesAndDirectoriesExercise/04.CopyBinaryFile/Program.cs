using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream streamWriter = new FileStream("../../../output.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (streamReader.CanRead)
                    {
                        int reader = streamReader.Read(buffer, 0, buffer.Length);

                        if (reader == 0)
                        {
                            break;
                        }

                        streamWriter.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
