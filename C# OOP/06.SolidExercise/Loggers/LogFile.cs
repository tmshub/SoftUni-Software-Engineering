using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _07.Solid.Appenders
{
    class LogFile : ILogFile
    {
        private const string PATH = "../../../log.txt";
        public int Size => File.ReadAllText(PATH)
            .Where(x => char.IsLetter(x))
            .Sum(x => x);

        public void Write(string content)
        {
            File.AppendAllText(PATH, content + Environment.NewLine);
        }

    }
}
