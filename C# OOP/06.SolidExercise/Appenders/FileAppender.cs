using _07.Solid.Enums;
using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _07.Solid.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (CanAppend(reportLevel))
            {
                string content = string.Format(this.layout.Template, date, reportLevel, message);
                MessagesCount += 1;
                logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {logFile.Size}";
        }
    }
}
