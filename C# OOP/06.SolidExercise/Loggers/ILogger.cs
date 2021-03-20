using _07.Solid.Appenders;
using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Loggers
{
    public interface ILogger
    {
        

        public void Error(string data, string message);
        public void Fatal(string data, string message);
        public void Critical(string data, string message);
        public void Warning(string data, string message);

        public void Info(string data, string message);
    }
}
