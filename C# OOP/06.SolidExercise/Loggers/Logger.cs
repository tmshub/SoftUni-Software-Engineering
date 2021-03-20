using _07.Solid.Appenders;
using _07.Solid.Enums;
using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;
        public Logger(params IAppender[] appender)
        {
            this.appenders = appender;
        }
       

        public void Error(string data, string message)
        {
            AppendMessages(data, ReportLevel.Error, message);
        }
        public void Warning(string data, string message)
        {
            AppendMessages(data, ReportLevel.Warning, message);
        }
        public void Info(string data, string message)
        {
            AppendMessages(data, ReportLevel.Info, message);
        }
        public void Fatal(string data, string message)
        {
            AppendMessages(data, ReportLevel.Fatal, message);
        }
        public void Critical(string data, string message)
        {
            AppendMessages(data, ReportLevel.Critical, message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger Info:");
            foreach (var item in appenders)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
        private void AppendMessages(string data, ReportLevel reportLevel, string message)
        {
            foreach (var item in appenders)
            {
                item.Append(data, reportLevel, message);
            }
        }
    }
}
