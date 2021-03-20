using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Appenders
{
    public interface ILogFile
    {
        public int Size { get; }

        void Write(string content);
    }
}
